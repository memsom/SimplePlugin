using Castle.Facilities.TypedFactory;
using System.Collections;
using System.Reflection;

namespace TranslatorPoweredPlugin
{
    public class TranslatorComponentSelector : DefaultTypedFactoryComponentSelector
    {
        public TranslatorComponentSelector()
        {
 
        }
            
        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            //if (method.Name == "CreateTranslator" && arguments.Length == 1 && arguments[0] is IccsCommand)
            //{
            //    var rawTranslatorName = adapter.GetTranslatorName(arguments[0].GetType().Name);
            //    if(!string.IsNullOrEmpty(rawTranslatorName))
            //    {
            //        var result = $"TranslatorPoweredPlugin.Translators.Commands.{rawTranslatorName}";

            //        return result;
            //    }
            //}
            //else if (method.Name == "CreateTranslator" && arguments.Length == 1 && arguments[0] is BaseIccsEventArgs)
            //{
            //    var result = typeof(EventTranslator).FullName;

            //    return result;
            //}

            return base.GetComponentName(method, arguments);
        }

        protected override IDictionary GetArguments(MethodInfo method, object[] arguments)
        {
            return base.GetArguments(method, arguments);
        }
    }
}