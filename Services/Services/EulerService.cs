using Services.Interfaces;

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
}