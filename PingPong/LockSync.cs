namespace PingPong
{
    public class LockSync
    {
        public static object locker = new();

        static void Ping()
        {
            while (true)
                lock (locker)
                {
                    {
                        Console.WriteLine(" Ping");
                        Thread.Sleep(500);
                    }
                }
        }

        static void Pong()
        {
            while (true)
                lock (locker)
                {
                    {
                        Console.WriteLine("Pong");
                        Thread.Sleep(500);
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