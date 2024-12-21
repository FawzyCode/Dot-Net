using System.Threading.Tasks;
namespace MultiThreadingTest
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            /*Task.Run(() => work(1));
            Task.Run(() => work(2));            
            Console.ReadLine();*/ //run async
            var source  = new CancellationTokenSource();
            var token = source.Token;
            Task.Run(() => work(token) , (token));
            Thread.Sleep(500);
            source.Cancel();
            Console.WriteLine("work finished");
        }
        private static void work(CancellationToken token)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                if(token.IsCancellationRequested)
                {
                    Console.WriteLine("work is finished");
                    return;
                }
                Console.WriteLine($"method running : {i}");
            }
        }
    }
}
