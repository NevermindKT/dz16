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

        public void process(int currTime, string formatted)
        {
            while(Queue.Count > 0)
            {
                Doctor? avaliableDoc = null;
                foreach(var doc in Doctors)
                {
                    lock(doc.Lock)
                    {
                        if(!doc.IsBusy)
                        {
                            avaliableDoc = doc;
                            break;
                        }
                    }
                }

                if (avaliableDoc == null)
                    break;

                var nextPatient = Queue.Dequeue();
                if (nextPatient == null)
                    break;

                if(random.NextDouble() < 0.1)
                {
                    Console.WriteLine($"{nextPatient.Name} leve the queue to room {RoomId}. ");
                    continue;
                }

                lock(avaliableDoc.Lock)
                {
                    avaliableDoc.Queue.Enqueue(nextPatient);
                    Console.WriteLine($"{nextPatient.Name} is arrived to {avaliableDoc.Name}. ");
                }
            }
        }
    }
}