using Bedrock.Shared.Cache.Interface;
using Bedrock.Shared.Configuration;

using Bedrock.Shared.Security.Api.Client.Client.Interface;
using Bedrock.Shared.Security.ClaimCollection;
using Bedrock.Shared.Security.Interface;

using Bedrock.Shared.Session.Interface;

namespace Bedrock.Template.Api.Service.Security
{
    public class ClaimCollectorFactory : ClaimCollectorFactoryBase, IClaimCollectorFactory
    {
        #region Constructors
        public ClaimCollectorFactory
        (
            ISharedSecurityClientAdmin sharedSecurityClientAdmin,
            ISession session,
            ICacheProvider cache,
            BedrockConfiguration bedrockConfiguration
        ) : base
        (
            cache, bedrockConfiguration
        )
        {
            SharedSecurityClientAdmin = sharedSecurityClientAdmin;
            Session = session;
        }
        #endregion

        #region Protected Properties
        protected ISharedSecurityClientAdmin SharedSecurityClientAdmin { get; set; }

        protected ISession Session { get; set; }
        #endregion

        #region Public Methods
        public override IClaimCollector CreateInstanceCollector(string application)
        {
            IClaimCollector returnValue;

            switch (application)
            {
                default:
                    {
                        returnValue = new ClaimCollector(SharedSecurityClientAdmin, Session, BedrockConfiguration);
                        break;
                    }
            }

            return returnValue;
        }

        public override ICollectPass CreateInstancePass(string application, IClaimCollector collector, string username, string subjectId)
        {
            return new CollectPass
            {
                CollectPassName = application.ToString(),
                Collector = collector,
                Issuer = BedrockConfiguration.Application.Name,
                Application = application,
                Cache = Cache,
                Username = username,
                SubjectId = subjectId
            };
        }
        #endregion
    }
}
