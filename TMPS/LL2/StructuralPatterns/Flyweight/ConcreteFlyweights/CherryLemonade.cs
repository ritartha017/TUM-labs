namespace Flyweight.ConcreteFlyweights;

using Flyweight.FlyweightInterface;

class CherryLemonade : ILemonade
{
    private string flavor = "cherry";
    private string lemonadeType = string.Empty;
    private int tableNo;
    public void Make(string lemonadeType, int tableNo)
    {
        this.lemonadeType = lemonadeType;
        this.tableNo = tableNo;
        Console.WriteLine($"Making a {this.flavor} lemonade {this.lemonadeType} for table no {this.tableNo}");
    }
}
