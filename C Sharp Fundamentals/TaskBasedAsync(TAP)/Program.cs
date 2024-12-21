namespace TaskBasedAsync_TAP_
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*  synchronous sequential
            var cts = new CancellationTokenSource();
            ProcessBatch1(cts.Token);
            ProcessBatch2(cts.Token);*/

            /*Asynch */
            var cts = new CancellationTokenSource();
            Console.WriteLine("Main Thread ID " + Environment.CurrentManagedThreadId);
            var task1 = ProcessBatch1(cts.Token);
            var task2 = ProcessBatch2(cts.Token);
            //await task1;
            //await task2;
            await Task.WhenAny(task1, task2);

            Console.WriteLine("enter your name : ");
            var name = Console.ReadLine();
            Console.WriteLine("welcome , " + name);
            Console.ReadKey();

        }

        private static object _Lock = new();

        private static async Task ProcessBatch1(CancellationToken cancellationToken)
        {
            Console.WriteLine("Batch1 Thread ID " + Environment.CurrentManagedThreadId);
            await Task.Delay(10);
            Console.WriteLine("Batch1(S2) Thread ID " + Environment.CurrentManagedThreadId);
            for (int i = 0; i <= 100; i++)
            {
                if (cancellationToken.IsCancellationRequested)   // do the cancellation exists ?
                {
                    return;
                }
               
                lock (_Lock)  // to execute code in {} and dont out before excute
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(i);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        private static async Task ProcessBatch2(CancellationToken cancellationToken)
        {
            Console.WriteLine("Batch2 Thread ID " + Environment.CurrentManagedThreadId);
            await Task.Delay(10);
            Console.WriteLine("Batch2(S2) Thread ID " + Environment.CurrentManagedThreadId);
            for (int i = 101; i <= 200; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }
                
                lock (_Lock)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(i);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
