using RatCow.SimplePlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RatCow.SimplePlugin.Interfaces.Events;
using RatCow.SimplePlugin.Interfaces.Support;

namespace AnotherPlugin
{
    public class GetData : Base, IGetData
    {
        readonly IDataProcessor processor;

        public GetData(IDataProcessor processor)
        {
            this.processor = processor;
        }

        public event EventHandler<GetDataEventArgs> DataRetrieved;

        public ItemId Retrieve(ItemId id)
        {
            var result = new ItemId();
            var data = processor.Retrieve(id);
            DataRetrieved?.Invoke(this, new GetDataEventArgs { Data = data, Id = result, Success = true });
            return result;
        }
    }
}
