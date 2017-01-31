using RatCow.SimplePlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RatCow.SimplePlugin.Interfaces.Events;
using RatCow.SimplePlugin.Interfaces.Support;

namespace AnotherPlugin
{
    public class AddData : Base, IAddData
    {
        readonly IDataProcessor processor;

        public AddData(IDataProcessor processor)
        {
            this.processor = processor;
        }

        public event EventHandler<AddDataEventArgs> DataAdded;

        public ItemId Add(string data)
        {
            var result = new ItemId();
            var id = processor.Add(data);
            DataAdded?.Invoke(this, new AddDataEventArgs { DataId = id, Id = result, Success = true });
            return result;
        }
    }
}
