using static GenericsExamples.Program;

namespace GenericsExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var generics = new List<int>();
            //generics.Add(1);
            //generics.Add(2);
            //generics.Add(3);

            //foreach (int i in generics)
            //{
            //    Console.WriteLine(i);
            //}
            var newgeneric = new GenericList<int>();
            newgeneric.Add(1);
            newgeneric.Add(2);
            newgeneric.Add(3);
            newgeneric.Add(4);
            newgeneric.Add(5);

            

            Console.WriteLine(newgeneric.count);
        }
        public class GenericList<T>
        {
            private readonly List<T> _Items;
            public void Add(T item)
            {
                if(_Items != null) 
                   _Items.Add(item);
                _Items.Add(item);
            }
            public void Remove(T item)
            {
                _Items.Remove(item);
            }
            public void Clear(T item)
            {
                _Items.Clear();
            }
            public void count(T item)
            {
                _Items.Count();
            }

        }

    }
}
