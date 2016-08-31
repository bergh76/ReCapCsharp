using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using UnitTestProject1;
using Xunit;

namespace Test
{
    public class xUnitTest
    {

        [Fact]
        public void testAllPassed()
        {
            // In-line setup     
            string bDate = "19761201";
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            Person p1 = new Person("Andreas", "Bergh", "andreas__bergh@hotmail.com", getDate);
            Assert.Equal(p1.FirstName ,"Andreas");
            Assert.Equal(p1.LastName, "Bergh");
            Assert.Equal(p1.Email, "andreas__bergh@hotmail.com");
            Assert.Equal(p1.DateOfBirth, getDate);
        }

        [Fact]
        public void testFailWrongDataInputCheck()
        {
            // In-line setup     
            string bDate = "19761201";
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            Person p2 = new Person("Knut", "Kragballe", getDate);
            Assert.Equal(p2.FirstName, "Andreas");
            Assert.Equal(p2.LastName, "Bergh");
            Assert.Equal(p2.DateOfBirth, getDate);
        }

        [Fact]
        public void testEmailFail()
        {
            // In-line setup     
            Person p3 = new Person("Sven", "Mellander", "sven.mellander&hotmail.com");
            Assert.Equal(p3.FirstName, "Sven");
            Assert.Equal(p3.LastName, "Mellander");
            Assert.Equal(p3.Email, "sven.menlander&hotmail.com");
        }

        [Fact]
        public void testIfTodayIsBirthdayPass()
        {
            // In-line setup     
            string year = "1976";
            DateTime date = DateTime.Now;
            var month = date.Month.ToString().PadLeft(2, '0');
            var day = date.Day.ToString().PadLeft(2, '0');
            var bDay = string.Format("{0}{1}{2}", year, month, day);
            DateTime getDate = DateTime.ParseExact(bDay, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            Person p1 = new Person("Andreas", "Bergh", "andreas__bergh@hotmail.com", getDate);
            Assert.Equal(p1.FirstName, "Andreas");
            Assert.Equal(p1.LastName, "Bergh");
            Assert.Equal(p1.Email, "andreas__bergh@hotmail.com");
            Assert.Equal(p1.DateOfBirth, getDate);
            bool isBirthday = p1.isBirthday(getDate);
            Assert.True(isBirthday);
        }

        [Fact]
        public void testIfTodayIsBirthdayFail()
        {
            // In-line setup     
            var bDay = "19761201";
            DateTime getDate = DateTime.ParseExact(bDay, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            Person p1 = new Person("Andreas", "Bergh", "andreas__bergh@hotmail.com", getDate);
            Assert.Equal(p1.FirstName, "Andreas");
            Assert.Equal(p1.LastName, "Bergh");
            Assert.Equal(p1.Email, "andreas__bergh@hotmail.com");
            Assert.Equal(p1.DateOfBirth, getDate);
            bool isBirthday = p1.isBirthday(getDate);
            Assert.True(isBirthday);
        }
        [Fact]
        public void testIfBirthdayIsInTheFuturePass()
        {
            // In-line setup     
            var bDay = "20170101";
            DateTime getDate = DateTime.ParseExact(bDay, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            Person p1 = new Person("Andreas", "Bergh", "andreas__bergh@hotmail.com", getDate);
            Assert.Equal(p1.FirstName, "Andreas");
            Assert.Equal(p1.LastName, "Bergh");
            Assert.Equal(p1.Email, "andreas__bergh@hotmail.com");
            var isBirthday = p1.DateOfBirth == getDate;
            Assert.True(isBirthday);
           
        }
    }
}