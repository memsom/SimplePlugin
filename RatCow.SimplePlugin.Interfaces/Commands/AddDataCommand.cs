using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatCow.SimplePlugin.Interfaces.Commands
{
    public class AddDataCommand: BaseCommand
    {
        public string Data { get; set; }
    }
}
