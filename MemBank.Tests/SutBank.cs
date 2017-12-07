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

            var status = bank.AddAccount(AccountType.Checking);
            Assert.True(status);
            Assert.Equal(bank.accounts.First().TypeName, "CHECKING");
            Assert.Equal(bank.accounts.First().AccountId, 1);
            Assert.Equal(bank.accounts.First().Balance, 0.0M);
        }

        [Fact]
        public void BankShouldHaveInvestmentAccount()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Investment);
            Assert.True(status);
            Assert.Equal(bank.accounts.First().TypeName, "INVESTMENT");
            Assert.Equal(bank.accounts.First().AccountId, 1);
            Assert.Equal(bank.accounts.First().Balance, 0.0M);
        }

        [Fact]
        public void BankShouldHaveIndividualAccount()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Individual);
            Assert.True(status);
            Assert.Equal(bank.accounts.First().TypeName, "INDIVIDUAL");
            Assert.Equal(bank.accounts.First().AccountId, 1);
            Assert.Equal(bank.accounts.First().Balance, 0.0M);
        }

        [Fact]
        public void IndividualAccountShouldHaveFiveHundredWithdrawLimit()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Individual);
            Assert.True(status);
            Assert.Equal(bank.accounts.First().TypeName, "INDIVIDUAL");
            Assert.Equal(bank.accounts.First().AccountId, 1);
            Assert.Equal(bank.accounts.First().WithdrawLimit, 500.0M);
        }

        [Fact]
        public void BankShouldHaveCorporateAccount()
        {
            var bank = new Bank("Bank Of Test");

            var status = bank.AddAccount(AccountType.Corporate);
            Assert.True(status);
            Assert.Equal(bank.accounts.First().TypeName, "CORPORATE");
            Assert.Equal(bank.accounts.First().AccountId, 1);
            Assert.Equal(bank.accounts.First().Balance, 0.0M);
        }
    }
}
