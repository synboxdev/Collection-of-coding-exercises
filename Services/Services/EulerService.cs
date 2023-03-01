﻿using Services.Interfaces;
using System.Collections;

namespace Services;

/// <summary>
/// This category of exercise is rather unique, since all of the exercises here will be based on 'Project Euler'.
/// Read more about it in README.md file, located in the root folder of the project, as well as in here: https://projecteuler.net/ 
///     
/// By no means, these are the most efficient, optimized, or maybe even correct solutions. 
/// Take it with a grain of salt and use your best judgment. Feel free to provide your own solutions or suggest changes! (See CONTRIBUTING.md in the root folder of the project) 
/// </summary>
public class EulerService : IEulerService
{
    private readonly INumbersService _numbersService;

    public EulerService(INumbersService numbersService)
    {
        _numbersService = numbersService;
    }

    /// <summary>
    /// Problem #1
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// Read more here: https://projecteuler.net/problem=1
    /// </summary>
    public int MultiplesOf3And5()
    {
        Console.WriteLine($"We will be finding the sum of multiple of 3 and 5, below 1000.");

        // Define a variable to hold the total sum.
        int totalSum = 0;

        // Iterate from zero, to BELOW 1000 (Which will be 999)
        for (int i = 0; i < 1000; i++)
            // Here's the solution - IF the value of current iterator i leaves NO remainder when divided from 3 OR 5, we add its value to the total sum.
            totalSum += i % 3 == 0 || i % 5 == 0 ? i : 0;

        Console.WriteLine($"Total sum of multiples of 3 and 5, below 1000 is equal to {totalSum}");
        return totalSum;
    }

    public int MultiplesOf3And5UsingLINQ()
    {
        Console.WriteLine($"We will be finding the sum of multiple of 3 and 5, below 1000.");

        // We define a variable to hold the total sum and calculate it right away utilizing LINQ functions.
        // Enumerable.Range will generate us a sequence of elements, starting from zero.
        // We then SUM the numbers that fit the condition. Our condition is same as in previous solution - IF the value of current iterator i leaves NO remainder when divided from 3 OR 5, we add its value to the total sum.
        int totalSum = Enumerable.Range(0, 1000).Where(number => number % 3 == 0 || number % 5 == 0).Sum();

        Console.WriteLine($"Total sum of multiples of 3 and 5, below 1000 is equal to {totalSum}");
        return totalSum;
    }

    /// <summary>
    /// Problem #2
    /// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
    /// Read more here: https://projecteuler.net/problem=2
    /// </summary>
    public int EvenFibonacciNumbers()
    {
        // We will largely re-use our previously solved solution's logic from 'Numbers' category - 'FibonacciSeriesCalculationAndDisplay'
        Console.WriteLine("We will be calculating the sum of even-valued Fibonacci sequence elements, whose values do not exceed four million");

        // We initialize the first two values of our Fibonacci sequence which will be 2 and 4 (Since these are first even-valued values from zero), and add them to our list of integer elements.
        int firstNumber = 2;
        int secondNumber = 4;
        List<int> fibonacciSequence = new List<int> { firstNumber, secondNumber };

        // The exit condition with 'break' keyword is defined inside the loop itself.
        while (true)
        {
            var nextNumber = firstNumber + secondNumber;        // Value of the next element in the sequence, is the addition of previous two.
            firstNumber = secondNumber;                         // Then - our first number gets value of the second one..
            secondNumber = nextNumber;                          // .. and our second number gets value of next number's (the one that was just calculated) value.

            if (nextNumber <= 4000000 && nextNumber % 2 == 0)   // If the next number is below four million AND it happens to be an even-valued number - add it the list.
                fibonacciSequence.Add(nextNumber);
            else if (nextNumber <= 4000000)                     // If the next number is simply below four million (and is NOT even-valued) - continue iterating and re-calculating the next number.
                continue;
            else break;                                         // If our number is above four million - regardless whether its odd or even, we exit out of the loop.
        }

        int totalSum = fibonacciSequence.Sum();                 // Our total sum will simple be equal to the sum of all elements in the list. Since we've already ensued that it only contains even-valued Fibonacci sequence elements, whose values do not exceed four million.
        Console.WriteLine($"Sum of even-valued Fibonacci sequence elements, whose values do not exceed four million is equal to {totalSum}");
        return totalSum;
    }

    /// <summary>
    /// Problem #3
    /// Find the largest prime factor of the number 600851475143
    /// Read more here: https://projecteuler.net/problem=3
    /// </summary>
    public int LargestPrimeFactor()
    {
        // Define the variable in question.
        double inputNumber = 600851475143;
        Console.WriteLine($"We will be finding the largest prime factor of the number {inputNumber}");

        // Initialize a variable that will hold the largest prime factor for our number.
        var largestPrimeFactor = 0;
        // Also, initialize a range of values, that are rounded-up square roots of our input number. Reason for this is to reduce the number of total iterations required.
        var range = Enumerable.Range(1, (int)Math.Round(Math.Sqrt(inputNumber) + 1));

        // Iterate over every element in out range (defined above)
        foreach (var element in range)
        {
            // Create a temporary number that will either hold the value of a factor or will simply remain null.
            int? factor = inputNumber % element == 0 ? element : null;

            // Assign a value to our 'largest prime factor' variable under the following three conditions:
            // 1. Our factor has to have a value (not be null).
            // 2. Our factor has to be a prime number (Call a method from previously solved exercise in 'Numbers' category)
            // 3. And lastly - our factor must be a higher value than the previously saved value. (Since we're looking for the largest prime factor)
            // If the condition above are met - new value for our 'largest prime factor' variable is assigned. 
            largestPrimeFactor = (int)(factor != null &&
                                       _numbersService.CheckIfNumberIsPrime(factor, true) &&
                                       factor > largestPrimeFactor ?
                                       factor : largestPrimeFactor);
        }

        // Once the loop has finished, display the results to the console window
        Console.WriteLine($"{(largestPrimeFactor > 0 ?
                          $"Largest prime factor for number {inputNumber} is equal to {largestPrimeFactor}" :
                          $"Number {inputNumber} does NOT even have a single valid prime factor")}");
        return largestPrimeFactor;
    }

    /// <summary>
    /// Problem #4
    /// Find the largest palindrome made from the product of two 3-digit numbers
    /// Read more here: https://projecteuler.net/problem=4
    /// </summary>
    public int LargestPalindromeProduct()
    {
        Console.WriteLine($"We will be looking for largest palindrome made from the product of two 3-digit numbers");

        // Define a variable to hold the highest valued palindrome.
        int largestPalindromeProduct = 0;

        // Utilize two for loops, each starting from 100, all the way to 999 (including 999).
        // When iterating over these loops, two conditions must be met:
        // 1. Product of multiplication, converted into a string, is equivalent to itself, when it is reversed.
        // 2. Resulting value of multiplication (as a numeric value) is higher than our currently saved 'largestPalindromeProduct'.
        // If both conditions are met - override our current 'largestPalindromeProduct' with current multiplication result. Otherwise, 'largestPalindromeProduct' value remains the same.
        for (int i = 100; i <= 999; i++)
            for (int j = 100; j <= 999; j++)
                largestPalindromeProduct = (i * j).ToString().SequenceEqual((i * j).ToString().Reverse()) && i * j > largestPalindromeProduct ?
                                            i * j :
                                            largestPalindromeProduct;

        // Display the result to the console window
        Console.WriteLine($"Largest palindrome made from the product of two 3-digit numbers is equal to {largestPalindromeProduct}");
        return largestPalindromeProduct;
    }

    public int LargestPalindromeProductUsingLINQ()
    {
        Console.WriteLine($"We will be looking for largest palindrome made from the product of two 3-digit numbers");

        // Define a variable to hold the highest valued palindrome.
        int largestPalindromeProduct = 0;

        // Create an Enumerable collection of all three digit numbers. Starting from 100, all the way to 999.
        var threeDigitNumbers = Enumerable.Range(100, 900);

        // Create a LINQ Query that will technically join our three digit numbers' enumerable collection with itself, and determine whether the product of multiplication is a palindromic string.
        var query = from first in threeDigitNumbers
                    from second in threeDigitNumbers
                    let product = first * second
                    where product.ToString().SequenceEqual(product.ToString().Reverse())
                    select product;

        // Once the query is formed and all palindromes are extracted from the three digit numbers' enumerable collection - retrieve the highest valued element, and that is going to be our solution to the exercise.
        largestPalindromeProduct = query.Max();

        // Display the result to the console window
        Console.WriteLine($"Largest palindrome made from the product of two 3-digit numbers is equal to {largestPalindromeProduct}");
        return largestPalindromeProduct;
    }

    /// <summary>
    /// Problem #5
    /// Find the smallest positive number that is evenly divisible by all of the numbers from 1 to 20
    /// Read more here: https://projecteuler.net/problem=5
    /// </summary>
    public int SmallestMultiple()
    {
        // Probably one of the most simple solutions to this exercise.
        // With very rough estimations, using Stopwatch class if we were to start smallestMultiple from 1, and increase it by one each iteration, solution is found in ~3.6 - 3.7 seconds. However, starting from 20, and increasing it by 20 each iteration, improves our solution time down to 0.3 seconds, which is quite nice.
        Console.WriteLine($"We will be looking for smallest positive number that is evenly divisible by all of the numbers from 1 to 20");

        // Define two variables before iterating to find the solutions. Default starting value for our smallest multiple, starting from 20, and a boolean variable to act as a 'trigger' using which we can break out of the loop, when the solution is found.
        int smallestMultiple = 20;
        bool isDivisibleByAll = false;

        // Loop, until the solution is found, and boolean variable is false.
        while (!isDivisibleByAll)
        {
            // Each iteration, we do internal loop, from 1 to 20 (inclusively), and check whether a given 'smallest multiple' variable is divisible without remainder from each iterator value.
            // If its not - we can instantly break out of the looping, since there's no point in checking other divisions.
            for (int i = 1; i <= 20; i++)
            {
                isDivisibleByAll = smallestMultiple % i == 0;
                if (!isDivisibleByAll) break;
            }

            // If the boolean variable holds TRUE, when division WITHOUT remainder was check for all numbers 1-20, that mean the current 'smallest multiple' variable IS the solution to our exercise - we can fully break out of the loop.
            if (isDivisibleByAll)
                break;

            // If the solution is yet to be found - we increase our current 'smallest multiple' variable by 20.
            // This is more efficient than increasing it by one each iteration, since our number must be divisible out of 20 anyway, so might as well increase it by the maximum number that it must be divisible out of.
            smallestMultiple += 20;
        }

        Console.WriteLine($"Smallest positive number that is evenly divisible by all of the numbers from 1 to 20 is equal to {smallestMultiple}");
        return smallestMultiple;
    }

    /// <summary>
    /// Problem #6
    /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum
    /// Read more here: https://projecteuler.net/problem=6
    /// </summary>
    public int SumSquareDifference()
    {
        // This is a rather simple, yet functional and easily understandable solution to this exercise, without using mathematical derivations that would require an extensive further explanations, but instead - utilizing simple functionalities that we're provided with.
        Console.WriteLine($"We will be looking for difference between the sum of the squares of the first one hundred natural numbers and the square of the sum");

        int sumOfSquares = 0;       // This is sum of squares of each element. For examples 1^2 + 2^2 + 3^2 ... = ...
        int sumOfNumbers = 0;       // This will be needed to calculate the square of the sum.

        // We can utilize a single loop, to make all the necessary calculation, for both of our variables. Iterate starting from 1, all the way to 100 (inclusively)
        for (int i = 1; i <= 100; i++)
        {
            sumOfSquares += (int)Math.Pow(i, 2);
            sumOfNumbers += i;
        }

        // This is square of COMBINED sum of elements in a range. For example (1 + 2 + 3)^2 = ...
        // Once we've calculated the sum of numbers, we can raise it to the power of two, and get the square of the sum.
        int squareOfTheSum = (int)Math.Pow(sumOfNumbers, 2);

        // Calculate the difference between square of the sum of numbers, minus sum of squares, and display the results to the console window
        int difference = squareOfTheSum - sumOfSquares;
        Console.WriteLine($"Difference between the sum of the squares of the first one hundred natural numbers and the square of the sum is equal to {difference}");
        return difference;
    }

    /// <summary>
    /// Problem #7
    /// Find the value of 10001st prime number
    /// Read more here: https://projecteuler.net/problem=7
    /// </summary>
    public int Get10001stPrime()
    {
        // Simple, easy to understand, rather elegant, but by far not the most efficient solution for the exercise.
        Console.WriteLine($"We will be looking for the value of 10001st prime number");

        // Initialize the variable to hold the number of primes we've iterated over, and hold the value of the current number. We start out from 2 since its the first prime number.
        int primeCounter = 0;
        int currentNumber = 2;

        // Iterate until we've found 10001 primes.
        while (primeCounter < 10001)
        {
            // If the current number IS a prime number - increase our prime number counter by one. Otherwise - it remains its value.
            primeCounter = _numbersService.CheckIfNumberIsPrime(currentNumber, true) ? primeCounter + 1 : primeCounter;

            // If we've found 10001 prime numbers - break out of the loop.
            if (primeCounter == 10001)
                break;
            // Otherwise - increase our current number by one, and continue with the next iteration of the loop.
            else
                currentNumber++;
        }

        // Display our results into the console window
        Console.WriteLine($"10001st prime number is equal to {currentNumber}");
        return currentNumber;
    }

    /// <summary>
    /// Problem #8
    /// Find the thirteen adjacent digits in the 1000-digit number that have the greatest product.
    /// Read more here: https://projecteuler.net/problem=8
    /// </summary>
    public int[] LargestProductInASeries()
    {
        // This is one thousand digits that are provided by the exercise. I've put it in a single, long string.
        string oneThousandDigits = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
        Console.WriteLine($"We will be looking for the thirteen adjacent digits in the 1000-digit number that have the greatest product");
        Console.WriteLine($"One thousand digits in question are the following: {oneThousandDigits}");

        // Define a few temporary variables that we'll need to find the solutions:
        // The number of adjacent numbers that we're looking the product of, a variable to hold the value of their multiplication, and an integer array, to hold the values of the digits themselves.
        int adjacentRange = 13;
        double greatestProduct = 0;
        int[] subsetOfElements = new int[adjacentRange];

        // Iterate over the input string of digits, all the way to 986'th position. That's 1000 - 13 - 1.
        // We subtract the number of the elements that we're looking for, plus an extra one, since we're staring iteration from the 0'th position element.
        for (int i = 0; i < oneThousandDigits.Length - adjacentRange - 1; i++)
        {
            // Get an array of adjacent number. We do that by calling Substring function from LINQ library, and retrieving the numeric value of each char type element.
            var adjacentNumbers = oneThousandDigits.Substring(i, adjacentRange).Select(number => Char.GetNumericValue(number)).ToArray();

            // Initialize a temporary variable to hold the value of the product of multiplication of our digits. Give it initial value of 1, since if we multiple our element with zero - we'll end up with zero.
            double productOfMultiplication = 1;
            foreach (var number in adjacentNumbers)
                productOfMultiplication *= number;

            // If the product of multiplication is greater than previously saved - that means we've found thirteen adjacent digits, whose product is a greater value.
            if (productOfMultiplication > greatestProduct)
            {
                // Replace the value of previously saved greatest product with a new value.
                greatestProduct = productOfMultiplication;
                // And save those adjacent digits into our 'subset of elements' variable.
                subsetOfElements = adjacentNumbers.Select(number => Convert.ToInt32(number)).ToArray();
            }
        }

        // Once the loop above is finished, we'll end up with a solution to our exercise. Display the results to the console window.
        Console.WriteLine($"Greatest product of {adjacentRange} adjacent digits in the given 1000 digits is equal to {greatestProduct}. And the digits themselves are the following:");
        subsetOfElements.ToList().ForEach(x => Console.Write($"{x} "));
        return subsetOfElements;
    }

    /// <summary>
    /// Problem #9
    /// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which, a^2 + b^2 = c^2.
    /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    /// Find the product a*b*c
    /// Read more here: https://projecteuler.net/problem=9
    /// </summary>
    public int SpecialPythagoreanTriplet()
    {
        // Define the sum, to which variables a, b and c should sum to.
        int sumOfTriplet = 1000;
        Console.WriteLine($"We will be looking for a product of Pythagorean triplet for which the sum of three numbers is equal to {sumOfTriplet}");

        // Here's equations the we must keep in mind, when looking for a solution
        // 1. a < b < c
        // 2. a^2 + b^2 = c^2
        // 3. c = 1000 - a - b      This means, that variable c is directly dependent on values of a and b. 

        // Define a variable to hold the product of the Pythagorean triplet for which the sum of three numbers is equal to 1000. 
        int? finalProduct = null;

        int b = 0;                              // Define the iterator 'b' before the loop.
        while (b <= sumOfTriplet / 2)           // Iteration for 'b' will loop until its value is equal or less than HALF of total sum of triplet.
        {
            int a = 0;                          // Define the iterator 'a' before the loop.
            while (a < b)                       // Iteration for 'a' will loop until its less than 'b'. Since we must follow equation '1' (See above).
            {
                int c = sumOfTriplet - a - b;   // Value of 'c' is equal to sum of triplets, minus 'a' and minus 'a'. See equation '3' above.

                if (a * a + b * b == c * c)     // If the number fits the rule-set of Pythagorean triplet - save the product of multiplication to our 'final product' variable, and break out of the loop.
                {
                    finalProduct = a * b * c;
                    break;
                }

                a++;                            // Once an iteration has passed, increase iterator 'a' by one.
            }
            if (finalProduct != null)           // If our 'final product' has gained a value, i.e. is no longer a null - we can break out of the 'b' loop as well, since we've already found the solution to the exercise.
                break;

            b++;                                // Once an iteration has passed, increase iterator 'b' by one.
        }

        Console.WriteLine($"A product of the Pythagorean triplet, whose numbers sum to 1000, is equal to {finalProduct}");
        return (int)finalProduct;
    }

    /// <summary>
    /// Problem #10
    /// Find the sum of all the primes below two million
    /// Read more here: https://projecteuler.net/problem=10
    /// We'll be implementing a simplified version of 'Sieve of Eratosthenes' algorithm.
    /// Read more here: https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
    /// </summary>
    public double SummationOfPrimes()
    {
        Console.WriteLine($"We will be looking for the sum of all the primes below two million");

        // Define a variable to hold the total sum of primes, below two million, as well as the upper limit of our exercise, which is two million.
        double totalSum = 0;
        int maxValue = 2000000;

        // Initialize a variable equivalent to the square root of our maximum value to reduce the amount of prime calculations that needs to be done.
        var sqrtOfMaxValue = (int)Math.Sqrt(maxValue);
        // Initialize a BitArray, which you can consider as a more compact and more efficient variation of a boolean array.
        // Consider this as a list of 'flags' which equate to TRUE if a given number is NOT a prime number, and FALSE is a number IS a prime number.
        // Prior to further explanation - reason for this seemingly 'inverted' flagging, is because default value of BitArray elements is false. So we simply INVERT the value for numbers that are NOT primes.
        BitArray composites = new BitArray(maxValue);

        // First loop start at two (which is the very first prime), all the way to square root of our maximum value.
        for (int i = 2; i <= sqrtOfMaxValue; ++i)
        {
            // If a given number's equivalent 'flag' is TRUE - its NOT a prime number, we skip over it.
            if (composites[i]) continue;

            // Otherwise - we will iterate over ALL the multiples of a given number, and set their 'flag' to TRUE, meaning - all those numbers are NOT primes.
            // For example, we start from 2 (which is the first prime). This method will start from 4, then go to 6, 8, 10, etc., and 'flag' all those numbers as NOT primes
            // Next example - number 3. This method will flag 9, 12, 15... as NOT primes. Next example - number 5. This method will flag 16, 20, 24... as NOT primes.
            for (int j = i * i; j < maxValue; j += i)
                composites[j] = true;

            // Finally - add our current iterator number i to the total sum. If it WAS NOT a prime, it would've been skipped at the start of this loop.
            totalSum += i;
        }

        // After all primes that are below the square root of our max value have been added to the total sum, and ALL multiples of them have been flagged, we must add the remaining primes to the total sum.
        for (int i = sqrtOfMaxValue + 1; i < maxValue; ++i)
            // If a given number has 'FALSE' flag, which mean it IS a prime number, add its value to the total sum.
            totalSum += !composites[i] ? i : 0;

        Console.WriteLine($"Total sum, of all prime numbers below two million is equal to {totalSum}");
        return totalSum;
    }

    /// <summary>
    /// Problem #11
    /// Find greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid
    /// Read more here: https://projecteuler.net/problem=11
    /// </summary>
    public int LargestProductInAGrid()
    {
        Console.WriteLine($"We will be looking for greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid");
        var grid = new int[,]
        {
            { 08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08 },
            { 49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00 },
            { 81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65 },
            { 52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91 },
            { 22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80 },
            { 24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50 },
            { 32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70 },
            { 67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21 },
            { 24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72 },
            { 21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95 },
            { 78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92 },
            { 16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57 },
            { 86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58 },
            { 19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40 },
            { 04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66 },
            { 88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69 },
            { 04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36 },
            { 20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16 },
            { 20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54 },
            { 01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48 }
        };
        Console.WriteLine("Here's our input 20x20 grid of integers:");
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write($"{grid[i, j]}\t");
            }
            Console.WriteLine("\n");
        }

        // Initialize a list of integer type arrays, into which we'll store sub sections of four adjacent element in one of eight possible directions.
        List<int[]> subSections = new List<int[]>();

        // Basic premise of the following two loops, and conditions is the following:
        // First, we ensure that we've got at LEAST four elements in a given direction, including our current element.
        // Then, we proceed to take those four elements, and store them as an individual array into our list of sub sections.
        // For horizontal and vertical directions (Up, Down, Left, Right), we utilize LINQ's Enumerable.Range function, which simply takes 4 elements from a given index either row-wise or column-wise.
        // For the remaining four diagonal directions - we utilize an unusual for loop, which has three iterators, one of which is used to define index in the subsection's array, and two others - to navigate to a proper location in our grid.
        // Most 'difficult' part about this exercise, is not getting lost between all the indexes. Once you get the hang of it - it relatively simple.

        // Iterate over each COLUMN.
        for (int columnIndex = 0; columnIndex < grid.GetLength(0); columnIndex++)
        {
            // Iterate over each ROW
            for (int rowIndex = 0; rowIndex < grid.GetLength(1); rowIndex++)
            {
                // RIGHT
                if (columnIndex + 3 < grid.GetLength(0))
                    subSections.Add(Enumerable.Range(columnIndex, 4).Select(i => grid[rowIndex, i]).ToArray());
                // LEFT
                if (columnIndex - 3 >= 0)
                    subSections.Add(Enumerable.Range(columnIndex - 3, 4).Select(i => grid[rowIndex, i]).ToArray());
                // UP
                if (rowIndex - 3 >= 0)
                    subSections.Add(Enumerable.Range(rowIndex - 3, 4).Select(i => grid[i, columnIndex]).ToArray());
                // DOWN
                if (rowIndex + 3 < grid.GetLength(1))
                    subSections.Add(Enumerable.Range(rowIndex, 4).Select(i => grid[i, columnIndex]).ToArray());
                // DOWN RIGHT
                if (columnIndex + 3 < grid.GetLength(0) &&
                    rowIndex + 3 < grid.GetLength(1))
                {
                    int[] subSection = new int[4];
                    for (int i = 0, j = columnIndex, k = rowIndex; i < 4; i++, j++, k++)
                        subSection[i] = grid[j, k];

                    subSections.Add(subSection);
                }
                // DOWN LEFT
                if (columnIndex - 3 >= 0 &&
                    rowIndex - 3 >= 0)
                {
                    int[] subSection = new int[4];
                    for (int i = 0, j = columnIndex, k = rowIndex; i < 4; i++, j--, k--)
                        subSection[i] = grid[j, k];

                    subSections.Add(subSection);
                }
                // UP RIGHT
                if (columnIndex + 3 < grid.GetLength(0) &&
                    rowIndex - 3 >= 0)
                {
                    int[] subSection = new int[4];
                    for (int i = 0, j = columnIndex, k = rowIndex; i < 4; i++, j++, k--)
                        subSection[i] = grid[j, k];

                    subSections.Add(subSection);
                }
                // UP LEFT
                if (columnIndex - 3 >= 0 &&
                    rowIndex - 3 >= 0)
                {
                    int[] subSection = new int[4];
                    for (int i = 0, j = columnIndex, k = rowIndex; i < 4; i++, j--, k--)
                        subSection[i] = grid[j, k];

                    subSections.Add(subSection);
                }
            }
        }

        // Create a list of integers, which will store all products of multiplication of our sub sections.
        List<int> productsOfSubsections = new List<int>();
        foreach (var subSection in subSections)
            productsOfSubsections.Add(subSection.Aggregate((a, x) => a * x));   // Instead of using a loop, we can utilize LINQ's Aggregate function.
                                                                                // Think of it as 'pushing' two elements together with a pre defined math operation being applied between them. In this case - its multiplication.

        // Our solution, is the highest valued product of four adjacent elements in the grid.
        int greatestProduct = productsOfSubsections.Max();

        // Display result to the console window.
        Console.WriteLine($"Greatest product of four adjacent elements in our grid is equal to {greatestProduct}");
        return greatestProduct;
    }

    /// <summary>
    /// Problem #12
    /// Find the value of the first triangle number to have over five hundred divisors
    /// Read more here: https://projecteuler.net/problem=12
    /// </summary>
    public int HighlyDivisibleTriangularNumber()
    {
        // Far from the most optimized solution, but its rather simple, readable, and performs decently (Finds solution in around half a second).
        // To slightly optimize the solution, we'll re-use Prime checking solution from 'Numbers' category. As far as i tested, without it, solution is found in ~3.5s, with it, in about ~0.7s
        Console.WriteLine($"We will be looking for the value of the first triangle number to have over five hundred divisors");

        // Define a few variables that will be needed to find the solution.
        int number = 1;             // Number that will be increased by one, in each iteration.
        int currentNumber = 1;      // Current number will be the cumulative sum, of all previous natural numbers. 
        int numberOfDivisors = 500; // This is our solution's end goal - to find a number, that will have OVER 500 divisors.
        int divisorCounter = 0;     // And this is a temporary counter, to hold number of divisors the current number has. It will be reset after each iteration.

        // While the current number has less than 500 divisors - continue iterating and looking for a solution.
        while (divisorCounter <= numberOfDivisors)
        {
            // If a given number is Prime - it already falls out. Simply iterate our number variable and cumulative current number, and proceed to the next iteration.
            if (_numbersService.CheckIfNumberIsPrime((int)Math.Sqrt(currentNumber), true))
            {
                number++;
                currentNumber += number;
                continue;
            }

            // Iterate from one, to the rounded square of our current number. Reason for this is that square root is a factor to the 'full number', and that vastly reduces the amount of variable we must check.
            for (int i = 1; i <= (int)Math.Sqrt(currentNumber); i++)
            {
                // If the current number is divisible without remainder from iterator i - increase the divisor count by two.
                // Here's an example - Lets say our current number is 400. Its square root is 20.
                // If we start from 1, then 20 / 1 = 20 (No remainder), but so is 400 / 1 = 400 (No remainder)
                // Next iteration, i = 2, then 20 / 2 = 10 (No remainder), but so is 400 / 2 = 200 (No remainder)
                // So in other words - we're hitting two birds with one stone, by significantly reducing the amount of iterations needed, and still getting the correct number of divisors for a given number.
                if (currentNumber % i == 0)
                    divisorCounter += 2;
            }

            // Once we've counter how many divisors our current number has - check if its more than the desired amount. If so - exit the loop entirely.
            if (divisorCounter > numberOfDivisors)
                break;
            // Otherwise - increase our number by one, and add its value to the cumulative sum of our current number. Also - reset the number of divisors of the current number, so it starts at zero for the next iteration.
            else
            {
                number++;
                currentNumber += number;
                divisorCounter = 0;
            }
        }

        // Display the results to the console window
        Console.WriteLine($"First triangle number to have over five hundred divisors is equal to {currentNumber}");
        return currentNumber;
    }
}