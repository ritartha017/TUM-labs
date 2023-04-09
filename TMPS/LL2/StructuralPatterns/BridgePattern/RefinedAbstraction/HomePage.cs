namespace BridgePattern.RefinedAbstraction;

using BridgePattern.Abstraction;
using BridgePattern.Implementor;

class HomePage : YouTubePage
{
    public HomePage(ITheme theme) : base(theme)
    {
    }

    public override string GetYouTubePageContent()
    {
        return $"Home page in {theme.GetColor()}";
    }
}