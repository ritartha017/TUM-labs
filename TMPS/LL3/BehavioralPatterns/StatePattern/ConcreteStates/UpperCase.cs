using System;
using StatePattern.State;

namespace StatePattern.ConcreteStates;

public class UpperCase : IWritingState
{
    public void Write(string text)
    {
        Console.WriteLine(text.ToUpper());
    }
}
