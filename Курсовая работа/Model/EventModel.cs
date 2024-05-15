using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа.Model
{
    internal class EventModel
    {
        public string EventName { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }
        public bool IsRunning { get; set; }

        public EventModel(string eventName, string startTime, string stopTime, bool isRunning = true)
        {
            EventName = eventName;
            StartTime = startTime;
            StopTime = stopTime;
            IsRunning = isRunning;
        }

        public EventModel()
        {
            EventName = string.Empty;
            StartTime = string.Empty;
            StopTime = string.Empty;
            IsRunning = true;
        }
    }
}
