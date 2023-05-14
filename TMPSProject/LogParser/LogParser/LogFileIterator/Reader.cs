namespace LogParser.LogFileIterator;

public class Reader
{
    public void SeeRows(LogFile logFile)
    {
        IRowIterator iterator = logFile.CreateNumerator();
        while (iterator.HasNext())
        {
            Row row = iterator.Next();
            Console.WriteLine(row.Content);
        }
    }
}

