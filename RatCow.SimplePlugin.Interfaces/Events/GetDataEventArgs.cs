using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatCow.SimplePlugin.Interfaces.Events
{
    public class GetDataEventArgs: BaseEventArgs
    {
        public string Data { get; set; }
    }
}
