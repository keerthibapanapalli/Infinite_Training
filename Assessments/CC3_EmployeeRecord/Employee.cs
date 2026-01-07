using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_properties
{
    public class Employee
    {
        public int EmployeeId {  get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
    }

    internal class EmployeeList_withIndex
    {
        List<Employee> employeelist = new List<Employee>
    {
        new Employee() { EmployeeId = 1, EmployeeName = "Keerthi", Gender = "Female" },
        new Employee() { EmployeeId = 2, EmployeeName = "Spoorthi", Gender = "Female" },
        new Employee() { EmployeeId = 3, EmployeeName = "Shailu", Gender = "Female" }
    };
    public string this[int empid]
        {
            get
            {
                return employeelist.FirstOrDefault(e => e.EmployeeId == empid)?.EmployeeName;
            }
            set
            {
                employeelist.FirstOrDefault(e => e.EmployeeId == empid).EmployeeName = value;
            }
        }
    }
}
