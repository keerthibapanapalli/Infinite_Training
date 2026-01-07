using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeRecord
{
    public class EmployeeRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public bool IsVeteran { get; set; }

        // Expression-body
        public override string ToString() => $"{Name} ({Role})";
    }

    //Dependency Injection
    public interface IEmployeeDataReader
    {
        EmployeeRecord GetEmployeeRecord(int employeeId);
    }

    public class MockEmployeeDataReader : IEmployeeDataReader
    {

        public EmployeeRecord GetEmployeeRecord(int employeeId)
        {
            switch (employeeId)
            {
                case 101:
                    return new EmployeeRecord { Id = 101, Name = "keerthi", Role = "Developer", IsVeteran = false };

                case 102:
                    return new EmployeeRecord { Id = 102, Name = "Spoorthi", Role = "Manager", IsVeteran = true };

                case 103:
                    return new EmployeeRecord { Id = 103, Name = "Shailaja", Role = "Intern", IsVeteran = false };

                default:
                    return new EmployeeRecord { Id = employeeId, Name = "Sritisha", Role = "HR", IsVeteran = false };
            }
        }
    //    public EmployeeRecord GetEmployeeRecord(int employeeId) =>
    //employeeId switch
    //{
    //    101 => new EmployeeRecord { Id = 101, Name = "keerthi", Role = "Developer", IsVeteran = false },
    //    102 => new EmployeeRecord { Id = 102, Name = "Spoorthi", Role = "Manager", IsVeteran = true },
    //    103 => new EmployeeRecord { Id = 103, Name = "Shailaja", Role = "Intern", IsVeteran = false },
    //    _ => new EmployeeRecord { Id = employeeId, Name = "Sritisha", Role = "HR", IsVeteran = false }
    //};

    }

    //Dictionary Initializer
    public class PayrollProcessor
    {
        private readonly IEmployeeDataReader _dataReader;

        private static readonly Dictionary<int, decimal> BaseSalaries = new Dictionary<int, decimal>
        {
            [101] = 65000m,
            [102] = 120000m,
            [103] = 20000m
        };

        public PayrollProcessor(IEmployeeDataReader dataReader) => _dataReader = dataReader;

        // Pattern Matching
        public decimal CalculateTotalCompensation(int employeeId)
        {
            var emp = _dataReader.GetEmployeeRecord(employeeId);
            decimal baseSalary = BaseSalaries.ContainsKey(employeeId) ? BaseSalaries[employeeId] : 0m;


            decimal bonus = 0m;

            if (emp.Role == "Manager" && emp.IsVeteran)
            {
                bonus = 10000m;
            }
            else if (emp.Role == "Manager" && !emp.IsVeteran)
            {
                bonus = 5000m;
            }
            else if (emp.Role == "Developer")
            {
                bonus = 2000m;
            }
            else if (emp.Role == "Intern")
            {

                bonus = 500m;
            }

            //decimal bonus = emp switch
            //{
            //    { Role: "Manager", IsVeteran: true } => 10000m,
            //    { Role: "Manager", IsVeteran: false } => 5000m,
            //    { Role: "Developer" } => 2000m,
            //    { Role: "Intern" } => 500m,
            //    _ => 0m
            //};

            return baseSalary + bonus;


        }
    }
}
