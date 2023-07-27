using System;
using System.Threading;
using System.Threading.Tasks;

namespace Thread02
{
    class Program
    {
        static void Func1()
        {
            Console.WriteLine("스레드1 호출");
        }

        static void Func2()
        {
            
            Console.WriteLine("스레드2 호출");
            
        }

        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(Func1));
            Thread th2 = new Thread(new ThreadStart(Func2));

            th1.Start();
            th2.Start();

            Console.WriteLine("메인 종료");
            Console.ReadLine();
        }
    }
}