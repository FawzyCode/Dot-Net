using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    public  class User
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        } 
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        private string mail;
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public User(string firstName , string lastName , String mail ) //constructor
        {
            FirstName = firstName;
            LastName = lastName;
            Mail = mail;    
        }

    }
}
