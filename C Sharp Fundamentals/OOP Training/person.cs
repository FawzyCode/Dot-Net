using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Training
{
    internal  abstract class person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public void SetName(string firstName, string lastName)
        {
            if (String.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Invalid Name");
            FirstName = firstName;
            LastName = lastName;

        }

        public DateOnly Birthdate { get; private set; }
        public void SetBirthDate(DateOnly birthdate)
        {
            if (birthdate < new DateOnly(1997, 5, 17))
                throw new ArgumentException("Invalid Birthdate");
            Birthdate = birthdate;
        }

        
        


    }
}
