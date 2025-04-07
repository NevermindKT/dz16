using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class PatientQueue
    {
        private Queue<Patient> queue = new Queue<Patient>();

        public void Enqueue(Patient patient) => queue.Enqueue(patient);
        public Patient? Dequeue() => queue.Count > 0 ? queue.Dequeue() : null;
        public int Count => queue.Count;
        public Patient? peek() => queue.Count > 0 ? queue.Peek() : null;
    }
}
