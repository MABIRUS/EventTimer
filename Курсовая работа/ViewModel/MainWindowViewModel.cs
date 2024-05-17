using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Курсовая_работа.Commands;
using Курсовая_работа.Model;

namespace Курсовая_работа.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<EventViewModel> _eventList;
        public ICollectionView EventListView { get; }

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
            EventListView = CollectionViewSource.GetDefaultView(_eventList);
            EventListView.Filter = FilterRunningEvents;

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

            foreach (var eventViewModel in _eventList)
            {
                if (DateTime.TryParse(eventViewModel.StartTime, out DateTime startTime) &&
                    DateTime.TryParse(eventViewModel.StopTime, out DateTime stopTime))
                {
                    if (Time.CurrentTime >= startTime && Time.CurrentTime < stopTime)
                    {
                        eventViewModel.IsRunning = true;
                    }
                    else
                    {
                        eventViewModel.IsRunning = false;
                    }

                    OnPropertyChanged(nameof(eventViewModel.BackgroundColor));
                }
            }

            EventListView.Refresh();
        }


        private bool FilterRunningEvents(object obj)
        {
            if (obj is EventViewModel eventViewModel)
            {
                return eventViewModel.IsRunning;
            }
            return false;
        }

    }
}
