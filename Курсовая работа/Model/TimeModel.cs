using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа.Model
{
    internal class TimeModel
    {
        private DateTime _currentTime;

        public DateTime CurrentTime => _currentTime;

        public override string ToString()
        {
            return _currentTime.ToString("HH:mm:ss");
        }

        public TimeModel()
        {
            UpdateTime();
        }

        public void UpdateTime()
        {
            _currentTime = DateTime.Now;
        }
    }
}
