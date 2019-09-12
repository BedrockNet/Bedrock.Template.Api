using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Bedrock.Shared.Entity.Implementation;
using Bedrock.Shared.Entity.Interface;
using Bedrock.Shared.Utility;

namespace Bedrock.Template.Api.Domain.Entity
{
	[Serializable]
	[MetadataType(typeof(Metadata))]
	public partial class RockType : BedrockIdEntity<RockType, int>, IBedrockEntity, IValidatableObject
	{
		#region Fields
		#endregion

		#region Constructors
		public RockType()
		{
			Initialize();

			Rocks = new List<Rock>();
		}
		#endregion

		#region Properties
		public string Name { get; set; }

		public string Description { get; set; }

		public int SortOrder { get; set; }

		public virtual ICollection<Rock> Rocks { get; set; }
		#endregion

		#region IValidateableObject Methods
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			ValidateInternal(validationContext);
			return ValidationResults;
		}
		#endregion

		#region Public Methods
		#endregion

		#region Private Methods
		partial void Initialize();

		partial void ValidateInternal(ValidationContext validationContext);
		#endregion
	}
}
