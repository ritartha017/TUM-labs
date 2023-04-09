namespace BridgePattern.Abstraction;

using BridgePattern.Implementor;

abstract class YouTubePage
{
    protected ITheme theme { get; set; }
    public YouTubePage(ITheme theme)
    {
        this.theme = theme;
    }
    public abstract string GetYouTubePageContent();
}
