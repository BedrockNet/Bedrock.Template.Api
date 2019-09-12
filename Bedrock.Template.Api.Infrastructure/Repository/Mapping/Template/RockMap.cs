using Bedrock.Template.Api.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bedrock.Template.Infrastructure.Repository.Mapping.Template
{
	public partial class RockMap : IEntityTypeConfiguration<Rock>
	{
		#region IEntityTypeConfiguration Members
		public void Configure(EntityTypeBuilder<Rock> builder)
		{
			// Primary Key
			builder.HasKey(t => t.Id);

			// Properties
			builder.Property(t => t.Name)
					.IsRequired()
					.HasMaxLength(100);

			builder.Property(t => t.Description)
					.IsRequired()
					.HasMaxLength(200);

			// Table & Column Mappings
			builder.ToTable("Rock");
			builder.Property(t => t.Id).HasColumnName("Id");
			builder.Property(t => t.RockTypeId).HasColumnName("RockTypeId");
			builder.Property(t => t.Name).HasColumnName("Name");
			builder.Property(t => t.Description).HasColumnName("Description");
			builder.Property(t => t.Weight).HasColumnName("Weight");
			builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
			builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
			builder.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
			builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
			builder.Property(t => t.DeletedBy).HasColumnName("DeletedBy");
			builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

			// Many to Many Relationships

			// Foreign Key Relationships
			builder.HasOne(t => t.RockType)
				.WithMany(t =>t.Rocks)
				.HasForeignKey(d => d.RockTypeId)
				.Metadata.DeleteBehavior = DeleteBehavior.Restrict;
		}
		#endregion
	}
}
