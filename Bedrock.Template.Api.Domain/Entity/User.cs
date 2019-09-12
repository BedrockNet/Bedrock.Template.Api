using System.ComponentModel.DataAnnotations;

namespace Bedrock.Template.Api.Domain.Entity
{
	public partial class User
	{
		#region Properties
		#endregion

		#region Private Methods
		partial void Initialize() { }

		partial void ValidateInternal(ValidationContext validationContext) { }
		#endregion

		#region Internal Classes
		internal sealed class Metadata
		{
			private Metadata() { }

			[Required]
			[MaxLength(100)]
			public string Username { get; set; }
		}
		#endregion
	}
}
