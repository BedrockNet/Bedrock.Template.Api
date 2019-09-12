using System.Collections.Generic;
using System.Reflection;

using Bedrock.Template.Api.Domain;
using Bedrock.Template.Api.Infrastructure.Ioc.Autofac;

using Bedrock.Shared.Enumeration;
using Bedrock.Shared.Ioc;

using Autofac;

using CoreConfiguration = Bedrock.Shared.Configuration;
using SharedIoC = Bedrock.Shared.Ioc.Autofac;

namespace Bedrock.Template.Api.Infrastructure
{
	public sealed class AutoBootstrapper
	{
		#region Properties
		public static DependentType DependentType { get; set; }

		public static string ConnectionStringKeyBedrock { get; set; }

		public static CoreConfiguration.BedrockConfiguration BedrockConfiguration { get; set; }

		public static IocConfiguration IocConfiguration { get; set; }
		#endregion

		#region Public Methods
		public static ContainerBuilder Bootstrap(DependentType dependentType, CoreConfiguration.BedrockConfiguration bedrockConfiguration)
		{
			var connectionStringKeyBedrock = string.Concat(typeof(AutoBootstrapper).Assembly.GetName().Name, ".ConnectionString.Template");

			return Bootstrap(dependentType, connectionStringKeyBedrock, bedrockConfiguration);
		}

		public static ContainerBuilder Bootstrap(DependentType dependentType, string connectionStringKeyBedrock, CoreConfiguration.BedrockConfiguration bedrockConfiguration)
		{
			DependentType = dependentType;
			ConnectionStringKeyBedrock = connectionStringKeyBedrock;
			BedrockConfiguration = bedrockConfiguration;
			IocConfiguration = IocConfiguration.Current;

			return CreateContainerBuilder();
		}

		public static void SetServiceLocator(IContainer container)
		{
			SharedIoC.AutofacFactory.SetServiceLocator(container);
		}
		#endregion

		#region Private Methods
		private static ContainerBuilder CreateContainerBuilder()
		{
			var returnValue = default(ContainerBuilder);

			var bootstrapAssembly = Assembly.GetAssembly(typeof(AutoBootstrapper));
			var domainAssembly = Assembly.GetAssembly(typeof(TemplateContext));

            var serviceAssemblies = new List<Assembly>();
            var domainAssemblies = new List<Assembly>();

            serviceAssemblies.Add(domainAssembly);
            domainAssemblies.Add(domainAssembly);

			switch (DependentType)
			{
				case DependentType.AspNetCore:
					{
                        var webAssembly = Assembly.Load("Bedrock.Template.Api");
                        var applicationServiceAssembly = Assembly.Load("Bedrock.Template.Api.Service");

                        serviceAssemblies.Add(applicationServiceAssembly);

                        returnValue = AutofacFactory.RegisterAll
						(
							DomainConstants.RepositoryKeyTypes,
							DomainConstants.RepositoryKeyTypeDefault,
							ConnectionStringKeyBedrock,
							bootstrapAssembly,
							serviceAssemblies.ToArray(),
							domainAssemblies.ToArray(),
							webAssembly,
							BedrockConfiguration,
							IocConfiguration,
							DependentType
						);

						break;
					}
                case DependentType.Console:
                    {
                        returnValue = AutofacFactory.RegisterBase
                        (
                            DomainConstants.RepositoryKeyTypes,
                            DomainConstants.RepositoryKeyTypeDefault,
                            ConnectionStringKeyBedrock,
                            bootstrapAssembly,
                            serviceAssemblies.ToArray(),
                            domainAssemblies.ToArray(),
                            null,
                            BedrockConfiguration,
                            IocConfiguration,
                            DependentType
                        );

                        break;
                    }
			}

			return returnValue;
		}
		#endregion
	}
}
