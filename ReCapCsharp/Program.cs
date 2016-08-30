using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapCsharp
{
    public enum WesternStarsign
    {
        Stenbocken, // 22 december – 20 januari
        Vattumannen, // 21 januari – 18 februari
        Fiskarna, // 19 februari – 20 mars
        Väduren,// 21 mars – 20 april
        Oxen, // 21 april – 21 maj
        Tvillingarna, // 22 maj – 21 juni
        Kräftan, // 22 juni – 22 juli
        Lejonet, // 23 juli – 23 augusti
        Jungfrun, // 24 augusti – 22 september
        Vågen, // 23 september – 23 oktober
        Skorpionen, // 24 oktober – 22 november
        Skytten, // 23 november – 21 december

    }
    class Program
    {
        public string _month;
        public string _year;
        public string _day;
        public string _birthday;
        public int age;

        public string setDate()
        {
            Console.WriteLine("Skriv in ditt födelseår:");
            string inYear = Console.ReadLine();
            Console.WriteLine("Skriv in ditt födelsemånad:");
            string inMonth = Console.ReadLine();
            Console.WriteLine("Skriv in ditt födelsedag:");
            string inDay = Console.ReadLine();
            _year = inYear;
            _month = inMonth;
            _day = inDay;
            return PrintOutBirthday();
        }
        public static void Main()
        {
            Program pOut = new Program();
            pOut.setDate();
            Console.WriteLine("Din födelsedag är:{0}", pOut.PrintOutBirthday());
            pOut.age = pOut.CalculateAge();
            if (pOut.age > 0)
            {
                Console.WriteLine("Du är {0} år", pOut.age);
                Console.WriteLine("Ditt chinesiska tecken är: {0}", pOut.getZodiacsign());
                Console.WriteLine("Ditt stjärntecken är: {0}", pOut.getSign() );
            }
            Console.ReadLine();
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
                Console.WriteLine("Grattis! Idag är det din födelsedag");
            }
            if (getDate.Year >= today.Year && getDate.Month > today.Month)
            {
                Console.WriteLine("Du är ännu inte född ");
            }
            if (getDate > today.AddYears(-age))
            {
                age--;
            }
            if (age >= 135)
            {
                Console.WriteLine("Du är hyfsat död!");
            }
            return age;
        }
        public string PrintOutBirthday()
        {
            _birthday = string.Format("{0}{1}{2}", _year, _month, _day);
            return _birthday;
        }

        public WesternStarsign getSign()
        {
            string bDate = _birthday;
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture,
                                       DateTimeStyles.None);
            switch (getDate.Month)
            {
                case 1:
                    if (getDate.Day < 20) return WesternStarsign.Stenbocken; else return WesternStarsign.Vattumannen;
                case 2:
                    if (getDate.Day < 19) return WesternStarsign.Vattumannen; else return WesternStarsign.Fiskarna ;
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
        public string getZodiacsign()
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