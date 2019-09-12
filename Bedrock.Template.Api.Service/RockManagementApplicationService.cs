using System.Collections.Generic;
using System.Threading.Tasks;

using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Template.Api.Domain.Service.Interface;
using Bedrock.Template.Api.Service.Contract.RockManagement;
using Bedrock.Template.Api.Service.Interface;

using Bedrock.Shared.Configuration;
using Bedrock.Shared.Pagination;
using Bedrock.Shared.Service.Interface;

namespace Bedrock.Template.Api.Service
{
    public partial class RockManagementApplicationService : ServiceBaseApplication, IRockManagementApplicationService
    {
        #region Constructors
        public RockManagementApplicationService
        (
            IRockService rockService,
            BedrockConfiguration bedrockConfiguration
        ) : base(bedrockConfiguration, rockService) { }
        #endregion

        #region Properties
        protected IRockService RockService { get; set; }
        #endregion

        #region IRockManagementApplicationService Methods
        public async Task<IEnumerable<GetRockContract>> GetRocksAsync()
        {
            var rocks = await RockService.GetRocksAsync();
            return GetRockContract.StaticMapToModelsFromDomainModels(rocks);
        }

        public async Task<IEnumerable<GetRockContract>> GetRocksWithProjectionAsync()
        {
            return await RockService.GetRocksAsync<GetRockContract>();
        }

        public async Task<GetRockContract> GetRockByIdAsync(int id)
        {
            return await RockService.GetRockByIdAsync<GetRockContract>(id);
        }

        public IServiceResponse<Rock, AddUpdateRockContract> AddRock(AddUpdateRockContract rockContract)
        {
            var rockToAdd = rockContract.MapToDomainModelFromModel(rockContract);
            var response = RockService.AddRock(rockToAdd);

            return Response(response.Entity, rockContract, response.ValidationState);
        }

        public async Task<IServiceResponse<Rock, AddUpdateRockContract>> UpdateRockAsync(AddUpdateRockContract rockContract)
        {
            var rockToUpdate = rockContract.MapToDomainModelFromModel(rockContract);
            var response = await RockService.UpdateRockAsync(rockToUpdate);

            return Response(response.Entity, rockContract, response.ValidationState);
        }

        public async Task<PaginationResult<GetRockContract>> SearchRocksAsync(RockSearchContract requestContract)
        {
            var searchContract = RockSearchContract.StaticMapToDomainModelFromModel(requestContract);
            var paginationResult = await RockService.SearchRocksAsync(searchContract);

            return Mapper.Map<PaginationResult<Rock>, PaginationResult<GetRockContract>>(new PaginationResult<GetRockContract>(), paginationResult);
        }

        public IEnumerable<RockProcedureContract> GetRocksWithProcedure(int id)
        {
            var rocks = RockService.GetRocksWithProcedure(id);
            return RockProcedureContract.StaticMapToModelsFromDomainModels(rocks);
        }
        #endregion
    }
}
