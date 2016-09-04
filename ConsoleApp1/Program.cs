using System;
using System.Globalization;

namespace ConsoleApp
{
    public class Program
    {
        public string _firstname;
        public string _lastname;
        public string _year;
        public string _month;
        public string _day;
        public string _birthday;
        public string _email;
        public int age;
        public static void Main(string[] args)
        {
            Program pOut = new Program();
            pOut._birthday = pOut.PrintOutDate();
            DateTime getDate = DateTime.ParseExact(pOut._birthday, "yyyyMMdd", CultureInfo.InvariantCulture,
                                       DateTimeStyles.None);
            Person p = new Person(pOut.GetFirstName(), pOut.GetLastName(), pOut.GetEmail(), getDate);
            pOut.age = p.CalculateAge(getDate);
            pOut.PrintOutResult(pOut, p);
            Console.WriteLine("\nPress any key to continue....");
            Console.ReadKey();
        }

        private string GetFirstName()
        {
            Console.Write("What is your firstname?: ");
            _firstname = Console.ReadLine();
            return _firstname;
        }

        private string GetLastName()
        {
            Console.Write("What is your lastname?: ");
            return _lastname = Console.ReadLine();
        }

        private string GetEmail()
        {
            Console.Write("What is your emailadress?: ");
            return _email = Console.ReadLine();
        }

        private string PrintOutDate()
        {
            Console.Write("Insert birthyear [xxxx]: ");
            _year = Console.ReadLine();
            Console.Write("Insert birthmonth [xx]: ");
            _month = Console.ReadLine();
            Console.Write("Insert day in birthmonth [xx]: ");
            _day = Console.ReadLine();
            _birthday = string.Format("{0}{1}{2}", _year, _month, _day);
            return _birthday;
        }

        private string AdultCheck(Person p)
        {
            bool adult = p.ISAdult;
            string message = string.Format("Age: {0} - Your an adult!", age);
            if (adult != true)
                message = string.Format("Age: {0} - You are not an adult!", age);
            return message;
        }

        private string CheckIfDayIsBirthday(Person p)
        {
            bool bday = p.ISBirthday;
            string message = "Nope....not your birthday today!";
            if (bday == true)
                message = string.Format("Congratulations! Today is your birthday!");
            return message;
        }

        private void PrintOutResult(Program pOut, Person p)
        {
            Console.Clear();
            string name = string.Format("Your name is: {0} {1}", p.FirstName, p.LastName);
            string birthday = string.Format("Your date of birth is:{0}", p.DateOfBirth);
            string isBirthday = string.Format("{0}", pOut.CheckIfDayIsBirthday(p));
            string isAdult = string.Format("{0}", pOut.AdultCheck(p));
            string csign = string.Format("Your chinese sign is:{0}", p.ChineseSign);
            string ssign = string.Format("Your sunsign is:{0}", p.SunSign);
            string result = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}", name, birthday, isBirthday, isAdult, csign, ssign);
            Console.WriteLine(result);
            Employee emp = new Employee(25000, p.Email);
            emp.ShowPayment();
        }
    }
}