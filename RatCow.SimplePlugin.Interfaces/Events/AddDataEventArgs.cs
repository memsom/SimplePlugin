﻿using RatCow.SimplePlugin.Interfaces.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatCow.SimplePlugin.Interfaces.Events
{
    public class AddDataEventArgs : BaseEventArgs
    {
        public ItemId DataId { get; set; }
    }
}
