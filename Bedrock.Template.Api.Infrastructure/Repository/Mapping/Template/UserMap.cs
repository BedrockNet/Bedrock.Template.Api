using Bedrock.Template.Api.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bedrock.Template.Api.Infrastructure.Repository.Mapping.Template
{
	public partial class UserMap : IEntityTypeConfiguration<User>
	{
        #region IEntityTypeConfiguration Members
        public void Configure(EntityTypeBuilder<User> builder)
        {
			// Primary Key
			builder.HasKey(t => t.Id);

			// Properties
			builder.Property(t => t.Username)
					.IsRequired()
					.HasMaxLength(100);

			// Table & Column Mappings
			builder.ToTable("User");
			builder.Property(t => t.Id).HasColumnName("Id");
			builder.Property(t => t.Username).HasColumnName("Username");
			builder.Property(t => t.GlobalKey).HasColumnName("GlobalKey");
			builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
			builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
			builder.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
			builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
			builder.Property(t => t.DeletedBy).HasColumnName("DeletedBy");
			builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

			// Many to Many Relationships

			// Foreign Key Relationships
		}
		#endregion
	}
}
