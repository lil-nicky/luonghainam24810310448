using System;

public class BankAccount
{
    private static long nextAccountNumber = 1000000001;

    private decimal balance;
    private decimal minimumBalance = 50000;

    public long AccountNumber { get; init; }

    private string accountHolder = string.Empty;

    public string AccountHolder
    {
        get
        {
            return accountHolder;
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                string errorMessage =
                    "ten chu tai khoan khong duoc de trong";

                throw new ArgumentException(errorMessage);
            }

            accountHolder = value;
        }
    }

    public decimal Balance
    {
        get
        {
            return balance;
        }
    }

    public BankAccount(
        string accountHolder,
        decimal initialBalance)
    {
        if (initialBalance < minimumBalance)
        {
            string errorMessage =
                "so du ban dau phai tu 50000 vnd tro len";

            throw new ArgumentException(errorMessage);
        }

        AccountNumber = nextAccountNumber;
        nextAccountNumber++;

        AccountHolder = accountHolder;
        balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            string errorMessage =
                "so tien nap phai lon hon 0";

            throw new ArgumentException(errorMessage);
        }

        balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            string errorMessage =
                "so tien rut phai lon hon 0";

            throw new ArgumentException(errorMessage);
        }

        if (balance - amount < minimumBalance)
        {
            return false;
        }

        balance -= amount;

        return true;
    }

    public void DisplayInfo()
    {
        long accountNumber = AccountNumber;
        string holder = AccountHolder;
        decimal currentBalance = Balance;

        string accountNumberText =
            $"so tai khoan {accountNumber}";

        string holderText =
            $"chu tai khoan {holder}";

        string balanceText =
            $"so du {currentBalance:N0} vnd";

        Console.WriteLine(accountNumberText);
        Console.WriteLine(holderText);
        Console.WriteLine(balanceText);
    }
}


class Program
{
    static void Main()
    {
        string title = "bai tap 1";
        Console.WriteLine(title);

        try
        {
            Console.WriteLine("nhap ten chu tai khoan thu nhat");
            string name1 = Console.ReadLine() ?? "";

            Console.WriteLine("nhap so du ban dau tai khoan thu nhat");
            decimal money1 =
                decimal.Parse(Console.ReadLine() ?? "0");

            BankAccount account1 =
                new BankAccount(name1, money1);


            Console.WriteLine("nhap ten chu tai khoan thu hai");
            string name2 = Console.ReadLine() ?? "";

            Console.WriteLine("nhap so du ban dau tai khoan thu hai");
            decimal money2 =
                decimal.Parse(Console.ReadLine() ?? "0");

            BankAccount account2 =
                new BankAccount(name2, money2);


            string accountTitle1 =
                "tai khoan thu nhat";

            Console.WriteLine(accountTitle1);
            account1.DisplayInfo();


            string accountTitle2 =
                "tai khoan thu hai";

            Console.WriteLine(accountTitle2);
            account2.DisplayInfo();


            Console.WriteLine("nhap so tien muon nap");
            decimal depositMoney =
                decimal.Parse(Console.ReadLine() ?? "0");

            account1.Deposit(depositMoney);

            string depositResult =
                $"so du sau khi nap {account1.Balance:N0} vnd";

            Console.WriteLine(depositResult);


            Console.WriteLine("nhap so tien muon rut");
            decimal withdrawMoney =
                decimal.Parse(Console.ReadLine() ?? "0");

            bool withdrawResult =
                account1.Withdraw(withdrawMoney);

            string withdrawResultText =
                $"ket qua rut tien {withdrawResult}";

            Console.WriteLine(withdrawResultText);

            account1.DisplayInfo();


            Console.WriteLine("nhap so tien muon rut vuot han muc");
            decimal invalidWithdrawMoney =
                decimal.Parse(Console.ReadLine() ?? "0");

            bool invalidResult =
                account1.Withdraw(invalidWithdrawMoney);

            string invalidResultText =
                $"ket qua rut tien {invalidResult}";

            Console.WriteLine(invalidResultText);

            account1.DisplayInfo();


            Console.WriteLine("nhap ten tai khoan khong hop le");
            string invalidName =
                Console.ReadLine() ?? "";

            Console.WriteLine("nhap so du tai khoan khong hop le");
            decimal invalidMoney =
                decimal.Parse(Console.ReadLine() ?? "0");

            BankAccount invalidAccount =
                new BankAccount(
                    invalidName,
                    invalidMoney);
        }
        catch (ArgumentException ex)
        {
            string errorText =
                $"loi {ex.Message}";

            Console.WriteLine(errorText);
        }
    }
}
