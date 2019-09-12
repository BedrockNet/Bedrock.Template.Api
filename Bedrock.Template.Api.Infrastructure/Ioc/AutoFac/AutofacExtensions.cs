using System;
using System.Collections.Generic;
using System.Reflection;

using Bedrock.Template.Api.Infrastructure.Repository;
using Bedrock.Template.Api.Service.Security;

using Bedrock.Shared.Configuration;
using Bedrock.Shared.Ioc;
using Bedrock.Shared.Ioc.Autofac;

using Bedrock.Shared.Security.Interface;
using Bedrock.Shared.Security.Api.Client.Client;
using Bedrock.Shared.Security.Api.Client.Client.Interface;

using Autofac;

namespace Bedrock.Template.Api.Infrastructure.Ioc.Autofac
{
    public static class AutofacExtensions
    {
        #region Methods
        public static ContainerBuilder RegisterDataContextTemplate(this ContainerBuilder builder, string connectionStringKey, BedrockConfiguration bedrockConfiguration)
        {
            var connectionStringValue = bedrockConfiguration.Data.ConnectionStrings[connectionStringKey];

            builder
                .RegisterType<TemplateContext>()
                .As<TemplateContext>()
                .WithParameter(new TypedParameter(typeof(string), connectionStringValue));

            return builder;
        }

        public static ContainerBuilder RegisterRepositoriesTemplate(this ContainerBuilder builder, Dictionary<Type, Type> keyTypes, Type keyTypeDefault, IocConfiguration iocConfiguration)
        {
            builder.RegisterRepositoriesOrmId(typeof(TemplateContext).GetTypeInfo().Assembly, keyTypes, keyTypeDefault, iocConfiguration, Domain.TemplateContext.GetTypes());
            return builder;
        }

        public static ContainerBuilder RegisterApplicationContextTemplate(this ContainerBuilder builder)
        {
            builder
                .RegisterType<Domain.TemplateContext>()
                .As<Domain.ITemplateContext>();

            return builder;
        }

        public static ContainerBuilder RegisterClaimCollectorFactory(this ContainerBuilder builder)
        {
            builder
              .RegisterType<ClaimCollectorFactory>()
              .As<IClaimCollectorFactory>()
              .SingleInstance();

            return builder;
        }

        public static ContainerBuilder RegisterSharedSecurityClientAdmin(this ContainerBuilder builder)
        {
            builder
              .RegisterType<SharedSecurityClientAdmin>()
              .As<ISharedSecurityClientAdmin>()
              .SingleInstance();

            return builder;
        }
        #endregion
    }
}
