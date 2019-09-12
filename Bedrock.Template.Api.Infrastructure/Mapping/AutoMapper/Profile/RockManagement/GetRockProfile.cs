using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Template.Api.Service.Contract.RockManagement;

using Bedrock.Shared.Mapper.AutoMapper;
using AM = AutoMapper;

namespace Bedrock.Template.Api.Infrastructure.Mapping.AutoMapper.RockManagement
{
	public class GetRockProfile : AM.Profile
	{
		#region Constructors
		public GetRockProfile()
		{
			AutoMapperConfiguration.MapperConfigurationExpression.CreateMap<Rock, GetRockContract>();
			AutoMapperConfiguration.MapperConfigurationExpression.CreateMap<GetRockContract, Rock>();
		}
		#endregion
	}
}
