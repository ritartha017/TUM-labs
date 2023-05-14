using System;
namespace LogParser.LogFileIterator;

public class LogFile : IRowNumerable
{
	private Row[] rows;

	public LogFile()
	{
		// read to rows the file content;
	}

	public int Count
	{
		get { return rows.Length; }
	}

	public Row this[int index]
	{
		get { return rows[index];  }
	}

	public IRowIterator CreateNumerator()
	{

		return new RowsNumerator(this);
	}
}

