﻿using System.Numerics;

namespace DSA;

public class Helper
{
    public static List<BigInteger> PrimeNumbersList = new()
    {
        2,   3,   5,   7,   11,  13,  17,  19,  23,  29,  31,  37,  41,  43,  47,  53,  59,  61,  67,  71,
        73,  79,  83,  89, 97,  101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173,
        179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281,
        283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409,
        419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541,
        547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659,
        661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809,
        811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941,
        947, 953, 967, 971, 977, 983, 991, 997, 1009, 1013, 1019, 1021, 1031, 1033, 1039, 1049, 1051, 1061, 1063, 1069
    };

    public static Dictionary<BigInteger, char> AlphabetDictionary = new()
    {
        { 1, 'A'},
        { 2, 'B'},
        { 3, 'C'},
        { 4, 'D'},
        { 5, 'E'},
        { 6, 'F'},
        { 7, 'G'},
        { 8, 'H'},
        { 9, 'I'},
        { 10, 'J'},
        { 11, 'K'},
        { 12, 'L'},
        { 13, 'M'},
        { 14, 'N'},
        { 15, 'O'},
        { 16, 'P'},
        { 17, 'Q'},
        { 18, 'R'},
        { 19, 'S'},
        { 20, 'T'},
        { 21, 'U'},
        { 22, 'V'},
        { 23, 'W'},
        { 24, 'X'},
        { 25, 'Y'},
        { 26, 'Z'},
    };

    public static BigInteger GCD(BigInteger a, BigInteger b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }
        return a | b;
    }

    public static BigInteger GenerateRandomBigInteger(BigInteger min, BigInteger max)
    {
        Random random = new Random();
        BigInteger range = max - min;

        byte[] bytes = new byte[range.ToByteArray().Length];
        random.NextBytes(bytes);
        BigInteger randomValue = new BigInteger(bytes);

        randomValue = BigInteger.Remainder(randomValue, range) + min;

        return randomValue;
    }
}
