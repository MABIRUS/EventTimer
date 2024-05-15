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
            Parse();

        }

        private void Parse()
        {
            using (StreamReader reader = new StreamReader(_fileName))
            {
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    string[] parts = str.Split(", ");
                    if (parts.Length != 2)
                    {
                        continue; // Пропускаем некорректные строки
                    }

                    string eventName = parts[0];
                    string durationStr = parts[1];

                    // Парсинг длительности события
                    if (TimeSpan.TryParse(durationStr, out TimeSpan duration))
                    {
                        DateTime startTime = _mainWindowViewModel.Time.CurrentTime;
                        DateTime stopTime = startTime.Add(duration);

                        EventModel eventModel = new EventModel
                        {
                            EventName = eventName,
                            StartTime = startTime.ToString("HH:mm:ss"),
                            StopTime = stopTime.ToString("HH:mm:ss")

                        };

                        _mainWindowViewModel._eventList.Add(new EventViewModel(eventModel));
                    }
                }
            }
        }

    }
}
