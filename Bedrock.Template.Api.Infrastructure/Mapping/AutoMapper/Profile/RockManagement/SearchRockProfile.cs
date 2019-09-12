using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Template.Api.Domain.Entity.Search;

using Bedrock.Template.Api.Service.Contract.RockManagement;

using Bedrock.Shared.Mapper.AutoMapper;
using Bedrock.Shared.Pagination;

using AM = AutoMapper;

namespace Bedrock.Template.Api.Infrastructure.Mapping.AutoMapper.RockManagement
{
    public class SearchRockProfile : AM.Profile
    {
        #region Constructors
        public SearchRockProfile()
        {
            AutoMapperConfiguration.MapperConfigurationExpression.CreateMap<RockSearchContract, RockSearch>();

            AutoMapperConfiguration.MapperConfigurationExpression.CreateMap<PaginationResult<Rock>, PaginationResult<GetRockContract>>()
                                   .AfterMap((s, d) => AM.Mapper.Map(s.Data, d.Data));
        }
        #endregion
    }
}
