using GoodExample.Abstract;
using GoodExample.Entities;

namespace GoodExample;

class GeneralPhoneValidator : IPhoneValidator
{
    public bool IsValid(Phone phone) =>
        !string.IsNullOrEmpty(phone.Model) && phone.Price > 0;
}
