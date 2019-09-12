using System.Threading.Tasks;

using Bedrock.Template.Api.Service.Interface;

using Bedrock.Shared.Security.Api.Contract.Lookup;
using Bedrock.Shared.Session.Interface;

using Bedrock.Shared.Web.Api.Controller;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Http = Microsoft.AspNetCore.Http;

namespace Bedrock.Template.Api.V1_0.Controllers
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class RockManagementController : BedrockApiController
    {
        #region Constructors
        public RockManagementController
        (
            ISession session,
            IRockManagementApplicationService rockManagementService,
            Http.IHttpContextAccessor httpContextAccessor
        ) : base(httpContextAccessor, session, rockManagementService) { }
        #endregion

        #region Properties
        protected IRockManagementApplicationService RockManagementService { get; set; }
        #endregion

        #region Api Methods
        #endregion
    }
}