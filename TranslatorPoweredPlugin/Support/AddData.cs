using RatCow.SimplePlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RatCow.SimplePlugin.Interfaces.Events;
using RatCow.SimplePlugin.Interfaces.Support;

namespace TranslatorPoweredPlugin.Support
{
    public class AddData : Base, IAddData
    {
        readonly IDataProcessor processor;
        readonly IDataStore store;

        public AddData(IDataProcessor processor, IDataStore store)
        {
            this.processor = processor;
            this.store = store;
            DataAdded += (s, e) =>
            {
                (this.store as IAddData).CallDataAdded(e);
            };
        }

        public event EventHandler<AddDataEventArgs> DataAdded;

        public ItemId Add(string data)
        {
            var result = new ItemId();
            var id = processor.Add(data);
            return result;
        }

        public void CallDataAdded(AddDataEventArgs e)
        {
            DataAdded?.Invoke(this, e);
        }
    }
}
