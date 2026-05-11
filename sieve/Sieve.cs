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
    private const int FirstPrime = 2;

    public PrimeGenerator(int limit)
    {
        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit),"Limit must be non-negative");
        }

        _limit = limit;
    }

    public IEnumerable<int> Generate()
    {
        if (_limit < 2)
        {
            return new List<int>();
        }

        var sieve = InitializeSieve();

        MarkPrimes(sieve);

        return SieveToPrimes(sieve);
    }

    private bool[] InitializeSieve()
    {
        var sieve = new bool[_limit + 1];

        for (var i = FirstPrime; i <= _limit; i++)
        {
            sieve[i] = true; // Assume all numbers are prime initially
        }

        return sieve;
    }

    private void MarkPrimes(IList<bool> sieve)
    {
        for (var i = FirstPrime; i * i <= _limit; i++)
        {
            if (sieve[i])
            {
                RemoveMultiples(sieve, i);
            }
        }
    }

    private void RemoveMultiples(IList<bool> sieve, int prime)
    {
        for (var multiple = prime * prime; multiple <= _limit; multiple += prime)
        {
            sieve[multiple] = false; // Mark multiples of prime as non-prime
        }
    }

    private IEnumerable<int> SieveToPrimes(IReadOnlyList<bool> sieve)
    {
        var primes = new List<int>();

        for (var i = FirstPrime; i <= _limit; i++)
        {
            if (sieve[i])
            {
                primes.Add(i); // Collect prime numbers
            }
        }

        return primes;
    }
}
