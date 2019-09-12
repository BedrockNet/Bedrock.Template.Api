using System;
using System.Linq;
using System.Threading.Tasks;

using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Template.Api.Domain.Service.Interface;

using Bedrock.Shared.Configuration;
using Bedrock.Shared.Data.Repository.Extension;
using Bedrock.Shared.Security.Interface;

namespace Bedrock.Template.Api.Domain.Service
{
    public class UserService : ServiceBaseDomain, IUserService
    {
        #region Constructors
        public UserService
        (
            ITemplateContext context,
            BedrockConfiguration bedrockConfiguration
        )
        : base(bedrockConfiguration, context) { }
        #endregion

        #region IUserService Methods
        public async Task<User> GetOrAddUserWithBedrockUser(IBedrockUser bedrockUser)
        {
            if (bedrockUser.GlobalKey == Guid.Empty)
                return default(User);

            var returnValue = await Context
                                    .Users
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(u => u.GlobalKey == bedrockUser.GlobalKey);

            if (returnValue == null)
            {
                returnValue = new User
                {
                    Username = bedrockUser.Emails?.FirstOrDefault(),
                    GlobalKey = bedrockUser.GlobalKey
                };

                Context.Users.Add(returnValue);
            }

            return returnValue;
        }
        #endregion
    }
}
