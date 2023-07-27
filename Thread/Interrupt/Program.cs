using System;
using System.Threading;
using System.Threading.Tasks;

namespace Interrupt
{
    class Program
    {
        static void Func1()
        {
            Console.WriteLine("Func1 스레드 {0}", Thread.CurrentThread.GetHashCode());
            Thread th = new Thread(new ThreadStart(Func2));
            th.Start();
            for(int i =0; i < 10; i++)
            {
                Console.WriteLine("{0} ", i * 10);
                Thread.Sleep(200);

                if(i == 3)
                {
                    Console.WriteLine("func1 종료");
                    Thread.CurrentThread.Interrupt();
                }
            }
        }

        static void Func2()
        {
            Console.WriteLine("Func2 스레드 {0}", Thread.CurrentThread.GetHashCode());
            for(int i = 0; i < 10; i++)
            {
                Console.Write("{0} ", i);
                Thread.Sleep(200);
            }
            Console.WriteLine("func2 종료");
        }

        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(Func1));

            th.Start();

            Console.WriteLine("메인 스레드 {0}", Thread.CurrentThread.GetHashCode());
            Console.WriteLine("메인 종료");
        }
    }
}