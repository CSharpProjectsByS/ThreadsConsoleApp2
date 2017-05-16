using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsConsoleApp3.Services
{
    public class ThreadService
    {
        private int nGreater = 999999;
        private int nSmaller = 150000;

        private readonly object locker = new object();

        public ThreadService()
        {
            RunScenerios();
        }

        public void RunScenerios()
        {
            Console.Clear();

            Console.WriteLine("1. Więcej dla background, mniej dla foreground.");
            Console.WriteLine("2. Więcej dla foreground, mniej dla background");
            Console.Write("Wybierz opcje: ");
            int number = Int32.Parse(Console.ReadLine());

            Console.Clear();

            switch (number)
            {
                case 1:
                    Console.WriteLine("Scenariusz pierwszy.");
                    RunFirstScenerio();
                    break;

                case 2:
                    Console.WriteLine("Sceneriusz drugi.");
                    RunSecondScenerio();
                    break;

                default :
                    Console.WriteLine("Nie ma takiej opcji.");
                    break;
            }

            
        }

        private void RunFirstScenerio()
        {
            Thread threadF = new Thread(() => DoSomething(nSmaller, "threadF",1));
            Thread threadB = new Thread(() => DoSomething(nGreater, "threadB",2));

            threadB.IsBackground = true;

            threadF.Start();
            threadB.Start();

        }

        private void RunSecondScenerio()
        {
            Thread threadF = new Thread(() => DoSomething(nGreater, "threadF",1));
            Thread threadB = new Thread(() => DoSomething(nSmaller, "threadB",2));

            threadB.IsBackground = true;

            threadF.Start();
            threadB.Start();

        }

        private void DoSomething(int n, String name, int positon)
        {

            for (int i = 0; i <= n; i++)
            {
                lock (locker)
                {
                    Console.SetCursorPosition(0, positon);
                    Console.Write("");
                    Console.SetCursorPosition(0, positon);
                    Console.Write("{1} postęp {0}% ", ((float) i/n) * 100 , name);
                    isPrimeNumber(i);
                }
                
            }
            
            lock (locker)
            {
                Console.SetCursorPosition(0, positon + 2);
                Console.Write("");
                Console.SetCursorPosition(0, positon + 2);
                Console.Write("Wątek {0} zakończył zadanie", name);
            }

        }

        private bool isPrimeNumber(int number)
        {
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                } 
            }

            return true;
        }
    }

    
}
