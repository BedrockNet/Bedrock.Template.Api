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
	public partial class Log : BedrockIdEntity<Log, long>, IBedrockEntity, IValidatableObject
	{
		#region Fields
		#endregion

		#region Constructors
		public Log()
		{
			Initialize();
		}
		#endregion

		#region Properties
		public System.DateTime LogDateTime { get; set; }

		public string MachineName { get; set; }

		public string Application { get; set; }

		public string Identity { get; set; }

		public string LoggerName { get; set; }

		public string LogLevel { get; set; }

		public string Message { get; set; }

		public string ExceptionSource { get; set; }

		public string ExceptionClass { get; set; }

		public string ExceptionMethod { get; set; }

		public string ExceptionError { get; set; }

		public string ExceptionStackTrace { get; set; }

		public string ExceptionInnerMessage { get; set; }
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
