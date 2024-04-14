using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
                    Console.WriteLine("\n\tCreate Department Section (Back - b)\n");
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
                                Console.WriteLine("\nYou must enter numbers between 0-1!\n");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nYou must enter numbers!\n");
                    }
                }
                else
                {
                    Console.WriteLine($"\n\tWelcome to {newDepartment.Name} (Back - b)\n");
                    Console.WriteLine("1. Add Employee");
                    Console.WriteLine("2. Get All Employees information");
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
                            case 2:
                                GetAllEmployees(newDepartment);
                                break;
                            case 3:
                                GetByIdEmployee(newDepartment);
                                break;
                            case 4:
                                GetBySearchEmployee(newDepartment);
                                break;
                            case 5:
                                DeleteEmployee(newDepartment);
                                break;
                            default:
                                Console.WriteLine("\nYou must enter numbers between 0-5!\n");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nYou must enter numbers!\n");
                    }
                }
            }
            Console.WriteLine("\t Program has been stopped");

        }

        public static void CreateDeparment(Department oldDepartment)
        {
            Console.WriteLine("\n\t Give A Name For Department");

            Console.Write("\nDepartment Name: ");
            string name = Console.ReadLine().Trim();

            if (name == "b") return;

            oldDepartment.Name = name;

            Console.WriteLine("\nDepartment has been created!");
        }

        public static void AddEmployee(Department oldDepartment)
        {
            Console.WriteLine("\n\tAdd Employee Section\n");

            Employee newEmployee = new Employee();

        PATH1:
            Console.Write("Employee First Name: ");
            string inputFirtName = Console.ReadLine().Trim();

            if (inputFirtName == "b") return;

            newEmployee.FirstName = inputFirtName;

        PATH2:
            Console.Write("Employee Last Name: ");
            string inputLastName = Console.ReadLine().Trim();

            if (inputLastName == "b") goto PATH1;

            newEmployee.LastName = inputLastName;

        PATH3:
            Console.Write("Employee Age: ");
            string inputAge = Console.ReadLine().Trim();

            if (inputAge == "b") goto PATH2;

            if (byte.TryParse(inputAge, out byte age))
            {
                newEmployee.Age = age;
                if (age < 18 || age > 70)
                {
                    goto PATH3;
                }
            }
            else
            {
                Console.WriteLine("\nYou must enter number between 18-70\n");
            }

        PATH4:
            Console.Write("Employee Experience Year: ");
            string inputExp = Console.ReadLine().Trim();

            if (inputExp == "b") goto PATH3;


            if (int.TryParse(inputExp, out int experience))
            {
                newEmployee.Experience = experience;
            }
            else
            {
                Console.WriteLine("\nYou must enter the number of exp year!\n");
                goto PATH4;
            }

        PATH9:
            Console.Write("Employee Address: ");
            string inputAddress = Console.ReadLine().Trim();

            if (inputAddress == "b") goto PATH4;

            newEmployee.Address = inputAddress;

        PATH5:
            Console.Write("Employee Birthday: ");
            string inputBirthday = Console.ReadLine().Trim();

            if (inputBirthday == "b") goto PATH9;

            if (int.TryParse(inputBirthday, out int birthday))
            {
                newEmployee.BirthDay = birthday;
                if(2024 - birthday != age)
                {
                    goto PATH5;
                }
            }
            else
            {
                Console.WriteLine("\nYou must enter the number of birtday's year!\n");
                goto PATH5;
            }

        PATH6:
            Console.Write("Employee Contact Number: ");
            string inputContactNumber = Console.ReadLine().Trim();

            if (inputContactNumber == "b") goto PATH5;

            if (!inputContactNumber.Contains("+994"))
            {
                Console.WriteLine("\nYou must write this number series before! (+994 XX XXX XX XX)\n");
                goto PATH6;
            }
            else
            {
                newEmployee.ContactNumber = inputContactNumber;
            }

        PATH7:
            Console.Write("Employee Salary: ");
            string inputSalary = Console.ReadLine().Trim();

            if (inputSalary == "b") goto PATH6;

            if (decimal.TryParse(inputSalary, out decimal salary))
            {
                newEmployee.Salary = salary;
            }
            else
            {
                Console.WriteLine("\nYou must enter a decimal number!\n");
                goto PATH7;
            }

        PATH8:
            Console.WriteLine("\n\tEmployee Roles\n");
            Console.WriteLine("1. CEO");
            Console.WriteLine("2. Manager");
            Console.WriteLine("3. Internar");
            Console.WriteLine("4. Employee");
            Console.Write("Employee Role Number: ");
            string inputRole = Console.ReadLine().Trim();

            if (inputRole == "b") goto PATH7;

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
                        goto PATH8;
                }
            }
            else
            {
                Console.WriteLine("\nYou must enter numbers!\n");
                goto PATH8;
            }


            oldDepartment.Create(newEmployee);

        }

        public static void DeleteEmployee(Department oldDepartment)
        {
            Console.WriteLine("\n\tDelete Employee Section\n");
        PATH1:
            Console.Write("Enter Employee ID: ");
            string id = Console.ReadLine().Trim();

            if (id == "b") return;

            if (int.TryParse(id, out int employeeId))
            {
                if (oldDepartment.Delete(employeeId))
                {
                    Console.WriteLine("\nEmployee has been deleted!\n");
                }
                else
                {
                    Console.WriteLine("There is no employee id in database!\n");
                    goto PATH1;
                }
            }
            else
            {
                Console.WriteLine("\nPlease, enter a number for employee id!\n");
                goto PATH1;
            }

        }

        public static void GetAllEmployees(Department oldDepartment)
        {
            Console.WriteLine("\n\tGet All Employee Section\n");

            Console.WriteLine("Id | First Name | Last Name | Age | Exp | Address | Birthday | Contact Number | Salary | Employee Role\n");
            foreach (Employee emp in oldDepartment.GetAll())
            {
                if (emp != null)
                {
                    Console.WriteLine($"{emp.Id} | {emp.FirstName} | {emp.LastName} | {emp.Age} | {emp.Experience} | {emp.Address} | {emp.BirthDay} | {emp.ContactNumber} | {emp.Salary} | {emp.EmployeeRole}");
                }
            }
        }

        public static void GetByIdEmployee(Department oldDepartment)
        {
            Console.WriteLine("\n\tGet By Id Employee Section\n");

        PATH1:
            Console.Write("Enter Employee ID: ");
            string id = Console.ReadLine().Trim();

            if (id == "b") return;

            Console.WriteLine();
            if (int.TryParse(id, out int employeeId))
            {
                Employee emp = oldDepartment.GetById(employeeId);

                if (emp != null)
                {
                    Console.WriteLine("Id | First Name | Last Name | Age | Exp | Address | Birthday | Contact Number | Salary | Employee Role\n");

                    Console.WriteLine($"{emp.Id} | {emp.FirstName} | {emp.LastName} | {emp.Age} | {emp.Experience} | {emp.Address} | {emp.BirthDay} | {emp.ContactNumber} | {emp.Salary} | {emp.EmployeeRole}");
                }
                else
                {
                    Console.WriteLine("\nThere is no employee id in database!\n");
                    goto PATH1;
                }
            }
            else
            {
                Console.WriteLine("Please, enter a number for employee id!\n");
                goto PATH1;
            }

        }

        public static void GetBySearchEmployee(Department oldDepartment)
        {
            Console.WriteLine("\n\tGet By Search Employee Section\n");

            Console.WriteLine("Search Engine related to these: First Name, Last Name, Salary == Search");
            Console.Write("Search Bar: ");
            string search = Console.ReadLine().Trim();

            if (search == "b") return;


            Console.WriteLine("\nId | First Name | Last Name | Age | Exp | Address | Birthday | Contact Number | Salary | Employee Role\n");

            foreach (Employee emp in oldDepartment.GetBySearch(search))
            {
                if (emp != null)
                {
                    Console.WriteLine($"{emp.Id} | {emp.FirstName} | {emp.LastName} | {emp.Age} | {emp.Experience} | {emp.Address} | {emp.BirthDay} | {emp.ContactNumber} | {emp.Salary} | {emp.EmployeeRole}");
                }
            }

        }


    }
}
