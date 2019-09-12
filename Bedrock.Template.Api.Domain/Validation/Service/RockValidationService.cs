using System;
using System.ComponentModel.DataAnnotations;

using Bedrock.Template.Api.Core.Enumeration.StringHelper;
using Bedrock.Template.Api.Core.Utility;

using Bedrock.Template.Api.Domain.Entity;

using Bedrock.Shared.Configuration;

namespace Bedrock.Template.Api.Domain.Validation.Service.Interface
{
    public class RockValidationService : ServiceBaseDomainValidation, IRockValidationService
    {
        #region Constructors
        public RockValidationService(ITemplateContext context, BedrockConfiguration configuration) : base(configuration, context) { }
        #endregion

        #region Public Static Properties
        public static Type Type
        {
            get { return typeof(RockValidationService); }
        }
        #endregion

        public static ValidationResult EnsureSomething(Rock rock, ValidationContext validationContext)
        {
            var notTrue = false;

            if (notTrue)
            {
                var message = StringHelperTemplate.Current.Lookup(StringErrorTemplate.SomethingIsWrong);
                return new ValidationResult(message);
            }

            return ValidationResult.Success;
        }

        public static ValidationResult EnsureSomethingElse(Rock rock, ValidationContext validationContext)
        {
            var notTrue = false;

            if (notTrue)
            {
                var message = StringHelperTemplate.Current.Lookup(StringErrorTemplate.SomethingElseIsWrong);
                return new ValidationResult(message);
            }

            return ValidationResult.Success;
        }
    }
}
