using GoodExample;

class Program
{
    static void Main(string[] args)
    {
        Account acc = new MicroAccount(100);

        InitializeAccount(acc);
        CalculateInterest(acc);

        Console.Read();
    }

    public static void InitializeAccount(Account account)
    {
        account.SetCapital(200);
        Console.WriteLine(account.Capital);
    }

    public static void CalculateInterest(Account account)
    {
        decimal sum = account.GetInterest(1000, 1, 10); // 1000 + 1000 * 10 / 100 + 100 (bonus)
        if (sum != 1200) // expecting 1200
        {
            throw new Exception("Obtained incorrect sum after all the calculations");
        }
    }
}