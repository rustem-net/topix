using System;
using Topix.Core.Contracts;

namespace Topix.Core.Base
{
    public class Subscription : ISubscription
    {
        public Subscription(Delegate @delegate)
        {
            Delegate = @delegate;
        }
        public Delegate Delegate { get; }

        #region Resharper Disposable Pattern

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~Subscription()
        {
            ReleaseUnmanagedResources();
        }

        #endregion
    }
}