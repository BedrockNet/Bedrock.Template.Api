using Bedrock.Shared.Configuration;
using Bedrock.Shared.Service.Implementation;
using Bedrock.Shared.Session.Interface;

namespace Bedrock.Template.Api.Service
{
    public abstract class ServiceBaseApplication : ServiceBase
    {
        #region Fields
        #endregion

        #region Constructors
        public ServiceBaseApplication(params ISessionAware[] sessionAwareDependencies) : this(null, sessionAwareDependencies) { }

        public ServiceBaseApplication(BedrockConfiguration bedrockConfiguration, params ISessionAware[] sessionAwareDependencies) : base(sessionAwareDependencies)
        {
            BedrockConfiguration = bedrockConfiguration;
        }
        #endregion

        #region Properties
        protected BedrockConfiguration BedrockConfiguration { get; set; }
		#endregion
	}
}
