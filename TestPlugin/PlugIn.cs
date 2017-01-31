using RatCow.SimplePlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace TestPlugin
{
    public class PlugIn : IPlugIn, IBootstrap
    {
        bool disposed = false;

        public int GetId()
        {
            return 1024;
        }

        public void Initialise(IWindsorContainer container)
        {
            container.Register(Component.For <IPlugIn>().ImplementedBy<PlugIn>().LifeStyle.Transient);
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DisposeManaged();
                }
            }

            disposed = true;
        }

        void DisposeManaged()
        {
            
        }

        #endregion
    }
}
