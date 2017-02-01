using RatCow.SimplePlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RatCow.SimplePlugin.Interfaces.Events;
using RatCow.SimplePlugin.Interfaces.Support;

namespace TranslatorPoweredPlugin.Support
{
    public class GetData : Base, IGetData
    {
        readonly IDataProcessor processor;
        readonly IDataStore store;

        public GetData(IDataProcessor processor, IDataStore store)
        {
            this.processor = processor;
            this.store = store;
            DataRetrieved += (s, e) =>
            {
                (this.store as IGetData).CallDataRetrieved(e);
            };
        }

        public event EventHandler<GetDataEventArgs> DataRetrieved;

        public void CallDataRetrieved(GetDataEventArgs e)
        {
            DataRetrieved?.Invoke(this, e);
        }

        public ItemId Retrieve(ItemId id)
        {
            var result = new ItemId();
            var data = processor.Retrieve(id);            
            return result;
        }

        string IGetData.RetrieveData(ItemId id)
        {
            return processor.Retrieve(id);
        }
    }
}
