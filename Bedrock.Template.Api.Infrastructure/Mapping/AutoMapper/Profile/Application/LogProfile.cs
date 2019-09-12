using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Template.Api.Service.Contract.Application;

using Bedrock.Shared.Mapper.AutoMapper;
using AM = AutoMapper;

namespace Bedrock.Template.Api.Infrastructure.Mapping.AutoMapper.Application
{
	public class LogProfile : AM.Profile
	{
		#region Constructors
		public LogProfile()
		{
			AutoMapperConfiguration.MapperConfigurationExpression.CreateMap<Log, LogContract>();
			AutoMapperConfiguration.MapperConfigurationExpression.CreateMap<LogContract, Log>();
		}
		#endregion
	}
}
