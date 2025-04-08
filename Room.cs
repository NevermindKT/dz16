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

        private Random random = new();

        public Room(int id, int doctorCount)
        {
            RoomId = id;
            for (int i = 0; i < doctorCount; i++)
            {
                var doctor = new Doctor($"Doc {i + 1} in room: {id}");
                Doctors.Add(doctor);
                doctor.WorckThread = new Thread(doctor.Work) { IsBackground = true };
                doctor.WorckThread.Start();
            }
        }

        public void process(int currTime)
        {
            foreach(var doctor in Doctors)
            {
                lock(doctor.Lock)
                {
                    if (doctor.IsBusy || Queue.Count == 0) continue;

                    var nextPatient = Queue.Dequeue();
                    if (nextPatient != null)
                    {
                        if (random.NextDouble() < 0.1)
                        {
                            Console.WriteLine($"{currTime}: {nextPatient.Name} is leving queue in room {RoomId}.");
                            continue;
                        }

                        doctor.Queue.Enqueue(nextPatient);
                        Console.WriteLine($"{currTime}: {nextPatient.Name} arrived to {doctor.Name} in room {RoomId}");
                    }
                }
            }
        }
    }
}