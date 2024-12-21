using System.Runtime.ExceptionServices;

namespace EventTest
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
             User user = new User("fawzy" , "elbayaa" , "fawzyelbayaa2022@gmail.com");
             LoginManager loginManager = new LoginManager();

             loginManager.UserLoginSuccessful += LoginManager_UserLoginSuccessful;
             loginManager.LoginUser(user);

        }

        private static void LoginManager_UserLoginSuccessful(User user)
        {
            Console.WriteLine("login is successfuly");
        }
    }
}
