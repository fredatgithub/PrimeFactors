using System.Numerics;

namespace PrimeFactors
{
  internal class Program
  {
    static void Main()
    {
      Action<string> print = Console.WriteLine;
      Action<string> printWithoutLineFeed = Console.Write;
      print("Recherche des facteurs diviseurs d'un nombre");
      const int endNumber = 12;
      var fullResult = new List<string>();
      for (int number = 2; number <= endNumber; number++)
      {
        DetectPrimeFactors(number, print);
        fullResult.Add(PrimeAllFactors(number));
      }

      // saving the results to a file
      string filePath = $"NumberFactors_{endNumber}.csv";
      File.WriteAllLines(filePath, fullResult);
      print("Results saved to file: " + filePath);
      print("Press any key to exit...");
      Console.ReadKey();
    }

    private static string PrimeAllFactors(int number)
    {       
      string result = string.Empty;
      if (number <= 1)
      {
        return $"{number};false";
      }

      if (IsPrime(number))
      {
        return $"{number};true";
      }
      
      var divisors = new List<int>();
      for (int divisor = 2; divisor <= number; divisor++)
      {
        if (number % divisor == 0 && number != divisor)
        {
          divisors.Add(divisor);
        }
      }

      return $"{number};false;{string.Join(";", divisors)}";
    }

    public static List<int> GetDiviseurs(int number)
    {
      var diviseurs = new List<int>();

      if (number <= 1)
        return diviseurs;

      for (int i = 2; i * i <= number; i++)
      {
        if (number % i == 0)
        {
          diviseurs.Add(i);

          int autreDiviseur = number / i;

          if (autreDiviseur != i && autreDiviseur != number)
          {
            diviseurs.Add(autreDiviseur);
          }
        }
      }

      diviseurs.Sort();
      return diviseurs;
    }


    private static string PrimeFactors(int number)
    {
      string result = string.Empty;
      if (number <= 1)
      {
        return $"{number};false";
      }
      if (IsPrime(number))
      {
        return $"{number};true";
      }

      var divisors = new List<int>();
      for (int divisor = 2; divisor <= number; divisor++)
      {
        if (IsPrime(divisor) && number % divisor == 0)
        {
          divisors.Add(divisor);
        }
      }

      return $"{number};false;{string.Join(";", divisors)}";
    }

    private static string PrimeFactorsSimple(int number)
    {
      string result = string.Empty;
      if (number <= 1)
      {
        return $"{number};false";
      }

      if (number == 2 || number == 3 || number == 5 || number == 7)
      {
        return $"{number};true";
      }

      if (number % 2 == 0 )
      {
        return $"{number};false;2";
      }

      if (number % 3 == 0 )
      {
        return $"{number};false;3";
      }

      if (number % 5 == 0 )
      {
        return $"{number};false;5";
      } 

      if (number % 7 == 0)
      {
        return $"{number};false;7";
      }

      int sqrt = (int)Math.Sqrt(number);
      var divisors = new List<int>();
      for (int divisor = 11; divisor <= sqrt; divisor += 2)
      {
        if (number % divisor == 0)
        {
          divisors.Add(divisor);
          return $"{number};false;{string.Join(";", divisors)}";
        }
        else
        {
          divisors.Add(divisor);
        }
      }

      return $"{number};true";
    }

    private static void DetectPrimeFactors(int number, Action<string> print)
    {
      if (IsPrime(number))
      {
        print($"{number};True");
        return;
      }

      PrintWithoutLineFeed($"{number};False;");
      for (int divisor = 2; divisor <= number; divisor++)
      {
        if (IsPrime(divisor) && number % divisor == 0)
        {
          PrintWithoutLineFeed($"{divisor};");
        }
      }

      print(string.Empty); // New line after printing all prime factors
    }

    private static void PrintWithoutLineFeed(string message)
    {
      Console.Write(message);
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

    /// <summary>Calculate if an Integer number is prime.</summary>
    /// <param name="number">The number to calculate its primality.</param>
    /// <returns>Returns True if the number is a prime, False otherwise.</returns>
    public static bool IsPrime(int number)
    {
      if (number <= 1)
      {
        return false;
      }

      if (number == 2 || number == 3 || number == 5 || number == 7)
      {
        return true;
      }

      if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0 || number % 7 == 0)
      {
        return false;
      }

      int sqrt = (int)Math.Sqrt(number);
      for (int divisor = 11; divisor <= sqrt; divisor += 2)
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
