using System;
using System.Threading;
using System.Threading.Tasks;

namespace Thread03
{
    class Program
    {
        static void Func1()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("스레드1 호출 {0}", i);
            }
        }

        static void Func2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("스레드2 호출 {0}", i);
            }
        }

        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(Func1));
            Thread th2 = new Thread(new ThreadStart(Func2));

            th1.Start();
            th2.Start();

            Console.WriteLine("메인 종료");
        }
    }
}