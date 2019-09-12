using System.Linq;
using System.Reflection;

using Bedrock.Shared.Session.Implementation;
using Bedrock.Shared.Session.Interface;

namespace Bedrock.Template.Api.Domain.Event
{
    public abstract class DomainEventHandlerBase : SessionAwareBase
    {
        #region Constructors
        public DomainEventHandlerBase(params ISessionAware[] sessionAwareDependencies) : base(sessionAwareDependencies)
        {
            SetContexts(sessionAwareDependencies);
        }
        #endregion

        #region Properties
        protected ITemplateContext Context { get; set; }
        #endregion

        #region Private Methods
        private void SetContexts(ISessionAware[] dependencies)
        {
            Context = dependencies
                        .FirstOrDefault(d => d.GetType()
                        .GetTypeInfo()
                        .IsAssignableFrom(typeof(TemplateContext))) as ITemplateContext;
        }
        #endregion
    }
}
