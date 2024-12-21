using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFundamentals._ConsleApp.TrainingApps.FileSystemsCommandLine
{
    internal class App
    {
        public static void Run(String[] args)
        {
            Console.Write("<<");
            var input = Console.ReadLine();
            var WhiteSpaceIndex = input.IndexOf(" ");
            var Command = input.Substring(0, WhiteSpaceIndex);
            var Path = input.Substring(WhiteSpaceIndex + 1);
            //Console.WriteLine(Command);
            //Console.WriteLine(Path);
            if (Command == "list")
            {
                foreach (var entry in Directory.GetDirectories(Path))
                {
                    Console.WriteLine($"\t[dir]{entry}");
                }
                foreach (var entry in Directory.GetFiles(Path))
                {
                    Console.WriteLine($"\t[files]{entry}");
                }
            }
            else if (Command == "info")
            {
                if (Directory.Exists(Path))
                {
                    var DirInfo = new DirectoryInfo(Path);
                    Console.WriteLine("[type] : Directory");
                    Console.WriteLine($"Created at : {DirInfo.CreationTime}");
                    Console.WriteLine($"Created at : {DirInfo.LastWriteTime}");

                }
                else if (File.Exists(Path))
                {
                    var FileInfo = new DirectoryInfo(Path);
                    Console.WriteLine("[type] : File");
                    Console.WriteLine($"Created at : {FileInfo.CreationTime}");
                    Console.WriteLine($"Created at : {FileInfo.LastWriteTime}");

                }

            }
            else if (Command == "mkdir")
            {
                Directory.CreateDirectory(Path);

            }
            else if (Command == "print")
            {
                if (File.Exists(Path))
                {
                    var Content = File.ReadAllText(Path);
                    Console.WriteLine(Content);
                }


            }
            else if ((Command == "remove"))
            {
                if (Directory.Exists(Path))
                {
                    Directory.Delete(Path);
                }
                else if (File.Exists(Path))
                {
                    File.Delete(Path);

                }
            }


        }
    }
}
