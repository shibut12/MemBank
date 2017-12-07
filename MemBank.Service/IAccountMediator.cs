using MemBank.Service.Enums;

namespace MemBank.Service
{
    public interface IAccountMediator
    {       
        bool AddAccount(AccountType type, string owner);
        decimal GetBalance(int accountId);
        bool Withdraw(int accountId, decimal amount);
        bool Deposit(int accountId, decimal amount);
        bool Transfer(int fromAccountId, int toAccountId, decimal acount);
    }
}