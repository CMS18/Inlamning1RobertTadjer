using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMBankRobertT.App.Models
{
    public class Account
    {
        public string ErrorMessage = "";
        public string SuccessMessage = "";

        public const string AmountLargerThanBalanceInFromAccount = "Du kan inte föra över mer än summan som finns på kontot";
        public const string CantTransferBetweenSameAccounts = "Du kan inte föra över pengar till samma konto";
        public const string AtLeastOneOfTheAccountsDoesntExist = "Åtminstone ett av kontona finns inte";
        public const string CantTransferNegativeAmounts = "Du kan inte föra över mindre än 0kr";

        public int AccountId { get; set; }
        public decimal Balance { get; set; }

        public Account Transfer(decimal amount, Account fromAccount, Account toAccount)
        {
            if (amount >= 0)
            {
                if (fromAccount == null || toAccount == null)
                {
                    ErrorMessage = AtLeastOneOfTheAccountsDoesntExist;
                    SuccessMessage = "";
                }
                else
                {
                    if (fromAccount != toAccount)
                    {
                        if (amount < fromAccount.Balance)
                        {
                            fromAccount.Balance -= amount;
                            toAccount.Balance += amount;
                            SuccessMessage = $"Du har fört över {amount}kr från konto {fromAccount.AccountId} till konto {toAccount.AccountId}.";
                            ErrorMessage = "";
                        }
                        else
                        {
                            ErrorMessage = AmountLargerThanBalanceInFromAccount;
                            SuccessMessage = "";
                        }
                    }
                    else
                    {
                        ErrorMessage = CantTransferBetweenSameAccounts;
                        SuccessMessage = "";
                    }
                }
            }
            else
            {
                ErrorMessage = CantTransferNegativeAmounts;
                SuccessMessage = "";
            }
            return fromAccount;
        }

    }
}
