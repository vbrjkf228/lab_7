using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Company
    {
        public string Name { get; set; }
        public string MainOfficeCity { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public bool IsFullTimeEmployee { get; set; }

        public Company() { }

        public Company(string name, string mainOfficeCity, string position, decimal salary, bool isFullTimeEmployee)
        {
            Name = name;
            MainOfficeCity = mainOfficeCity;
            Position = position;
            Salary = salary;
            IsFullTimeEmployee = isFullTimeEmployee;
        }

        public Company(Company other)
        {
            Name = other.Name;
            MainOfficeCity = other.MainOfficeCity;
            Position = other.Position;
            Salary = other.Salary;
            IsFullTimeEmployee = other.IsFullTimeEmployee;
        }
    }
}
