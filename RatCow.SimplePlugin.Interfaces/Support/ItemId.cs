using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatCow.SimplePlugin.Interfaces.Support
{
    public class ItemId
    {
        public ItemId() 
            : this(Guid.NewGuid())
        {

        }

        public ItemId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
