using System.Numerics;

namespace PrimeFactors
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello, World!");
    }

    /// <summary>Calculate if a big Integer number is prime.</summary>
    /// <param name="number">The number to calculate its primality.</param>
    /// <returns>Returns True if the number is a prime, False otherwise.</returns>
    public static bool IsPrime(BigInteger number)
    {
      if (number.IsEven && number != 2) // even numbers are not prime except 2
      {
        return false;
      }

      if (number.Sign == 0 || number.Sign == -1)
      {
        return false; // calculate only positive numbers
      }

      if (number == 2 || number == 3 || number == 5 || number == 7)
      {
        return true;
      }

      if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0 || number % 7 == 0)
      {
        return false;
      }

      BigInteger squareRoot = (BigInteger)Math.Pow(Math.E, BigInteger.Log(number) / 2);
      for (BigInteger divisor = 11; divisor < squareRoot; divisor += 2)
      {
        if (number % divisor == 0)
        {
          return false;
        }
      }

      return true;
    }
  }
}
