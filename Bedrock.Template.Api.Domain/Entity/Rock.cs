using System.ComponentModel.DataAnnotations;
using Bedrock.Template.Api.Domain.Event.Rock;

namespace Bedrock.Template.Api.Domain.Entity
{
	public partial class Rock
	{
        #region Properties
        #endregion

        #region Public Methods
        public void DoSomethingToRaiseEvent()
        {
            Events.Add(new RockAddedEvent(this));
        }
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
			public string Name { get; set; }

			[Required]
			[MaxLength(200)]
			public string Description { get; set; }
		}
		#endregion
	}
}
