using ALMBankRobertT.App.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ALMBankRobertT.Tests
{
    public class UnitTests
    {
        [Fact]
        public void WithdrawalOverDraft()
        {
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Robert",
                    CustomerId = 1,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 1,
                            Balance = 600M
                        }
                    }
                }
            };

            BankRepository.AddCustomers(customers);
            decimal amount = 800M;
            decimal expected = 600M;

            var actualAccount = BankRepository.Withdrawal(1, amount);

            Assert.Equal(expected, actualAccount.Balance, 2);
        }



        [Fact]
        public void Withdrawal_CantWithdrawFromNonExistingAccount()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Robert",
                    CustomerId = 1,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 3,
                            Balance = 600M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = 200M;
            string expected = BankRepository.AccountDoesNotExist;

            // Act
            BankRepository.Withdrawal(1, amount);

            // Assert
            Assert.Equal(expected, BankRepository.ErrorMessage);
        }


        [Fact]
        public void Deposit_CanMakeBasicDeposit()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Robert",
                   CustomerId = 1,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 4,
                            Balance = 600M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = 200M;
            decimal expected = 800M;

            // Act
            var account = BankRepository.Deposit(4, amount);

            // Assert
            Assert.Equal(expected, account.Balance, 2);
        }

        [Fact]
        public void Deposit_CantDepositNegativeAmount()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Ludde",
                    CustomerId = 5,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 5,
                            Balance = 600M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = -200M;
            decimal expected = 600M;

            // Act
            var account = BankRepository.Deposit(5, amount);

            // Assert
            Assert.Equal(expected, account.Balance, 2);
        }

        [Fact]
        public void Deposit_CantDepositToNonExistingAccount()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Robert",
                    CustomerId = 3,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 3,
                            Balance = 600M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = 200M;
            string expected = BankRepository.AccountDoesNotExist;

            // Act
            BankRepository.Deposit(1, amount);

            // Assert
            Assert.Equal(expected, BankRepository.ErrorMessage);
        }
    }

}