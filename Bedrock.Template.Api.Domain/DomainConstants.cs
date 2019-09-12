using System;
using System.Collections.Generic;

namespace Bedrock.Template.Api.Domain
{
    public static class DomainConstants
    {
        #region Public Properties
        public static Type RepositoryKeyTypeDefault
        {
            get { return typeof(int); }
        }

        public static Dictionary<Type, Type> RepositoryKeyTypes
        {
            get { return new Dictionary<Type, Type> { }; }
        }
        #endregion
    }
}
