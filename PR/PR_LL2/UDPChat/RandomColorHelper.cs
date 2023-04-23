namespace UDPChatNamespace;

static class RandomColorHelper
{
    public static ConsoleColor GetRandomConsoleColor()
    {
        Random _random = new Random();
        var consoleColors = Enum.GetValues(typeof(ConsoleColor));
        return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
    }
}
