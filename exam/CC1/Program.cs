using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityBillingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Online Utility Billing System ===");

            Console.Write("Enter number of customers: ");
            int count = Convert.ToInt16(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\n--- Customer {i + 1} ---");

                Console.Write("Customer Name: ");
                string name = Console.ReadLine();

                Console.Write("Monthly Usage Readings (in units, space-separated): ");
                string[] input = Console.ReadLine().Split(' ');
                decimal[] readings = Array.ConvertAll(input, decimal.Parse);

                Customer customer = new Customer(name);
                customer.CalculateBill(out decimal total, out decimal tax, out decimal netPayable, readings);
                customer.PrintInvoice(total, tax, netPayable);
            }

            Console.WriteLine("\n=== Billing Complete ===");
            Console.ReadLine();
        }
    }
}
