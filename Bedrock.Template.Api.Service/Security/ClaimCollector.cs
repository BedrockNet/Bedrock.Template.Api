using System;
using System.Collections.Generic;
using System.Linq;

using Bedrock.Shared.Configuration;

using Bedrock.Shared.Security.Api.Client.Client.Interface;
using Bedrock.Shared.Security.ClaimCollection;
using Bedrock.Shared.Security.Interface;
using Bedrock.Shared.Security.Model;

using Bedrock.Shared.Session.Interface;
using Bedrock.Shared.Utility;

namespace Bedrock.Template.Api.Service.Security
{
    public class ClaimCollector : ClaimCollectorBase, IClaimCollector
    {
        #region Constructors
        public ClaimCollector
        (
            ISharedSecurityClientAdmin sharedSecurityClientAdmin,
            ISession session,
            BedrockConfiguration bedrockConfiguration
        ) : base(bedrockConfiguration)
        {
            SharedSecurityClientAdmin = sharedSecurityClientAdmin;
        }
        #endregion

        #region Protected Properties
        protected ISharedSecurityClientAdmin SharedSecurityClientAdmin { get; set; }
        #endregion

        #region Protected Methods
        protected override IEnumerable<BedrockClaimModel> CollectClaims(ICollectPass collectPass)
        {
            var subject = Guid.Parse(collectPass.SubjectId);
            var result = AsyncHelper.RunSync(() => SharedSecurityClientAdmin.LoadPermissionsByApplicationAndUserGlobalKey(collectPass.Application, subject));
            var userPermissions = result.ResponseMessage.IsSuccessStatusCode ? result.ResponseValue : Enumerable.Empty<BedrockClaimModel>();

            return userPermissions
                    .Select(up => new BedrockClaimModel
                    {
                        Issuer = up.Issuer,
                        OriginalIssuer = up.OriginalIssuer,
                        Type = up.Type,
                        Value = up.Value,
                        ValueType = up.ValueType,
                        ResourceType = up.ResourceType,
                        Application = up.Application
                    }).ToList();
        }
        #endregion
    }
}
