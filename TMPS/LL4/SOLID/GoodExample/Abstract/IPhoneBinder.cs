using GoodExample.Entities;

namespace GoodExample.Abstract;

interface IPhoneBinder
{
    Phone CreatePhone(string?[] data);
}
