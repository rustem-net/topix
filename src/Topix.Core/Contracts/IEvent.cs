using System;

namespace Topix.Core.Contracts
{
    public interface IEvent
    {
        Guid Id { get; }
    }
}