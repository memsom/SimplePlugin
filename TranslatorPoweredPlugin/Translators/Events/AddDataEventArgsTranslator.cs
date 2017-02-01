using RatCow.SimplePlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RatCow.SimplePlugin.Interfaces.Events;

namespace TranslatorPoweredPlugin.Translators.Events
{
    public class AddDataEventArgsTranslator: EventTranslator
    {
        readonly IAddData addData;

        public AddDataEventArgsTranslator(IAddData addData)
        {
            this.addData = addData;
        }

        public override void Run(BaseEventArgs e)
        {
            var addDataEvent = e as AddDataEventArgs;
            addData.CallDataAdded(addDataEvent);
        }
    }
}
