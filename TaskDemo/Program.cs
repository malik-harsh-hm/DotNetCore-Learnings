namespace TaskDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Main Application thread {0}", Thread.CurrentThread.ManagedThreadId);
            Calculate();
            Console.WriteLine("End Main Application thread {0}", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
        static void Calculate()
        {
            var t1 = Task.Run(() => { return Calculate1(); });
            var a1 = t1.GetAwaiter();
            a1.OnCompleted(() =>
            {
                var r1 = a1.GetResult();
                var t2 = Task.Run(() => { return Calculate2(r1); });
                var a2 = t2.GetAwaiter();
                a2.OnCompleted(() =>
                {
                    var r2 = a2.GetResult();
                    var t3 = Task.Run(() => { return Calculate3(r2); });
                    var a3 = t3.GetAwaiter();
                    a3.OnCompleted(() =>
                    {
                        var r3 = a3.GetResult();
                        Console.WriteLine("Final Result = " + r3);
                    });
                });
            });

        }
        static string Calculate1()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Calculate 1 thread {0} ", Thread.CurrentThread.ManagedThreadId);
            return "One ";
        }

        static string Calculate2(string input)
        {
            Thread.Sleep(3000);
            Console.WriteLine("Calculate 2 thread {0} ", Thread.CurrentThread.ManagedThreadId);
            return input + "Two ";
        }

        static string Calculate3(string input)
        {
            Thread.Sleep(3000);
            Console.WriteLine("Calculate 3 thread {0} ", Thread.CurrentThread.ManagedThreadId);
            return input + "Three ";
        }


    }
}
