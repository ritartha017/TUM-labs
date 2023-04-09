namespace BridgePattern.RefinedAbstraction;

using BridgePattern.Implementor;

class DarkTheme : ITheme
{
    public string GetColor()
    {
        return "Dark Black";
    }
}
