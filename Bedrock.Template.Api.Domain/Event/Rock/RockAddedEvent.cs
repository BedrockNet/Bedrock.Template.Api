using Bedrock.Shared.Domain.Interface;
using DomainEntity = Bedrock.Template.Api.Domain.Entity;

namespace Bedrock.Template.Api.Domain.Event.Rock
{
    public class RockAddedEvent : IDomainEvent
    {
        #region Constructors
        public RockAddedEvent(DomainEntity.Rock rock)
        {
            Rock = rock;
        }
        #endregion

        #region Properties
        public DomainEntity.Rock Rock { get; set; }
        #endregion
    }
}
