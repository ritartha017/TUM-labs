namespace Banks.ConcreteCreators;

using System;

using Banks.ConcreteProducts;
using Banks.Creator;
using Banks.Product;

class MAIBBank : Bank
{
    public override BankAccount CreateAccount()
    {
        return new MaibAccount();
    }
}
