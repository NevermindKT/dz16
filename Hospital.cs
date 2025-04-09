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

        private int NextPatient = 1;

        Schedule schedule = new();
        TimeSim time = new();

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
            time.Tick();

            int currMinute = time.CurrentMinutes;
            string formatedTime = time.GetFormattedTime();


            if(!schedule.isWorking(currMinute))
            {
                Console.WriteLine($"Hospital closed.");
                return;
            }

            if (currMinute >= NextPatient && schedule.isArriving(currMinute))
            {
                var patient = new Patient($"Patient: {PatientIdCounter++}");
                assignPatientToRoom(patient, formatedTime);
                NextPatient = currMinute + Random.Next(2, 11);
            }

            foreach(var room in Rooms)
            {
                room.process(currMinute, formatedTime);
            }
        }

        private void assignPatientToRoom(Patient patient, string formated)
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                var room = Rooms[roomAssignmentIndex];
                roomAssignmentIndex = (roomAssignmentIndex + 1) % Rooms.Count;

                if (room.Queue.Count < 25)
                {
                    room.Queue.Enqueue(patient);
                    Console.WriteLine($"{formated}: {patient.Name} arrived in queue to room {room.RoomId}. ");
                    return;
                }
            }

            Console.WriteLine($"{formated}: {patient.Name} cannot asses in queue. ");
        }
    }
}