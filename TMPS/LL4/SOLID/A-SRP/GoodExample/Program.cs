using GoodExample;
using GoodExample.Entities;
using GoodExample.Implementations;

MobileStore store = new MobileStore(
    new ConsolePhoneReader(), new GeneralPhoneBinder(),
    new GeneralPhoneValidator(), new TextPhoneSaver());
store.Process();