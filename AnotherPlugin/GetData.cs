﻿using RatCow.SimplePlugin.Interfaces;
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

        public void CallDataRetrieved(GetDataEventArgs e)
        {
            DataRetrieved?.Invoke(this, e);
        }

        public ItemId Retrieve(ItemId id)
        {
            var result = new ItemId();
            var data = processor.Retrieve(id);
            CallDataRetrieved(new GetDataEventArgs { Data = data, Id = result, Success = true });
            return result;
        }

        string IGetData.RetrieveData(ItemId id)
        {
            return processor.Retrieve(id);
        }
    }
}
