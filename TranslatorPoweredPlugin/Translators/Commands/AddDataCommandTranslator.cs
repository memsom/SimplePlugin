using RatCow.SimplePlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TranslatorPoweredPlugin.Support;
using TranslatorPoweredPlugin.Translators.Events;
using RatCow.SimplePlugin.Interfaces.Commands;
using RatCow.SimplePlugin.Interfaces.Events;

namespace TranslatorPoweredPlugin.Translators.Commands
{
    public class AddDataCommandTranslator : CommandTranslator
    {
        readonly IAddData addData;

        public AddDataCommandTranslator(IAddData addData)
        {
            this.addData = addData;
        }

        public override BaseEventArgs Run(BaseCommand command)
        {
            var addDataCommand = (command as AddDataCommand);
            var result = addData.Add(addDataCommand.Data);
            return new AddDataEventArgs { Id = addDataCommand.Id, DataId = result, Success = true };
        }
    }
}
