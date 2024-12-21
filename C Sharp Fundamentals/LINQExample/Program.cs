namespace LINQExample
{
    public  class Program
    {
        static void Main(string[] args)
        {
            var numbers =new List<int> {1,2,3,4,5,6,7,8,9,10};
            /*linq expresion*/
            var result = (from number in numbers where number >5 select number);
            /*method expresion*/
            //var result = numbers.Where(x => x>5);
            foreach (int num in result)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("------------------------");
            numbers.AddRange(new int[] { 11, 12, 13, 14, 15,16 });
            foreach(int number in result)
                Console.WriteLine(number);

            /* filtering numbers larger than 5
            var res = new List<int>();
            foreach (int number in numbers)
            {
                if(number >5)
                {
                    res.Add(number);
                    
                }
            }
            foreach (int number in res)
                Console.WriteLine(number);*/

        }
    }
}
