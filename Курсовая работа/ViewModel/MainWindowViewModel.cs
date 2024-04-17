using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсовая_работа.Model;

namespace Курсовая_работа.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public List<EventModel> EventList;

        private TimeModel _time;

        public TimeModel Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        public MainWindowViewModel()
        {
            EventList = new List<EventModel>;
            Time = new TimeModel();
            StartTimer();
        }

        private void StartTimer()
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += (sender, args) => UpdateTime();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void UpdateTime()
        {
            Time.UpdateTime();
            OnPropertyChanged(nameof(Time));
        }
    }
}
