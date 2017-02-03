using RatCow.SimplePlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RatCow.SimplePlugin.Interfaces.Commands;
using RatCow.SimplePlugin.Interfaces.Events;
using TranslatorPoweredPlugin.Support;

namespace TranslatorPoweredPlugin.Translators.Commands
{
    public class GetDataCommandTranslator: CommandTranslator
    {
        readonly IGetData getData;

        public GetDataCommandTranslator(IGetData getData)
        {
            this.getData = getData;
        }

        public override BaseEventArgs Run(BaseCommand command)
        {
            var getDataCommand = (command as GetDataCommand);
            var result = getData.RetrieveData(getDataCommand.DataId);
            return new GetDataEventArgs { Id = getDataCommand.Id, Data = result, Success = true };
        }
    }
}
