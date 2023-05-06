using GoodExample;

Book book = new (new ConsolePrinter());
book.Print();
book.Printer = new HtmlPrinter();
book.Print();