using RatCow.SimplePlugin.Interfaces.Commands;
using RatCow.SimplePlugin.Interfaces.Events;
using TranslatorPoweredPlugin.Translators.Commands;
using TranslatorPoweredPlugin.Translators.Events;

namespace TranslatorPoweredPlugin
{
    public interface ITranslatorFactory
    {
        EventTranslator CreateTranslator(BaseEventArgs anEvent);

        CommandTranslator CreateTranslator(BaseCommand aCommand);

        void Destroy(object translator);
    }
}
