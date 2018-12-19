using System;
using Topix.Core.Base;

namespace Topix.Core.Contracts
{
    public interface IHub
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;

        ISubscription Subscribe<TEvent>(Action<TEvent> subscribedAction) where TEvent : IEvent;
    }
}