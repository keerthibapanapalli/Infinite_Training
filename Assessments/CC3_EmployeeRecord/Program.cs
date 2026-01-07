using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecord
{
    class Program
    {
        static void Main()
        {
            IEmployeeDataReader reader = new MockEmployeeDataReader();
            var payroll = new PayrollProcessor(reader);

            foreach (var id in new[] { 101, 102, 103, 999 })
            {
                var total = payroll.CalculateTotalCompensation(id);
                Console.WriteLine($"Employee {id}: Total Compensation = {total:C}");
            }
            Console.ReadLine();
        }
    }
}


