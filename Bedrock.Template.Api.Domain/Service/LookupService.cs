using System.Collections.Generic;
using System.Threading.Tasks;

using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Template.Api.Domain.Service.Interface;

using Bedrock.Shared.Configuration;
using Bedrock.Shared.Data.Repository.Extension;

namespace Bedrock.Template.Api.Domain.Service
{
    public class LookupService : ServiceBaseDomain, ILookupService
    {
        #region Constructors
        public LookupService
        (
            ITemplateContext context,
            BedrockConfiguration bedrockConfiguration
        )
        : base(bedrockConfiguration, context) { }
        #endregion

        #region ILookupService Methods
        #endregion
    }
}
