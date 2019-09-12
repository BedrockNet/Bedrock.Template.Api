using System.Collections.Generic;
using System.Threading.Tasks;

using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Template.Api.Service.Contract.RockManagement;

using Bedrock.Shared.Pagination;

using Bedrock.Shared.Service.Interface;
using Bedrock.Shared.Session.Interface;

namespace Bedrock.Template.Api.Service.Interface
{
    public interface IRockManagementApplicationService : ISessionAware
    {
        #region Methods
        Task<IEnumerable<GetRockContract>> GetRocksAsync();

        Task<IEnumerable<GetRockContract>> GetRocksWithProjectionAsync();

        Task<GetRockContract> GetRockByIdAsync(int id);

        IServiceResponse<Rock, AddUpdateRockContract> AddRock(AddUpdateRockContract rockContract);

        Task<IServiceResponse<Rock, AddUpdateRockContract>> UpdateRockAsync(AddUpdateRockContract rockContract);

        Task<PaginationResult<GetRockContract>> SearchRocksAsync(RockSearchContract requestContract);

        IEnumerable<RockProcedureContract> GetRocksWithProcedure(int id);
        #endregion
    }
}
