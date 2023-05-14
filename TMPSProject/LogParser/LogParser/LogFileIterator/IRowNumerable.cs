using System;
namespace LogParser.LogFileIterator;

public interface IRowNumerable
{
    IRowIterator CreateNumerator();
    int Count { get; }
    Row this[int index] { get; }
}

