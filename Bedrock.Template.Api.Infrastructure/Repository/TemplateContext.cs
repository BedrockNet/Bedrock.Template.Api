using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Template.Api.Infrastructure.Repository.Mapping.Template;

using Bedrock.Shared.Data.Repository.EntityFramework;
using Bedrock.Shared.Data.Repository.EntityFramework.Helper;
using Bedrock.Shared.Domain.Interface;

using Microsoft.EntityFrameworkCore;
using SharedConfiguration = Bedrock.Shared.Configuration;

namespace Bedrock.Template.Api.Infrastructure.Repository
{
	public partial class TemplateContext : BedrockContext
	{
		#region Constructors
		public TemplateContext(IDomainEventDispatcher domainEventDispatcher, SharedConfiguration.BedrockConfiguration bedrockConfiguration) : base(domainEventDispatcher, bedrockConfiguration) { }

		public TemplateContext(IDomainEventDispatcher domainEventDispatcher, string nameOrConnectionString, SharedConfiguration.BedrockConfiguration bedrockConfiguration) : base(nameOrConnectionString, domainEventDispatcher, bedrockConfiguration) { }

		public TemplateContext(IDomainEventDispatcher domainEventDispatcher, DbContextOptions options, SharedConfiguration.BedrockConfiguration bedrockConfiguration) : base(options, domainEventDispatcher, bedrockConfiguration) { }
		#endregion

		#region Public Properties
		public DbSet<Log> Logs { get; set; }

		public DbSet<Rock> Rocks { get; set; }

		public DbSet<RockType> RockTypes { get; set; }

		public DbSet<User> Users { get; set; }
		#endregion

		#region DbContext Members
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			IgnoreProperties(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(TemplateContext).Assembly);

			base.OnModelCreating(modelBuilder);
		}
		#endregion

		#region Private Methods
		private void IgnoreProperties(ModelBuilder modelBuilder){ }
		#endregion
	}
}
