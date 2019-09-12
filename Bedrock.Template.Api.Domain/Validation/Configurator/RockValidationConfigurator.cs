using Bedrock.Template.Api.Core.Enumeration.StringHelper;
using Bedrock.Template.Api.Core.Utility;

using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Template.Api.Domain.Validation.Service.Interface;

using Bedrock.Shared.Data.Validation.Implementation.Configuration;
using Bedrock.Shared.Data.Validation.Interface;

using SharedValidation = Bedrock.Shared.Data.Validation.Implementation;

namespace Bedrock.Template.Api.Domain.Validation.Configurator
{
    public class RockValidationConfigurator : ValidationConfiguratorBase, IValidationConfigurator
    {
        #region Public Methods (Configuration)
        public IValidationConfiguration GetConfigurationAddRock(Rock rockToAdd)
        {
            var returnValue = new ValidationConfiguration(SharedValidation.ValidationRequest.FieldsRecursive());

            var rules = returnValue
                            .CreateRules<Rock>()
                            .AddExpression(c => c.Id <= 0, StringHelperTemplate.Current.Lookup(StringErrorTemplate.CannotHaveId))
                            .AddRuleCustom(RockValidationService.Type, nameof(RockValidationService.EnsureSomething))
                            .AddRuleCustom(RockValidationService.Type, nameof(RockValidationService.EnsureSomethingElse));
            // etc...

            return returnValue;
        }

        public IValidationConfiguration GetConfigurationUpdateRock(Rock rockToAdd)
        {
            var returnValue = new ValidationConfiguration(SharedValidation.ValidationRequest.FieldsRecursive());

            var rules = returnValue
                            .CreateRules<Rock>()
                            .AddExpression(c => c.Id > 0, StringHelperTemplate.Current.Lookup(StringErrorTemplate.MustHaveId))
                            .AddRuleRange(c => c.Id, 1, int.MaxValue)
                            .AddRuleCustom(RockValidationService.Type, nameof(RockValidationService.EnsureSomething))
                            .AddRuleCustom(RockValidationService.Type, nameof(RockValidationService.EnsureSomethingElse));
            // etc...

            return returnValue;
        }
        #endregion
    }
}
