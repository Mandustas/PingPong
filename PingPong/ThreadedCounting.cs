using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    public class Counter
    {
        public List<int> IntList { get; set; }

        public Counter(List<int> intList)
        {
            IntList = intList;
        }

        public Counter()
        {
            IntList = new List<int>();
        }

        internal void Count(int i)
        {
            IntList.Add(i);
            Console.WriteLine(i);

        }

        public void PrintList()
        {
            for (int i = 0; i < IntList.Count; i++)
            {
                Console.WriteLine(IntList[i]);
            }
        }
    }

    public class ThreadedCounting
    {
        public static Mutex mutex = new();

        public static void CountInThreads(Counter counter)
        {
            AutoResetEvent myEvent1 = new AutoResetEvent(true);
            AutoResetEvent myEvent2 = new AutoResetEvent(true);
            AutoResetEvent myEvent3 = new AutoResetEvent(true);

            Thread myThread3 = new Thread(() =>
            {
                myEvent3.WaitOne();
                for (int i = 1; i <= 100; i++)
                {
                    if (i % 3 == 0)
                    {
                        myEvent3.WaitOne();
                        counter.Count(i);
                        myEvent1.Set();
                    }
                }
            });
            myThread3.Start();

            Thread myThread2 = new Thread(() =>
            {
                myEvent2.WaitOne();
                for (int i = 1; i <= 100; i++)
                {
                    if (i % 3 == 0)
                    {
                        myEvent2.WaitOne();
                        counter.Count(i - 1);
                        myEvent3.Set();
                    }
                }
            });
            myThread2.Start();

            Thread myThread1 = new Thread(() =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    if (i % 3 == 0)
                    {
                        myEvent1.WaitOne();
                        counter.Count(i - 2);
                        myEvent2.Set();
                    }
                }
            });
            myThread1.Start();

        }
    }
}
