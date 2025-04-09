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
        public int TotalWorkTime { get; private set; } = 0;
        public Thread? WorckThread { get; set; }
        public readonly object Lock = new();
        public Queue<Patient> Queue { get; set; } = new();

        public Doctor(string name)
        {
            Name = name;
        }

        public void Work()
        {
            while (true)
            {
                Patient? patient = null;
                lock(Lock)
                {
                    if(Queue.Count > 0)
                    {
                        patient = Queue.Dequeue();
                        IsBusy = true;
                    }
                }

                if(patient != null)
                {
                    Console.WriteLine($"{Name} start heal(idk) {patient.Name}. ");
                    Thread.Sleep(5000);
                    TotalWorkTime += 5;
                    Console.WriteLine($"{Name} ended heal {patient.Name}. ");

                    lock(Lock)
                    {
                        IsBusy = false;
                    }
                }

                Thread.Sleep(100);
            }
        }
    }
}