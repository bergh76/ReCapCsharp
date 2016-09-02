using System;
using System.Globalization;
using Xunit;

namespace TestConsoleApp
{
    public class xUnitTest
    {
        [Fact]
        public void testAllPassed()
        {
            // In-line setup     
            //Arrange
            string firstname = "Andreas";
            string lastname = "Bergh";
            string email = "andreas__bergh@hotmail.com";
            string bDate = "19761201";
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            //Act
            Person p1 = new Person(firstname, lastname, email, getDate);
            //Assert
            Assert.Equal(p1.FirstName , firstname);
            Assert.Equal(p1.LastName, lastname);
            Assert.Equal(p1.Email, email);
            Assert.Equal(p1.DateOfBirth, getDate);
        }
        [Fact]
        public void testFirstNameNotNull()
        {  
            //Arrange
            string firstname = "Andreas";
            string lastname = "Bergh";
            string email = "andreas__bergh@hotmail.com";
            string bDate = "19761201";
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            //Act
            Person p1 = new Person(firstname, lastname, email, getDate);
            //Assert
            Assert.NotEmpty(p1.FirstName);
        }

        [Fact]
        public void testFirstNameIsNull()
        {
            //Arrange
            string firstname = "";
            string lastname = "Bergh";
            string email = "andreas__bergh@hotmail.com";
            string bDate = "19761201";
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            //Act
            Person p1 = new Person(firstname, lastname, email, getDate);
            //Assert
            Assert.Null(p1.FirstName);
        }


        [Fact]
        public void testFailWrongDataInputCheck()
        {
            //Arrange   
            string bDate = "19761201";
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            //Act
            Person p2 = new Person("Knut", "Kragballe", getDate);
            //Assert
            Assert.NotEqual(p2.FirstName, "Andreas");
            Assert.NotEqual(p2.LastName, "Bergh");
            Assert.Equal(p2.DateOfBirth, getDate);
        }

        [Fact]
        public void testEmailFail()
        {
            // Arrange
            string firstname = "Andreas";
            string lastname = "Bergh";
            string email = "andreas__bergh@hotmail.com";
            string bDate = "19761201";
            DateTime getDate = DateTime.ParseExact(bDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            //Act
            Person p3 = new Person(firstname, lastname, email, getDate);
            //Assert
            Assert.Equal(p3.Email, email);
        }

        [Fact]
        public void testIfTodayIsBirthdayPass()
        {
            // Arrange     
            string firstname = "Andreas";
            string lastname = "Bergh";
            string email = "andreas__bergh@hotmail.com";
            string year = "1976";
            var month = DateTime.Now.Month.ToString().PadLeft(2, '0');
            var day = DateTime.Now.Day.ToString().PadLeft(2, '0');
            var bDay = string.Format("{0}{1}{2}", year, month, day);
            DateTime getDate = DateTime.ParseExact(bDay, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            //Act
            Person p1 = new Person(firstname, lastname, email, getDate);
            //Assert
            Assert.Equal(p1.DateOfBirth, getDate);
            bool isBirthday = p1.CheckIfBirthday(getDate);
            Assert.True(isBirthday);
        }

        [Fact]
        public void testIfTodayIsBirthdayFail()
        {
            // Arrange 
            var bDay = "19761201";
            DateTime getDate = DateTime.ParseExact(bDay, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            //Act
            Person p1 = new Person("Andreas", "Bergh", "andreas__bergh@hotmail.com", getDate);
            bool isBirthday = p1.CheckIfBirthday(getDate);
            //Assert
            Assert.False(isBirthday);
        }
    }
}