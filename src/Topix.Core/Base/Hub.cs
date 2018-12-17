using System;
using System.Collections.Generic;

namespace Topix.Core.Base
{
    public class Hub
    {
        private readonly Dictionary<Type, List<Subscription>> _subscriptionMap = new Dictionary<Type, List<Subscription>>();

        public void Publish<TEvent>(TEvent @event)
            where TEvent : Event
        {
            var eventType = typeof(TEvent);
            if (_subscriptionMap.TryGetValue(eventType, out List<Subscription> subscriptions))
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

        public Subscription Subscribe<TEvent>(Action<TEvent> subscribedAction)
            where TEvent : Event
        {
            if (subscribedAction == null)
            {
                throw new ArgumentNullException(nameof(subscribedAction));
            }

            var eventType = typeof(TEvent);
            var subscription = new Subscription(subscribedAction);
            if (!_subscriptionMap.TryGetValue(eventType, out var subscriptions))
            {
                subscriptions = new List<Subscription>();
                _subscriptionMap.Add(eventType, subscriptions);
            }

            subscriptions.Add(subscription);

            return subscription;
        }
    }
}
