namespace BridgePattern.ConcreteImplementor;

using BridgePattern.Implementor;

class LightTheme : ITheme
{
    public string GetColor()
    {
        return "Light";
    }
}
