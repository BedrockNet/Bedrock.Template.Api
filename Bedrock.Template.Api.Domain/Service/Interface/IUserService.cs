using System.Threading.Tasks;

using Bedrock.Template.Api.Domain.Entity;

using Bedrock.Shared.Security.Interface;
using Bedrock.Shared.Session.Interface;

namespace Bedrock.Template.Api.Domain.Service.Interface
{
    public interface IUserService : ISessionAware
    {
        #region Methods
        Task<User> GetOrAddUserWithBedrockUser(IBedrockUser bedrockUser);
        #endregion
    }
}
