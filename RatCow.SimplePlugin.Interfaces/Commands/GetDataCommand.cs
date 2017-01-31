using RatCow.SimplePlugin.Interfaces.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatCow.SimplePlugin.Interfaces.Commands
{
    public class GetDataCommand: BaseCommand
    {
        public ItemId DataId { get; set; }
    }
}
