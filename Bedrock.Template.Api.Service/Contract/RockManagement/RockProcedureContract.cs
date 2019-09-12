using Bedrock.Shared.Model;
using ProcedureEntity = Bedrock.Template.Api.Domain.Entity.Procedure;

namespace Bedrock.Template.Api.Service.Contract.RockManagement
{
    public class RockProcedureContract : BedrockModel<ProcedureEntity.Rock, RockProcedureContract>
    {
        #region Public Properties
        public string Name { get; set; }

        public string Description { get; set; }
        #endregion
    }
}
