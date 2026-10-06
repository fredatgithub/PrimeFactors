namespace PrimeWithDynamicSearch
{
  internal class Program
  {
    static void Main()
    {
      Action<string> print = Console.WriteLine;
      print("Recherche des nombres premiers plus rapidement");
      const int endNumber = 10_000_000; // 10_000_000;
      var possibleDivisors = new List<int> { 2, 3, 5, 7 };
      print($"2 est premier avec une liste de diviseur possible de {possibleDivisors.Count}");
      for (int i = 3; i <= endNumber; i += 2)
      {
        if (IsPrime(i, possibleDivisors))
        {
          print($"{i} est premier avec une liste de diviseur possible de {possibleDivisors.Count}");
          if (!possibleDivisors.Contains(i))
          {
            possibleDivisors.Add(i);
          }
        }
      }

      // on écrit les résultats dans un fichier
      string filePath = $"PrimeNumbers_{endNumber}.txt";
      File.WriteAllLines(filePath, possibleDivisors.Select(x => x.ToString()));
      print("Press any key to exit...");
      Console.ReadKey();
    }

    /// <summary>Calculate if an Integer number is prime.</summary>
    /// <param name="number">The number to calculate its primality.</param>
    /// <param name="possibleDivisors">A list of possible divisors to check for primality.</param>
    /// <returns>Returns True if the number is a prime, False otherwise.</returns>
    public static bool IsPrime(int number, List<int> possibleDivisors)
    {
      if (number <= 1)
      {
        return false;
      }

      if (possibleDivisors.Contains(number))
      {
        return true;
      }

      foreach (int divisor in possibleDivisors)
      {
        if (divisor * divisor > number)
        {
          break;
        }

        if (number % divisor == 0)
        {
          return false;
        }
      }

      return true;
    }
  }
}
