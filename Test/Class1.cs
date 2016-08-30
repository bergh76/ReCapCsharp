using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestProject1;
using Xunit;

namespace Test
{
    public class Class1
    {

        [Fact]
        public void testAllPassed()
        {      // In-line setup     
            Person p1 = new Person("Andreas", "Bergh", "andreas__bergh@hotmail.com", new DateTime(19761201));
            Assert.Equal(p1.FirstName ,"Andreas");
            Assert.Equal(p1.LastName, "Bergh");
            Assert.Equal(p1.Email, "andreas__bergh@hotmail.com");
            Assert.Equal(p1.DateOfBirth, new DateTime(19761201));
        }
        [Fact]
        public void testNoEmailPassed()
        {
            // In-line setup     
            Person p2 = new Person("Knut", "Kragballe", new DateTime(17920518));
            Assert.Equal(p2.FirstName, "Andreas");
            Assert.Equal(p2.LastName, "Bergh");
            Assert.Equal(p2.DateOfBirth, new DateTime(19761201));
        }
        [Fact]
        public void testNoDatePassed()
        {      // In-line setup     
            Person p3 = new Person("Sven", "Mellander", "sven.mellander&hotmail.com");
            Assert.Equal(p3.FirstName, "Sven");
            Assert.Equal(p3.LastName, "Mellander");
            Assert.Equal(p3.Email, "sven.menlander&hotmail.com");
        }

        //[Fact]
        //public void testStatusFailed()
        //{
        //    // In-line setup     
        //    Person p4 = new Person("Andreas", "Bergh", "andreas__bergh%hotmail.com", new DateTime(19761201));            
        //}
    }
}