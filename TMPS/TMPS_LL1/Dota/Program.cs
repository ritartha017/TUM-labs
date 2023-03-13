using Dota;

class Program
{
    static void Main(string[] args)
    {
        Hero axe = new Hero(new AxeFactory());
        axe.Hit();
 
        Hero cm = new Hero(new CrystalMaidenFactory());
        cm.Hit();
 
        Console.ReadLine();
    }
}