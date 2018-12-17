using System;

namespace Topix.Core.Base
{
    public class Event
    {
        public Event()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
    }
}