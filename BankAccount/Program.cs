using BankAccount.Models;
using BankAccount.Services;

BankAccountService service = new BankAccountService();

while (true)
{
    Console.WriteLine("\n===== BANK MENU =====");
    Console.WriteLine("1. Create account");
    Console.WriteLine("2. Show all accounts");
    Console.WriteLine("3. Find account by ID");
    Console.WriteLine("4. Deposit");
    Console.WriteLine("5. Withdraw");
    Console.WriteLine("6. Transfer");
    Console.WriteLine("0. Exit");
    Console.Write("Choose: ");

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Invalid input. Enter a number.");
        continue;
    }

    if (choice == 0)
    {
        Console.WriteLine("Goodbye!");
        break;
    }

    try
    {
        switch (choice)
        {
            case 1:
                Console.Write("Owner name: ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Initial balance: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal balance))
                {
                    Console.WriteLine("Invalid balance.");
                    break;
                }

                BankAccount.Models.BankAccount newAccount = service.CreateAccount(name, balance);
                Console.WriteLine("Account created:");
                Console.WriteLine(newAccount);
                break;

            case 2:
                List<BankAccount.Models.BankAccount> accounts = service.GetAllAccounts();   

                if (accounts.Count == 0)
                {
                    Console.WriteLine("No accounts found.");
                    break;
                }

                foreach (BankAccount.Models.BankAccount account in accounts)
                {
                    Console.WriteLine(account);
                }
                break;

            case 3:
                Console.Write("Enter account ID: ");
                if (!int.TryParse(Console.ReadLine(), out int searchId))
                {
                    Console.WriteLine("Invalid ID.");
                    break;
                }

                Console.WriteLine(service.GetAccountById(searchId));
                break;

            case 4:
                Console.Write("Enter account ID: ");
                if (!int.TryParse(Console.ReadLine(), out int depositId))
                {
                    Console.WriteLine("Invalid ID.");
                    break;
                }

                Console.Write("Enter amount: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                {
                    Console.WriteLine("Invalid amount.");
                    break;
                }

                service.Deposit(depositId, depositAmount);
                Console.WriteLine("Deposit successful.");
                Console.WriteLine(service.GetAccountById(depositId));
                break;

            case 5:
                Console.Write("Enter account ID: ");
                if (!int.TryParse(Console.ReadLine(), out int withdrawId))
                {
                    Console.WriteLine("Invalid ID.");
                    break;
                }

                Console.Write("Enter amount: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                {
                    Console.WriteLine("Invalid amount.");
                    break;
                }

                service.Withdraw(withdrawId, withdrawAmount);
                Console.WriteLine("Withdrawal successful.");
                Console.WriteLine(service.GetAccountById(withdrawId));
                break;

            case 6:
                Console.Write("Sender account ID: ");
                if (!int.TryParse(Console.ReadLine(), out int fromId))
                {
                    Console.WriteLine("Invalid sender ID.");
                    break;
                }

                Console.Write("Receiver account ID: ");
                if (!int.TryParse(Console.ReadLine(), out int toId))
                {
                    Console.WriteLine("Invalid receiver ID.");
                    break;
                }

                Console.Write("Transfer amount: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
                {
                    Console.WriteLine("Invalid amount.");
                    break;
                }

                service.Transfer(fromId, toId, transferAmount);

                Console.WriteLine("Transfer successful.");
                Console.WriteLine(service.GetAccountById(fromId));
                Console.WriteLine(service.GetAccountById(toId));
                break;

            default:
                Console.WriteLine("Invalid menu option.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}