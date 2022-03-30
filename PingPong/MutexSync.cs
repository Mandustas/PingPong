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
                mutex.ReleaseMutex();
            }
        }

        static void Pong()
        {

            while (true)
            {
                mutex.WaitOne();
                Console.WriteLine("Pong");
                mutex.ReleaseMutex();
            }
        }

        public static void PingPong()
        {
            Task.Run(Ping);
            Task.Run(Pong);
        }
    }
}