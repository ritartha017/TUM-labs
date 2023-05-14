namespace LogParser.LogFileIterator;

public class RowsNumerator : IRowIterator
{
	IRowNumerable aggregate;
	int index = 0;

	public RowsNumerator(IRowNumerable a)
	{
		aggregate = a;
	}

	public bool HasNext()
	{
		return index < aggregate.Count;
	}

	public Row Next()
	{
		return aggregate[index++];
	}
}

