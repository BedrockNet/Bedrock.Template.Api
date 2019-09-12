using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bedrock.Template.Api.Domain.Service.Interface;
using Bedrock.Template.Api.Service.Interface;

using Bedrock.Shared.Configuration;
using Bedrock.Shared.Extension;
using Bedrock.Template.Api.Service.Contract.Lookup;
using Bedrock.Template.Api.Core.Utility;
using Bedrock.Template.Api.Core.Enumeration.StringHelper;

namespace Bedrock.Template.Api.Service
{
    public partial class LookupApplicationService : ServiceBaseApplication, ILookupApplicationService
    {
        #region Constructors
        public LookupApplicationService
        (
            ILookupService lookupService,
            BedrockConfiguration bedrockConfiguration
        ) : base(bedrockConfiguration, lookupService) { }
        #endregion

        #region Properties
        protected ILookupService LookupService { get; set; }

        protected TimeSpan CacheExpiry
        {
            get { return new TimeSpan(0, BedrockConfiguration.Cache.CacheExpiry, 0); }
        }
        #endregion

        #region ILookupApplicationService Methods
        public IEnumerable<string> GetCacheKeys()
        {
            return Cache
                    .InnerCache
                    .KeyDictionary
                    .Keys
                    .OrderBy(o => o);
        }

        public async Task ClearCacheByKeyAsync(string cacheKey)
        {
            await Cache.InvalidateCacheItemAsync(cacheKey);
        }

        public async Task ClearCacheByKeysAsync(string[] keys)
        {
            var tasks = new List<Task>();
            keys.Each(k => tasks.Add(Cache.InvalidateCacheItemAsync(k)));

            await Task.WhenAll(tasks);
        }

        public async Task ClearCacheAllAsync()
        {
            await Cache.InvalidateCacheAsync();
        }

        public async Task<IEnumerable<RockTypeContract>> GetRockTypesAsync()
        {
            var cacheKey = StringHelperTemplate.Current.Lookup(StringCacheKeyTemplate.RockTypes);
            return await await Cache.GetAsync(cacheKey, CacheExpiry, async () => RockTypeContract.StaticMapToModelsFromDomainModels(await LookupService.GetRockTypesAsync()));
        }
        #endregion
    }
}
