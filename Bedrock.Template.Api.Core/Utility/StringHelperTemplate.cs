using System;

using Bedrock.Template.Api.Core.Enumeration.StringHelper;
using Bedrock.Shared.Utility;

namespace Bedrock.Template.Api.Core.Utility
{
    public class StringHelperTemplate : Singleton<StringHelperTemplate>
    {
		#region Public Methods
		public string Lookup<T>(T key) where T : struct, IConvertible
		{
			return Lookup(key, new string[] { });
		}

		public string Lookup<T>(T key, params string[] args) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            var returnValue = string.Empty;
            var lookup = (object)key;

            TypeSwitch.On<T>
            (
                TypeSwitch.Case<StringApplicationTemplate>(() =>
                {
                    returnValue = Lookup((StringApplicationTemplate)lookup, args);
                }),
                TypeSwitch.Case<StringWarningTemplate>(() =>
                {
                    returnValue = Lookup((StringWarningTemplate)lookup, args);
                }),
                TypeSwitch.Case<StringErrorTemplate>(() =>
                {
                    returnValue = Lookup((StringErrorTemplate)lookup, args);
                }),
                TypeSwitch.Case<StringExceptionTemplate>(() =>
                {
                    returnValue = Lookup((StringExceptionTemplate)lookup, args);
                }),
                TypeSwitch.Case<StringCacheKeyTemplate>(() =>
                {
                    returnValue = Lookup((StringCacheKeyTemplate)lookup, args);
                }),
                TypeSwitch.Default(() =>
                {
                    returnValue = StringHelper.Current.Lookup(key, args);
                })
            );

            return returnValue;
        }
        #endregion

        #region Private Methods
        private string Lookup(StringApplicationTemplate key, params string[] args)
        {
            var returnValue = string.Empty;
            return returnValue;
        }

        private string Lookup(StringWarningTemplate key, params string[] args)
        {
            var returnValue = string.Empty;
            return returnValue;
        }

        private string Lookup(StringErrorTemplate key, params string[] args)
        {
            var returnValue = string.Empty;
            return returnValue;
        }

        private string Lookup(StringExceptionTemplate key, params string[] args)
        {
            var returnValue = string.Empty;
            return returnValue;
        }

        private string Lookup(StringCacheKeyTemplate key, params string[] args)
        {
            var returnValue = string.Empty;
            var keyPrefix = "Bedrock:Template:Api:";
            return returnValue;
        }
        #endregion
    }
}
