using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Bedrock.Template.Api.Infrastructure;

using Bedrock.Shared.Configuration;
using Bedrock.Shared.Enumeration;
using Bedrock.Shared.Extension;
using Bedrock.Shared.Log.Extension;

using Bedrock.Shared.Security.Api.Client.Configuration;

using Bedrock.Shared.Security.Constant;
using Bedrock.Shared.Security.Interface;

using Bedrock.Shared.Web.Api.Swagger;
using Bedrock.Shared.Web.Extension;
using Bedrock.Shared.Web.Middleware.Options;
using Bedrock.Shared.Web.Security;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;

using Newtonsoft.Json;

using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

using SharedEnumeration = Bedrock.Shared.Enumeration;
using SharedInterface = Bedrock.Shared.Log.Interface;

namespace Bedrock.Template.Api
{
    public class Startup
    {
        #region Constructors
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                                .SetBasePath(env.ContentRootPath)
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                                .AddJsonFile("bedrockconfig.json", optional: true, reloadOnChange: true)
                                .AddJsonFile($"bedrockconfig.{env.EnvironmentName}.json", optional: true)
                                .AddEnvironmentVariables()
                                .Build();
        }
        #endregion

        #region Protected Properties
        protected BedrockConfiguration BedrockConfiguration { get; set; }
        #endregion

        #region Public Properties
        public static IConfiguration Configuration { get; private set; }

        public IContainer ApplicationContainer { get; private set; }
        #endregion

        #region Public Methods
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            Initialize(services);

            AddCors(services);
            AddMvc(services);
            AddAuthentication(services);
            AddApiVersioning(services);
            AddVersionedApiExplorer(services);
            AddSwaggerGen(services);

            Bootstrap(services);

            return new AutofacServiceProvider(ApplicationContainer);
        }

        public void Configure
        (
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            SharedInterface.ILogger logger,
            IApplicationLifetime appLifetime,
            IApiVersionDescriptionProvider provider,
            BedrockConfiguration bedrockConfiguration
        )
        {
            AddLogging(loggerFactory, logger);

            app.UseHttpException();

            app.UseCors("CorsPolicy");

            if (BedrockConfiguration.Security.IsEnabled)
            {
                app.UseAuthentication();
                app.UseMiddleware<SetUserMiddleware>(new PostAuthenticationMiddlewareOptions(new ClaimTypeAad()));
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            AddSwaggerGen(app, provider);

            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
        #endregion

        #region Private Methods (ConfigureServices)
        private void Initialize(IServiceCollection services)
        {
            var config = services.ConfigurePoco<SharedSecurityClientConfig>(Configuration.GetSection("SharedSecurityClientConfig"));
            BedrockConfiguration = services.ConfigurePoco<BedrockConfiguration>(Configuration.GetSection("BedrockConfig"));

            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        private void AddCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    c => c.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
            });
        }

        private void AddMvc(IServiceCollection services)
        {
            services
                .AddMvc(config =>
                {
                    if (BedrockConfiguration.Security.IsEnabled)
                        config.Filters.Add(new AuthorizeFilter("default"));

                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
        }

        private void AddAuthentication(IServiceCollection services)
        {
            var claimType = new ClaimTypeAad();

            services.AddSingleton<IClaimsTransformation, AzureAdScopeClaimTransformation>();
            services.AddSingleton<IClaimType, ClaimTypeAad>(c => claimType);

            if (!BedrockConfiguration.Security.IsEnabled)
                return;

            var azureConfig = BedrockConfiguration.Security.Application.AzureAdB2C;

            services.AddAuthorization(o =>
            {
                o.AddPolicy("default", policy =>
                {
                    policy.RequireClaim(claimType.ScopeClaimType, azureConfig.ScopeRead);
                    policy.RequireClaim(claimType.ScopeClaimType, azureConfig.ScopeWrite);
                    policy.RequireClaim(claimType.ScopeClaimType, azureConfig.ScopeImpersonation);
                });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Audience = azureConfig.ClientId;
                options.Authority = $"{azureConfig.InstanceUrl}/{azureConfig.Tenant}/{azureConfig.Policy}/{azureConfig.ApiVersion}";
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
            });
        }

        private void AddApiVersioning(IServiceCollection services)
        {
            services
                .AddApiVersioning(options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                });
        }

        private void AddVersionedApiExplorer(IServiceCollection services)
        {
            services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
        }

        private void AddSwaggerGen(IServiceCollection services)
        {
            if (BedrockConfiguration.Application.Environment != SharedEnumeration.Environment.Local)
                return;

            var azureConfig = BedrockConfiguration.Security.Application.AzureAdB2C;

            services.AddTransient(i =>
            {
                return new Info()
                {
                    Title = "Bedrock Template API",
                    Description = "A sample application using Bedrock.Shared, Swagger, Swashbuckle, and API versioning.",
                    Contact = new Contact() { Name = "Bedrock Net", Email = "bedrocknetdeveloper@gmail.com" },
                    TermsOfService = "https://github.com/BedrockNet/Bedrock.Template.Api/blob/master/license.txt",
                    License = new License() { Name = "Bedrock Template API", Url = "https://github.com/BedrockNet/Bedrock.Template.Api" }
                };
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services
                .AddSwaggerGen(options =>
                {
                    options.CustomSchemaIds(x => x.FullName);
                    options.OperationFilter<SwaggerDefaultValues>();
                    options.OperationFilter<AuthorizeCheckOperationFilter>();
                    options.IncludeXmlComments(XmlCommentsFilePath);

                    AddSwaggerGenAuthentication(options);
                });
        }

        private void AddSwaggerGenAuthentication(SwaggerGenOptions options)
        {
            if (!BedrockConfiguration.Security.IsEnabled)
                return;

            var azureConfig = BedrockConfiguration.Security.Application.AzureAdB2C;

            options.AddSecurityDefinition("oauth2", new OAuth2Scheme
            {
                Type = "oauth2",
                Flow = "implicit",
                AuthorizationUrl = $"{azureConfig.InstanceUrl}/{azureConfig.Tenant}/{azureConfig.AuthorizeUri}",
                Scopes = new Dictionary<string, string>
                        {
                            { azureConfig.ApplicationId + azureConfig.ScopeRead, "Read API Access" },
                            { azureConfig.ApplicationId + azureConfig.ScopeWrite, "Write API Access" },
                            { azureConfig.ApplicationId + azureConfig.ScopeImpersonation, "Access API" }
                        },
                TokenUrl = $"{azureConfig.InstanceUrl}/{azureConfig.Tenant}/{azureConfig.TokenUri}"
            });

            options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
            {
                {
                    "oauth2",
                    new[]
                    {
                        azureConfig.ApplicationId + azureConfig.ScopeRead,
                        azureConfig.ApplicationId + azureConfig.ScopeWrite,
                        azureConfig.ApplicationId + azureConfig.ScopeImpersonation
                    }
                }
            });
        }

        private void Bootstrap(IServiceCollection services)
        {
            var builder = AutoBootstrapper.Bootstrap(DependentType.AspNetCore, BedrockConfiguration);

            builder
                .RegisterAssemblyTypes(typeof(Startup).Assembly)
                .Where(t => typeof(Controller)
                                .IsAssignableFrom(t) &&
                                    t.Name.EndsWith("Controller", StringComparison.Ordinal))
                .PropertiesAutowired();

            builder.Populate(services);
            ApplicationContainer = builder.Build();

            AutoBootstrapper.SetServiceLocator(ApplicationContainer);
        }

        private static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
        #endregion

        #region Private Methods (Configure)
        private void AddLogging(ILoggerFactory loggerFactory, SharedInterface.ILogger logger)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddLogger(logger, LogLevel.Error);
        }

        private void AddSwaggerGen(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            if (BedrockConfiguration.Application.Environment != SharedEnumeration.Environment.Local)
                return;

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.OAuthClientId(BedrockConfiguration.Security.Application.SwaggerAdB2C.ClientId);
                options.OAuthRealm(BedrockConfiguration.Security.Application.AzureAdB2C.ClientId);
                options.OAuthAppName("Swagger Api");
                options.OAuthScopeSeparator(" ");
                options.OAuthAdditionalQueryStringParams(new Dictionary<string, string> { { "resource", BedrockConfiguration.Security.Application.AzureAdB2C.ClientId } });
                options.DocExpansion(DocExpansion.None);

                provider.ApiVersionDescriptions.Each(d => options.SwaggerEndpoint($"/swagger/{d.GroupName}/swagger.json", d.GroupName.ToUpperInvariant()));
            });
        }
        #endregion
    }
}
