using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC2_EmployeeManagementSystem
{
    class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public int Experience { get; set; }

        // Constructor
        public Employee(int empId, string name, string department, double salary, int experience)
        {
            EmpId = empId;
            Name = name;
            Department = department;
            Salary = salary;
            Experience = experience;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            List<Employee> employeesList = new List<Employee>
            {
                new Employee(101, "Keerthi", "IT", 75000, 6),
                new Employee(102, "Veda", "HR", 45000, 3),
                new Employee(103, "Anil", "Finance", 55000, 8),
                new Employee(104, "Chaitanya", "Sales", 40000, 2),
                new Employee(105, "Arjun", "IT", 90000, 10),
                new Employee(106, "Shailaja", "Finance", 60000, 4),
                new Employee(107, "Esha", "HR", 52000, 7),
                new Employee(108, "Cherry", "Sales", 48000, 5),
                new Employee(109, "Amit", "IT", 65000, 6),
                new Employee(110, "Spoorthi", "Finance", 70000, 9)
            };

            Console.WriteLine("=== All Employees ===");
            DisplayEmployees(employeesList);

            // Filtering using Lambda
            var highSalary = employeesList.Where(e => e.Salary > 50000).ToList();
            var itDept = employeesList.Where(e => e.Department == "IT").ToList();
            var experienced = employeesList.Where(e => e.Experience > 5).ToList();
            var nameStartsWithA = employeesList.Where(e => e.Name.StartsWith("A")).ToList();

            Console.WriteLine("\n=== Employees with Salary > 50,000 ===");
            DisplayEmployees(highSalary);

            Console.WriteLine("\n=== Employees in IT Department ===");
            DisplayEmployees(itDept);

            Console.WriteLine("\n=== Employees with Experience > 5 years ===");
            DisplayEmployees(experienced);

            Console.WriteLine("\n=== Employees whose name starts with 'A' ===");
            DisplayEmployees(nameStartsWithA);


            // Sorting using Lambda
            var sortByName = employeesList.OrderBy(e => e.Name).ToList();
            var sortBySalaryDesc = employeesList.OrderByDescending(e => e.Salary).ToList();
            var sortByExperienceAsc = employeesList.OrderBy(e => e.Experience).ToList();

            Console.WriteLine("\n=== Sorted by Name (A-Z) ===");
            DisplayEmployees(sortByName);

            Console.WriteLine("\n=== Sorted by Salary (High => Low) ===");
            DisplayEmployees(sortBySalaryDesc);

            Console.WriteLine("\n=== Sorted by Experience (Low => High) ===");
            DisplayEmployees(sortByExperienceAsc);

            var promotionList = employeesList.Where(e => e.Experience > 5 && e.Salary < 70000).ToList();
            Console.WriteLine("\n=== Promotion List ===");
            DisplayEmployees(promotionList);

            Console.ReadLine();
        }

        static void DisplayEmployees(List<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.EmpId} | {emp.Name} | {emp.Department} | {emp.Salary:C} | {emp.Experience} yrs");
            }
        }
    }
}
