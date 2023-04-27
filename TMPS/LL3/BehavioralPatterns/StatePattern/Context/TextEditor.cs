using System;
using StatePattern.State;

namespace StatePattern.Context;

public class TextEditor
{
	protected IWritingState state;

	public TextEditor(IWritingState state)
	{
		this.state = state;
	}

	public void SetState(IWritingState state)
	{
		this.state = state;
	}

	public void Type(string text)
	{
		this.state.Write(text);
	}
}

