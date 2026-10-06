using System.Numerics;

Action<string> print = Console.WriteLine;
Action<string> printWithoutLineFeed = Console.Write;
print("Search for BigInteger Prime");

print("Recherche des facteurs diviseurs d'un nombre");

BigInteger startNumber = ulong.MaxValue;
BigInteger endNumber = startNumber + 100;

List<string> fullResult = new();
for (BigInteger number = startNumber; number <= endNumber; number += 2)
{
  // DetectPrimeFactors(number, print);
  fullResult.Add(PrimeAllFactors(number));
  print(number.ToString());
}

// saving the results to a file
string filePath = $"NumberFactors_{endNumber}.csv";
File.WriteAllLines(filePath, fullResult);
print("Results saved to file: " + filePath);
print("Press any key to exit...");
Console.ReadKey();

string PrimeAllFactors(BigInteger number)
{
  if (number <= 1)
  {
    return $"{number};false";
  }

  if (IsPrime(number))
  {
    return $"{number};true";
  }

  var divisors = new List<BigInteger>();
  for (BigInteger divisor = 2; divisor <= number; divisor++)
  {
    if (number % divisor == 0 && number != divisor)
    {
      divisors.Add(divisor);
    }
  }

  return $"{number};false;{string.Join(";", divisors)}";
}

void DetectPrimeFactors(BigInteger number, Action<string> print)
{
  if (IsPrime(number))
  {
    print($"{number};True");
    return;
  }

  PrintWithoutLineFeed($"{number};False;");
  for (BigInteger divisor = 2; divisor <= number; divisor++)
  {
    if (IsPrime(divisor) && number % divisor == 0)
    {
      PrintWithoutLineFeed($"{divisor};");
    }
  }

  print(string.Empty); // New line after printing all prime factors
}

void PrintWithoutLineFeed(string message)
{
  Console.WriteLine(message);
}

/// <summary>Calculate if a big Integer number is prime.</summary>
/// <param name="number">The number to calculate its primality.</param>
/// <returns>Returns True if the number is a prime, False otherwise.</returns>
static bool IsPrime(BigInteger number)
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

  for (BigInteger divisor = 11; divisor * divisor <= number; divisor += 2)
  {
    if (number % divisor == 0)
    {
      return false;
    }
  }

  return true;
}

static bool IsPrimeWithPossibleDivisors(BigInteger number, List<BigInteger> possibleDivisors)
{
  if (number.IsEven && number != 2) // even numbers are not prime except 2
  {
    return false;
  }

  if (number.Sign == 0 || number.Sign == -1)
  {
    return false; // calculate only positive numbers
  }

  if (possibleDivisors.Contains(number))
  {
    return true;
  }

  foreach (BigInteger divisor in possibleDivisors)
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
