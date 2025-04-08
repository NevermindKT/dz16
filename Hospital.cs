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

        Schedule schedule = new();

        private int roomAssignmentIndex = 0;

        public Hospital()
        {
            int roomCount = Random.Next(5, 31);
            for (int i = 0; i < roomCount; i++)
            {
                int doctorCount = Random.Next(1, 5);
                Rooms.Add(new Room(i + 1, doctorCount));
            }

            Console.WriteLine($"Created {Rooms.Count} rooms:");
            foreach (var room in Rooms)
            {
                Console.WriteLine($" - Room {room.RoomId} с {room.Doctors.Count} doctors:");
                foreach (var doc in room.Doctors)
                    Console.WriteLine($"   > {doc.Name}");
            }
        }

        public void tick()
        {
            CurrMinute++;

            if(!schedule.isWorking(CurrMinute))
            {
                Console.WriteLine($"{CurrMinute}: hospital closed.");
                return;
            }

            if(CurrMinute >= NextPatient && schedule.isArriving(CurrMinute))
            {
                var patient = new Patient($"patient: {PatientIdCounter++}");
                assignPatientToRoom(patient);
                NextPatient = CurrMinute + Random.Next(2, 10);
            }

            foreach(var room in Rooms)
            {
                room.process(CurrMinute);
            }
        }

        private void assignPatientToRoom(Patient patient)
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                var room = Rooms[roomAssignmentIndex];
                roomAssignmentIndex = (roomAssignmentIndex + 1) % Rooms.Count;

                if (room.Queue.Count < 25)
                {
                    room.Queue.Enqueue(patient);
                    Console.WriteLine($"{CurrMinute}: {patient.Name} arrived in room {room.RoomId}");
                    return;
                }
            }

            Console.WriteLine($"{CurrMinute}: {patient.Name} cannot asses in queue.");
        }
    }
}