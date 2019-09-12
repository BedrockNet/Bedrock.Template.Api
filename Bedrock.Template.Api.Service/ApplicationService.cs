using System.Collections.Generic;
using System.Threading.Tasks;

using Bedrock.Template.Api.Domain.Service.Interface;

using Bedrock.Template.Api.Service.Contract.Application;
using Bedrock.Template.Api.Service.Interface;

using Bedrock.Shared.Configuration;

namespace Bedrock.Template.Api.Service
{
    public class ApplicationService : ServiceBaseApplication, IApplicationService
    {
        #region Constructors
        public ApplicationService
        (
            ILogService logService,
            BedrockConfiguration bedrockConfiguration
        ) : base
        (
            bedrockConfiguration,
            logService
        ) { }
        #endregion

        #region Properties
        protected ILogService LogService { get; set; }
        #endregion

        #region IApplicationService Methods
        public async Task<IEnumerable<LogContract>> GetErrorsAllAsync()
        {
            return await LogService.GetErrorsAllAsync<LogContract>();
        }
        #endregion
    }
}
