using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMBankRobertT.App.Models
{
    public class BankRepository
    {
        private static List<Customer> Customers { get; set; }
        public static List<Customer> GetCustomers()
        {
            return Customers;
        }

        public static void AddCustomers(List<Customer> customers)
        {
            Customers = customers;
        }
    }
}
