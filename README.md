# Prime Factors

Cette application console en C# permet de détecter les nombres premiers et les facteurs premiers d'un intervalle de nombres.

## Objectif

Le projet contient deux exemples complémentaires :

- `PrimeFactors` : analyse les nombres et affiche leurs facteurs premiers.
- `PrimeWithDynamicSearch` : recherche les nombres premiers de manière plus rapide en enrichissant progressivement une liste de diviseurs possibles.

## Fonctionnement

### 1. PrimeFactors

Le programme parcourt les nombres de 2 jusqu'à une limite définie (`endNumber`), puis :

- vérifie si chaque nombre est premier,
- affiche les facteurs premiers trouvés,
- enregistre le résultat dans un fichier CSV nommé `NumberFactors_<limit>.csv`.

L'application utilise des méthodes de calcul de primalité et de recherche de diviseurs pour produire des résultats exploitables dans un fichier de sortie.

### 2. PrimeWithDynamicSearch

Cette version cible une optimisation de la recherche des nombres premiers :

- elle commence avec une liste initiale de diviseurs possibles (`2, 3, 5, 7`),
- teste chaque nombre impair,
- ajoute les nouveaux nombres premiers découverts à la liste pour accélérer les vérifications suivantes,
- enregistre les résultats dans un fichier texte `PrimeNumbers_<limit>.txt`.

## Exemple de sortie

Le programme affiche des informations du type :

```text
Recherche des facteurs diviseurs d'un nombre
2;True
3;True
4;False;2
5;True
6;False;2;3
```

## Structure du projet

```text
PrimeFactors/
├── PrimeFactors.sln
├── PrimeFactors/
│   └── Program.cs
├── PrimeWithDynamicSearch/
│   └── Program.cs
├── README.md
└── LICENSE.txt
```

## Prérequis

- .NET SDK installé sur votre machine
- Un terminal ou une invite de commande pour lancer l'application

## Lancer le projet

Depuis la racine du dépôt :

```bash
dotnet build
```

Pour exécuter la version principale :

```bash
dotnet run --project PrimeFactors/PrimeFactors.csproj
```

Pour exécuter la version optimisée :

```bash
dotnet run --project PrimeWithDynamicSearch/PrimeWithDynamicSearch.csproj
```

## Résultat

Les applications permettent d'explorer la notion de nombres premiers et de factorisation, avec une approche simple et pédagogique de recherche algorithmique en C#.

---

# English version

This console application in C# detects prime numbers and prime factors across a range of values.

## Purpose

The project contains two complementary examples:

- `PrimeFactors`: analyzes numbers and displays their prime factors.
- `PrimeWithDynamicSearch`: finds prime numbers more efficiently by progressively expanding a list of possible divisors.

## How it works

### 1. PrimeFactors

The program loops from 2 up to a configured limit (`endNumber`) and then:

- checks whether each number is prime,
- prints the prime factors found,
- saves the results to a CSV file named `NumberFactors_<limit>.csv`.

The application uses primality-checking and divisor-search methods to generate data that can be stored in an output file.

### 2. PrimeWithDynamicSearch

This version focuses on improving prime-number detection performance:

- it starts with an initial list of possible divisors (`2, 3, 5, 7`),
- tests each odd number,
- adds newly discovered prime numbers to the list to speed up the next checks,
- writes the results to a text file named `PrimeNumbers_<limit>.txt`.

## Example output

The program prints output similar to:

```text
Recherche des facteurs diviseurs d'un nombre
2;True
3;True
4;False;2
5;True
6;False;2;3
```

## Project structure

```text
PrimeFactors/
├── PrimeFactors.sln
├── PrimeFactors/
│   └── Program.cs
├── PrimeWithDynamicSearch/
│   └── Program.cs
├── README.md
└── LICENSE.txt
```

## Prerequisites

- .NET SDK installed on your machine
- A terminal or command prompt to run the app

## Run the project

From the repository root:

```bash
dotnet build
```

To run the main version:

```bash
dotnet run --project PrimeFactors/PrimeFactors.csproj
```

To run the optimized version:

```bash
dotnet run --project PrimeWithDynamicSearch/PrimeWithDynamicSearch.csproj
```

## Result

These applications explore the concept of prime numbers and factorization using a simple and educational algorithmic approach in C#.
