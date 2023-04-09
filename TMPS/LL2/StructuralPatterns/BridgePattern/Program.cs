using BridgePattern.Abstraction;
using BridgePattern.ConcreteImplementor;
using BridgePattern.RefinedAbstraction;

YouTubePage subscriptionsPage = new SubscriptionsPage(new DarkTheme());
var homePage = new HomePage(new LightTheme());

Console.WriteLine(subscriptionsPage.GetYouTubePageContent());
Console.WriteLine(homePage.GetYouTubePageContent());