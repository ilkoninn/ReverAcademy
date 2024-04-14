using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentConsoleApp.Models;

namespace DepartmentConsoleApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Department newDepartment = new Department();
            bool running = true;


            Console.WriteLine("========== Welcome Department App ==========\n");
            while (running)
            {
                if (newDepartment.Name == null)
                {
                    Console.WriteLine("\tCreate Department Section\n");
                    Console.WriteLine("1. Give a name for department");
                    Console.WriteLine("0. Exit");
                    Console.Write("\nInput: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int number))
                    {
                        switch (number)
                        {
                            case 0:
                                running = false;
                                break;
                            case 1:
                                CreateDeparment(newDepartment);
                                break;
                            default:
                                Console.WriteLine("\nYou must enter numbers between 0-1!");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nYou must enter numbers!");
                    }
                }
                else
                {
                    Console.WriteLine($"\tWelcome to {newDepartment.Name}\n");
                    Console.WriteLine("1. Add Employee");
                    Console.WriteLine("2. Get All Employee information");
                    Console.WriteLine("3. Get by Id Employee information");
                    Console.WriteLine("4. Get by Search Employee information");
                    Console.WriteLine("5. Delete Employee");
                    Console.WriteLine("0. Exit");
                    Console.Write("\nInput: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int number))
                    {
                        switch (number)
                        {
                            case 0:
                                running = false;
                                break;
                            case 1:
                                AddEmployee(newDepartment);
                                break;
                            default:
                                Console.WriteLine("\nYou must enter numbers between 0-5!");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nYou must enter numbers!");
                    }
                }
            }
            Console.WriteLine("\t Program has been stopped");

        }

        public static void CreateDeparment(Department oldDepartment)
        {
            Console.Write("\nDepartment Name: ");
            string name = Console.ReadLine();

            oldDepartment.Name = name;

            Console.WriteLine("\nDepartment has been created!\n");
        }

        public static void AddEmployee(Department oldDepartment)
        {
            Console.WriteLine("\n\tAdd Employee Section\n");

            Employee newEmployee = new Employee();

            Console.Write("Employee First Name: ");
            string inputFirtName = Console.ReadLine();

            newEmployee.FirstName = inputFirtName;

            Console.Write("Employee Last Name: ");
            string inputLastName = Console.ReadLine();

            newEmployee.LastName = inputLastName;

        PATH1:
            Console.Write("Employee Age: ");
            string inputAge = Console.ReadLine();
            if (byte.TryParse(inputAge, out byte age))// 0-255, 1000
            {
                newEmployee.Age = age;
                if (age < 18 || age > 70)
                {
                    goto PATH1;
                }
            }
            else
            {
                Console.WriteLine("\nYou must enter number between 18-70\n");
            }

        PATH2:
            Console.Write("Employee Experience Year: ");
            string inputExp = Console.ReadLine();

            if (int.TryParse(inputExp, out int experience))
            {
                newEmployee.Experience = experience;
            }
            else
            {
                Console.WriteLine("\nYou must enter the number of exp year!\n");
                goto PATH2;
            }

            Console.Write("Employee Address: ");
            string inputAddress = Console.ReadLine();

            newEmployee.Address = inputAddress;

        PATH3:
            Console.Write("Employee Birthday: ");
            string inputBirthday = Console.ReadLine();

            if (int.TryParse(inputBirthday, out int birthday))
            {
                newEmployee.BirthDay = birthday;
            }
            else
            {
                Console.WriteLine("\nYou must enter the number of birtday's year!\n");
                goto PATH3;
            }

        PATH4:
            Console.Write("Employee Contact Number: ");
            string inputContactNumber = Console.ReadLine();

            if (!inputContactNumber.Contains("+994"))
            {
                Console.WriteLine("\nYou must write this number series before! (+994 XX XXX XX XX)\n");
                goto PATH4;
            }
            else
            {
                newEmployee.ContactNumber = inputContactNumber;
            }

        PATH5:
            Console.Write("Employee Salary: ");
            string inputSalary = Console.ReadLine();

            if (decimal.TryParse(inputSalary, out decimal salary))
            {
                newEmployee.Salary = salary;
            }
            else
            {
                Console.WriteLine("\nYou must enter a decimal number!\n");
                goto PATH5;
            }

        PATH6:
            Console.WriteLine("\n\tEmployee Roles\n");
            Console.WriteLine("1. CEO");
            Console.WriteLine("2. Manager");
            Console.WriteLine("3. Internar");
            Console.WriteLine("4. Employee");
            Console.Write("Employee Role Number: ");
            string inputRole = Console.ReadLine();

            if (int.TryParse(inputRole, out int role))
            {
                switch (role)
                {
                    case 1:
                        newEmployee.EmployeeRole = EmployeeRoles.CEO;
                        break;
                    case 2:
                        newEmployee.EmployeeRole = EmployeeRoles.Manager;
                        break;
                    case 3:
                        newEmployee.EmployeeRole = EmployeeRoles.Internar;
                        break;
                    case 4:
                        newEmployee.EmployeeRole = EmployeeRoles.Employee;
                        break;
                    default:
                        Console.WriteLine("\nYou must enter number between 1-4!\n");
                        goto PATH6;
                }
            }
            else
            {
                Console.WriteLine("\nYou must enter numbers!\n");
                goto PATH6;
            }


            oldDepartment.Create(newEmployee);
        }


    }
}
