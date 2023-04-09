namespace BridgePattern.RefinedAbstraction;

using BridgePattern.Abstraction;
using BridgePattern.Implementor;

class SubscriptionsPage : YouTubePage
{
    public SubscriptionsPage(ITheme theme) : base(theme)
    {
    }

    public override string GetYouTubePageContent()
    {
        return $"Subscriptions page in {theme.GetColor()}";
    }
}
