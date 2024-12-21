
using System.Runtime.CompilerServices;
using System.Threading;

namespace MultiThreading
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            
            

            //var Th1 = new Thread(ProcessBatch1);
            //Th1.Priority = ThreadPriority.Highest;
            //var Th2 = new Thread(ProcessBatch2);
            //Th2.Priority = ThreadPriority.Lowest;
            //
            //Th1.Start();      //thread 1 is processing with th2
            //Th2.Start();
            var cts = new CancellationTokenSource(); // oject of cancellation token
            ThreadPool.QueueUserWorkItem(ProcessBatch1, cts.Token);// start thread 1
            ThreadPool.QueueUserWorkItem(ProcessBatch2 , cts.Token);  //start thread 2 
            Thread.Sleep(1000);  // wait 200 ms to can see  the elements in the threads
            cts.Cancel();   // cancellation
            Console.ReadKey();   // wait ant character
            
            
            

           
        }
        private static object _Lock = new();

        private static void ProcessBatch1(object ?state)
        {
            var cancellationtoken = (CancellationToken)state;   //casting state to Cancellation token
            Thread.Sleep(1000);     // wait 1 sec
            for (int i = 0; i <= 1000; i++)
            {
                if (cancellationtoken.IsCancellationRequested)   // do the cancellation exists ?
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

        private static void ProcessBatch2(object? state)
        {
            var cancellationtoken = (CancellationToken)state;
            Thread.Sleep(1000);
            for (int i = 1001; i <= 2000; i++)
            {
                if (cancellationtoken.IsCancellationRequested)
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

