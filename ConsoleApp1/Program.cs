using System;
using System.Globalization;

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

        public string PrintOutBirthday()
        {
            _birthday = string.Format("{0}{1}{2}", _year, _month, _day);
            return _birthday;
        }

        private Starsign getSign()
        {
            string bDate = _birthday;
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture,
                                       DateTimeStyles.None);
            switch (getDate.Month)
            {
                case 1:
                    if (getDate.Day < 20) return Starsign.Stenbocken; else return Starsign.Vattumannen;
                case 2:
                    if (getDate.Day < 19) return Starsign.Vattumannen; else return Starsign.Fiskarna;
                case 3:
                    if (getDate.Day < 21) return Starsign.Fiskarna; else return Starsign.Väduren;
                case 4:
                    if (getDate.Day < 20) return Starsign.Väduren; else return Starsign.Oxen;
                case 5:
                    if (getDate.Day < 21) return Starsign.Oxen; else return Starsign.Tvillingarna;
                case 6:
                    if (getDate.Day < 21) return Starsign.Tvillingarna; else return Starsign.Kräftan;
                case 7:
                    if (getDate.Day < 23) return Starsign.Kräftan; else return Starsign.Lejonet;
                case 8:
                    if (getDate.Day < 23) return Starsign.Lejonet; else return Starsign.Jungfrun;
                case 9:
                    if (getDate.Day < 23) return Starsign.Jungfrun; else return Starsign.Vågen;
                case 10:
                    if (getDate.Day < 23) return Starsign.Vågen; else return Starsign.Skorpionen;
                case 11:
                    if (getDate.Day < 23) return Starsign.Skorpionen; else return Starsign.Skytten;
                case 12:
                    if (getDate.Day < 22) return Starsign.Skytten; else return Starsign.Stenbocken;
                default:
                    if (getDate.Day < 22) return Starsign.Skytten; else return Starsign.Stenbocken;

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