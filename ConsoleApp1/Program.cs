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
            //pOut.GetFirstName();            
            Person p = new Person(pOut.GetFirstName(), pOut.GetLastName(), pOut.GetEmail(), getDate);
            pOut.age = p.CalculateAge(getDate);
            pOut.PrintOutResult(pOut, p);
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }

        private string GetFirstName()
        {
            Console.WriteLine("What is your firstname?:");
            _firstname = Console.ReadLine();
            return _firstname;
        }

        private string GetLastName()
        {
            Console.WriteLine("What is your lastname?:");
            return _lastname = Console.ReadLine();
        }

        private string GetEmail()
        {
            Console.WriteLine("What is your emailadress?");
            return _email = Console.ReadLine();
        }

        private string PrintOutDate()
        {
            Console.WriteLine("Insert birthyear [xxxx]:");
            _year = Console.ReadLine();
            Console.WriteLine("Insert birthmonth [xx]:");
            _month = Console.ReadLine();
            Console.WriteLine("Insert day in birthmonth [xx]:");
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
            //if (pOut.age > 0)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Your name is: {0} {1}", p.FirstName, p.LastName);
            //    Console.WriteLine("Your date of birth is:{0}", pOut._birthday);
            //    Console.WriteLine("{0}", pOut.CheckIfDayIsBirthday(p));
            //    Console.WriteLine("{0}", pOut.AdultCheck(p));
            //    Console.WriteLine("Your chinese sign is:{0}", p.ChineseSign);
            //    Console.WriteLine("Your sunsign is:{0}", p.SunSign);
            //    Employee emp = new Employee(25000, p.Email);
            //    emp.ShowPayment();
            //}
            //Console.ReadLine();
            string name = "";
            string birthday = "";
            string isBirthday = "";
            string isAdult = "";
            string csign = "";
            string ssign = "";
            string result = "";
            if (pOut.age > 0)
            {
                Console.Clear();
                name = string.Format("Your name is: {0} {1}", p.FirstName, p.LastName);
                birthday = string.Format("Your date of birth is:{0}", pOut._birthday);
                isBirthday = string.Format("{0}", pOut.CheckIfDayIsBirthday(p));
                isAdult = string.Format("{0}", pOut.AdultCheck(p));
                csign = string.Format("Your chinese sign is:{0}", p.ChineseSign);
                ssign = string.Format("Your sunsign is:{0}", p.SunSign);
                result = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}", name, birthday, isBirthday, isAdult, csign, ssign);
                Console.WriteLine(result);
                Employee emp = new Employee(25000, p.Email);
                emp.ShowPayment();
            }
        }
    }
}