using System.Collections.Generic;
using System.Threading.Tasks;

using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Template.Api.Domain.Service.Interface;

using Bedrock.Shared.Data.Repository.Extension;
using Bedrock.Shared.Mapper.Extension;

using SharedConfiguration = Bedrock.Shared.Configuration;

namespace Bedrock.Template.Api.Domain.Service
{
    public class DomainService : ServiceBaseDomain, IDomainService
    {
        #region Constructors
        public DomainService
        (
            ITemplateContext context,
            SharedConfiguration.BedrockConfiguration bedrockConfiguration
        )
        : base(bedrockConfiguration, context) { }
        #endregion

        #region IDomainService Methods
        #endregion
    }
}
