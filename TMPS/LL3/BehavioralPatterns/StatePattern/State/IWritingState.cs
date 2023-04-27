using System;

namespace StatePattern.State;

public interface IWritingState
{
    public void Write(string text);
}

