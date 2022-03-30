namespace PingPong
{
    public class Unblocking
    {
        public static object locker = new();
        public static bool flag = true;
        public static int i = 0;

        static void Ping()
        {
            while (i < 20)
            {
                if (flag)
                {
                    Console.WriteLine(" Ping");
                    flag = false;
                    i++;
                }
            }
        }

        static void Pong()
        {
            while (i < 20)
            {
                if (!flag)
                {
                    Console.WriteLine("Pong");
                    flag = true;
                    i++;
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