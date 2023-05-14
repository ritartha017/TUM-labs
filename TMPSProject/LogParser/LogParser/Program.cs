using LogParser;

var logsFileName = "test.json";

var parser = ParserFactory.GetParser(logsFileName);
Console.WriteLine(parser);

Console.ReadKey();