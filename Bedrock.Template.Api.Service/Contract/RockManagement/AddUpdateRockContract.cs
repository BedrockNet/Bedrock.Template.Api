using System.ComponentModel.DataAnnotations;

using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Shared.Model;

namespace Bedrock.Template.Api.Service.Contract.RockManagement
{
    public class AddUpdateRockContract : BedrockIdModel<Rock, AddUpdateRockContract, int>
    {
        #region Properties
        public int RockTypeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public decimal Weight { get; set; }
        #endregion
    }
}
