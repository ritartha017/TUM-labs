namespace RSAAlgorithm;

public class Program
{
    public static void Main()
    {
        var rsa = new RSA();

        rsa.SetPublicPrivateKeys();
        
        string message = "KALOED";
        Console.WriteLine($"Message to encrypt: {message}");
        
        var encryptedMessageList = rsa.Encrypt(message);
        var encryptedMessage = string.Join("", encryptedMessageList);
        Console.WriteLine($"Encrypted text: {encryptedMessage}");

        var decryptedMessage = rsa.Decrypt(encryptedMessageList);
        Console.WriteLine($"Decrypted message: {decryptedMessage}");
    }
}
