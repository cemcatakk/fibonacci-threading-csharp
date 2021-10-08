using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMPE312_Thread
{
    
    class Program
    {
        class Container
        {
            public static List<int> fibseries = new List<int>();
        }
        public static void CreateFibSeries()
        {
            int i;
            Container.fibseries.Add(0);
            Container.fibseries.Add(1);
            for (i = 2; i < 10; ++i)
            {
                Container.fibseries.Insert(i, Container.fibseries[i - 1] + Container.fibseries[i - 2]);
            }
        }
        public static void thread1()
        {
            //Call the method to create fib series
            CreateFibSeries();
            //Then use foreach loop to print each fib value
            foreach (int fib in Container.fibseries)
            {
                Console.WriteLine("Thread 1: " + fib);
                //Wait for 0.5s
                Thread.Sleep(500);
            }
        }
        public static void thread2()
        {
            //Reverse fibseries list
            Container.fibseries.Reverse();
            foreach (int fib in Container.fibseries)
            {
                //Print each value and wait for 0.5s
                Console.WriteLine("Thread 2: " + fib);
                Thread.Sleep(500);
            }
        }
        static void Main(string[] args)
        {
            //Create threads and start t1 first, t2 after 10 secs.
            Thread t1 = new Thread(thread1);
            Thread t2 = new Thread(thread2);
            t1.Start();
            Thread.Sleep(10000);
            t2.Start();
            Console.ReadKey();
        }
    }
}
