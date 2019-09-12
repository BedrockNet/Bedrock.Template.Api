using System.Collections.Generic;
using System.Threading.Tasks;

using Bedrock.Template.Api.Service.Contract.Application;
using Bedrock.Shared.Session.Interface;

namespace Bedrock.Template.Api.Service.Interface
{
    public partial interface IApplicationService : ISessionAware
    {
        #region Methods
        Task<IEnumerable<LogContract>> GetErrorsAllAsync();
        #endregion
    }
}
