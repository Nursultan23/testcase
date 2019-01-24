using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QueueTest.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string PhoneNumber { get; }

        public Person(string PhoneNumber)
        {
            if (!(new Regex(@"^(\+)([0-9]+$)")).IsMatch(PhoneNumber) || PhoneNumber.Length != 8)
                throw new Exception(string.Format("Тел. номер - {0} не соответствует Шаблону +0000000",PhoneNumber));
            
            this.PhoneNumber = PhoneNumber;
        }

    }
}
