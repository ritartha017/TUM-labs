using System.Numerics;
using DSA;

/******KEY GENERATION******/
BigInteger q = 11;                             // Selected a prime q.
BigInteger h = 3;                              // The hash value as the message digest. Random but 2 < h < p -2.

BigInteger p = q + q;
while ((p - 1) % q != (BigInteger)0)           // Computed prime modulus: (p-1) mod q = 0.
{
    p++;
    if (!Helper.PrimeNumbersList.Contains(p))
        continue;
}
Console.WriteLine($"q = {q}\np = {p}");

var g = BigInteger.ModPow(h, (p - 1) / q, p);  // g = h**((p–1)/q) mod p.
Console.WriteLine($"g = {g}");

var x = 7;                                     // Selected: Randomly, but 0 < x < q.
var y = BigInteger.ModPow(g, x, p);            // Computed: y = g**x mod p.

Console.WriteLine($"PrivateKey = <p, q, g, x> = <{p}, {q}, {g}, {x}>");
Console.WriteLine($"PublicKey = <p, q, g, y> = <{p}, {q}, {g}, {y}>");

/******KEY DISTRIBUTION******/

/******DSA SIGNING******/
var k = 5;                                                      // Selected: Randomly, but 0 < k < q.
var r = BigInteger.ModPow(BigInteger.ModPow(g, k, p), 1, q);    // Computed: r = (g**k mod p) mod q.
Console.WriteLine($"r = {r}");

BigInteger i = 0;
while ((k * i) % q != 1)                                        // Computed: k*i mod q = 1.
{
    i++;
}
Console.WriteLine($"i = {i}");

var s = BigInteger.ModPow(i * (h + x * r), 1, q);              // Computed: s = i*(h+r*x) mod q.
Console.WriteLine($"Digital signature is: <r, s> = <{r}, {s}>");

/******DSA VERIFICATION******/
if (r > 0 & r < q & s > 0 & s < q is not true)                  // Verify 0 < r < q and 0 < s < q.
{
    Console.WriteLine("Signature is not valid");
    return;
}

BigInteger w = 0;
while ((s * w) % q != 1)                                        // Computed: s*w mod q = 1.
{
    w++;
}
Console.WriteLine($"w = {w}");

var u1 = BigInteger.ModPow(h * w, 1, q);                        // Computed: u1 = h*w mod q.
var u2 = BigInteger.ModPow(r * w, 1, q);                        // Computed: u2 = r*w mod q.
Console.WriteLine($"u1 = {u1}, u2 = {u2}");

var v = BigInteger.ModPow(BigInteger.ModPow(BigInteger.Pow(g, (int)u1) * BigInteger.Pow(y, (int)u2), 1, p), 1, q);
Console.WriteLine($"v = {v}");                                  // Computed: v = (((g**u1)*(y**u2)) mod p) mod q.
if (v == r)
    Console.WriteLine("Verification passed.");
else
    Console.WriteLine("Signature is not valid");


/* https://www.herongyang.com/Cryptography/DSA-Introduction-Algorithm-Illustration-p23-q11.html */