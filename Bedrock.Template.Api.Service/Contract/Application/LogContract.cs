using System.ComponentModel.DataAnnotations;

using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Shared.Model;

namespace Bedrock.Template.Api.Service.Contract.Application
{
	public partial class LogContract : BedrockIdModel<Log, LogContract, long>
	{
		#region Constructors
		#endregion

		#region Properties
		public System.DateTime LogDateTime { get; set; }

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

		public string Message { get; set; }

		[MaxLength(200)]
		public string ExceptionSource { get; set; }

		[MaxLength(200)]
		public string ExceptionClass { get; set; }

		[MaxLength(200)]
		public string ExceptionMethod { get; set; }

		[MaxLength(1000)]
		public string ExceptionError { get; set; }

		public string ExceptionStackTrace { get; set; }

		public string ExceptionInnerMessage { get; set; }
		#endregion
	}
}
