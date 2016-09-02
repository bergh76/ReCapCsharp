using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    class Person: Employee
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
            DateOfBirth = dateValidation(dateofbirth);
            Email = checkEmail(email);
            ISAdult = isAdult(DateOfBirth);
            SunSign = string.Format("{0}",getSign(DateOfBirth));
            ChineseSign = getZodiacsign(DateOfBirth);
            ISBirthday = isBirthday(DateOfBirth);
            ScreenName = screenName(FirstName, LastName, DateOfBirth);
        }

        public Person(string firstname, string lastname, string email)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = checkEmail(email);
            ISAdult = isAdult(DateOfBirth);
            SunSign = string.Format("{0}", getSign(DateOfBirth));
            ChineseSign = getZodiacsign(DateOfBirth);
            ISBirthday = isBirthday(DateOfBirth);
            ScreenName = screenName(FirstName, LastName, DateOfBirth);
        }

        public Person(string firstname, string lastname, DateTime dateofbirth)
        {
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateValidation(dateofbirth);
            ISAdult = isAdult(DateOfBirth);
            SunSign = string.Format("{0}", getSign(DateOfBirth));
            ChineseSign = getZodiacsign(DateOfBirth);
            ISBirthday = isBirthday(DateOfBirth);
            ScreenName = screenName(FirstName, LastName, DateOfBirth);
        }

        private DateTime dateValidation(DateTime dateofbirth)
        {
            DateTime dateNow = DateTime.Now;
            var valDate = dateofbirth > dateNow && dateofbirth != DateTime.MinValue;
            if (valDate == true) throw new ArgumentException("Your birthdate is not valid");
            return dateofbirth;
        }

        private bool isAdult(DateTime DateOfBirth)
        {
            bool isAdult = true;
            DateTime today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age)) age--;
            if (age >= 18) { return isAdult; }
            else { isAdult = false; return isAdult; }
        }

        private string getZodiacsign(DateTime DateOfBirth)
        {
            if (DateOfBirth != DateTime.MinValue)
            {
                EastAsianLunisolarCalendar chineseSign = new ChineseLunisolarCalendar();
                int getSexYear = chineseSign.GetSexagenaryYear(DateOfBirth);
                int getSexTerre = chineseSign.GetTerrestrialBranch(getSexYear);
                string[] years = "Rat,Ox,Tiger,Rabbit,Dragon,Snake,Horse,Goat,Monkey,Rooster,Dog,Pig".Split(',');
                string sign = years[getSexTerre - 1];
                return years[getSexTerre - 1];
            }
            throw new ArgumentException("Cant calculate your chinesesign.\n Check your birthdate");
        }

        public bool isBirthday(DateTime DateOfBirth)
        {
            bool isBirthday = true;
            DateTime today = DateTime.Today;
            if (DateOfBirth.Month != today.Month || DateOfBirth.Day != today.Day)
            { isBirthday = false; return isBirthday; }
            return isBirthday;
        }

        private string screenName(string FirstName, string LastName, DateTime DateOfBirth)
        {
            DateTime dateNow = DateTime.Now;
            if (DateOfBirth != DateTime.MinValue)
            {
                string bYear = DateOfBirth.Year.ToString().Substring(2, 2);
                string bMonth = DateOfBirth.Month.ToString().PadLeft(2, '0');
                string bDay = DateOfBirth.Day.ToString().PadLeft(2, '0');
                string nParam = string.Format("{0}{1}{2}", bYear, bMonth, bDay);
                string screenName = FirstName.ToLower() + "." + LastName.ToLower() + nParam;
                return screenName;
            }
            throw new ArgumentException("No birthdate is assigned");
        }

        private string checkEmail(string email)
        {
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Data for email is empty");
            }
            if (isEmail != true)
            {
                throw new ArgumentException("Data for email is empty");
            }
            else
            {
                return email.ToLower();
            }
        }

        private WesternStarsign getSign(DateTime DateOfBirth)
        {
            switch (DateOfBirth.Month)
            {
                case 1:
                    if (DateOfBirth.Day < 20) return WesternStarsign.Stenbocken; else return WesternStarsign.Vattumannen;
                case 2:
                    if (DateOfBirth.Day < 19) return WesternStarsign.Vattumannen; else return WesternStarsign.Fiskarna;
                case 3:
                    if (DateOfBirth.Day < 21) return WesternStarsign.Fiskarna; else return WesternStarsign.Väduren;
                case 4:
                    if (DateOfBirth.Day < 20) return WesternStarsign.Väduren; else return WesternStarsign.Oxen;
                case 5:
                    if (DateOfBirth.Day < 21) return WesternStarsign.Oxen; else return WesternStarsign.Tvillingarna;
                case 6:
                    if (DateOfBirth.Day < 21) return WesternStarsign.Tvillingarna; else return WesternStarsign.Kräftan;
                case 7:
                    if (DateOfBirth.Day < 23) return WesternStarsign.Kräftan; else return WesternStarsign.Lejonet;
                case 8:
                    if (DateOfBirth.Day < 23) return WesternStarsign.Lejonet; else return WesternStarsign.Jungfrun;
                case 9:
                    if (DateOfBirth.Day < 23) return WesternStarsign.Jungfrun; else return WesternStarsign.Vågen;
                case 10:
                    if (DateOfBirth.Day < 23) return WesternStarsign.Vågen; else return WesternStarsign.Skorpionen;
                case 11:
                    if (DateOfBirth.Day < 23) return WesternStarsign.Skorpionen; else return WesternStarsign.Skytten;
                case 12:
                    if (DateOfBirth.Day < 22) return WesternStarsign.Skytten; else return WesternStarsign.Stenbocken;
                default:
                    if (DateOfBirth.Day < 22) return WesternStarsign.Skytten; else return WesternStarsign.Stenbocken;
            }
        }

    }
}