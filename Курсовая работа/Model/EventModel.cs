using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа.Model
{
    internal class EventModel
    {
        public string EventName { get; }
        public string StartTime { get; }
        public string StopTime { get; }

        public EventModel(string eventName, string startTime, string stopTime)
        {
            EventName = eventName;
            StartTime = startTime;
            StopTime = stopTime;
        }

    }
}
