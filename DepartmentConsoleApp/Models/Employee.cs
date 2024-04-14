using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentConsoleApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private byte _age;
        public byte Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 18 || value > 70)
                {
                    Console.WriteLine("\nEmployee age must be at least 18!\n");
                }
                else
                {
                    _age = value;
                }
            }
        }
        public int Experience { get; set; }
        public string Address { get; set; }
        public int BirthDay { get; set; }
        public string ContactNumber { get; set; }
        public decimal Salary { get; set; }
        public EmployeeRoles EmployeeRole { get; set; }

        public Employee()
        {

        }

        //public Employee(string firstName, string lastName,
        //    int experience, string address, int birthDay, string contactNumber,
        //    decimal salary, EmployeeRoles role)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Experience = experience;
        //    Address = address;
        //    BirthDay = birthDay;
        //    ContactNumber = contactNumber;
        //    Salary = salary;
        //    EmployeeRole = role;
        //}

    }
}
