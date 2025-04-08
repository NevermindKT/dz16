using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class PatientQueue
    {
        private ConcurrentQueue<Patient> queue = new ConcurrentQueue<Patient>();

        public void Enqueue(Patient patient) => queue.Enqueue(patient);
        public Patient? Dequeue()
        {
            queue.TryDequeue(out Patient? patient);
            return patient;
        }
        public int Count => queue.Count;
        public Patient? peek()
        {
            queue.TryPeek(out Patient? patient);
            return patient;
        }
    }
}