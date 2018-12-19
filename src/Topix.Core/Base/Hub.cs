using System;
using System.Collections.Generic;
using Topix.Core.Contracts;

namespace Topix.Core.Base
{
    public class Hub : IHub
    {
        private readonly Dictionary<Type, List<ISubscription>> _subscriptionMap = new Dictionary<Type, List<ISubscription>>();

        public void Publish<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            var eventType = typeof(TEvent);
            if (_subscriptionMap.TryGetValue(eventType, out List<ISubscription> subscriptions))
            {
                foreach (var subscription in subscriptions)
                {
                    try
                    {
                        var action = (Action<TEvent>)subscription.Delegate;

                        action(@event);
                    }
                    catch (Exception exc)
                    {
                        //TODO: do not swallow !!!!
                        continue;
                    }
                }
            }
        }

        public ISubscription Subscribe<TEvent>(Action<TEvent> subscribedAction)
            where TEvent : IEvent
        {
            if (subscribedAction == null)
            {
                throw new ArgumentNullException(nameof(subscribedAction));
            }

            var eventType = typeof(TEvent);
            var subscription = new Subscription(subscribedAction);
            if (!_subscriptionMap.TryGetValue(eventType, out var subscriptions))
            {
                subscriptions = new List<ISubscription>();
                _subscriptionMap.Add(eventType, subscriptions);
            }

            subscriptions.Add(subscription);

            return subscription;
        }
    }
}
