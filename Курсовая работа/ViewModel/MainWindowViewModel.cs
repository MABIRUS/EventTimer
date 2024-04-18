using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсовая_работа.Model;

namespace Курсовая_работа.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<EventViewModel> _eventList;
        public IEnumerable<EventViewModel> EventList => _eventList;

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
            _eventList = new ObservableCollection<EventViewModel>();
            Time = new TimeModel();
            StartTimer();

            _eventList.Add(new EventViewModel(new EventModel("Событие 1", "14:32:17", "14:42:17")));
            _eventList.Add(new EventViewModel(new EventModel("Событие 2", "14:12:11", "15:22:37")));
            _eventList.Add(new EventViewModel(new EventModel("Событие 3", "13:04:24", "14:37:55")));
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

        public void RemoveAt(int index)
        {
            _eventList.RemoveAt(index);
        }
    }
}
