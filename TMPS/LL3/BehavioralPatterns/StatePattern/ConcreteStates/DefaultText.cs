using System;
using StatePattern.State;

namespace StatePattern.ConcreteStates;

public class DefaultText : IWritingState
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}
