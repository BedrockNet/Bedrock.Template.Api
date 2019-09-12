using System.Collections.Generic;
using System.Threading.Tasks;

using Bedrock.Template.Api.Core.Enumeration.StringHelper;
using Bedrock.Template.Api.Core.Utility;

using Bedrock.Template.Api.Service.Contract.RockManagement;
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
        //[ResourceAuthorize("Rock", "GetAll", "General" )]
        [HttpGet, Route("GetRocks")]
        [ProducesResponseType(typeof(IEnumerable<GetRockContract>), 200)]
        public async Task<IActionResult> GetRocks()
        {
            //var isAuthorized = await HttpContextAccessor.HttpContext.CheckAccessAsync("Rock", new string[] { "GetAll" }, "General");

            //if (!isAuthorized)
            //    return this.AccessDenied();

            var rocks = await RockManagementService.GetRocksAsync();
            return Ok(rocks);
        }

        [HttpGet, Route("GetRocksWithProjection")]
        [ProducesResponseType(typeof(IEnumerable<GetRockContract>), 200)]
        public async Task<IActionResult> GetRocksWithProjection()
        {
            var rocks = await RockManagementService.GetRocksWithProjectionAsync();
            return Ok(rocks);
        }

        [HttpGet, Route("GetRockById/{id}")]
        [ProducesResponseType(typeof(GetRockContract), 200)]
        public async Task<IActionResult> GetRockById(int id)
        {
            var rock = await RockManagementService.GetRockByIdAsync(id);
            return Ok(rock);
        }

        [HttpPost, Route("AddRock")]
        public IActionResult AddRock([FromBody]AddUpdateRockContract rockContract)
        {
            EnsureModel(rockContract);

            var response = RockManagementService.AddRock(rockContract);

            EnsureValidity(response.ValidationState, StringHelperTemplate.Current.Lookup(StringErrorTemplate.DataInvalidForOperation));

            CurrentSession.Complete(response);

            return Created(string.Empty, response.Contract);
        }

        [HttpPost, Route("UpdateRock")]
        public async Task<IActionResult> UpdateRock([FromBody]AddUpdateRockContract contractToUpdate)
        {
            EnsureModel(contractToUpdate);

            var response = await RockManagementService.UpdateRockAsync(contractToUpdate);

            EnsureValidity(response.ValidationState, StringHelperTemplate.Current.Lookup(StringErrorTemplate.DataInvalidForOperation));

            await Task.WhenAll(CurrentSession.CompleteAsync(response));

            return Ok(response.Contract);
        }

        [HttpPost, Route("SearchRocks")]
        public async Task<IActionResult> SearchRocks([FromBody] RockSearchContract requestContract)
        {
            EnsureModel(requestContract);

            var returnValue = await RockManagementService.SearchRocksAsync(requestContract);
            return Ok(returnValue);
        }

        [HttpGet, Route("GetRocksWithProcedure/{id}")]
        [ProducesResponseType(typeof(IEnumerable<RockProcedureContract>), 200)]
        public IActionResult GetRocksWithProcedure(int id)
        {
            var rocks = RockManagementService.GetRocksWithProcedure(id);
            return Ok(rocks);
        }
        #endregion
    }
}