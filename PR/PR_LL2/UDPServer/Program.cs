using UDPServerNamespace;

var chat = new UDPServer();

_ = Task.Run(chat.ReceiveMessageAsync);

Console.Read();