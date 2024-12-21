using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFundamentals._ConsleApp.TrainingApps.PasswordManagment
{
    public static class App
    {
        private static readonly Dictionary<string, string> Dic = new();
        public static void Run(string[] args)
        {
            /*Password manager
             * 1 - List all password
             * 2 - Add or change password 
             * 3 - Get password
             * 4 - Delete password
             */
            ReadPassword();
            while (true)
            {
                /*select option from this options*/
                Console.WriteLine("Please Select an optoin : ");
                Console.WriteLine("1 - List all password: ");
                Console.WriteLine("2 - Add or change password : ");
                Console.WriteLine("3 - Get password:");
                Console.WriteLine("4 - Delete password ");
                /*the user enter number from 1 to 4 */
                var Input = Console.ReadLine();
                if (Input == "1")    // show all password
                {
                    ListAllPassword();
                }
                else if (Input == "2") // ADD OR CHANGE password
                {
                    AddOrChangePasseword();
                }
                else if (Input == "3")   // read the password
                {
                    GetPassword();
                }
                else if (Input == "4")  // delet the password
                {
                    DeletePassaword();
                }
                else
                {
                    Console.WriteLine("invalid option");   // when user choose input not exists
                }
                Console.WriteLine("----------------------------------");
            }

            

         }

        private static void DeletePassaword()
        {
            Console.WriteLine("enter the website name");
            var AppName = Console.ReadLine();         // The website name
            if (Dic.ContainsKey(AppName))            // the website is exist
            {
                Dic.Remove(AppName);
                SavePasswored();
            }
            else
            {
                Console.WriteLine("the password is not found");
            }

        }

        private static void GetPassword()
        {
            Console.WriteLine("enter the website name");
            var AppName = Console.ReadLine();         // The website name
            if (Dic.ContainsKey(AppName))            // the website is exist
            {
                Console.WriteLine($"the password is {Dic[AppName]} ");
            }
            else
            {
                Console.WriteLine("the password is not found");
            }
        }

        private static void AddOrChangePasseword()
        {    
            Console.WriteLine("enter the website name");
            var AppName = Console.ReadLine();         // The website name
            Console.WriteLine("enter the password");
            var pass = Console.ReadLine();            //the password of website  
            if (Dic.ContainsKey(AppName))             //key is already exist
            {
                
                Dic[AppName] = pass;                  //chande the password only  
            }
            else
            {
                Dic.Add(AppName, pass);             // add to dictionary website and password it
            }
            SavePasswored();

        }

        private static void ListAllPassword()
        {
            foreach (var item in Dic)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }
           
        }
        private static void ReadPassword()
        {
            if(File.Exists("Passwords.txt"))
            {
                var PasswordLines = File.ReadAllText("Passwords.txt"); //read the all keys and password
                foreach (var line in PasswordLines.Split(Environment.NewLine)) // to \n or \r\r to new line
                {
                    if (!string.IsNullOrEmpty(line))  // gmail.com = 0100000
                    {
                        var EqualIndex = line.IndexOf('=');
                        var AppName = line.Substring(0, EqualIndex);
                        var password = line.Substring(EqualIndex + 1);
                        Dic.Add(AppName , password);
                    }

                }
            }

            
        }
        private static void SavePasswored()
        {
            var sb = new StringBuilder();
            foreach (var item in Dic)  //looping in all items in dictionary
            {
               sb.AppendLine($"{item.Key} = {item.Value}"); //key = password
            }
            File.WriteAllText("Passwords.txt" , sb.ToString()); //add the all passwords in this file to save 


        }
    }

}

