using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Template.Api.Service.Contract.RockManagement;

using Bedrock.Shared.Mapper.AutoMapper;
using AM = AutoMapper;

namespace Bedrock.Template.Api.Infrastructure.Mapping.AutoMapper.RockManagement
{
	public class AddUpdateRockProfile : AM.Profile
	{
		#region Constructors
		public AddUpdateRockProfile()
		{
			AutoMapperConfiguration.MapperConfigurationExpression.CreateMap<Rock, AddUpdateRockContract>();

			AutoMapperConfiguration.MapperConfigurationExpression.CreateMap<AddUpdateRockContract, Rock>();

            AutoMapperConfiguration.MapperConfigurationExpression.CreateMap<Rock, Rock>()
                                    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                                    .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                                    .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                                    .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                                    .ForMember(dest => dest.DeletedBy, opt => opt.Ignore())
                                    .ForMember(dest => dest.DeletedDate, opt => opt.Ignore());
        }
		#endregion
	}
}
