namespace Flyweight.ConcreteFlyweights;

using Flyweight.FlyweightInterface;

class ClassicLemonade : ILemonade
{
    private string flavor = "lemon";
    private string lemonadeType = string.Empty;
    private int tableNo;
    public void Make(string lemonadeType, int tableNo)
    {
        this.lemonadeType = lemonadeType;
        this.tableNo = tableNo;
        Console.WriteLine($"Making a {this.flavor} lemonade {this.lemonadeType} for table no {this.tableNo}");
    }
}
