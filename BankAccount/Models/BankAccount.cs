namespace BankAccount.Models;

public class BankAccount
{
    private static int _id = 0;
    public int Id { get;  }
    public string OwnerName { get; private set; }
    public decimal Balance { get; private set; }

    public BankAccount(string ownerName, decimal balance)
    {
        if (string.IsNullOrWhiteSpace(ownerName))
        {
            throw new ArgumentNullException(nameof(ownerName));
        }

        if (balance < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(balance));
        }
        OwnerName = ownerName;
        Balance = balance;
        Id = ++_id;
    }

    public void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        if (amount > Balance)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }
        Balance -= amount;
    }

    
    public override string ToString()
    {
        return $"ID: {Id} | Owner: {OwnerName} | Balance: {Balance} AZN";
    }
}