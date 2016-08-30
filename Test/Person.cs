using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        readonly bool ISAdult;
        readonly string SunSign;
        readonly string ChineseSign;
        readonly DateTime Birthday;
        readonly string ScreenName;

        public Person(string firstname, string lastname, string email, DateTime dateofbirth)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            DateOfBirth = dateofbirth;
        }

        public Person(string firstname, string lastname, string email)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
        }
        public Person(string firstname, string lastname, DateTime dateofbirth)
        {
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateofbirth;
        }
    }
}
