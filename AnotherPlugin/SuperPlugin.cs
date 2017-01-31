using RatCow.SimplePlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherPlugin
{
    public class SuperPlugin : Base, IPlugIn
    {
        public int GetId()
        {
            return 90210;
        }
    }
}
