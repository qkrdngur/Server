using System;
using System.Threading;
using System.Threading.Tasks;

namespace Thread01
{
    class Program
    {
        static void Run()
        {
            Console.WriteLine("스레드에서 호출");
        }

        static void Parameterized_Run2(object obj)
        {
            for(int i = 0; i < (int)obj; i++)
            {
                Console.WriteLine("Parameterized 스레드에서 호출 : {0}", i);
            }
        }

        static void Main(string[] args)
        {
            //Thread th = new Thread(new ThreadStart(Run));

            //th.Start();

            int i = 5;
            Thread th2 = new Thread(new ParameterizedThreadStart(Parameterized_Run2));
            th2.Start(i);
        }
    }
}