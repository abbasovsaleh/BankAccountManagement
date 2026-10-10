namespace BankAccount.Interfaces;

public interface IBankAccountService
{
    
    Models.BankAccount CreateAccount(string name, decimal balance);

    List<Models.BankAccount> GetAllAccounts();

    Models.BankAccount GetAccountById(int id);

    void Deposit(int id, decimal amount);

    void Withdraw(int id, decimal amount);

    void Transfer(int fromId, int toId, decimal amount);
    

}