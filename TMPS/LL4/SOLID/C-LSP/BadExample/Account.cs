namespace BadExample;

class Account
{
    protected int capital;

    public Account(int sum)
    {
        if (sum < 100)
            throw new Exception("Incorrect sum. Sum should be greater than 100.");
        this.capital = sum;
    }

    public virtual int Capital
    {
        get { return capital; }
        set
        {
            if (value < 100)
                throw new Exception("Incorrect sum. Sum should be greater than 100.");
            capital = value;
        }
    }

    public virtual void SetCapital(int money)
    {
        if (money < 0)
            throw new Exception("You cannot put less than 0 on the account.");
        this.Capital = money;
    }

    public virtual decimal GetInterest(decimal sum, int month, int rate)
    {
        if (sum < 0 || month > 12 || month < 1 || rate < 0)
            throw new Exception("Incorrect data.");

        decimal result = sum;
        for (int i = 0; i < month; i++)
            result += result * rate / 100;

        if (sum >= 1000)
            result += 100;

        Console.WriteLine($"Sum from account: {result}");

        return result;
    }
}
