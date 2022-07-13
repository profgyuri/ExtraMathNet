namespace ExtraMathNet;

/// <summary>
/// Class used to generate prime numbers and prime factorization.
/// </summary>
public class PrimeNumbers
{
    /// <summary>
    /// The integer part of the square root of a number.
    /// </summary>
    private long _sqrtBase;
    private readonly List<long> _primes;

    /// <summary>
    /// Initializes a new instance of the <see cref="PrimeNumbers"/> class.
    /// </summary>
    public PrimeNumbers()
    {
        _primes = new List<long>{2, 3};
    }
    
    /*We only need to compare the integer part of the square root.
     * Only marginally, but faster than Math.Sqrt <br/>
     * For the logic of this method see: https://youtu.be/PJHtqMjrStk */
    private void SetSqrtBase(long number)
    {
        if (number - _sqrtBase * _sqrtBase > _sqrtBase + _sqrtBase)
        {
            _sqrtBase++;
        }
    }
    
    private void CheckAndAddIfPrime(long number)
    {
        SetSqrtBase(number);
        //We skip number 2 and 3 from checking, since we don't need it based on the 6 step idea.
        //Also we don't need to go above the square root of the number.
        for (var i = 2; i < _primes.Count; i++)
        {
            //If the remainder of division with any prime equals to 0, the checked number is not a prime.
            if (number % _primes[i] == 0)
            {
                return;
            }

            if (_primes[i] > _sqrtBase)
            {
                break;
            }
        }

        //If we don't get 0 as remainder, the number is prime.
        _primes.Add(number);
    }
    
    /// <summary>
    /// Gets the first bigger number that is evenly divisible by 6
    /// to check if it's neighbours are prime.
    /// </summary>
    /// <returns></returns>
    private long GetCurrent()
    {
        //make the current number equal to the next number divisible by 6
        var current = _primes[^1];
        current += 6 - current % 6;

        if (current - 1 == _primes[^1])
        {
            CheckAndAddIfPrime(current + 1);
            current += 6;
        }

        return current;
    }
    
     /// <summary>
    /// Calculates the first <paramref name="n"/> prime numbers, if haven't already calculated.
    /// </summary>
    /// <param name="n">The total number of primes to calculate.</param>
    public void CalculateFirstNPrimes(int n)
    {
        if (_primes.Count >= n)
        {
            return;
        }

        //To continue calculation from the last prime already in the list.
        var current = GetCurrent();

        while (_primes.Count < n)
        {
            CheckAndAddIfPrime(current - 1);
            //not checking if we have the correct amount here sacrifices precision in favor of speed
            CheckAndAddIfPrime(current + 1);

            //increasing the current base value, taking into account that every prime number is next to a multiple of 6
            current += 6;
        }

        if (_primes.Count > n)
        {
            _primes.RemoveAt(_primes.Count - 1);
        }
    }

    /// <summary>
    /// Calculates primes up to <paramref name="n"/> inclusive.
    /// </summary>
    /// <param name="n">The maximum allowed value of a prime upon calculation.</param>
    public void CalculatePrimesUpToN(long n)
    {
        if (_primes[^1] >= n)
        {
            return;
        }

        var current = GetCurrent();

        for (var i = current; i <= n + 1; i += 6)
        {
            CheckAndAddIfPrime(i - 1);
            CheckAndAddIfPrime(i + 1);
        }

        if (_primes[^1] > n)
        {
            _primes.RemoveAt(_primes.Count - 1);
        }
    }

    /// <summary>
    /// Gets the prime factors of every positive integer below 2^64
    /// </summary>
    /// <param name="number">The number to get the prime factor of.</param>
    /// <returns>A dictionary of the prime factorization of the input number,
    /// where the key is the prime, and the value is it's exponent.</returns>
    public Dictionary<ulong, byte> GetPrimeFactors(ulong number)
    {
        var factors = new Dictionary<ulong, byte>();
        var primeNumberCount = 2;
        var primeIndex = 0;
        var sqrt = Math.Sqrt(number);

        while (number > 1)
        {
            if (primeIndex == primeNumberCount)
            {
                //Adding more primes as needed.
                CalculateFirstNPrimes(++primeNumberCount);
            }

            if (_primes[primeIndex] > sqrt)
            {
                //If the algorithm cannot find primes under the square root, the input number is a prime itself.
                factors.Add(number, 1);
                break;
            }

            var prime = (ulong)_primes[primeIndex++];

            //As long as we can divide the input with the current prime, add it to the factors.
            while (number % prime == 0)
            {
                number /= prime;

                if (!factors.ContainsKey(prime))
                {
                    factors.Add(prime, 0);
                }
                
                factors[prime]++;
            }
        }

        return factors;
    }

    /// <summary>
    /// Gets every calculated prime numbers.
    /// </summary>
    /// <returns>A list of previously calculated prime numbers.</returns>
    public List<long> GetCalculatedPrimes()
    {
        return _primes;
    }
}