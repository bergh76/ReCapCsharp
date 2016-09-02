using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        public string _month;
        public string _year;
        public string _day;
        public string _birthday;
        public int age;
        public static void Main(string[] args)
        {
            Program pOut = new Program();
            pOut.setDate();
            Console.WriteLine("Your date of birth is:{0}", pOut.PrintOutBirthday());
            pOut.age = pOut.CalculateAge();
            if (pOut.age > 0)
            {
                Console.WriteLine("You are {0} years old.", pOut.age);
                Console.WriteLine("Your chinese sign is: {0}", pOut.getZodiacsign());
                Console.WriteLine("Your sunsign is: {0}", pOut.getSign());
            }
            Console.ReadLine();
        }

        private string setDate()
        {
            Console.WriteLine("Insert birthyear [xxxx]:");
            string inYear = Console.ReadLine();
            Console.WriteLine("Insert birthmonth [xx]:");
            string inMonth = Console.ReadLine();
            Console.WriteLine("Insert day in birthmonth [xx]:");
            string inDay = Console.ReadLine();
            _year = inYear;
            _month = inMonth;
            _day = inDay;
            return PrintOutBirthday();
        }

        private int CalculateAge()
        {
            string bDate = _birthday;
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture,
                                       DateTimeStyles.None);
            DateTime today = DateTime.Today;
            var age = today.Year - getDate.Year;
            if (getDate.Month == today.Month && getDate.Day == today.Day)
            {
                throw new ArgumentException("Congratulations! Today is your birthday");
            }
            if (getDate.Year >= today.Year && getDate.Month > today.Month)
            {
                throw new ArgumentException("You have not yet been born.");
            }
            if (getDate > today.AddYears(-age))
            {
                age--;
            }
            if (age >= 135)
            {
                throw new ArgumentException("Get out of here. No way you are over 135 years old!");
            }
            return age;
        }

        private string PrintOutBirthday()
        {
            _birthday = string.Format("{0}{1}{2}", _year, _month, _day);
            return _birthday;
        }

        private WesternStarsign getSign()
        {
            string bDate = _birthday;
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture,
                                       DateTimeStyles.None);
            switch (getDate.Month)
            {
                case 1:
                    if (getDate.Day < 20) return WesternStarsign.Stenbocken; else return WesternStarsign.Vattumannen;
                case 2:
                    if (getDate.Day < 19) return WesternStarsign.Vattumannen; else return WesternStarsign.Fiskarna;
                case 3:
                    if (getDate.Day < 21) return WesternStarsign.Fiskarna; else return WesternStarsign.Väduren;
                case 4:
                    if (getDate.Day < 20) return WesternStarsign.Väduren; else return WesternStarsign.Oxen;
                case 5:
                    if (getDate.Day < 21) return WesternStarsign.Oxen; else return WesternStarsign.Tvillingarna;
                case 6:
                    if (getDate.Day < 21) return WesternStarsign.Tvillingarna; else return WesternStarsign.Kräftan;
                case 7:
                    if (getDate.Day < 23) return WesternStarsign.Kräftan; else return WesternStarsign.Lejonet;
                case 8:
                    if (getDate.Day < 23) return WesternStarsign.Lejonet; else return WesternStarsign.Jungfrun;
                case 9:
                    if (getDate.Day < 23) return WesternStarsign.Jungfrun; else return WesternStarsign.Vågen;
                case 10:
                    if (getDate.Day < 23) return WesternStarsign.Vågen; else return WesternStarsign.Skorpionen;
                case 11:
                    if (getDate.Day < 23) return WesternStarsign.Skorpionen; else return WesternStarsign.Skytten;
                case 12:
                    if (getDate.Day < 22) return WesternStarsign.Skytten; else return WesternStarsign.Stenbocken;
                default:
                    if (getDate.Day < 22) return WesternStarsign.Skytten; else return WesternStarsign.Stenbocken;

            }
        }

        private string getZodiacsign()
        {
            string bDate = _birthday;
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture,
                                       DateTimeStyles.None);
            EastAsianLunisolarCalendar chineseSign = new ChineseLunisolarCalendar();
            int getSexYear = chineseSign.GetSexagenaryYear(getDate);
            int getSexTerre = chineseSign.GetTerrestrialBranch(getSexYear);
            string[] years = "Rat,Ox,Tiger,Rabbit,Dragon,Snake,Horse,Goat,Monkey,Rooster,Dog,Pig".Split(',');
            string sign = years[getSexTerre - 1];
            return years[getSexTerre - 1];
        }
    }
}