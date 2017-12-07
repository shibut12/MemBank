using System;
using System.Linq;
using System.Collections.Generic;
using MemBank.Service.Enums;

namespace MemBank.Service
{
    public class Bank : IAccountMediator
    {
        public string Name{get;}
        public List<Account> accounts {get;set;}

        public Bank(string bankName)
        {
            this.Name = bankName;
            this.accounts = new List<Account>();
        }

        public bool AddAccount(AccountType type, string owner)
        {
            try 
            {
                Account account = AccountFactory.Create(type);
                account.AccountId = this.accounts.Count + 1;
                account.Owner = owner;
                this.accounts.Add(account);
            }
            catch(ArgumentException)
            {
                return false;
            }

            return true;
        }

        public decimal GetBalance(int accountId)
        {
            Account account = this.accounts.First(id=>id.AccountId == accountId);
            return account.Balance;
        }

        public bool Withdraw(int accountId, decimal amount)
        {
            Account account = this.accounts.First(id=>id.AccountId == accountId);
            if(account.WithdrawLimit==0.0M || account.WithdrawLimit>amount)
            {
                if(account.Balance>amount)
                {
                    account.Balance -= amount;
                    return true;
                }
                else
                {
                    throw new InvalidOperationException(string.Format("Insufficient balance in account: {0}", accountId));
                }
            }
            else
            {
                throw new InvalidOperationException(string.Format("requested amount is morethan the withdraw limt on account: {0}", accountId));
            }
        }

        public bool Deposit(int accountId, decimal amount)
        {
            try
            {
                Account account = this.accounts.First(id=>id.AccountId == accountId);
                account.Balance += amount;
                return true;
            }
            catch(Exception)
            {
                throw new InvalidOperationException(string.Format("Unable to locate account for : {0}", accountId));
            }
        }

        public bool Transfer(int fromAccountId, int toAccountId, decimal amount)
        {
            Account fromAccount = this.accounts.First(id=>id.AccountId == fromAccountId);
            Account toAccount = this.accounts.First(id=>id.AccountId == toAccountId);
            
            if(fromAccount.Balance>amount)
            {
                fromAccount.Balance -= amount;
                toAccount.Balance += amount;
                return true;
            }
            else
            {
                throw new InvalidOperationException(string.Format("Insufficient balance in account: {0}", fromAccountId));
            }
        }
    }
}
