using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Курсовая_работа.Commands;
using Курсовая_работа.Model;

namespace Курсовая_работа.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<EventViewModel> _eventList;
        public IEnumerable<EventViewModel> EventList => _eventList;

        private TimeModel _time;

        public ICommand Tracking { get; }

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
            Tracking = new TrackingCommand(this);

            _eventList = new ObservableCollection<EventViewModel>();
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

        public void RemoveAt(int index)
        {
            _eventList.RemoveAt(index);
        }
    }
}
