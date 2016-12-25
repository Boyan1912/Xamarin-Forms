using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Xamarin.Forms
{
    public abstract class DisposableContentView : ContentView, IDisposable
    {
        private bool disposed;

        public DisposableContentView()
        {
            
        }

        public IDisposable UnManagedResource { get; set; }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (UnManagedResource != null)
                    {
                        UnManagedResource.Dispose();
                        UnManagedResource = null;
                    }
                }

                disposed = true;
            }
        }

        ~DisposableContentView()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class DisposableImage : Image, IDisposable
    {

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                }
                
                disposedValue = true;
            }
        }

        ~DisposableImage()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
