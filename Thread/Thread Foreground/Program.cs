using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadForeground
{
    class Program
    {
        static void Func()
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine(i++);
                Thread.Sleep(300);
            }
        }

        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(Func));

            th.IsBackground = true;//메인이 끝나면 함께 종료
            th.Start();
            //th.Join();//쓰레드가 종료 될 때까지 기다린다.
            Console.WriteLine("메인 종료");
        }
    }
}