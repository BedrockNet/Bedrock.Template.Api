using Bedrock.Template.Api.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bedrock.Template.Infrastructure.Repository.Mapping.Template
{
	public partial class RockTypeMap : IEntityTypeConfiguration<RockType>
	{
		#region IEntityTypeConfiguration Members
		public void Configure(EntityTypeBuilder<RockType> builder)
		{
			// Primary Key
			builder.HasKey(t => t.Id);

			// Properties
			builder.Property(t => t.Id)
					.ValueGeneratedNever();

			builder.Property(t => t.Name)
					.IsRequired()
					.HasMaxLength(100);

			builder.Property(t => t.Description)
					.IsRequired()
					.HasMaxLength(200);

			// Table & Column Mappings
			builder.ToTable("RockType");
			builder.Property(t => t.Id).HasColumnName("Id");
			builder.Property(t => t.Name).HasColumnName("Name");
			builder.Property(t => t.Description).HasColumnName("Description");
			builder.Property(t => t.SortOrder).HasColumnName("SortOrder");

			// Many to Many Relationships

			// Foreign Key Relationships
		}
		#endregion
	}
}
