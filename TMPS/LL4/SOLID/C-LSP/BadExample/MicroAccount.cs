namespace BadExample;

class MicroAccount : Account
{
    public MicroAccount(int sum) : base(sum)
    {
    }

    public override int Capital
    {
        get { return capital; }
        set
        {
            capital = value;
        }
    }
    public override void SetCapital(int money)
    {
        if (money < 0)
            throw new Exception("You cannot put less than 0 on the account");

        if (money > 100)
            throw new Exception("You cannot deposit more than 100");

        this.Capital = money;
    }

    public override decimal GetInterest(decimal sum, int month, int rate)
    {
        if (sum < 0 || month > 12 || month < 1 || rate < 0)
            throw new Exception("Incorrect data.");

        decimal result = sum;
        for (int i = 0; i < month; i++)
            result += result * rate / 100;

        Console.WriteLine($"Sum from micro account: {result}");

        return result;
    }
}