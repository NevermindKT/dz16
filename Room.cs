using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Room
    {
        public int RoomId { get; set; }
        public List<Doctor> Doctors { get; set; } = new();
        public PatientQueue Queue { get; set; } = new();

        public Room(int id)
        {
            RoomId = id;
        }

        public void process(int currTime)
        {
            foreach(var doctor in Doctors)
            {
                if (!doctor.IsBusy || doctor.BusyUntil <= currTime)
                {
                    var nextPatient = Queue.Dequeue();
                    if(nextPatient != null)
                    {
                        doctor.IsBusy = true;
                        doctor.BusyUntil = currTime + 5;
                        Console.WriteLine($"Doc {doctor.Name}, took in patient {nextPatient.Name}, in {currTime}");
                    }
                    else 
                    {
                        doctor.IsBusy = true;
                    }
                }
            }
        }
    }
}