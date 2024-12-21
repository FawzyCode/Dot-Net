namespace DelegatesTest
{
    public static class Program
    {
        public delegate void VoidDelegateFirst();
        public delegate int IntDelegateSecond(int num1 , int num2);
        static void Main(string[] args)
        {
            VoidDelegateFirst firstDelegate = new VoidDelegateFirst(print);
            //firstDelegate.Invoke();
            //firstDelegate();
            //Console.WriteLine("---------------");
            IntDelegateSecond SecondDelegate = new IntDelegateSecond(Addition);
            //int res1 = SecondDelegate(2, 4);
            //int res2 = SecondDelegate(3, 5);
            //Console.WriteLine($"res1 = {res1} , res2 = {res2}");

            /*working with class using delegate with parameters*/
            DelegateInvoker.InvokeDelgate(firstDelegate);
            Console.WriteLine(DelegateInvoker.InvokeDelegateWithParametes(SecondDelegate));


        }
        public static void print()
        {
            Console.WriteLine("hello fawzy in delegate example");
        }
        public static int Addition(int x , int y)
        {
            return x + y;
        }
    }
}
