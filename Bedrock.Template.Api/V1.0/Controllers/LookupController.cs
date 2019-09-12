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
    public class LookupController : BedrockApiController
    {
        #region Constructors
        public LookupController
        (
            ISession session,
            ILookupApplicationService lookupApplicationService,
            Http.IHttpContextAccessor httpContextAccessor
        ) : base(httpContextAccessor, session, lookupApplicationService) { }
        #endregion

        #region Properties
        protected ILookupApplicationService LookupService { get; set; }
        #endregion

        #region Api Methods
        /// <summary>
        /// Gets keys for all cached items
        /// </summary>
        /// <returns>Enumerable of strings</returns>
        [HttpGet, Route("GetCacheKeys")]
        public IActionResult GetCacheKeys()
        {
            var keys = LookupService.GetCacheKeys();
            return Ok(keys);
        }

        /// <summary>
        /// Clear cache item by key
        /// </summary>
        /// <remarks>
        /// Sample Remark
        /// </remarks>
        /// <param name="cacheKey">The key of the item to clear from the cache</param>
        /// <returns></returns>
        [HttpGet, Route("ClearCache/{cacheKey}"), AllowAnonymous]
        public async Task<IActionResult> ClearCacheByKey(string cacheKey)
        {
            await LookupService.ClearCacheByKeyAsync(cacheKey);
            return Ok();
        }

        /// <summary>
        /// Clear cache items by keys
        /// </summary>
        /// <param name="cacheKeysContract"></param>
        /// <returns></returns>
        [HttpPost, Route("ClearCacheByKeys"), AllowAnonymous]
        public async Task<IActionResult> ClearCacheByKeys(CacheKeysContract cacheKeysContract)
        {
            await LookupService.ClearCacheByKeysAsync(cacheKeysContract.Keys);
            return Ok();
        }

        /// <summary>
        /// Clear entire cache
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("ClearCache")]
        public async Task<IActionResult> ClearCacheAll()
        {
            await LookupService.ClearCacheAllAsync();
            return Ok();
        }
        #endregion
    }
}