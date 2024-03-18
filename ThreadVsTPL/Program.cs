namespace ThreadVsTPL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Start Main Application thread {Thread.CurrentThread.ManagedThreadId}");

            Task t1 = new Task(() => { HeavyTask(); });
            t1.Start();

            Task t2 = Task.Run(() => { HeavyTask(); });

            Task t3 = Task.Factory.StartNew(() => { HeavyTask(); });

            Console.WriteLine($"End Main Application thread {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadKey();

        }
        static void HeavyTask()
        {
            Console.WriteLine($"Start Child thread {Thread.CurrentThread.ManagedThreadId}");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Count is {i}");
            }
            Console.WriteLine($"End Child thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
