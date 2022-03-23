namespace PingPong
{
    public class MonitorSync
    {
        public static object locker = new();

        static void Ping()
        {

            while (true)
            {
                bool isLock = false;
                try
                {

                    Monitor.Enter(locker, ref isLock);
                    Console.WriteLine(" Ping");
                    Thread.Sleep(500);
                }
                finally
                {
                    if (isLock) Monitor.Exit(locker);
                }
            }
        }

        static void Pong()
        {

            while (true)
            {
                bool isLock = false;
                try
                {
                    Monitor.Enter(locker, ref isLock);
                    Console.WriteLine("Pong");
                    Thread.Sleep(500);
                }
                finally
                {
                    if (isLock) Monitor.Exit(locker);
                }
            }
        }

        public static void PingPong()
        {
            Task.Run(Ping).Wait(1);
            Task.Run(Pong);
        }
    }
}