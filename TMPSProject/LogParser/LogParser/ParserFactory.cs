using LogParser.ConcreteParsers;

namespace LogParser;

public class ParserFactory
{
	public static Parser GetParser(string file)
	{
		if (file.EndsWith(".xml"))
			return new XMLParser();
		else if (file.EndsWith(".json"))
			return new JSONParser();
		else
			return null;
	}
}

