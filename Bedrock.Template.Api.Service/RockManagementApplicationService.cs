using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bedrock.Template.Api.Domain.Service.Interface;
using Bedrock.Template.Api.Service.Interface;

using Bedrock.Shared.Configuration;
using Bedrock.Shared.Extension;
using Bedrock.Template.Api.Service.Contract.Lookup;
using Bedrock.Template.Api.Core.Utility;
using Bedrock.Template.Api.Core.Enumeration.StringHelper;

namespace Bedrock.Template.Api.Service
{
    public partial class RockManagementApplicationService : ServiceBaseApplication, IRockManagementApplicationService
    {
        #region Constructors
        public RockManagementApplicationService
        (
            IRockService rockService,
            BedrockConfiguration bedrockConfiguration
        ) : base(bedrockConfiguration, rockService) { }
        #endregion

        #region Properties
        protected IRockService RockService { get; set; }
        #endregion

        #region IRockManagementApplicationService Methods
        #endregion
    }
}
