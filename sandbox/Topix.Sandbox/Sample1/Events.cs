using System;
using System.Collections.Generic;
using System.Text;
using Topix.Core.Base;

namespace Topix.Sandbox.Sample1
{
    public class Events
    {
        public class PrintEvent : Event
        {
            public PrintEvent(string message)
            {
                Message = message;
            }
            public string Message { get; set; }
        }
    }
}
