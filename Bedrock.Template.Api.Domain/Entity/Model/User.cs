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
	public partial class User : BedrockDeletableIdEntity<User, int>, IBedrockDeletableEntity, IValidatableObject
	{
		#region Fields
		#endregion

		#region Constructors
		public User()
		{
			Initialize();
		}
		#endregion

		#region Properties
		public string Username { get; set; }

		public System.Guid GlobalKey { get; set; }
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
