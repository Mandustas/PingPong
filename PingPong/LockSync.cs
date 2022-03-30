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
                    }
                }
        }

        public static void PingPong()
        {
            Task.Run(Ping);
            Task.Run(Pong);
        }
    }
}