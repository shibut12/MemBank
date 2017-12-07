using System;
using System.Collections.Generic;
using MemBank.Service.Enums;

namespace MemBank.Service
{
    public class Bank
    {
        public string Name{get;}
        public List<Account> accounts {get;set;}

        public Bank(string bankName)
        {
            this.Name = bankName;
            this.accounts = new List<Account>();
        }

        public bool AddAccount(AccountType type)
        {
            try 
            {
                Account account = AccountFactory.Create(type);
                account.AccountId = this.accounts.Count + 1;
                this.accounts.Add(account);
            }
            catch(ArgumentException)
            {
                return false;
            }

            return true;
        }
    }
}
