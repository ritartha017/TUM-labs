namespace GoodExample.Implementations;

class GeneralPhoneBinder : IPhoneBinder
{
    public Phone CreatePhone(string?[] data)
    {
        if (data is { Length: 2 } && data[0] is string model &&
            model.Length > 0 && int.TryParse(data[1], out var price))
        {
            return new Phone(model, price);

        }
        throw new Exception("Incorrect input data.");
    }
}