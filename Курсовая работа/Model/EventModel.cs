using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа.Model
{
    internal class EventModel
    {
        private string _eventName { get; }
        private string _startTime { get; }
        private string _stopTime { get; }

        public EventModel(string eventName, DateTime startTime, DateTime stopTime)
        {
            _eventName = eventName;
            _startTime = startTime.ToString("HH:mm:ss");
            _stopTime = stopTime.ToString("HH:mm:ss");
        }

    }
}
