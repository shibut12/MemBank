using System;
using Xunit;
using MemBank.Service;
using MemBank.Service.Enums;
using System.Linq;

namespace MemBank.Tests
{
    public class Sutbank
    {
        [Fact]
        public void BankShouldHaveAName()
        {
            var bank = new Bank("Bank Of Test");

            Assert.Equal(bank.Name, "Bank Of Test");
        }

        [Fact]
        public void BankShouldHaveCheckingAccount()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Checking, "Test Owner");
            Assert.True(status);
            Assert.Equal(bank.accounts.First().TypeName, "CHECKING");
            Assert.Equal(bank.accounts.First().AccountId, 1);
            Assert.Equal(bank.accounts.First().Balance, 0.0M);
        }

        [Fact]
        public void CheckingAccountShouldhaveAnOwner()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Checking, "Test Owner");
            Assert.True(status);
            Assert.Equal(bank.accounts.First().TypeName, "CHECKING");
            Assert.Equal(bank.accounts.First().Owner, "Test Owner");
            Assert.Equal(bank.accounts.First().AccountId, 1);
            Assert.Equal(bank.accounts.First().Balance, 0.0M);
        }

        [Fact]
        public void BankShouldHaveInvestmentAccount()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Investment, "Test Owner");
            Assert.True(status);
            Assert.Equal(bank.accounts.First().TypeName, "INVESTMENT");
            Assert.Equal(bank.accounts.First().AccountId, 1);
            Assert.Equal(bank.accounts.First().Balance, 0.0M);
        }

        [Fact]
        public void BankShouldHaveIndividualAccount()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Individual, "Test Owner");
            Assert.True(status);
            Assert.Equal(bank.accounts.First().TypeName, "INDIVIDUAL");
            Assert.Equal(bank.accounts.First().AccountId, 1);
            Assert.Equal(bank.accounts.First().Balance, 0.0M);
        }

        [Fact]
        public void IndividualAccountShouldHaveFiveHundredWithdrawLimit()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Individual, "Test Owner");
            Assert.True(status);
            Assert.Equal(bank.accounts.First().TypeName, "INDIVIDUAL");
            Assert.Equal(bank.accounts.First().AccountId, 1);
            Assert.Equal(bank.accounts.First().WithdrawLimit, 500.0M);
        }

        [Fact]
        public void BankShouldHaveCorporateAccount()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Corporate, "Test Owner");
            Assert.True(status);
            Assert.Equal(bank.accounts.First().TypeName, "CORPORATE");
            Assert.Equal(bank.accounts.First().AccountId, 1);
            Assert.Equal(bank.accounts.First().Balance, 0.0M);
        }

        [Fact]
        public void BankShouldSupportManyAccount()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Corporate, "Test Owner");
            Assert.True(status);
            status = bank.AddAccount(AccountType.Checking, "Test Owner");
            Assert.True(status);
            status = bank.AddAccount(AccountType.Individual, "Test Owner");
            Assert.True(status);
            status = bank.AddAccount(AccountType.Investment, "Test Owner");
            Assert.True(status);
            Assert.Equal(bank.accounts.Count, 4);
        }

        [Fact]
        public void BankShouldAllowDepositMoneyToCheckingAccount()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Checking, "Test Owner");
            Assert.True(status);
            bank.Deposit(1, 100.00M);
            Assert.Equal(bank.accounts.Count, 1);
            Assert.Equal(bank.GetBalance(1), 100.00M);
        }

        [Fact]
        public void BankShouldAllowDepositMoneyToInvestmentAccount()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Investment, "Test Owner");
            Assert.True(status);
            bank.Deposit(1, 400.00M);
            Assert.Equal(bank.accounts.Count, 1);
            Assert.Equal(bank.GetBalance(1), 400.00M);
        }

        [Fact]
        public void BankShouldAllowDepositMoneyToCorporateAccount()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Corporate, "Test Owner");
            Assert.True(status);
            bank.Deposit(1, 300.00M);
            Assert.Equal(bank.accounts.Count, 1);
            Assert.Equal(bank.GetBalance(1), 300.00M);
        }

        [Fact]
        public void BankShouldAllowDepositMoneyToIndividualAccount()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Individual, "Test Owner");
            Assert.True(status);
            bank.Deposit(1, 600.00M);
            Assert.Equal(bank.accounts.Count, 1);
            Assert.Equal(bank.GetBalance(1), 600.00M);
        }

        [Fact]
        public void BankShouldAllowWithdrawMoneyFromAllAccounts()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Individual, "Test Owner");
            status = bank.AddAccount(AccountType.Checking, "Test Owner");
            status = bank.AddAccount(AccountType.Corporate, "Test Owner");
            status = bank.AddAccount(AccountType.Investment, "Test Owner");
            bank.Deposit(1, 600.00M);
            bank.Deposit(2, 300.00M);
            bank.Deposit(3, 900.00M);
            bank.Deposit(4, 999.50M);

            bank.Withdraw(1, 100.00M);
            bank.Withdraw(2, 100.00M);
            bank.Withdraw(3, 100.00M);
            bank.Withdraw(4, 100.00M);

            Assert.Equal(bank.accounts.Count, 4);
            Assert.Equal(bank.GetBalance(1), 500.00M);
            Assert.Equal(bank.GetBalance(2), 200.00M);
            Assert.Equal(bank.GetBalance(3), 800.00M);
            Assert.Equal(bank.GetBalance(4), 899.50M);
        }

        [Fact]
        public void IndividualAccountSHouldHaveWithdrawLimitOf500()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Individual, "Test Owner");
            bank.Deposit(1, 5000.00M);

            Assert.Equal(bank.accounts.Count, 1);
            Assert.Throws<InvalidOperationException>(()=>bank.Withdraw(1, 600.00M));
        }
    }
}
