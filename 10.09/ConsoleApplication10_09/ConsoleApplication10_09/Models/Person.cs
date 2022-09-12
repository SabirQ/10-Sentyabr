using ConsoleApplication10_09.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10_09.Models
{
    public class Person:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public Person(string name,string surname,string phone, string mail)
        {
            Name = name;
            Surname = surname;
            Mail = mail;
            Phone = phone;
        }
    }
}
