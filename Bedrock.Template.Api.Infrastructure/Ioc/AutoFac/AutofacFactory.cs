using System;
using System.Collections.Generic;
using System.Reflection;

using Bedrock.Shared.Enumeration;

using Bedrock.Shared.Ioc;
using Bedrock.Shared.Ioc.Autofac;

using Autofac;

using CoreConfiguration = Bedrock.Shared.Configuration;
using SharedIoC = Bedrock.Shared.Ioc.Autofac;

namespace Bedrock.Template.Api.Infrastructure.Ioc.Autofac
{
    public static class AutofacFactory
    {
        #region Public Methods
        public static ContainerBuilder RegisterAll
        (
            Dictionary<Type, Type> repositoryKeyTypes,
            Type repositoryKeyTypeDefault,
            string connectionStringKeyBedrock,
            Assembly bootstrapAssembly,
            Assembly[] serviceAssemblies,
            Assembly[] domainAssemblies,
            Assembly webAssembly,
            CoreConfiguration.BedrockConfiguration bedrockConfiguration,
            IocConfiguration iocConfiguration,
            DependentType dependentType
        )
        {
            return RegisterBase
            (
                repositoryKeyTypes,
                repositoryKeyTypeDefault,
                connectionStringKeyBedrock,
                bootstrapAssembly,
                serviceAssemblies,
                domainAssemblies,
                webAssembly,
                bedrockConfiguration,
                iocConfiguration,
                dependentType
            )
            .RegisterSecurity(iocConfiguration);
        }

        public static ContainerBuilder RegisterBase
        (
            Dictionary<Type, Type> repositoryKeyTypes,
            Type repositoryKeyTypeDefault,
            string connectionStringKeyTemplate,
            Assembly bootstrapAssembly,
            Assembly[] serviceAssemblies,
            Assembly[] domainAssemblies,
            Assembly webAssembly,
            CoreConfiguration.BedrockConfiguration bedrockConfiguration,
            IocConfiguration iocConfiguration,
            DependentType dependentType
        )
        {
            return SharedIoC
                    .AutofacFactory
                    .RegisterAll(bootstrapAssembly, serviceAssemblies, domainAssemblies, dependentType, bedrockConfiguration)
                    .RegisterDataContextTemplate(connectionStringKeyTemplate, bedrockConfiguration)
                    .RegisterRepositoriesTemplate(repositoryKeyTypes, repositoryKeyTypeDefault, iocConfiguration)
                    .RegisterApplicationContextTemplate();
        }
        #endregion

        #region Private Methods
        private static ContainerBuilder RegisterSecurity(this ContainerBuilder builder, IocConfiguration iocConfiguration)
        {
            return builder
                    .RegisterResourceAuthorizationManager(iocConfiguration)
                    .RegisterClaimCollectorFactory()
                    .RegisterSharedSecurityClientAdmin();
        }
        #endregion
    }
}
