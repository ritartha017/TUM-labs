namespace Accounts.Client;

using Accounts.ConcretePrototypes;
using Accounts.Prototype;

class Client
{
    static void Main(string[] args)
    {
        IAccountPrototype prototype = new PersonalAccount();
        IAccountPrototype clone = prototype.Clone();
        prototype.GetInfo();
        clone.GetInfo();
    }
}