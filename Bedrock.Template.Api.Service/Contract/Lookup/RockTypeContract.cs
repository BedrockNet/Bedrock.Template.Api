using System.ComponentModel.DataAnnotations;

using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Shared.Model;

namespace Bedrock.Template.Api.Service.Contract.Lookup
{
    public partial class RockTypeContract : BedrockIdModel<RockType, RockTypeContract, int>
    {
        #region Properties
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public int SortOrder { get; set; }
        #endregion
    }
}
