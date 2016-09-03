using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    class Person : Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        readonly bool _isAdult;
        public bool ISAdult
        {
            get
            {
                bool isAdult = true;
                var age = CalculateAge(DateOfBirth);
                if (age >= 18) { return isAdult; }
                else { isAdult = false; return isAdult; }
            }
        }

        readonly string _sunsign;
        public Enum SunSign
        {
            get
            {
                if (DateOfBirth.Month != 0)
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
                throw new ArgumentException("Cant assign a zodiac sign.\n Check your birthdate");
            }
        }

        readonly string _chinesesign;
        public string ChineseSign
        {
            get
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
                throw new ArgumentException("Cant assign your chinese sign.\n Check your birthdate");
            }
        }

        readonly bool _isBirthday;
        public bool ISBirthday
        {
            get
            {
                bool isBirthday = true;
                DateTime today = DateTime.Today;
                if (DateOfBirth.Month != today.Month || DateOfBirth.Day != today.Day)
                { isBirthday = false; return isBirthday; }
                return isBirthday;
            }
        }

        readonly List<string> _screenname;
        public List<string> ScreenName
        {
            get
            {
                DateTime dateNow = DateTime.Now;
                if (DateOfBirth != DateTime.MinValue)
                {
                    var sName = new List<string>();
                    string bYear = DateOfBirth.Year.ToString().Substring(2, 2);
                    string bMonth = DateOfBirth.Month.ToString().PadLeft(2, '0');
                    string bDay = DateOfBirth.Day.ToString().PadLeft(2, '0');
                    string nParam1 = FirstName.ToLower() + "." + LastName.ToLower() + string.Format("{0}{1}{2}", bYear, bMonth, bDay);
                    sName.Add(nParam1);
                    string nParam2 = string.Format("{0}{1}{2}", bDay, bMonth, bYear) + FirstName.ToLower() + "." + LastName.ToLower();
                    sName.Add(nParam2);
                    return sName;
                }
                throw new ArgumentException("No birthdate is assigned");
            }
        }

        //Constructors
        public Person(string firstname, string lastname, string email, DateTime dateofbirth)
        {
            FirstName = CheckFirstName(firstname);
            LastName = CheckLastName(lastname);
            DateOfBirth = DateValidation(dateofbirth);
            Email = CheckEmail(email);
            _isAdult = ISAdult;
            _sunsign = string.Format("{0}", SunSign);
            _chinesesign = ChineseSign;
            _isBirthday = ISBirthday;
            _screenname = ScreenName;
        }

        public Person(string firstname, string lastname, string email)
        {
            FirstName = CheckFirstName(firstname);
            LastName = CheckLastName(lastname);
            Email = CheckEmail(email);
            _isAdult = ISAdult;
            _sunsign = string.Format("{0}", SunSign);
            _chinesesign = ChineseSign;
            _isBirthday = ISBirthday;
            _screenname = ScreenName;
        }

        public Person(string firstname, string lastname, DateTime dateofbirth)
        {
            FirstName = CheckFirstName(firstname);
            LastName = CheckLastName(lastname);
            DateOfBirth = DateValidation(dateofbirth);
            _isAdult = ISAdult;
            _sunsign = string.Format("{0}", SunSign);
            _chinesesign = ChineseSign;
            _isBirthday = ISBirthday;
            _screenname = ScreenName;
        }


        //Methods
        internal string CheckFirstName(string firstname)
        {
            if (string.IsNullOrEmpty(firstname))
            {
                throw new ArgumentException("No firstname is applied!");
            }
            return firstname;
        }
        internal string CheckLastName(string lastname)
        {
            if (string.IsNullOrEmpty(lastname))
                throw new ArgumentException("No lastname is applied!");
            return lastname;
        }

        internal DateTime DateValidation(DateTime dateofbirth)
        {
            var valDate = dateofbirth > DateTime.Now && dateofbirth != DateTime.MinValue;
            if (valDate == true) throw new ArgumentException("Your birthdate is not valid");
            return dateofbirth;
        }

        internal string CheckEmail(string email)
        {
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (string.IsNullOrEmpty(email))
            {
                return email;
            }
            if (isEmail != true)
            {
                throw new ArgumentException("Email input is faulty!");
            }
            else
            {
                return email.ToLower();
            }
        }

        internal int CalculateAge(DateTime dateofbirth)
        {
            DateTime today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age)) age--;
            return age;
        }

        internal List<string> GetScreenName()
        {
            DateTime dateNow = DateTime.Now;
            if (DateOfBirth != DateTime.MinValue)
            {
                var sName = new List<string>();
                string bYear = DateOfBirth.Year.ToString().Substring(2, 2);
                string bMonth = DateOfBirth.Month.ToString().PadLeft(2, '0');
                string bDay = DateOfBirth.Day.ToString().PadLeft(2, '0');
                string nParam1 = FirstName.ToLower() + "." + LastName.ToLower() + string.Format("{0}{1}{2}", bYear, bMonth, bDay);
                sName.Add(nParam1);
                string nParam2 = string.Format("{0}{1}{2}", bDay, bMonth, bYear) + FirstName.ToLower() + "." + LastName.ToLower();
                sName.Add(nParam2);
                return sName;
            }
            throw new ArgumentException("No birthdate is assigned");
        }


    }
}