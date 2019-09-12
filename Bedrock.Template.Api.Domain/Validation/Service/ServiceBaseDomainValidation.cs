using Bedrock.Shared.Configuration;
using Bedrock.Shared.Session.Interface;

namespace Bedrock.Template.Api.Domain.Validation.Service
{
    public abstract class ServiceBaseDomainValidation : ServiceBaseDomain
    {
        #region Constructors
        public ServiceBaseDomainValidation(BedrockConfiguration bedrockConfiguration, params ISessionAware[] sessionAwareDependencies) : base(bedrockConfiguration, sessionAwareDependencies) { }
        #endregion
    }
}
