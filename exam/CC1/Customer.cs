using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityBillingSystem
{
    internal class Customer
    {
        public static int customerCounter = 101;
        public int customerId;
        public string name;
        public decimal ratePerUnit = 6.53m;

        public Customer(string name)
        {
            this.customerId = customerCounter;
            customerCounter++;
            this.name = name;
        }

        public void CalculateBill(out decimal total, out decimal tax, out decimal netPayable, params decimal[] readings)
        {
            decimal usage = BillingUtils.CalculateUsage(readings);
            total = usage * ratePerUnit;
            tax = BillingUtils.CalculateTax(total);
            netPayable = total + tax + BillingUtils.serviceCharge;
        }

        public void PrintInvoice(decimal total, decimal tax, decimal netPayable)
        {
            Console.WriteLine("\n---------Utility Bill ------------");
            Console.WriteLine($"Customer ID       : {customerId}");
            Console.WriteLine($"Customer Name     : {name}");
            Console.WriteLine($"Rate per Unit     : {ratePerUnit:F2}");
            Console.WriteLine($"Service Charge    : {BillingUtils.serviceCharge:F2}");
            Console.WriteLine($"-------------------------------");
            Console.WriteLine($"Total Usage Cost  : {total:F2}");
            Console.WriteLine($"Tax (18%)         : {tax:F2}");
            Console.WriteLine($"Net Payable       : {netPayable:F2}");
            Console.WriteLine("-----------------------------------");
        }

    }
}
