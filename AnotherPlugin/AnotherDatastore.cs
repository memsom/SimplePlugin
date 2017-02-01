using RatCow.SimplePlugin.Interfaces;
using RatCow.SimplePlugin.Interfaces.Events;
using RatCow.SimplePlugin.Interfaces.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherPlugin
{
    public class AnotherDataStore : Base, IDataStore
    {
        readonly IAddData addData;
        readonly IGetData getData;

        public AnotherDataStore(IAddData addData, IGetData getData)
        {
            this.addData = addData;
            this.addData.DataAdded += (s, e) => DataAdded?.Invoke(s, e);
            this.getData = getData;
            this.getData.DataRetrieved += (s, e) => DataRetrieved?.Invoke(s, e);
        }

        public event EventHandler<AddDataEventArgs> DataAdded = delegate { };
        public event EventHandler<GetDataEventArgs> DataRetrieved = delegate { };

        public ItemId Add(string data)
        {
            return addData.Add(data);
        }

        public void CallDataAdded(AddDataEventArgs e)
        {
            DataAdded?.Invoke(this, e);
        }

        public void CallDataRetrieved(GetDataEventArgs e)
        {
            DataRetrieved?.Invoke(this, e);
        }

        public ItemId Retrieve(ItemId id)
        {
            return getData.Retrieve(id);
        }

        public string RetrieveData(ItemId id)
        {
            throw new NotImplementedException();
        }
    }
}
