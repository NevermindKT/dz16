using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Patient
    {
        public string Name { get; set; }
        public Patient(string name)
        {
            Name = name;
        }
    }
}