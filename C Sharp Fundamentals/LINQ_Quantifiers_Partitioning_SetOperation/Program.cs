namespace LINQ_Quantifiers_Partitioning_SetOperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Numbers = new List<int> { 7, 1, 9, 2, 4, 3, 5, 8,-1,6, 10,-1,7 };
            var SecondList = new List<int> { 2, 5, 4, 3 ,6,50,60,100};
            //quantifiers (all - any - contains)
                     //1- all
                     //var res = Numbers.All(x => x > 0); 
                     //Console.WriteLine(res);
                     
                     //2 - any
                     //var res = Numbers.Any();
                     //Console.WriteLine(res);
                     
                     //3 - Contains
                     //var res = Numbers.Contains(5);
                     //Console.WriteLine(res);
            // Partioning (Skip - skipwhile - take - takewhile - chunk)
                      // 1- take
                      //var query = Numbers.Take(4);
                      //foreach (var number in query) 
                      //    Console.WriteLine(number);
                      
                      // 2- takewhile
                      //var query = Numbers.TakeWhile(x=> x>0);
                      //foreach (var number in query)
                      //    Console.WriteLine(number);
                      
                      // 3 - skip
                      //var query = Numbers.SkipWhile(x=> x!=-1);
                      //foreach (var number in query)
                      //    Console.WriteLine(number);
                      
                      // 4- chunk
                      //var query = Numbers.Chunk(2);
                      //foreach (var number in query)
                      //{
                      //    foreach(var items in number)
                      //    {
                      //        Console.WriteLine(items);
                      //    }
                      //    Console.WriteLine("----------------------");
                      //}

            //SetOperationns(Distinct - DistinctBy - Except - ExeptBy - InterSect - Intersectby - Union - unionby)
                   // 1 -  Distinct
                   //var query = Numbers.OrderBy(x=> x).Distinct();
                   //foreach (var number in query)
                   //    Console.WriteLine(number);
                   
                   //2- Except
                   //var query = Numbers.Except(SecondList);
                   //foreach (var number in query)
                   //    Console.WriteLine(number);
                   
                   //3 - intersect
                   // var query = Numbers.OrderBy(x => x).Intersect(SecondList);
                   // foreach (var number in query)
                   //     Console.WriteLine(number);
                   
                   // 4 - Union
                   var query = Numbers.OrderBy(x => x).Union(SecondList);
                   foreach (var number in query)
                       Console.WriteLine(number);

        }
    }
}
