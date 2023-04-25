using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Spectre.Console;

void ShowTimeForGMTOffset(string offset)
{
    if (offset.StartsWith("+")) offset = offset[1..];
    TimeSpan parsedOffset = TimeSpan.Parse(offset);
    DateTimeOffset now = DateTimeOffset.UtcNow.ToOffset(parsedOffset);
    string result = now.ToString("yyyy-MM-dd HH:mm:ss zzz");
    Console.WriteLine($"{result}\n");
}

while (true)
{
    AnsiConsole.Markup("Get desired offset in following format [underline green]<GMT-X> / <GMT+X>[/]:\t");
    string? desiredOffset = Console.ReadLine();
    string pattern = @"^GMT[+-](1[01]|[0-9])$";
    var match = Regex.Match(desiredOffset!, pattern, RegexOptions.IgnoreCase);
    if (!match.Success)
    {
        Console.WriteLine("Incorrect input format");
    }
    else
    {
        var offset = Regex.Match(desiredOffset!, @"[+-]\d+").Value;
        ShowTimeForGMTOffset($"{offset}:00");
    }
}
