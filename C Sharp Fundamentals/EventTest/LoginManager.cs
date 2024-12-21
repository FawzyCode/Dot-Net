using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    public class LoginManager
    {
        public delegate void Handler(User user);   //definition the delegate to init event
        public event Handler UserLoginSuccessful;  // definition the event

        public   void LoginUser(User user)
        {
            if(! user.Mail.EndsWith("@gmail.com"))
            {
                return ;
            }
            OnUserLoginSuccessful(user);
        }
       public  void OnUserLoginSuccessful(User user)
        {
            if(UserLoginSuccessful != null)
                 UserLoginSuccessful.Invoke(user) ; 
        }
    }
}
