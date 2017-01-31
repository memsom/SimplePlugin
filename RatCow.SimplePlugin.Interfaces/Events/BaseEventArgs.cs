using RatCow.SimplePlugin.Interfaces.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatCow.SimplePlugin.Interfaces.Events
{
    public class BaseEventArgs: EventArgs
    {
        public ItemId Id { get; set; }
        public bool Success { get; set; }
    }
}
