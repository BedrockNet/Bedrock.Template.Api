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
	public partial class Rock : BedrockDeletableIdEntity<Rock, int>, IBedrockDeletableEntity, IValidatableObject
	{
		#region Fields
		#endregion

		#region Constructors
		public Rock()
		{
			Initialize();
		}
		#endregion

		#region Properties
		public int RockTypeId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public decimal Weight { get; set; }

		public virtual RockType RockType { get; set; }
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
