using Bedrock.Template.Api.Domain.Entity.Search;

using Bedrock.Shared.Model;
using Bedrock.Shared.Pagination;

namespace Bedrock.Template.Api.Service.Contract.RockManagement
{
    public class RockSearchContract : BedrockModel<RockSearch, RockSearchContract>
    {
        #region Properties
        public string Title { get; set; }

        public string Description { get; set; }
        
        public int FieldToIgnore { get; set; }

        public bool? IsDeleted { get; set; }

        public CriteriaFieldDateTime CreatedDate { get; set; }

        public CriteriaFieldNullableDateTime UpdatedDate { get; set; }

        public PagingInstruction PagingInstruction { get; set; }
        #endregion
    }
}
