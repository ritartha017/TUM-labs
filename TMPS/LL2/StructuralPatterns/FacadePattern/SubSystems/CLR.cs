namespace ProxyPattern.SubSystems;

class CLR
{
    public void CompileToNativeCode()
    {
        Console.WriteLine("Jit-Compiler compiled the code to native code.");
    }

    public void Execute()
    {
        Console.WriteLine("Executing the app...");
    }

    public void Finish()
    {
        Console.WriteLine("Exiting the app...");
    }
}
