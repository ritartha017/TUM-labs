using System;
using StatePattern.State;

namespace StatePattern.ConcreteStates;

public class LowerCase : IWritingState
{
    public void Write(string text)
    {
        Console.WriteLine(text.ToLower());
    }
}
