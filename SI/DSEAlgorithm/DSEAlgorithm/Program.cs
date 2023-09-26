using System.Text;

using DESAlgorithm;

// Read used encryption key.
var keyInHexadecimal = "133457799BBCDFF1";
Console.WriteLine($"Used key:\t{keyInHexadecimal}");

// Step 1: Create 16 subkeys, each of which is 48-bits long.
var keys16 = Create16SubKeysOf48BitLength(keyInHexadecimal);

// String to encode.
var stringToEncode = "0123456789ABCDEF";
Console.WriteLine($"String to encode: {stringToEncode}");

// Step 2: Encode each 64-bit block of data.
var result = EncodeEach64bitBlockOfData(stringToEncode, keys16);
Console.WriteLine($"Obtained result: {result}");

Console.WriteLine(DecodeEach64bitBlockOfData(result, keys16));

string EncodeEach64bitBlockOfData(string stringToEncode, List<string> keys16)
{
    var stringInBinary = HexStringToBinary(stringToEncode);
    var firstPermutResult = PermuteAccordingToIPTable(stringInBinary);
    var (L16, R16) = Do16RoundsToEncrypt(firstPermutResult, keys16);
    var R16L16 = R16 + L16;
    var finalPermutationResult = PerformFinalPermutation(R16L16);
    var resultInHex = BinaryStringToHexString(finalPermutationResult);
    return resultInHex;
}

string DecodeEach64bitBlockOfData(string stringToDecode, List<string> keys16)
{
    var stringInBinary = HexStringToBinary(stringToDecode);
    var firstPermutResult = PermuteAccordingToIPTable(stringInBinary);
    var (L16, R16) = Do16RoundsToDecrypt(firstPermutResult, keys16);
    var R16L16 = R16 + L16;
    var finalPermutationResult = PerformFinalPermutation(R16L16);
    var resultInHex = BinaryStringToHexString(finalPermutationResult);
    return resultInHex;
}

string BinaryStringToHexString(string str)
{
    var sb = new StringBuilder();
    for (int i = 0; i < str.Length; i += 4)
    {
        sb.Append(ConverterHelper.HexToBinary
            .FirstOrDefault(x => x.Value == str.Substring(i, 4)).Key);
    }
    return sb.ToString();
}

char BinaryToHex(string str)
{
    return ConverterHelper.HexToBinary.FirstOrDefault(x => x.Value == str).Key;
}

string PerformFinalPermutation(string str)
{
    var sb = new StringBuilder();
    foreach (var digit in ConverterHelper.IP1Table)
    {
        sb.Append(str[digit - 1]);
    }
    var result = sb.ToString();
    if (result.Length != 64)
        Console.WriteLine($"Smth went wrong. Key should have 64 bits but have {result.Length}");
    return result;
}

(string, string) Do16RoundsToEncrypt(string firstPermutResult, List<string> keys16)
{
    var firstHalfLength = (int)(firstPermutResult.Length / 2);
    var secondHalfLength = firstPermutResult.Length - firstHalfLength;
    var L0 = firstPermutResult[..firstHalfLength];
    var R0 = firstPermutResult.Substring(firstHalfLength, secondHalfLength);

    var n = 0;
    var KnXORERn = string.Empty;
    List<string> Ln = new() { L0 };
    List<string> Rn = new() { R0 };
    var prevLn = L0;
    var prevRn = R0;
    for (int roundNumber = 1; roundNumber <= 16; roundNumber++)
    {
        n = roundNumber;
        Ln.Add(Rn[n - 1]);
        KnXORERn = DoXOR(Ln[n - 1], f(Rn[n - 1], keys16[n - 1]));
        Rn.Add(KnXORERn);
    }
    return (Ln[16], Rn[16]);
}

(string, string) Do16RoundsToDecrypt(string firstPermutResult, List<string> keys16)
{
    var firstHalfLength = (int)(firstPermutResult.Length / 2);
    var secondHalfLength = firstPermutResult.Length - firstHalfLength;
    var L0 = firstPermutResult[..firstHalfLength];
    var R0 = firstPermutResult.Substring(firstHalfLength, secondHalfLength);

    var n = 0;
    var KnXORERn = string.Empty;
    List<string> Ln = new() { L0 };
    List<string> Rn = new() { R0 };
    var prevLn = L0;
    var prevRn = R0;
    var keysNo = 15;
    for (int roundNumber = 1; roundNumber <= 16; roundNumber++)
    {
        n = roundNumber;
        Ln.Add(Rn[n - 1]);
        KnXORERn = DoXOR(Ln[n - 1], f(Rn[n - 1], keys16[keysNo]));
        Rn.Add(KnXORERn);
        --keysNo;
    }
    return (Ln[16], Rn[16]);
}

string f(string Rn, string Kn)
{
    var extendedIn48bitsKey = PermuteAccordingToEBitSelectionTable(Rn);
    var KnXORERn = DoXOR(Kn, extendedIn48bitsKey);
    var sBoxTablesRes = ComputeEachGroupOfSixBitsAccordingToSBoxTables(KnXORERn);
    var result = PermuteAccordingToPFinalPermutOfSBoxTable(sBoxTablesRes);
    return result;
}

string ComputeEachGroupOfSixBitsAccordingToSBoxTables(string knXORERn)
{
    var KnXORERnInChunksOf6 = knXORERn.Chunk(6)
                                      .Select(x => new string(x))
                                      .ToList();
    int rowNumber = 0;
    int columnNumber = 0;
    var sBoxTableValue = 0;
    var SnBn = new StringBuilder();
    for (int chunkNo = 0; chunkNo < KnXORERnInChunksOf6.Count; chunkNo++)
    {
        rowNumber = (int)Char.GetNumericValue(DoOR(KnXORERnInChunksOf6[chunkNo][0], KnXORERnInChunksOf6[chunkNo][5]));
        columnNumber = BinaryStringToInt(KnXORERnInChunksOf6[chunkNo].Substring(1, 4));
        sBoxTableValue = GetSBoxValue(chunkNo + 1, rowNumber, columnNumber);
        SnBn.Append(DecimalNumberToBinary(sBoxTableValue));
    }
    return SnBn.ToString();
}

string DecimalNumberToBinary(int number)
{
    return ConverterHelper.BinaryToInt.FirstOrDefault(x => x.Value == number).Key;
}

int GetSBoxValue(int chunkNo, int rowNumber, int columnNumber)
{
    return chunkNo switch
    {
        1 => ConverterHelper.SBoxTable1[rowNumber, columnNumber],
        2 => ConverterHelper.SBoxTable2[rowNumber, columnNumber],
        3 => ConverterHelper.SBoxTable3[rowNumber, columnNumber],
        4 => ConverterHelper.SBoxTable4[rowNumber, columnNumber],
        5 => ConverterHelper.SBoxTable5[rowNumber, columnNumber],
        6 => ConverterHelper.SBoxTable6[rowNumber, columnNumber],
        7 => ConverterHelper.SBoxTable7[rowNumber, columnNumber],
        8 => ConverterHelper.SBoxTable8[rowNumber, columnNumber],
    };
}

string DoXOR(string kn, string extendedIn48bitsKey)
{
    var ans = string.Empty;
    for (int i = 0; i < kn.Length; i++)
    {
        ans += (kn[i] == extendedIn48bitsKey[i]) ? "0" : "1";
    }
    return ans;
}

char DoOR(char str1, char str2)
{
    return (str1, str2) switch
            {
                ('0', '0') => '0',
                ('0', '1') => '1',
                ('1', '0') => '2',
                ('1', '1') => '3'
            };
}

List<string> Create16SubKeysOf48BitLength(string keyInHexadecimal)
{
    var keyInBinary = HexStringToBinary(keyInHexadecimal);
    var bit56key = PermuteAccordingToPC1Table(keyInBinary);
    var firstHalfLength = (int)(bit56key.Length / 2);
    var secondHalfLength = bit56key.Length - firstHalfLength;
    var C0 = bit56key[..firstHalfLength]; ;
    var D0 = bit56key.Substring(firstHalfLength, secondHalfLength); ;

    List<string> Cn = new() { C0 };
    List<string> Dn = new() { D0 };
    for (int i = 1; i <= 16; i++)
    {
        Cn.Add(ShiftStringToLeft(Cn[i - 1], ConverterHelper.ScheduleOfShifts[i]));
        Dn.Add(ShiftStringToLeft(Dn[i - 1], ConverterHelper.ScheduleOfShifts[i]));
    }

    List<string> CnDn = new();
    for (int i = 1; i <= 16; i++)
    {
        var resultKey = PermuteAccordingToPC2Table(Cn[i] + Dn[i]);
        CnDn.Add(resultKey);
    }
    return CnDn;
}

string ShiftStringToLeft(string s, int count)
{
    return string.Concat(s.Remove(0, count), s.AsSpan(0, count));
}

string PermuteAccordingToPC1Table(string bit64Key)
{
    var result = new StringBuilder();
    foreach (var digit in ConverterHelper.PC1Table)
    {
        result.Append(bit64Key[digit - 1]);
    }
    var result56bit = result.ToString();
    if (result56bit.Length != 56)
        Console.WriteLine($"Smth went wrong. Key should have 56 bits but have {result56bit.Length}");
    return result56bit;
}

string PermuteAccordingToPC2Table(string key)
{
    var result = new StringBuilder();
    foreach (var digit in ConverterHelper.PC2Table)
    {
        result.Append(key[digit - 1]);
    }
    var result48bit = result.ToString();
    if (result48bit.Length != 48)
        Console.WriteLine($"Smth went wrong. Key should have 48b bits but have {result48bit.Length}");
    return result48bit;
}

string PermuteAccordingToIPTable(string bit64Key)
{
    var result = new StringBuilder();

    foreach (var digit in ConverterHelper.IPTable)
    {
        result.Append(bit64Key[digit - 1]);
    }
    return result.ToString();
}

string PermuteAccordingToEBitSelectionTable(string bit32Key)
{
    var result = new StringBuilder();
    foreach (var digit in ConverterHelper.EBitSelectionTable)
    {
        result.Append(bit32Key[digit - 1]);
    }
    var result56bit = result.ToString();
    if (result56bit.Length != 48)
        Console.WriteLine($"Smth went wrong. Key should have 48 bits but have {result56bit.Length}");
    return result56bit;
}

string PermuteAccordingToPFinalPermutOfSBoxTable(string str)
{
    var result = new StringBuilder();
    foreach (var digit in ConverterHelper.FinalPermutOfSBoxTable)
    {
        result.Append(str[digit - 1]);
    }
    var result32bit = result.ToString();
    if (result32bit.Length != 32)
        Console.WriteLine($"Smth went wrong. Key should have 32 bits but have {result32bit.Length}");
    return result32bit;
}

string HexStringToBinary(string stringInHex)
{
    var result = new StringBuilder();
    foreach (char character in stringInHex)
    {
        result.Append(ConverterHelper.HexToBinary[char.ToLower(character)]);
    }
    var resultKey = result.ToString();
    if (resultKey.Length != 64)
    {
        Console.WriteLine("Something went wrong. Key length different from 64.");
    }

    return resultKey;
}

int BinaryStringToInt(string stringInBinary)
{
    return ConverterHelper.BinaryToInt[stringInBinary];
}