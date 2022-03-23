namespace PingPong
{
    public class MutexSync
    {
        public static Mutex mutex = new();

        static void Ping()
        {

            while (true)
            {
                mutex.WaitOne();
                Console.WriteLine(" Ping");
                Thread.Sleep(500);
                mutex.ReleaseMutex();
            }
        }

        static void Pong()
        {

            while (true)
            {
                mutex.WaitOne();
                Console.WriteLine("Pong");
                Thread.Sleep(500);
                mutex.ReleaseMutex();
            }
        }

        public static void PingPong()
        {
            Task.Run(Ping).Wait(1);
            Task.Run(Pong);
        }
    }
}