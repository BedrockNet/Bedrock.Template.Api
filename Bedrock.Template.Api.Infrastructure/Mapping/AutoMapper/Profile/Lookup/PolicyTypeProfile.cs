using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Template.Api.Service.Contract.Lookup;

using Bedrock.Shared.Mapper.AutoMapper;
using AM = AutoMapper;

namespace Bedrock.Template.Api.Infrastructure.Mapping.AutoMapper.Profile.Lookup
{
    public class RockTypeProfile : AM.Profile
    {
        #region Constructors
        public RockTypeProfile()
        {
            AutoMapperConfiguration.MapperConfigurationExpression.CreateMap<RockType, RockTypeContract>();
            AutoMapperConfiguration.MapperConfigurationExpression.CreateMap<RockTypeContract, RockType>();
        }
        #endregion

    }
}
