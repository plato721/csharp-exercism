using System;
using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects) =>
        subjects.Select((s, i) => i == subjects.Length - 1
            ? $"And all for the want of a {subjects[0]}."
            : $"For want of a {s} the {subjects[i + 1]} was lost.").ToArray();
}
