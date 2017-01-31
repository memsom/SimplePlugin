using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherPlugin
{
    public class Base : IDisposable
    {
        private bool disposed;

        protected virtual void DisposeManaged()
        {

        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DisposeManaged();
                }
            }

            disposed = true;
        }

        #endregion
    }
}
