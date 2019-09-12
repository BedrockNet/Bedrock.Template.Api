using System.ComponentModel.DataAnnotations;

using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Template.Api.Service.Contract.Lookup;

using Bedrock.Shared.Model;

namespace Bedrock.Template.Api.Service.Contract.RockManagement
{
    public class GetRockContract : BedrockIdModel<Rock, GetRockContract, int>
    {
        #region Constructors
        public GetRockContract() { }
        #endregion

        #region Properties
        public int RockTypeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public RockTypeContract RockType { get; set; }
        #endregion
    }
}