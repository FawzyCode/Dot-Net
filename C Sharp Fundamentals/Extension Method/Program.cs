using System;

namespace Extension_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryFileSyestemEntries(@"D:\web course\Codes\C Sharp Fundamentals\OOP Training", 1);
                       
        }
        /* static int factorial(int Number)
         {
             if(Number <=1)
             {
                 return Number;
             }
             else
             {
                 return Number * factorial(Number-1);
             }

         }*/
        static void DirectoryFileSyestemEntries(string DirPath, int Level)
        {
            foreach(var FileName in Directory.GetFiles(DirPath))
            {
                Console.WriteLine($"{new string('-', Level)} {new DirectoryInfo(FileName).Name}");
                
            }
            foreach(var dirName in Directory.GetDirectories(DirPath))
            {
                Console.WriteLine($"{new string('-', Level)} {new DirectoryInfo(dirName).Name}");
                //DirectoryFileSyestemEntries(dirName, Level + 1);
            }
        }

    }
}
