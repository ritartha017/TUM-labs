using ProxyPattern.Client;
using ProxyPattern.Facade;
using ProxyPattern.SubSystems;

CSharpCompiler cSharpCompiler = new();
CLR clr = new();
TextEditor textEditor = new();

RiderFacade ide = new(textEditor, cSharpCompiler, clr);

Programmist programmist = new();
programmist.CreateCSharpApp(ide);