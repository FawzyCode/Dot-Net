using System.Text;

namespace UserGeneratenumberAnyString
{
    internal class Program
    {

        static void Main(string[] args)
        {
           




            while (true)
            {
                Console.WriteLine("please select an option ");
                Console.WriteLine("[1] generate rondom number\t[2] generate rondom string\t[3]genrate rondom string with option ");
                var rnd_Num = Console.ReadLine();
                if (rnd_Num == "1")
                {
                    GenrateRondomNumber();
                }
                else if (rnd_Num == "2")
                {
                    GenrateRondomString();

                }
                else if (rnd_Num == "3")
                {
                    GenrateRondomStringOption();
                }

            }
        }
        static void GenrateRondomNumber()
        {
            Console.WriteLine("enter min value to access rondom");
            var Min_Value = int.Parse(Console.ReadLine());

            Console.WriteLine("enter max value to access rondom");
            var Max_Value = int.Parse(Console.ReadLine());
            var rand = new Random();
            var Random_value = rand.Next(Min_Value, Max_Value);
            Console.WriteLine($"the rondom value {Random_value}");


        }

        static void GenrateRondomString()
        {
            const string Buffer = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789/+_)(*&^%$#@!~}{?/";
            Console.Write("enter the length of string choose : ");
            var string_length = int.Parse(Console.ReadLine());
            var rand_buiilder = new StringBuilder();
            var rand = new Random();
            while (rand_buiilder.Length < string_length)
            {
                var rand_index = rand.Next(0, Buffer.Length - 1);
                rand_buiilder.Append(Buffer[rand_index]);
            }
            Console.WriteLine($"rondom string :{rand_buiilder}");


        }
        static void GenrateRondomStringOption()
        {
            string buffer1 = " ", buffer2 = " ", buffer3 = " ", buffer4 = " ";
            string Buffer = "";
            var rand_buiilder = new StringBuilder();


            const string Buffer_Capital = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string Buffer_Small = "abcdefghijklmnopqrstuvwxyz";
            const string Buffer_Number = "0123456789";
            const string Buffer_Symbol = "/+_)(*&^%$#@!~}{?/";

            Console.WriteLine("do you include capital letters :\n[1]yes\t[2]No");
            var Var_str = Console.ReadLine();
            if (Var_str == "1")
            {
                buffer1 = Buffer_Capital;

            }
            else if (Var_str == "2")
            {
                buffer1 = " ";
            }
            Console.WriteLine("do you include small letters :\n[1]yes\t[2]No");
            Var_str = Console.ReadLine();
            if (Var_str == "1")
            {
                buffer2 = Buffer_Small;
            }
            else if (Var_str == "2")
            {
                buffer2 = " ";
            }

            Console.WriteLine("do you include Number letters :\n[1]yes\t[2]No");
            Var_str = Console.ReadLine();
            if (Var_str == "1")
            {
                buffer3 = Buffer_Number;
            }
            else if (Var_str == "2")
            {
                buffer3 = " ";
            }

            Console.WriteLine("do you include Symbol letters :\n[1]yes\t[2]No");
            Var_str = Console.ReadLine();
            if (Var_str == "1")
            {
                buffer4 = Buffer_Symbol;
            }
            else if (Var_str == "2")
            {
                buffer4 = " ";
            }
            Buffer = buffer1 + buffer2 + buffer3 + buffer4;

            Console.Write("enter the length of string choose : ");
            var string_length = int.Parse(Console.ReadLine());

            var rand = new Random();
            int max_rnd = Buffer.Length - 1;


            while (rand_buiilder.Length < string_length)
            {
                var rand_index = rand.Next(0, Buffer.Length - 1);
                rand_buiilder.Append(Buffer[rand_index]);
            }
            Console.WriteLine($"rondom string :{rand_buiilder}");
        }



    }

}
