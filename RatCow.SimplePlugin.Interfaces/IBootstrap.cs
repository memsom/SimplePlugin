using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatCow.SimplePlugin.Interfaces
{
    public interface IBootstrap : IDisposable
    {
        void Initialise(IWindsorContainer container);
    }
}
