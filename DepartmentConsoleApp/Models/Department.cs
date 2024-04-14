namespace DepartmentConsoleApp.Models
{
    public class Department
    {
        public string Name { get; set; }
        public int EmployeeCount { get; set; }
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
            Array.Resize(ref Employees, Employees.Length + 1);
            Employees[Employees.Length - 1] = employee;
        }

        public void Delete(int id)
        {
            for (int i = 0; i < Employees.Length; i++)
            {
                if (Employees[i].Id == id)
                {
                    Employees[i] = null;
                }
            }
        }

        public Employee[] GetAll()
        {
            return Employees;
        }

        public Employee GetBySearch(string search)
        {
            foreach (Employee emp in Employees)
            {
                if (emp.FirstName.Contains(search)
                    || emp.LastName.Contains(search)
                    || emp.Salary.ToString().Contains(search))
                {
                    return emp;
                }
            }

            return null;
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
