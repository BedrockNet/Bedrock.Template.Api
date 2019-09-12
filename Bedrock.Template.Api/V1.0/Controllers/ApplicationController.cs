using System;
using System.Threading.Tasks;

using Bedrock.Template.Api.Service.Interface;

using Bedrock.Shared.Session.Interface;
using Bedrock.Shared.Web.Api.Controller;

using Microsoft.AspNetCore.Mvc;
using Http = Microsoft.AspNetCore.Http;

namespace Bedrock.Template.Api.V1_0.Controllers
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class ApplicationController : BedrockApiController
    {
        #region Constructors
        public ApplicationController
        (
            IApplicationService applicationService,
            ISession session,
            Http.IHttpContextAccessor httpContextAccessor
        ) : base(httpContextAccessor, session, applicationService) { }
        #endregion

        #region Protected Properties
        protected IApplicationService ApplicationService { get; set; }
        #endregion

        #region Api Methods
        [HttpGet, Route("LogClientError")]
        public IActionResult LogClientError(string clientError)
        {
            var exception = new Exception("Client");
            Logger.Error(exception, clientError);
            return Ok();
        }

        [HttpGet, Route("GetErrorAll")]
        public async Task<IActionResult> GetErrorAll()
        {
            var errors = await ApplicationService.GetErrorsAllAsync();
            return Ok(errors);
        }
        #endregion
    }
}
