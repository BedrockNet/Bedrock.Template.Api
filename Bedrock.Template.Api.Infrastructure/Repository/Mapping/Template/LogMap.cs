using Bedrock.Template.Api.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bedrock.Template.Api.Infrastructure.Repository.Mapping.Template
{
	public partial class LogMap : IEntityTypeConfiguration<Log>
	{
        #region IEntityTypeConfiguration Members
        public void Configure(EntityTypeBuilder<Log> builder)
        {
			// Primary Key
			builder.HasKey(t => t.Id);

			// Properties
			builder.Property(t => t.MachineName)
					.HasMaxLength(50);

			builder.Property(t => t.Application)
					.HasMaxLength(50);

			builder.Property(t => t.Identity)
					.HasMaxLength(100);

			builder.Property(t => t.LoggerName)
					.HasMaxLength(200);

			builder.Property(t => t.LogLevel)
					.HasMaxLength(20);

			builder.Property(t => t.ExceptionSource)
					.HasMaxLength(200);

			builder.Property(t => t.ExceptionClass)
					.HasMaxLength(200);

			builder.Property(t => t.ExceptionMethod)
					.HasMaxLength(200);

			builder.Property(t => t.ExceptionError)
					.HasMaxLength(1000);

			// Table & Column Mappings
			builder.ToTable("Log");
			builder.Property(t => t.Id).HasColumnName("Id");
			builder.Property(t => t.LogDateTime).HasColumnName("LogDateTime");
			builder.Property(t => t.MachineName).HasColumnName("MachineName");
			builder.Property(t => t.Application).HasColumnName("Application");
			builder.Property(t => t.Identity).HasColumnName("Identity");
			builder.Property(t => t.LoggerName).HasColumnName("LoggerName");
			builder.Property(t => t.LogLevel).HasColumnName("LogLevel");
			builder.Property(t => t.Message).HasColumnName("Message");
			builder.Property(t => t.ExceptionSource).HasColumnName("ExceptionSource");
			builder.Property(t => t.ExceptionClass).HasColumnName("ExceptionClass");
			builder.Property(t => t.ExceptionMethod).HasColumnName("ExceptionMethod");
			builder.Property(t => t.ExceptionError).HasColumnName("ExceptionError");
			builder.Property(t => t.ExceptionStackTrace).HasColumnName("ExceptionStackTrace");
			builder.Property(t => t.ExceptionInnerMessage).HasColumnName("ExceptionInnerMessage");

			// Many to Many Relationships

			// Foreign Key Relationships
		}
		#endregion
	}
}
