using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Курсовая_работа.Model;
using Курсовая_работа.ViewModel;

namespace Курсовая_работа.Commands
{
    internal class TrackingCommand : CommandBase
    {
        private MainWindowViewModel _mainWindowViewModel;
        private string _fileName;
        private List<EventModel> _eventTypes = new List<EventModel>();

        public TrackingCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string initialDirectory = Directory.GetCurrentDirectory();
            for (int i = 0; i < 3; i++)
            {
                initialDirectory = Directory.GetParent(initialDirectory)?.FullName ?? initialDirectory;
            }

            openFileDialog.InitialDirectory = initialDirectory;
            openFileDialog.ShowDialog();
            _fileName = openFileDialog.FileName;
            LoadEventTypes();
            GenerateRandomEvents();
        }

        private void LoadEventTypes()
        {
            using (StreamReader reader = new StreamReader(_fileName))
            {
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    string[] parts = str.Split(", ");
                    if (parts.Length != 2)
                    {
                        continue;
                    }

                    string eventName = parts[0];
                    string durationStr = parts[1];

                    if (TimeSpan.TryParse(durationStr, out TimeSpan duration))
                    {
                        _eventTypes.Add(new EventModel { EventName = eventName, Duration = duration });
                    }
                }
            }
        }

        private void GenerateRandomEvents()
        {
            Random random = new Random();
            DateTime currentTime = _mainWindowViewModel.Time.CurrentTime;
            int eventCount = 20;
            int minIntervalSeconds = 2;
            int maxIntervalSeconds = 5;

            for (int i = 0; i < eventCount; i++)
            {
                int eventTypeIndex = random.Next(0, _eventTypes.Count);
                EventModel selectedEvent = _eventTypes[eventTypeIndex];

                if (i > 0)
                {
                    int interval = random.Next(minIntervalSeconds, maxIntervalSeconds + 1);
                    currentTime = currentTime.AddSeconds(interval);
                }

                DateTime startTime = currentTime;
                DateTime stopTime = startTime.Add(selectedEvent.Duration);

                EventModel eventModel = new EventModel
                {
                    EventName = selectedEvent.EventName,
                    StartTime = startTime.ToString("HH:mm:ss"),
                    StopTime = stopTime.ToString("HH:mm:ss")
                };

                _mainWindowViewModel._eventList.Add(new EventViewModel(eventModel));
            }
        }
    }
}
