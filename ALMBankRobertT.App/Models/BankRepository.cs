using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMBankRobertT.App.Models
{
    public class BankRepository
    {
        public static string ErrorMessage = "";
        public static string SuccessMessage = "";

        public const string AccountDoesNotExist = "No account with such an ID exists.";

        private static List<Customer> Customers { get; set; }
        public static List<Customer> GetCustomers()
        {
            return Customers;
        }

        public static void AddCustomers(List<Customer> customers)
        {
            Customers = customers;
        }

        public static List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            for (int i = 0; i < Customers.Count; i++)
            {              
                accounts.AddRange(Customers[i].Accounts);
            }
            return accounts;
        }

        public static Account Withdrawal(int accountId, decimal amount)
        {
            var account = GetAccount(accountId);

            if (amount < 0)
            {
                ErrorMessage = "You can't widthdraw negative amounts";
            }
            else
            {
                if (account != null)
                {
                    if (amount <= account.Balance)
                    {
                        account.Balance -= amount;
                        SuccessMessage = $"You successfully withdrew {amount} SEK from account {accountId}. Current balance: {account.Balance} SEK.";
                        ErrorMessage = "";
                    }
                    else
                    {
                        ErrorMessage = "You can't widthdraw more than the balance of the account.";
                        SuccessMessage = "";
                    }
                }
                else
                {
                    ErrorMessage = AccountDoesNotExist;
                    SuccessMessage = "";
                }
            }

            return account;
        }

        public static Account Deposit(int accountId, decimal amount)
        {
            var account = GetAccount(accountId);

            if (account != null)
            {
                if (amount < 0)
                {
                    ErrorMessage = "You can't deposit negative amounts.";
                    SuccessMessage = "";
                }
                else
                {
                    account.Balance += amount;
                    SuccessMessage = $"You successfully deposited {amount} SEK to account {accountId}. Current balance: {account.Balance} SEK.";
                    ErrorMessage = "";
                }
            }
            else
            {
                ErrorMessage = AccountDoesNotExist;
                SuccessMessage = "";
            }

            return account;
        }

        private static Account GetAccount(int accountId)
        {
            var account = GetAccounts().Find(a => a.AccountId == accountId);
            return account;
        }
    }
}

