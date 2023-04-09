using AdapterPattern.Adaptee;
using AdapterPattern.Adapter;
using AdapterPattern.Client;
using AdapterPattern.Target;

var client = new User();
var windowsMachine = new Windows();

client.InsertHDMIConnectorIntoComputer(windowsMachine);

var macMachine = new MAC();
var macMachineAdapter = new MACAdapter(macMachine);

client.InsertHDMIConnectorIntoComputer(macMachineAdapter);
