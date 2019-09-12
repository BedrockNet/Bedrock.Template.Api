using System.Collections.Generic;
using System.Threading.Tasks;

using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Shared.Session.Interface;
using Bedrock.Shared.Service.Interface;
using Bedrock.Template.Api.Domain.Entity.Search;
using Bedrock.Shared.Pagination;

using ProcedureEntity = Bedrock.Template.Api.Domain.Entity.Procedure;

namespace Bedrock.Template.Api.Domain.Service.Interface
{
    public interface IRockService : ISessionAware
    {
        #region Methods
        Task<IEnumerable<Rock>> GetRocksAsync();

        Task<IEnumerable<T>> GetRocksAsync<T>();

        Task<Rock> GetRockByIdAsync(int id);

        Task<T> GetRockByIdAsync<T>(int id);

        IServiceResponse<Rock, Rock> AddRock(Rock rock);

        Task<IServiceResponse<Rock, Rock>> UpdateRockAsync(Rock rock);

        Task<PaginationResult<Rock>> SearchRocksAsync(RockSearch rockSearch);

        IEnumerable<ProcedureEntity.Rock> GetRocksWithProcedure(int id);
        #endregion
    }
}
