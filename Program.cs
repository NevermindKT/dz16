
namespace Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hospital = new Hospital();

            var mainThread = new Thread(() =>
            {
                while (!Console.KeyAvailable)
                {
                    hospital.tick();
                    Thread.Sleep(1);
                }
            });

            mainThread.IsBackground = true;
            mainThread.Start();

            Console.ReadKey();
            Console.WriteLine("END.");
        }
    }
}