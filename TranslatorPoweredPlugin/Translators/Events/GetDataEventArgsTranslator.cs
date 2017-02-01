using RatCow.SimplePlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RatCow.SimplePlugin.Interfaces.Events;

namespace TranslatorPoweredPlugin.Translators.Events
{
    public class GetDataEventArgsTranslator: EventTranslator
    {
        readonly IGetData getData;

        public GetDataEventArgsTranslator(IGetData getData)
        {
            this.getData = getData;
        }

        public override void Run(BaseEventArgs e)
        {
            var getDataEvent = e as GetDataEventArgs;
            getData.CallDataRetrieved(getDataEvent);
        }
    }
}
