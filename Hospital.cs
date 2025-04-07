using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Hospital
    {
        public List<Room> Rooms { get; set; } = new();
        private int PatientIdCounter = 1;
        private Random Random = new();
        private int CurrMinute = 0;
        private int NextPatient = 1;

        public void tick()
        {
            CurrMinute++;

            if(CurrMinute >= NextPatient)
            {
                var patient = new Patient($"patient:{PatientIdCounter}");
            }
        }

        private void assignPatientToRoom(Patient patient)
        {
            var targetRoom = Rooms.OrderBy(r => r.Queue.Count).FirstOrDefault();
            if(targetRoom != null && targetRoom.Queue.Count < 25)
            {
                targetRoom.Queue.Enqueue(patient);
                Console.WriteLine($"patient {patient.Name} arrived in cabinet {targetRoom.RoomId} in {CurrMinute} minute-s");
            }
            else
            {
                Console.WriteLine($"Patient {patient.Name} cannot acces in queue all queue is full.");
            }
        }
    }
}