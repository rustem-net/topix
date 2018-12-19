using System;
using Topix.Core.Contracts;

namespace Topix.Core.Base
{
    public class Event : IEvent
    {
        public Event()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
    }
}