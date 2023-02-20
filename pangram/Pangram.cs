using System.Collections.Generic;
using System.Linq;

public static class Pangram
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    public static bool IsPangram(string input)
    {
        var foundLetters = input
            .Aggregate(new HashSet<string>(), (letters, l) =>
            {
                var lAsLowerString = l.ToString().ToLowerInvariant();

                if(Alphabet.Contains(lAsLowerString))
                {
                    letters.Add(lAsLowerString);
                }

                return letters;
            })
            .Order();

        return string.Join("", foundLetters) == Alphabet;
    }
}
