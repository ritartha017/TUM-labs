using System.Numerics;
using System.Text;
using RSAHelper;
using RSAShuffler;

namespace RSAAlgorithm;

public class RSA
{
    private BigInteger publicKey;
    private BigInteger privateKey;
    private BigInteger n;

	public RSA()
	{
    }

    public void SetPublicPrivateKeys()
    {
        // Step 1: Select 2 large random prime numbers. P and Q.
        var randomPrimes = Helper.PrimeNumbersList.Shuffle().Take(2);
        BigInteger p = randomPrimes.First();
        BigInteger q = randomPrimes.Last();
        // BigInteger p = 61, q = 533;
        Console.WriteLine($"First random prime number: {p}\nSecond random prime number: {q}");

        // Step 2: Calculating the modulus for encryption and decryption.
        n = p * q;
        Console.WriteLine($"Modulus n = p * q = {p} * {q} = {n}");

        // Step 3: Calculate Euler's Totient function.
        BigInteger phiN = (p - 1) * (q - 1);
        Console.WriteLine($"φ(n) = (p - 1) * (q -1) = ({p} - 1) * ({q} - 1) = {phiN}");

        // Step 4: Choose a small number e, co-prime to phiN with gcd(e, phiN) = 1 and 1 < e < phiN.
        BigInteger e = 2;
        while (true)
        {
            if (Helper.GCD(e, phiN) == 1)
                break;
            e++;
        }
        publicKey = e;

        // Step 5: Find d, such that d * e mod phiN = 1.
        BigInteger d = 0;
        while ((d * e) % phiN != 1)
        {
            d++;
        }
        privateKey = d;

        Console.WriteLine($"Public key <e, n>: <{publicKey}, {n}>");
        Console.WriteLine($"Private key <d, n>: <{privateKey}, {n}>");
    }

    public List<BigInteger> Encrypt(string message)
    {
        List<BigInteger> result = new();
        foreach (char letter in message)
        {
            result.Add(BigInteger.ModPow((int)letter, publicKey, n));
        }
        return result;
    }

    public string Decrypt(List<BigInteger> encoded)
    {
        StringBuilder decrypted = new();
        foreach (BigInteger number in encoded)
        {
            decrypted.Append((char)BigInteger.ModPow(number, privateKey, n));
        }
        return decrypted.ToString();
    }
}