using Banks.ConcreteCreators;
using Banks.Creator;

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new MAIBBank();
        bank.CreateAccount();

        bank = new BCRBank();
        bank.CreateAccount();

        Console.ReadLine();
    }
}