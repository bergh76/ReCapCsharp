using System;

namespace ConsoleApp
{
     internal class Employee : IPayable
    {
        private double _salary;
        private string _email;

        public Employee()
        {
            _salary = 0.0;
            _email = "";
        }
        public Employee(double salary, string email)
        { 
            _salary = salary;
            _email = email;
        }

        double IPayable.getRetrieveAmountDue()
        {
            return _salary;
        }

        double IPayable.getAddToAmountDue()
        {
            return _salary;
        }

        string IPayable.getPaymentAddress()
        {
            return _email;
        }
        
    }
}