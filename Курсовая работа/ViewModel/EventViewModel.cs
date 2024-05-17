using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсовая_работа.Model;

namespace Курсовая_работа.ViewModel
{
    internal class EventViewModel : BaseViewModel
    {
        private EventModel _eventModel;

        public string EventName => _eventModel.EventName;
        public string StartTime => _eventModel.StartTime;
        public string StopTime => _eventModel.StopTime;

        public bool IsRunning
        {
            get => _eventModel.IsRunning;
            set
            {
                if (_eventModel.IsRunning != value)
                {
                    _eventModel.IsRunning = value;
                    OnPropertyChanged(nameof(IsRunning));
                }
            }
        }

        public string BackgroundColor
        {
            get
            {
                if (DateTime.TryParse(StopTime, out DateTime stopTime))
                {
                    TimeSpan remainingTime = stopTime - DateTime.Now;

                    if (remainingTime <= TimeSpan.FromSeconds(10))
                    {
                        return "Red";
                    }
                    else if (remainingTime <= TimeSpan.FromSeconds(30))
                    {
                        return "Yellow";
                    }
                    else if (remainingTime <= TimeSpan.FromMinutes(1))
                    {
                        return "Green";
                    }
                }
                return "Transparent";
            }
        }

        public EventViewModel(EventModel eventModel)
        {
            _eventModel = eventModel;
        }
    }

}
