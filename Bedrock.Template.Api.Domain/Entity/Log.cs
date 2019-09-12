using System.ComponentModel.DataAnnotations;

namespace Bedrock.Template.Api.Domain.Entity
{
	public partial class Log
	{
		#region Properties
		#endregion

		#region Private Methods
		partial void Initialize() { }
		#endregion

		#region Internal Classes
		internal sealed class Metadata
		{
			private Metadata() { }

			[MaxLength(50)]
			public string MachineName { get; set; }

			[MaxLength(50)]
			public string Application { get; set; }

			[MaxLength(100)]
			public string Identity { get; set; }

			[MaxLength(200)]
			public string LoggerName { get; set; }

			[MaxLength(20)]
			public string LogLevel { get; set; }

			[MaxLength(200)]
			public string ExceptionSource { get; set; }

			[MaxLength(200)]
			public string ExceptionClass { get; set; }

			[MaxLength(200)]
			public string ExceptionMethod { get; set; }

			[MaxLength(1000)]
			public string ExceptionError { get; set; }
		}
		#endregion
	}
}
