namespace GoodExample;

class MicroAccount : Account
{
    public MicroAccount(int sum) : base(sum)
    {
    }

    // 1000, 1, 10
    public override decimal GetInterest(decimal sum, int month, int rate)
    {
        if (sum < 0 || month > 12 || month < 1 || rate < 0)
            throw new Exception("Incorrect data.");

        decimal result = sum;
        for (int i = 0; i < month; i++)
            result += result * rate / 100;

        Console.WriteLine($"Sum from micro account: {result}");

        if (sum >= 1000)
            result += 100;

        return result;
    }
}