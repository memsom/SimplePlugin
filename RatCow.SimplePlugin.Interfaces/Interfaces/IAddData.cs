using RatCow.SimplePlugin.Interfaces.Events;
using RatCow.SimplePlugin.Interfaces.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatCow.SimplePlugin.Interfaces
{
    public interface IAddData: IDisposable
    {
        ItemId Add(string data);

        event EventHandler<AddDataEventArgs> DataAdded;
    }
}
