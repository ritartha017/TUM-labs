namespace ProxyPattern.Facade;

using ProxyPattern.SubSystems;

class RiderFacade
{
    TextEditor textEditor;
    CSharpCompiler cSharpCompiler;
    CLR clr;

    public RiderFacade(TextEditor textEditor, CSharpCompiler cSharpCompiler, CLR clr)
    {
        this.textEditor = textEditor;
        this.cSharpCompiler = cSharpCompiler;
        this.clr = clr;
    }

    public void Start()
    {
        textEditor.WriteCode();
        textEditor.Save();
        cSharpCompiler.Compile();
        clr.CompileToNativeCode();
        clr.Execute();
    }

    public void Stop()
    {
        clr.Finish();
    }
}
