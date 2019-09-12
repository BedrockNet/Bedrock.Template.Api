using Bedrock.Shared.Pagination;

namespace Bedrock.Template.Api.Domain.Entity.Search
{
    public class RockSearch
    {
        #region Properties
        [ExactMatchSearchFilter]
        [Map("Name")] // Can also map child properties (i.e., [Map("Child.Property")])
        public string Title { get; set; }

        public string Description { get; set; }

        [IgnoreSearchFilter]
        public int FieldToIgnore { get; set; }

        [ExactMatchSearchFilter]
        public bool? IsDeleted { get; set; }

        public CriteriaFieldDateTime CreatedDate { get; set; }

        public CriteriaFieldNullableDateTime UpdatedDate { get; set; }

        [IgnoreSearchFilter]
        public PagingInstruction PagingInstruction { get; set; }
        #endregion
    }
}
