using Bedrock.Template.Api.Service.Contract.RockManagement;
using Bedrock.Shared.Mapper.AutoMapper;

using ProcedureEntity = Bedrock.Template.Api.Domain.Entity.Procedure;
using AM = AutoMapper;

namespace Bedrock.Template.Api.Infrastructure.Mapping.AutoMapper.RockManagement
{
	public class RockProcedureProfile : AM.Profile
	{
		#region Constructors
		public RockProcedureProfile()
		{
			AutoMapperConfiguration.MapperConfigurationExpression.CreateMap<ProcedureEntity.Rock, RockProcedureContract>();
		}
		#endregion
	}
}
