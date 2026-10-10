using BankAccount.Interfaces;

namespace BankAccount.Services;

public class BankAccountService : IBankAccountService
{
    private List<Models.BankAccount> accounts = new List<Models.BankAccount>();
    
    public Models.BankAccount CreateAccount(string name, decimal balance)
    {
        var account = new Models.BankAccount(name, balance);
        accounts.Add(account);
        return account;
    }

    public List<Models.BankAccount> GetAllAccounts()
    {
        return accounts;
    }

    public Models.BankAccount? GetAccountById(int id)
    {
       foreach(Models.BankAccount? account in accounts)
       {
           if (account.Id == id)
           {
               return account;
           }
       }
       return null;
    }

    public void Deposit(int id, decimal amount)
    {
        var account = GetAccountById(id);
        account.Deposit(amount);
    }

    public void Withdraw(int id, decimal amount)
    {
        var account = GetAccountById(id);
        account.Withdraw(amount);
    }

    public void Transfer(int fromId, int toId, decimal amount)
    {
        var fromAccount = GetAccountById(fromId);
        var toAccount = GetAccountById(toId);
        if (fromAccount == toAccount)
        {
            throw new InvalidOperationException("Cannot transfer to the same account");
        }
        fromAccount.Withdraw(amount);
        toAccount.Deposit(amount); 
        
    }
}