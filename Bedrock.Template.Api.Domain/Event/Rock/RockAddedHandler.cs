using Bedrock.Shared.Domain.Interface;

namespace Bedrock.Template.Api.Domain.Event.Rock
{
    public class RockAddedHandler : DomainEventHandlerBase, IDomainEventHandler<RockAddedEvent>
    {
        #region Constructors
        public RockAddedHandler(ITemplateContext context) : base(context) { }
        #endregion

        #region IDomainEventHandler Methods
        public void Handle(RockAddedEvent domainEvent)
        {
            // Do Something
        }
        #endregion
    }
}
