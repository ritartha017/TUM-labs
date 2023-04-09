namespace ProxyPattern.Client;

using ProxyPattern.Facade;

class Programmist
{
    public void CompileApp(RiderFacade facade)
    {
        facade.Start();
        facade.Stop();
    }

    public void CreateCSharpApp(RiderFacade facade)
    {
        facade.Start();
        facade.Stop();
    }
}
