using System.ComponentModel.DataAnnotations;

using Bedrock.Shared.Session.Interface;
using Bedrock.Shared.Utility;

namespace Bedrock.Template.Api.Domain.Validation
{
    public class ValidationUtility : Singleton<ValidationUtility>
    {
        #region Protected Methods
        public ITemplateContext GetContextTemplate(ValidationContext validationContext)
        {
            var context = (ITemplateContext)validationContext.GetService(typeof(ITemplateContext));
            context.Enlist(GetSession(validationContext));
            return context;
        }
        #endregion

        #region Private Methods
        private ISession GetSession(ValidationContext validationContext)
        {
            return (ISession)validationContext.GetService(typeof(ISession));
        }
        #endregion
    }
}
