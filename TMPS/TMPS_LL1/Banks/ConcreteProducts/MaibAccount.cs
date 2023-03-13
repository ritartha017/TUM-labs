namespace Banks.ConcreteProducts;

using Banks.Product;

class MaibAccount : BankAccount
{
    public MaibAccount()
    {
        Console.WriteLine("MAIB account was created.");
    }
}
