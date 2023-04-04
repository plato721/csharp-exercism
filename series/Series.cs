using System;
using System.Collections.Generic;
using System.Linq;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        var slices = new List<string>();

        foreach (var i in Enumerable.Range(0, sliceLength - 1))
        {
            var remainder = numbers;
            while (remainder.Length >= sliceLength)
            {
                var nextSlice = remainder.Take(sliceLength).ToString();
                slices.Add(nextSlice);
                remainder = remainder.Skip(sliceLength).ToString();
            }
        }

        return slices.ToArray();
    }
}
