namespace ThreadTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 0;

            object obj = new object();

            Thread T1 = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    try
                    {
                        Monitor.Enter(obj);
                        num++;
                    }
                    finally
                    {
                        Monitor.Exit(obj);
                    }
                    //lock과 같음
                }
            });
            T1.Start();

            Thread T2 = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock(obj)
                    {
                        num++;
                    }
                }
            });
            T2.Start();

            T1.Join();
            T2.Join();
            Console.WriteLine(num);
        }
    }
}