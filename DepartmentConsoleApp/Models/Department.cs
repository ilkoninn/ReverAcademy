using System.Net.Http.Headers;

namespace DepartmentConsoleApp.Models
{
    public class Department
    {
        public string Name { get; set; }
        public int EmployeeCount { get; set; }
        public static int _id = 0;
        public Employee[] Employees;

        public Department()
        {
            Employees = new Employee[0];
        }

        public Department(string name)
        {
            Name = name;
        }

        public void Create(Employee employee)
        {
            _id += 1;
            employee.Id = _id;
            
            Array.Resize(ref Employees, Employees.Length + 1);
            Employees[Employees.Length - 1] = employee;

            Console.WriteLine("\nNew employee has been created!\n");
        }

        public bool Delete(int id)
        {
            for (int i = 0; i < Employees.Length; i++)
            {
                if (Employees[i].Id == id)
                {
                    Employees[i] = null;

                    return true;                    
                }
            }

            return false;
        }

        public Employee[] GetAll()
        {
            return Employees;
        }

        public Employee[] GetBySearch(string search)
        {
            Employee[] searchedEmployees = new Employee[0];

            foreach (Employee emp in Employees)
            {
                if (emp.FirstName.ToLower().Contains(search)
                    || emp.LastName.ToLower().Contains(search)
                    || emp.Salary.ToString() == search)
                {
                    Array.Resize(ref searchedEmployees, searchedEmployees.Length + 1);
                    searchedEmployees[searchedEmployees.Length - 1] = emp;
                }
            }

            return searchedEmployees;
        }

        public Employee GetById(int id)
        {
            foreach (Employee emp in Employees)
            {
                if (emp.Id == id)
                {
                    return emp;
                }
            }   

            return null;
        }


    }
}
