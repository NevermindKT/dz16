using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class TimeSim
    {
        public int TotalMinutes { get; private set; } = 0;

        public void Tick() => TotalMinutes++;

        public string GetFormattedTime()
        {
            int days = TotalMinutes / (24 * 60);
            int hours = (TotalMinutes / 60) % 24;
            int minutes = TotalMinutes % 60;

            return $"Day: {days + 1} hour: {hours} minutes: {minutes}";
        }

        public int CurrentMinutes => TotalMinutes;
    }
}