namespace PingPong
{
    public class AutoResetEventSync
    {
        public static AutoResetEvent waitHandler = new AutoResetEvent(true);

        static void Ping()
        {

            while (true)
            {
                waitHandler.WaitOne();
                Console.WriteLine(" Ping");
                Thread.Sleep(500);
                waitHandler.Set();
            }
        }

        static void Pong()
        {

            while (true)
            {
                waitHandler.WaitOne();
                Console.WriteLine("Pong");
                Thread.Sleep(500);
                waitHandler.Set();
            }
        }

        public static void PingPong()
        {
            Task.Run(Ping).Wait(1);
            Task.Run(Pong);
        }
    }
}