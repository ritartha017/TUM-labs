using ProxyPattern.Interface;
using ProxyPattern.ProxyObject;

IInternet internet = new ProxyInternet();
try
{
    internet.ConnectTo("utm.md");
    internet.ConnectTo("abc.com");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}