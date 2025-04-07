using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Doctor
    {
        public string Name { get; set; }
        public bool IsBusy { get; set; }
        public int BusyUntil { get; set; } = 0;

        public Doctor(string name)
        {
            Name = name;
        }
    }
}