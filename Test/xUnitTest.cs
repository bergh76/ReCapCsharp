using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp;
using Xunit;

namespace ConsoleApp
{
    public class xUnitTest
    {
        [Fact]
        public void testAllPassed()
        {
            // In-line setup     
            //Act
            string firstname = "Andreas";
            string lastname = "Bergh";
            string email = "andreas__bergh@hotmail.com";
            string bDate = "19761201";
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            Person p1 = new Person(firstname, lastname, email, getDate);
            //Assert
            Assert.Equal(p1.FirstName , firstname);
            Assert.Equal(p1.LastName, lastname);
            Assert.Equal(p1.Email, email);
            Assert.Equal(p1.DateOfBirth, getDate);
        }

        [Fact]
        public void testFailWrongDataInputCheck()
        {
            // In-line setup     
            string bDate = "19761201";
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            Person p2 = new Person("Knut", "Kragballe", getDate);
            Assert.NotEqual(p2.FirstName, "Andreas");
            Assert.NotEqual(p2.LastName, "Bergh");
            Assert.Equal(p2.DateOfBirth, getDate);
        }

        [Fact]
        public void testEmailFail()
        {
            //Act
            string firstname = "Andreas";
            string lastname = "Bergh";
            string email = "andreas__bergh@hotmail.com";
            string bDate = "19761201";
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);

            Person p3 = new Person(firstname, lastname, email, getDate);
            //Assert
            Assert.Equal(p3.FirstName, firstname);
            Assert.Equal(p3.LastName, lastname);
            Assert.Equal(p3.Email, email);
        }

        [Fact]
        public void testIfTodayIsBirthdayPass()
        {
            // In-line setup     
            string firstname = "Andreas";
            string lastname = "Bergh";
            string email = "andreas__bergh@hotmail.com";
            string year = "1976";
            DateTime date = DateTime.Now;
            var month = date.Month.ToString().PadLeft(2, '0');
            var day = date.Day.ToString().PadLeft(2, '0');
            var bDay = string.Format("{0}{1}{2}", year, month, day);
            DateTime getDate = DateTime.ParseExact(bDay, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            Person p1 = new Person(firstname, lastname, email, getDate);
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
            bool isBirthday = p1.isBirthday(getDate);
            Assert.False(isBirthday);
        }
    }
}