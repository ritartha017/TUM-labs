using Accounts.Prototype;

namespace Accounts.ConcretePrototypes;

class PersonalAccount : IAccountPrototype
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Options { get; set; }

    public PersonalAccount()
        : base()
    {
        Console.WriteLine("PERFORMING SOME COMPLEX DB QUERIES ....");
        Id = new Random().Next();
        Name = Guid.NewGuid().ToString();
        Options = Guid.NewGuid().ToString();
    }

    public IAccountPrototype Clone()
    {
        return new PersonalAccount();
    }

    public void GetInfo()
    {
        Console.WriteLine("AccId->\t\t{0}", this.Id);
        Console.WriteLine("AccName->\t{0}", this.Name);
        Console.WriteLine("AccOptions->\t{0}", this.Options);
    }
}
