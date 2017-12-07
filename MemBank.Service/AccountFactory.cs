using System;
using MemBank.Service.Enums;

namespace MemBank.Service
{
    public static class AccountFactory
    {
        public static Account Create(AccountType type)
        {
            switch(type)
            {
                case AccountType.Checking:
                    return CreateCheckingAccount();
                case AccountType.Investment:
                    return CreateInvestmentAccount();
                case AccountType.Individual:
                    return CreateIndividualAccount();
                case AccountType.Corporate:
                    return CreateCorporateAccount();
                default:
                    throw new ArgumentException(string.Format("The account type: {0},  has not implemented yet.", (int)type));
            }
        }

        private static Account CreateCorporateAccount()
        {
            Account account = new Account();
            account.Balance = 0.0M;
            account.TypeName = "CORPORATE";
            account.WithdrawLimit = 0.0M;

            return account;
        }

        private static Account CreateIndividualAccount()
        {
            Account account = new Account();
            account.Balance = 0.0M;
            account.TypeName = "INDIVIDUAL";
            account.WithdrawLimit = 500.0M;

            return account;
        }

        private static Account CreateInvestmentAccount()
        {
            Account account = new Account();
            account.Balance = 0.0M;
            account.TypeName = "INVESTMENT";
            account.WithdrawLimit = 0.0M;

            return account;
        }

        private static Account CreateCheckingAccount()
        {
            Account account = new Account();
            account.Balance = 0.0M;
            account.TypeName = "CHECKING";
            account.WithdrawLimit = 0.0M;

            return account;
        }
    }
}