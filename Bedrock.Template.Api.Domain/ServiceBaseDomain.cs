using System.Linq;

using Bedrock.Shared.Configuration;

using Bedrock.Shared.Domain.Implementation;
using Bedrock.Shared.Domain.Interface;

using Bedrock.Shared.Service.Implementation;
using Bedrock.Shared.Session.Interface;

namespace Bedrock.Template.Api.Domain
{
	public class ServiceBaseDomain : ServiceBaseValidation
	{
		#region Fields
		#endregion

		#region Constructors
		public ServiceBaseDomain(BedrockConfiguration bedrockConfiguration, params ISessionAware[] sessionAwareDependencies) : base(sessionAwareDependencies)
		{
            BedrockConfiguration = bedrockConfiguration;

			SetContexts(sessionAwareDependencies);
			SetEventDispatcher(sessionAwareDependencies);
		}
		#endregion

		#region Properties
		protected ITemplateContext Context { get; set; }

		protected IDomainEventDispatcher EventDispatcher { get; set; }

		protected BedrockConfiguration BedrockConfiguration { get; set; }
		#endregion

		#region Private Methods
		private void SetContexts(ISessionAware[] dependencies)
		{
			Context = dependencies
									.FirstOrDefault(d => d.GetType()
															.IsAssignableFrom(typeof(TemplateContext))) as ITemplateContext;
		}

		private void SetEventDispatcher(ISessionAware[] dependencies)
		{
			EventDispatcher = dependencies
									.FirstOrDefault(d => d.GetType()
															.IsAssignableFrom(typeof(DomainEventDispatcher))) as IDomainEventDispatcher;
		}
		#endregion
	}
}