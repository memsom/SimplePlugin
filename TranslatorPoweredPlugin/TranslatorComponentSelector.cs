using Castle.Facilities.TypedFactory;
using RatCow.SimplePlugin.Interfaces.Commands;
using RatCow.SimplePlugin.Interfaces.Events;
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
            if (method.Name == "CreateTranslator" && arguments.Length == 1 && arguments[0] is BaseCommand)
            {
                return $"TranslatorPoweredPlugin.Translators.Commands.{arguments[0].GetType().Name}Translator";
            }
            else if (method.Name == "CreateTranslator" && arguments.Length == 1 && arguments[0] is BaseEventArgs)
            {
                return $"TranslatorPoweredPlugin.Translators.Events.{arguments[0].GetType().Name}Translator";
            }

            return base.GetComponentName(method, arguments);
        }

        protected override IDictionary GetArguments(MethodInfo method, object[] arguments)
        {
            return base.GetArguments(method, arguments);
        }
    }
}