using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatCow.SimplePlugin.Interfaces
{
    public interface IPlugIn: IDisposable
    {
        //simple test to see if we can get this to work
        int GetId();
    }
}
