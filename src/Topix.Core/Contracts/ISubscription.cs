using System;

namespace Topix.Core.Contracts
{
    public interface ISubscription : IDisposable
    {
        Delegate Delegate { get; }
    }
}