using System.Collections.Generic;
using System.Threading.Tasks;

using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Shared.Session.Interface;

namespace Bedrock.Template.Api.Domain.Service.Interface
{
    public interface ILogService : ISessionAware
    {
        #region Methods
        Task<IEnumerable<T>> GetErrorsAllAsync<T>();
        #endregion
    }
}
