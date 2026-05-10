using System;
using System.Collections.Generic;

public static class Sieve
{
    public static IEnumerable<int> Primes(int limit)
    {
        var primeGenerator = new PrimeGenerator(limit);
        return primeGenerator.Generate();
    }
}

public class PrimeGenerator
{
    private readonly int _limit;
    private readonly List<int> _primes;
    private const int FirstPrime = 2;

    public PrimeGenerator(int limit)
    {
        _limit = limit;
        if (_limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit),"Limit must be non-negative");
        }
        _primes = new List<int>();
    }

    public List<int> Generate()
    {
        if (_limit < FirstPrime)
        {
            return _primes; // Return empty list for limits less than 2
        }

        var sieve = BuildSieve();


        for (var i = FirstPrime; i <= _limit; i++)
        {
            if (sieve[i])
            {
                _primes.Add(i);
            }
        }

        return _primes;
    }

    private bool[] BuildSieve()
    {
        var sieve = new bool[_limit + 1];

        sieve[0] = false; // 0 is not prime
        sieve[1] = false; // 1 is not prime

        for (var i = FirstPrime; i <= _limit; i++)
        {
            sieve[i] = true; // Assume all numbers are prime initially
        }

        for (var i = FirstPrime; i * i <= _limit; i++)
        {
            if (sieve[i])
            {
                RemoveMultiples(sieve, i);
            }
        }

        return sieve;
    }

    private void RemoveMultiples(bool[] sieve, int prime)
    {
        for (var multiple = prime * prime; multiple <= _limit; multiple += prime)
        {
            sieve[multiple] = false; // Mark multiples of prime as non-prime
        }
    }
}
