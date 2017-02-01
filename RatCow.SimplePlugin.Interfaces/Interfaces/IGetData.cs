using RatCow.SimplePlugin.Interfaces.Events;
using RatCow.SimplePlugin.Interfaces.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatCow.SimplePlugin.Interfaces
{
    public interface IGetData
    {
        ItemId Retrieve(ItemId id);

        string RetrieveData(ItemId id);

        event EventHandler<GetDataEventArgs> DataRetrieved;

        void CallDataRetrieved(GetDataEventArgs e);
    }
}
