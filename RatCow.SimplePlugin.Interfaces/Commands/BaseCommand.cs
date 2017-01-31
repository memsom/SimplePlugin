using RatCow.SimplePlugin.Interfaces.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatCow.SimplePlugin.Interfaces.Commands
{
    public class BaseCommand: DisposableObject
    {
        public BaseCommand()
        {
            Id = new ItemId();
        }

        public ItemId Id { get; private set; }

        protected override void DisposeManaged()
        {
            Id = null;
        }
    }
}
