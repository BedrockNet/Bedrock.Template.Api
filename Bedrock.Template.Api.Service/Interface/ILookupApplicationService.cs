﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Bedrock.Shared.Session.Interface;

namespace Bedrock.Template.Api.Service.Interface
{
    public interface ILookupApplicationService : ISessionAware
    {
        #region Methods
        IEnumerable<string> GetCacheKeys();

        Task ClearCacheByKeyAsync(string cacheKey);

        Task ClearCacheByKeysAsync(string[] keys);

        Task ClearCacheAllAsync();
        #endregion
    }
}
