namespace PingPong
{

    class Program
    {
        public static void Main()
        {
            LockSync.PingPong();
            MonitorSync.PingPong();
            MutexSync.PingPong();
            AutoResetEventSync.PingPong();

            Console.ReadLine();
        }
    }
}