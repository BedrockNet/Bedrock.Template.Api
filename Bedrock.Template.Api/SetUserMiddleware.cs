using System.Threading.Tasks;

using Bedrock.Template.Api.Domain.Service.Interface;

using Bedrock.Shared.Web.Middleware;
using Bedrock.Shared.Web.Middleware.Options;

using Microsoft.AspNetCore.Http;
using SharedSession = Bedrock.Shared.Session.Interface;

namespace Bedrock.Template.Api
{
    public class SetUserMiddleware : PostAuthenticateMiddleware
    {
        #region Constructors
        public SetUserMiddleware(RequestDelegate next, PostAuthenticationMiddlewareOptions options) : base(next, options) { }
        #endregion

        #region Private Methods
        protected override async Task PostAuthenticate(HttpContext context)
        {
            await base.PostAuthenticate(context);

            var session = (SharedSession.ISession)context.RequestServices.GetService(typeof(SharedSession.ISession));
            var userService = (IUserService)context.RequestServices.GetService(typeof(IUserService));

            userService.Enlist(session);

            var user = await userService.GetOrAddUserWithBedrockUser(BedrockUser);

            if (user != null)
            {
                session.Complete();
                BedrockUser.UserId = user.Id;
            }
        }
        #endregion
    }
}
