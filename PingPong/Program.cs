namespace PingPong
{

    class Program
    {
        public static void Main()
        {
            //LockSync.PingPong();
            //MutexSync.PingPong();
            //AutoResetEventSync.PingPong();
            //Unblocking.PingPong();
            Counter counter = new Counter();
            ThreadedCounting.CountInThreads(counter);

            Console.ReadLine();
        }
    }
}