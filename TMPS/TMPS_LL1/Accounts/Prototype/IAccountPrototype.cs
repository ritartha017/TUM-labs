namespace Accounts.Prototype;

interface IAccountPrototype
{
    abstract void GetInfo();
    public abstract IAccountPrototype Clone();
}