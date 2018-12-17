using System;
using Topix.Core.Base;

namespace Topix.Sandbox.Sample1
{
    public class Sample1Runner
    {
        private static Hub _hub;
        public static void Run()
        {
            Bootstrap();
            Execute();
        }

        public static void Bootstrap()
        {
            _hub = new Hub();

            _hub.Subscribe<Events.PrintEvent>(@event =>
            {
                Console.WriteLine($"{@event.Id} => {@event.Message}");
            });
        }

        public static void Execute()
        {
            _hub.Publish(new Events.PrintEvent("Hello "));
            _hub.Publish(new Events.PrintEvent("Pub "));
            _hub.Publish(new Events.PrintEvent("Sub "));
        }
    }
}
