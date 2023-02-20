using System;
using System.Collections.Generic;
using System.Linq;

public static class Pangram
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
    
    public static bool IsPangram(string input)
    {
        var foundLetters = input
            .ToCharArray()
            .ToList()
            .Aggregate(new HashSet<char>(), (letters, letter) =>
        {
            var lowerChar = letter.ToString().ToLowerInvariant();

            if(Alphabet.Contains(lowerChar))
            {
                letters.Add(lowerChar.ToCharArray()[0]);
            }

            return letters;
        })
            .Order();

        return string.Join("", foundLetters) == Alphabet;
    }
}
