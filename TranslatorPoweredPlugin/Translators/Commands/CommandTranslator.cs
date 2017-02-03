using RatCow.SimplePlugin.Interfaces.Commands;
using RatCow.SimplePlugin.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslatorPoweredPlugin.Translators.Commands
{
    public class CommandTranslator: BaseTranslator
    {
        public virtual BaseEventArgs Run(BaseCommand command)
        {
            return null;
        }
    }
}
