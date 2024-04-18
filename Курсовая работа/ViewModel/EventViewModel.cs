using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсовая_работа.Model;

namespace Курсовая_работа.ViewModel
{
    internal class EventViewModel
    {
        private EventModel _eventModel;

        public string EventName => _eventModel.EventName;
        public string StartTime => _eventModel.StartTime;
        public string StopTime => _eventModel.StopTime;

        public EventViewModel(EventModel eventModel)
        {
            _eventModel = eventModel;
        }
    }
}
