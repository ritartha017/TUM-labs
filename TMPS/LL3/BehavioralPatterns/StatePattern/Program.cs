using StatePattern;
using StatePattern.ConcreteStates;
using StatePattern.Context;

TextEditor editor = new(new DefaultText());
editor.Type("Default text");

editor.SetState(new UpperCase());
editor.Type("Text in upper");
editor.Type("Text in upper");

editor.SetState(new LowerCase());
editor.Type("Text in lower");

Console.ReadKey();
