namespace Banks.ConcreteProducts;

using Banks.Product;

class BCRAccount : BankAccount
{
    public BCRAccount()
    {
        Console.WriteLine("BCR account was created.");
    }
}
