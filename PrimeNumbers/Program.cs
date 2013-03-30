using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;

class Program
{
    static List<uint> foundPrimes = new List<uint>();
    static void Main(string[] args)
    {
        List<uint> inputs = new List<uint>();
        uint input = 0;
        using (StreamReader reader = File.OpenText(args[0]))
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (null == line)
                continue;
            
            if (uint.TryParse(line, out input))
            {
                inputs.Add(input);
            }
        }

        Console.WriteLine(GetFinalOutput(inputs));
    }

    private static string GetFinalOutput(List<uint> inputs)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var input in inputs)
        {
            uint begin = (foundPrimes.Count > 0) ? foundPrimes[foundPrimes.Count - 1] : 1;
            List<uint> newPrimes = FindPrimes(begin + 1, input);
            foundPrimes.AddRange(newPrimes);
            sb.AppendLine(GetExistingPrimes(input));  
        }

        return sb.ToString().TrimEnd();
    }

    private static List<uint> FindPrimes(uint start, uint end)
    {
        List<uint> newPrimes = new List<uint>();
        for (uint i = start; i < end; i++)
        {
            if (IsPrime(i)) newPrimes.Add(i);
        }

        return newPrimes;
    }

    private static bool IsPrime(uint numToTest)
    {
        if (numToTest == 1) return false;
        if (numToTest == 2) return true;
        for (int i = 2; i < numToTest; i++)
        {
            if (numToTest % i == 0) return false;
        }
        return true;
    }
        
    private static string GetExistingPrimes(uint limit)
    {
        var ret = foundPrimes.Where(a => (a <= limit));
        return String.Join(",", ret);
    }
}