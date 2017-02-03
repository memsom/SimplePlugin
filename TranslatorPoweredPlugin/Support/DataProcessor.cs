using RatCow.SimplePlugin.Interfaces.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslatorPoweredPlugin.Support
{
    public class DataProcessor : Base, IDataProcessor
    {
        Dictionary<ItemId, string> Data = new Dictionary<ItemId, string>();

        public DataProcessor()
        {

        }

        public ItemId Add(string data)
        {
            var dataId = new ItemId();

            Data.Add(dataId, data);

            return dataId;
        }

        public string Retrieve(ItemId dataId)
        {
            if (Data.ContainsKey(dataId))
            {
                return Data[dataId];
            }
            return string.Empty;
        }
    }
}
