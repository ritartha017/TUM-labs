namespace Banks.Creator;

using Banks.Product;

abstract class Bank
{
    abstract public BankAccount CreateAccount();
}
