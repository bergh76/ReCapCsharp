using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        readonly bool ISBirthday;
        readonly string ScreenName;

        public Person(string firstname, string lastname, string email, DateTime dateofbirth)
        {
            FirstName = firstname;
            LastName = lastname;
            var e = checkEmail(email);
            Email = e;
            DateOfBirth = dateofbirth;
            var adult = isAdult(DateOfBirth);
            ISAdult = adult;
            var chineseSign = getZodiacsign(DateOfBirth);
            ChineseSign = chineseSign;
            var bDay = isBirthday(DateOfBirth);
            ISBirthday = bDay;
            var sName = screenName(FirstName, LastName, DateOfBirth);
            ScreenName = sName;
        }

        public Person(string firstname, string lastname, string email)
        {

            FirstName = firstname;
            LastName = lastname;
            var e = checkEmail(email);
            Email = e;
            var chineseSign = getZodiacsign(DateOfBirth);
            ChineseSign = chineseSign;
            var bDay = isBirthday(DateOfBirth);
            ISBirthday = bDay;
            var sName = screenName(FirstName, LastName, DateOfBirth);
            ScreenName = sName;
        }
        public Person(string firstname, string lastname, DateTime dateofbirth)
        {
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateofbirth;
            var adult = isAdult(DateOfBirth);
            ISAdult = adult;
            var chineseSign = getZodiacsign(DateOfBirth);
            ChineseSign = chineseSign;
            var bDay = isBirthday(DateOfBirth);
            ISBirthday = bDay;
            var sName = screenName(FirstName, LastName, DateOfBirth);
            ScreenName = sName;
        }
        private bool isAdult(DateTime DateOfBirth)
        {
            DateTime today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age)) age--;
            bool isAdult = true;
            if (age >= 18) { return isAdult; }
            else  { isAdult = ISAdult.Equals(false); return isAdult; }
        }
        public string getZodiacsign(DateTime DateOfBirth)
        {
            EastAsianLunisolarCalendar chineseSign = new ChineseLunisolarCalendar();
            int getSexYear = chineseSign.GetSexagenaryYear(DateOfBirth);
            int getSexTerre = chineseSign.GetTerrestrialBranch(getSexYear);
            string[] years = "Rat,Ox,Tiger,Rabbit,Dragon,Snake,Horse,Goat,Monkey,Rooster,Dog,Pig".Split(',');
            string sign = years[getSexTerre - 1];
            return years[getSexTerre - 1];
        }

        public bool isBirthday(DateTime DateOfBirth)
        {
            bool isBirthday = true;
            DateTime today = DateTime.Today;
            if (DateOfBirth.Month != today.Month && DateOfBirth.Day != today.Day)
            { isBirthday = false; return isBirthday; }            
            return isBirthday;
        }

        public string screenName(string FirstName, string LastName, DateTime BirthDay)
        {
            string bYear = BirthDay.Year.ToString().Substring(2, 2).ToString();
            string bMonth = BirthDay.Month.ToString();
            string bDay = BirthDay.Day.ToString();
            string nParam = string.Format("{0}{1}{2}", bYear, bMonth, bDay);
            string screenName = FirstName + "." + LastName + nParam;
            return screenName;

        }

        public string checkEmail(string email)
        {
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (isEmail == true)
            {
                return email;
            }
            else
            {
                string notvalid = "Not valid email";
                email = notvalid;
                return email;
            }
        }
    }
}