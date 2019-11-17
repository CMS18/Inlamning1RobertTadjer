using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMBankRobertT.App.Models.ViewModels
{
    public class BankRepositoryViewModel
    {
        public List<Customer> Customers { get; set; }

        public BankRepositoryViewModel()
        {
            Customers = BankRepository.GetCustomers();
        }
    }
}
