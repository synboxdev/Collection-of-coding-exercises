using Services.Interfaces;
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

    /// <summary>
    /// Problem #13
    /// Find the first ten digits of the sum of the following one-hundred 50-digit numbers
    /// Read more here: https://projecteuler.net/problem=13
    /// </summary>
    public string LargeSum()
    {
        string[] oneHundredNumbers =
        {
            "37107287533902102798797998220837590246510135740250",
            "46376937677490009712648124896970078050417018260538",
            "74324986199524741059474233309513058123726617309629",
            "91942213363574161572522430563301811072406154908250",
            "23067588207539346171171980310421047513778063246676",
            "89261670696623633820136378418383684178734361726757",
            "28112879812849979408065481931592621691275889832738",
            "44274228917432520321923589422876796487670272189318",
            "47451445736001306439091167216856844588711603153276",
            "70386486105843025439939619828917593665686757934951",
            "62176457141856560629502157223196586755079324193331",
            "64906352462741904929101432445813822663347944758178",
            "92575867718337217661963751590579239728245598838407",
            "58203565325359399008402633568948830189458628227828",
            "80181199384826282014278194139940567587151170094390",
            "35398664372827112653829987240784473053190104293586",
            "86515506006295864861532075273371959191420517255829",
            "71693888707715466499115593487603532921714970056938",
            "54370070576826684624621495650076471787294438377604",
            "53282654108756828443191190634694037855217779295145",
            "36123272525000296071075082563815656710885258350721",
            "45876576172410976447339110607218265236877223636045",
            "17423706905851860660448207621209813287860733969412",
            "81142660418086830619328460811191061556940512689692",
            "51934325451728388641918047049293215058642563049483",
            "62467221648435076201727918039944693004732956340691",
            "15732444386908125794514089057706229429197107928209",
            "55037687525678773091862540744969844508330393682126",
            "18336384825330154686196124348767681297534375946515",
            "80386287592878490201521685554828717201219257766954",
            "78182833757993103614740356856449095527097864797581",
            "16726320100436897842553539920931837441497806860984",
            "48403098129077791799088218795327364475675590848030",
            "87086987551392711854517078544161852424320693150332",
            "59959406895756536782107074926966537676326235447210",
            "69793950679652694742597709739166693763042633987085",
            "41052684708299085211399427365734116182760315001271",
            "65378607361501080857009149939512557028198746004375",
            "35829035317434717326932123578154982629742552737307",
            "94953759765105305946966067683156574377167401875275",
            "88902802571733229619176668713819931811048770190271",
            "25267680276078003013678680992525463401061632866526",
            "36270218540497705585629946580636237993140746255962",
            "24074486908231174977792365466257246923322810917141",
            "91430288197103288597806669760892938638285025333403",
            "34413065578016127815921815005561868836468420090470",
            "23053081172816430487623791969842487255036638784583",
            "11487696932154902810424020138335124462181441773470",
            "63783299490636259666498587618221225225512486764533",
            "67720186971698544312419572409913959008952310058822",
            "95548255300263520781532296796249481641953868218774",
            "76085327132285723110424803456124867697064507995236",
            "37774242535411291684276865538926205024910326572967",
            "23701913275725675285653248258265463092207058596522",
            "29798860272258331913126375147341994889534765745501",
            "18495701454879288984856827726077713721403798879715",
            "38298203783031473527721580348144513491373226651381",
            "34829543829199918180278916522431027392251122869539",
            "40957953066405232632538044100059654939159879593635",
            "29746152185502371307642255121183693803580388584903",
            "41698116222072977186158236678424689157993532961922",
            "62467957194401269043877107275048102390895523597457",
            "23189706772547915061505504953922979530901129967519",
            "86188088225875314529584099251203829009407770775672",
            "11306739708304724483816533873502340845647058077308",
            "82959174767140363198008187129011875491310547126581",
            "97623331044818386269515456334926366572897563400500",
            "42846280183517070527831839425882145521227251250327",
            "55121603546981200581762165212827652751691296897789",
            "32238195734329339946437501907836945765883352399886",
            "75506164965184775180738168837861091527357929701337",
            "62177842752192623401942399639168044983993173312731",
            "32924185707147349566916674687634660915035914677504",
            "99518671430235219628894890102423325116913619626622",
            "73267460800591547471830798392868535206946944540724",
            "76841822524674417161514036427982273348055556214818",
            "97142617910342598647204516893989422179826088076852",
            "87783646182799346313767754307809363333018982642090",
            "10848802521674670883215120185883543223812876952786",
            "71329612474782464538636993009049310363619763878039",
            "62184073572399794223406235393808339651327408011116",
            "66627891981488087797941876876144230030984490851411",
            "60661826293682836764744779239180335110989069790714",
            "85786944089552990653640447425576083659976645795096",
            "66024396409905389607120198219976047599490197230297",
            "64913982680032973156037120041377903785566085089252",
            "16730939319872750275468906903707539413042652315011",
            "94809377245048795150954100921645863754710598436791",
            "78639167021187492431995700641917969777599028300699",
            "15368713711936614952811305876380278410754449733078",
            "40789923115535562561142322423255033685442488917353",
            "44889911501440648020369068063960672322193204149535",
            "41503128880339536053299340368006977710650566631954",
            "81234880673210146739058568557934581403627822703280",
            "82616570773948327592232845941706525094512325230608",
            "22918802058777319719839450180888072429661980811197",
            "77158542502016545090413245809786882778948721859617",
            "72107838435069186155435662884062257473692284509516",
            "20849603980134001723930671666823555245252804609722",
            "53503534226472524250874054075591789781264330331690"
        };
        Console.WriteLine($"We will be looking for the first ten digits of the sum of the following one-hundred 50-digit numbers:");
        oneHundredNumbers.ToList().ForEach(x => Console.WriteLine(x));

        // We utilize LINQ to convert the one hundred numbers, to a list of double type variables, and then get their sum.
        // Also we utilize fixed-point format specifier for our ToString function, to get the 'full' number, without exponent or decimal values.
        string sumOfNumbers = oneHundredNumbers.ToList().ConvertAll(double.Parse).Sum().ToString("F0");

        // And our solution, the first ten digits, is simply the first ten elements of the sum.
        string firstTenDigits = sumOfNumbers.Substring(0, 10);

        // Display the results to the console window.
        Console.WriteLine($"The first ten digits of the sum of all these numbers is equal to {firstTenDigits}");
        return firstTenDigits;
    }

    /// <summary>
    /// Problem #14
    /// Find which starting number, under one million, produces the longest chain
    /// Read more here: https://projecteuler.net/problem=14
    /// </summary>
    public int LongestCollatzSequence()
    {
        Console.WriteLine($"We will determine which starting number, under one million, produces the longest chain");

        // Initialize a variable that will hold the final value of a number, which will produce the longest Collatz's sequence.
        KeyValuePair<int, int> numberWithLongestSequence = new KeyValuePair<int, int>(1, 1);

        // Loop from one to one million.
        for (int i = 1; i < 1000000; i++)
        {
            // Define placeholder variable for our starting number, and a variable to hold length of its Collatz sequence.
            double startingNumber = i;
            int lengthOfSequence = 1;

            // While the current starting number's value is not equal to one - continue applying Collatz's sequence logic.
            while (startingNumber != 1)
            {
                // Re-calculate the next value for the current number.
                startingNumber = startingNumber % 2 == 0 ?  // Our number's next value will be based on whether its Odd or Even.
                                 (startingNumber / 2) :     // If its even - divide it in half.
                                 (startingNumber * 3) + 1;  // If its odd - multiply by 3 and add one.

                // Increase length of its sequence by one.
                lengthOfSequence++;
                continue;
            }

            // If the length of the current number's sequence is greater than the length of previously saved number's - save it to our KeyValuePair variable, otherwise - it retains its value.
            numberWithLongestSequence = lengthOfSequence > numberWithLongestSequence.Value ?
                                        new KeyValuePair<int, int>(i, lengthOfSequence) :
                                        numberWithLongestSequence;
        }

        // Display the results to the console window
        Console.WriteLine($"Number, under one million, produces the longest chain of Collatz's sequence is equal to {numberWithLongestSequence.Key}, it's Collatz's sequence length is equal to {numberWithLongestSequence.Value}");
        return numberWithLongestSequence.Key;
    }

    /// <summary>
    /// Problem #15
    /// Starting in the top left corner of a 20×20 grid, and only being able to move to the right and down, find how many possible route there are to reach the bottom right corner.
    /// Read more here: https://projecteuler.net/problem=15
    /// </summary>
    public double LatticePaths()
    {
        // Solution for this exercise will be heavily based on math, following few topics - Factorials, combinatorics and Binomial_coefficient.
        // Application of these topics, in basic form will be explained in the solution, but if you wish to read more, by all means - https://en.wikipedia.org/wiki/Factorial, https://en.wikipedia.org/wiki/Combinatorics, https://en.wikipedia.org/wiki/Binomial_coefficient#Factorial_formula
        // We will also be re-using one of solutions from 'Numbers' category, to get factorial value of a given number.
        Console.WriteLine($"Given a 20x20 grid, starting in top left corner, and only being able to move to the right and down, we will find how many possible route there are to reach the bottom right corner");

        // Here's an explanation:
        // First of all, lets establish a few things we know from the problem:
        //      1. We may ONLY go right, or down.
        //      2. Regardless on our path, there are 40 steps that we must make, to reach the bottom right corner.
        //         That means, we must take at some point we must make 20 steps downwards, and 20 steps to the right.
        //         One we step downwards, we automatically lose one possibility to choose from the step to the right, since there are now one less 'row' to step downwards from.
        //      Think of 20 floor building, with an elevator (Us stepping downwards), and flight of stairs on each floor (which equals to us stepping to right).
        //      If we take elevator from 20th to 19th floor, we lose 1 flight of stairs to choose from, since we can't go up (by rules of exercise).

        // Rules and explanations leaves us with the following:
        // How many different ways can you choose 20 elements out of a set of 40 elements. Meaning 20 choices of going down or right, to complete 40 steps to the finish.

        // Here's where we apply Binomial coefficient - factorial formula, where n = 40, k = 20.
        // That equates to 40!/((20!)(40-20)!), which simplifies to 40!/(20!)^2, and after canceling out one 20! with part of 40! leaves us with the following:
        // (40 * 39 * 38 * ..... * 21) / 20!
        // Meaning - 40 steps to take, 20 steps to either right or downwards.

        // Now, we simply define variable to hold the value of calculation
        double numberOfPossibleRoutes = 0;

        // Apply the math defined above, and utilize 'FindFactorialOfAPositiveNumber' solution from 'Numbers' category.
        // We apply the following:
        //      40!/(20!)^2
        numberOfPossibleRoutes =
            Math.Floor          // I've utilized Math Floor to round the number, because doing calculation with big numbers seem to have left small decimal places.
            ((double)_numbersService.FindFactorialOfAPositiveNumber(40, true) /
             Math.Pow((double)_numbersService.FindFactorialOfAPositiveNumber(20, true), 2));

        Console.WriteLine($"Number of possible routes to reach the finish is equal to {numberOfPossibleRoutes}");
        return numberOfPossibleRoutes;
    }

    /// <summary>
    /// Problem #16
    /// Find the sum of the digits of the number 2^1000
    /// Read more here: https://projecteuler.net/problem=16
    /// </summary>
    public int PowerDigitSum()
    {
        Console.WriteLine($"We will be calculating the sum of the digits of the number 2^1000");

        // Calculate the full number of 2 raised to the power of 1000
        double fullNumber = Math.Pow(2, 1000);

        // Convert our number, into an array of individual digits.
        // Also we utilize fixed-point format specifier for our ToString function, to get the 'full' number, without exponent or decimal values.
        int[] arrayOfDigits = fullNumber.ToString("F0").ToCharArray().Select(digit => Convert.ToInt32(Char.GetNumericValue(digit))).ToArray();

        // Calculate the sum of individual digits.
        int sumOfDigits = arrayOfDigits.Aggregate((a, b) => a + b);

        Console.WriteLine($"Sum of digits, of the number 2^1000, is equal to {sumOfDigits}");
        return sumOfDigits;
    }

    /// <summary>
    /// Problem #17
    /// Find how many letters would be used, if all the numbers from 1 to 1000 (one thousand) inclusive were written out in words
    /// Read more here: https://projecteuler.net/problem=17
    /// </summary>
    public int NumberLetterCounts()
    {
        Console.WriteLine($"We will find out how many letters would be used, if all the numbers from 1 to 1000 (one thousand) inclusive were written out in words");

        // Define a few arrays that will hold spelled out value of single digits, values between 10 and 20, since they are spelled out differently, and flat tens (20, 30, .. etc.)
        string[] singleDigit = new string[]
        {
            "",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };

        string[] tenToTwenty = new string[]
        {
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
        };

        string[] tenFlat = new string[]
        {
            "",
            "",
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
        };

        // Initialize a variable to hold the total sum of letters used.
        int lettersUsed = 0;

        // Iterate from 1 to 1000 (inclusive)
        for (int i = 1; i <= 1000; i++)
        {
            // Our 'current number' will be iterator i, converted into a string.
            string currentNumber = i.ToString();

            // Initialize variables to hold spelled out variations of thousands, hundreds, tens and single digits.
            string thousands = string.Empty;
            string hundreds = string.Empty;
            string tens = string.Empty;
            string ones = string.Empty;

            // If a digit has length of 4, that's simply 'One thousand', since that's the extent to which our exercise goes, so we can hard code the value.
            if (currentNumber.Length == 4)
            {
                thousands = "onethousand";
            }
            // If a digit has length of 3, that means its hundreds value.
            // We take its 1'st element (at position 0), take the corresponding index at 'Single digit' array and then cut that element from the string.
            // So for example we have digit '154' we take '1', get its corresponding value in 'Single digit' array, which would be second element (at position 1), which is equal to 'one'
            //      And then we cut it out of the string, we we're continuing with '54' to the next conditional statement.
            if (currentNumber.Length == 3)
            {
                hundreds = $"{singleDigit[Convert.ToInt32(currentNumber.Substring(0, 1))]}hundred";
                currentNumber = currentNumber.Substring(1);
            }
            // If the digit has length of 2, that means we're in the tens.
            // If the number is between 10 and 20, we take its 2nd element, and get its corresponding element at 'ten to twenty' array.
            // For example we have number '18', we take '8' and get element at position 8 from 'ten to twenty' array which is 'eight'
            // If the number is ABOVE 20, then we take its 1st element's value from 'ten flat' array, and its 2nd element's value from 'single digit' array.
            if (currentNumber.Length == 2)
            {
                if (Convert.ToInt32(currentNumber) >= 10 &&
                    Convert.ToInt32(currentNumber) < 20)
                {
                    tens += $"{tenToTwenty[Convert.ToInt32(currentNumber.Substring(1, 1))]}";
                }
                else
                {
                    tens += $"{tenFlat[Convert.ToInt32(currentNumber.Substring(0, 1))]}";
                    ones += $"{singleDigit[Convert.ToInt32(currentNumber.Substring(1))]}";
                }
            }
            // If our digit has length of 1, we simply get its corresponding element at 'single digits' array
            if (currentNumber.Length == 1)
            {
                ones += $"{singleDigit[Convert.ToInt32(currentNumber)]}";
            }

            // Once all variables have been filled out accordingly, we will form the final string of the number.
            // If a number has thousands OR hundreds value, we must add 'and' between them, and tens or ones (The use of "and" when writing out numbers is in compliance with British usage.)
            // Other than that - we simply 'glue' all variables that hold spelled out variations together, into one single string, that has no spaces, hyphens or any other symbols.
            string numberSpelledOut = $"{thousands}{hundreds}" +
                                      $"{((!string.IsNullOrEmpty(thousands) || !string.IsNullOrEmpty(hundreds)) &&
                                          (!string.IsNullOrEmpty(tens) || !string.IsNullOrEmpty(ones)) ? "and" : "")}" +
                                      $"{(!string.IsNullOrEmpty(tens) ? $"{tens}" : "")}" +
                                      $"{(!string.IsNullOrEmpty(ones) ? $"{ones}" : "")}";

            // Add the length of our 'glued' together string, to the total amount of letters used.
            lettersUsed += numberSpelledOut.Length;
        }

        // Display the results to the console window
        Console.WriteLine($"Total of {lettersUsed} letters would be used, to spell out all numbers from 1 to 1000");
        return lettersUsed;
    }

    /// <summary>
    /// Problem #18
    /// By starting at the top of the triangle below and moving to adjacent numbers on the row below, find the maximum total from top to bottom.
    /// Read more here: https://projecteuler.net/problem=18
    /// </summary>
    public int MaximumPathSumI()
    {
        Console.WriteLine($"We will be calculating the maximum total moving from top to bottom, for the following triangle: ");
        // Initialize the triangle that is given by the exercise.
        var triangle =
            "75\n" +
            "95 64\n" +
            "17 47 82\n" +
            "18 35 87 10\n" +
            "20 04 82 47 65\n" +
            "19 01 23 75 03 34\n" +
            "88 02 77 73 07 63 67\n" +
            "99 65 04 28 06 16 70 92\n" +
            "41 41 26 56 83 40 80 70 33\n" +
            "41 48 72 33 47 32 37 16 94 29\n" +
            "53 71 44 65 25 43 91 52 97 51 14\n" +
            "70 11 33 28 77 73 17 78 39 68 17 57\n" +
            "91 71 52 38 17 14 91 43 58 50 27 29 48\n" +
            "63 66 04 68 89 53 67 30 73 16 69 87 40 31\n" +
            "04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";
        Console.WriteLine(triangle);

        // Initialize an array of string type elements, into which we pass the input triangle, by splitting it by new line (\n) symbol.
        string[] rows = triangle.Split('\n').ToArray();

        // We will be implementing 'Bottoms up' algorithm, where we calculate current row, by adding the higher of the two elements from the row BELOW the current on.
        // Iterate over all the rows, starting from second to last, all the way to the top row.
        for (int i = rows.Length - 2; i >= 0; i--)
        {
            // Get integer type arrays from both current, and the row below.
            // We do that by taking each row (which is a string), splitting it by spaces, converting each element to integer type and adding them to an array.
            int[] currentRowDigits = rows[i].Split(' ').Select(c => Convert.ToInt32(c)).ToArray();
            int[] rowBelowDigits = rows[i + 1].Split(' ').Select(c => Convert.ToInt32(c)).ToArray();

            // Iterate over the current row, and ADD the maximum of the two elements from the row BELOW.
            // So for example, our current rows', current element is equal to 63. Two element BELOW it are 4 and 62. That means we'll add 62 to the current element 63, and end up with 125.
            for (int j = 0; j < currentRowDigits.Length; j++)
                currentRowDigits[j] += Math.Max(rowBelowDigits[j], rowBelowDigits[j + 1]);

            // After the current row has been re-calculated, we re-insert it back into same place, inside our array of rows.
            rows[i] = string.Join(" ", currentRowDigits);
        }

        // Our maximum total is the single element, at the very top of the pyramid, which is the sole element in the very first row.
        int maximumTotal = Convert.ToInt32(rows[0]);
        Console.WriteLine($"Maximum total from top to bottom is equal to {maximumTotal}");
        return maximumTotal;
    }

    /// <summary>
    /// Problem #19
    /// Find out how many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000
    /// Read more here: https://projecteuler.net/problem=19
    /// </summary>
    public int CountingSundays()
    {
        Console.WriteLine($"We will count how many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000");

        // Initialize our start and end dates which are provided by the exercise.
        DateTime startDate = new DateTime(1901, 1, 1);
        DateTime endDate = new DateTime(2000, 12, 31);

        // Initialize a variable to hold the total count of sundays that fall on the first day of the month
        int numberOfSundays = 0;

        // Iterate until our start date, reaches our end date.
        while (startDate <= endDate)
        {
            // By the rules of our exercise, our variable 'Number of sundays' increase by one if a given day is a Sunday, and it happens to be the very first day of the month.
            numberOfSundays += startDate.DayOfWeek == DayOfWeek.Sunday && startDate.Day == 1 ? 1 : 0;

            // At the end of each iteration - increase our 'Start' date by one singular day.
            startDate = startDate.AddDays(1);
        }

        // Display the results to the console window.
        Console.WriteLine($"During the twentieth century (1 Jan 1901 to 31 Dec 2000) a total of {numberOfSundays} sundays have fell exactly on the first day of the month!");
        return numberOfSundays;
    }

    /// <summary>
    /// Problem #20
    /// Find the sum of the digits in the number 100!
    /// Read more here: https://projecteuler.net/problem=20
    /// </summary>
    public int FactorialDigitSum()
    {
        // We will be re-utilizing a solution from 'Numbers' category - to calculate a factorial of a given number.
        Console.WriteLine($"We will be calculating the sum of the digits in the number 100!");

        // Get factorial value of number 100
        var factorialValue = _numbersService.FindFactorialOfAPositiveNumber(100, true);

        // Convert our number, into an array of individual digits.
        // Also we utilize fixed-point format specifier for our ToString function, to get the 'full' number, without exponent or decimal values.
        int[] arrayOfDigits = factorialValue.ToString("F0").ToCharArray().Select(digit => Convert.ToInt32(Char.GetNumericValue(digit))).ToArray();

        // Calculate the sum of individual digits.
        int sumOfDigits = arrayOfDigits.Aggregate((a, b) => a + b);

        Console.WriteLine($"Total sum of the digits of the factorial 100! is equal to {sumOfDigits}");
        return sumOfDigits;
    }

    /// <summary>
    /// Problem #21
    /// Evaluate the sum of all the amicable numbers under 10000
    /// Read more here: https://projecteuler.net/problem=21
    /// </summary>
    public int AmicableNumbers()
    {
        Console.WriteLine($"We will calculate the sum of all the amicable numbers under 10000");

        // Initialize a variable to hold the total sum of all amicable numbers.
        int totalSum = 0;

        // Top-most loop starts at 1, iterates up to 10000.
        for (int i = 1; i < 10000; i++)
        {
            // Initialize a variable to hold the sum of divisors of the original number - which is our iterator i
            int sumOfDivisorsOfFirst = 0;

            // Iterate from 1 up to our current (original) number, and if it divides out of j without any remainder - add its value to the sum of divisors.
            for (int j = 1; j < i; j++)
                sumOfDivisorsOfFirst += i % j == 0 ? j : 0;

            // Now, initialize a variable that will hold the sum of divisors of our second element. Since amicable number must form a pair with another number.
            int sumOfDivisorsOfSecond = 0;

            // Iterate from 1 up to the sum of divisors of the original number
            // And if a the sum of the divisors of the original number, divides without remainder out of iterator k - we add its value to the sum of divisors of the second number.
            for (int k = 1; k < sumOfDivisorsOfFirst; k++)
                sumOfDivisorsOfSecond += sumOfDivisorsOfFirst % k == 0 ? k : 0;

            // If the current (original) number is:
            // 1. NOT equal to the sum of its divisors (for example, number 1 would have sum of divisors which is also equal to 1)
            // 2. And its equal to its paired number's sum of divisors
            // We add its value to the total sum. Its paired number (if its higher) will be add at a later time during its own iteration.
            totalSum += i != sumOfDivisorsOfFirst && sumOfDivisorsOfSecond == i ? i : 0;
        }

        // Display results to the console window
        Console.WriteLine($"Total sum of all amicable numbers under 10000 is equal to {totalSum}");
        return totalSum;
    }

    /// <summary>
    /// Problem #22
    /// Calculate total of all the name scores in the file (Based on exercises rules)
    /// Read more here: https://projecteuler.net/problem=22
    /// </summary>
    public int NamesScores()
    {
        Console.WriteLine($"We will be calculating the total of all the name scores in the file (Based on exercises rules)");

        // Initialize a variable as a long string that holds all names (Copied from the text file, given in the exercise)
        string allNamesString = "\"MARY\",\"PATRICIA\",\"LINDA\",\"BARBARA\",\"ELIZABETH\",\"JENNIFER\",\"MARIA\",\"SUSAN\",\"MARGARET\",\"DOROTHY\",\"LISA\",\"NANCY\",\"KAREN\",\"BETTY\",\"HELEN\",\"SANDRA\",\"DONNA\",\"CAROL\",\"RUTH\",\"SHARON\",\"MICHELLE\",\"LAURA\",\"SARAH\",\"KIMBERLY\",\"DEBORAH\",\"JESSICA\",\"SHIRLEY\",\"CYNTHIA\",\"ANGELA\",\"MELISSA\",\"BRENDA\",\"AMY\",\"ANNA\",\"REBECCA\",\"VIRGINIA\",\"KATHLEEN\",\"PAMELA\",\"MARTHA\",\"DEBRA\",\"AMANDA\",\"STEPHANIE\",\"CAROLYN\",\"CHRISTINE\",\"MARIE\",\"JANET\",\"CATHERINE\",\"FRANCES\",\"ANN\",\"JOYCE\",\"DIANE\",\"ALICE\",\"JULIE\",\"HEATHER\",\"TERESA\",\"DORIS\",\"GLORIA\",\"EVELYN\",\"JEAN\",\"CHERYL\",\"MILDRED\",\"KATHERINE\",\"JOAN\",\"ASHLEY\",\"JUDITH\",\"ROSE\",\"JANICE\",\"KELLY\",\"NICOLE\",\"JUDY\",\"CHRISTINA\",\"KATHY\",\"THERESA\",\"BEVERLY\",\"DENISE\",\"TAMMY\",\"IRENE\",\"JANE\",\"LORI\",\"RACHEL\",\"MARILYN\",\"ANDREA\",\"KATHRYN\",\"LOUISE\",\"SARA\",\"ANNE\",\"JACQUELINE\",\"WANDA\",\"BONNIE\",\"JULIA\",\"RUBY\",\"LOIS\",\"TINA\",\"PHYLLIS\",\"NORMA\",\"PAULA\",\"DIANA\",\"ANNIE\",\"LILLIAN\",\"EMILY\",\"ROBIN\",\"PEGGY\",\"CRYSTAL\",\"GLADYS\",\"RITA\",\"DAWN\",\"CONNIE\",\"FLORENCE\",\"TRACY\",\"EDNA\",\"TIFFANY\",\"CARMEN\",\"ROSA\",\"CINDY\",\"GRACE\",\"WENDY\",\"VICTORIA\",\"EDITH\",\"KIM\",\"SHERRY\",\"SYLVIA\",\"JOSEPHINE\",\"THELMA\",\"SHANNON\",\"SHEILA\",\"ETHEL\",\"ELLEN\",\"ELAINE\",\"MARJORIE\",\"CARRIE\",\"CHARLOTTE\",\"MONICA\",\"ESTHER\",\"PAULINE\",\"EMMA\",\"JUANITA\",\"ANITA\",\"RHONDA\",\"HAZEL\",\"AMBER\",\"EVA\",\"DEBBIE\",\"APRIL\",\"LESLIE\",\"CLARA\",\"LUCILLE\",\"JAMIE\",\"JOANNE\",\"ELEANOR\",\"VALERIE\",\"DANIELLE\",\"MEGAN\",\"ALICIA\",\"SUZANNE\",\"MICHELE\",\"GAIL\",\"BERTHA\",\"DARLENE\",\"VERONICA\",\"JILL\",\"ERIN\",\"GERALDINE\",\"LAUREN\",\"CATHY\",\"JOANN\",\"LORRAINE\",\"LYNN\",\"SALLY\",\"REGINA\",\"ERICA\",\"BEATRICE\",\"DOLORES\",\"BERNICE\",\"AUDREY\",\"YVONNE\",\"ANNETTE\",\"JUNE\",\"SAMANTHA\",\"MARION\",\"DANA\",\"STACY\",\"ANA\",\"RENEE\",\"IDA\",\"VIVIAN\",\"ROBERTA\",\"HOLLY\",\"BRITTANY\",\"MELANIE\",\"LORETTA\",\"YOLANDA\",\"JEANETTE\",\"LAURIE\",\"KATIE\",\"KRISTEN\",\"VANESSA\",\"ALMA\",\"SUE\",\"ELSIE\",\"BETH\",\"JEANNE\",\"VICKI\",\"CARLA\",\"TARA\",\"ROSEMARY\",\"EILEEN\",\"TERRI\",\"GERTRUDE\",\"LUCY\",\"TONYA\",\"ELLA\",\"STACEY\",\"WILMA\",\"GINA\",\"KRISTIN\",\"JESSIE\",\"NATALIE\",\"AGNES\",\"VERA\",\"WILLIE\",\"CHARLENE\",\"BESSIE\",\"DELORES\",\"MELINDA\",\"PEARL\",\"ARLENE\",\"MAUREEN\",\"COLLEEN\",\"ALLISON\",\"TAMARA\",\"JOY\",\"GEORGIA\",\"CONSTANCE\",\"LILLIE\",\"CLAUDIA\",\"JACKIE\",\"MARCIA\",\"TANYA\",\"NELLIE\",\"MINNIE\",\"MARLENE\",\"HEIDI\",\"GLENDA\",\"LYDIA\",\"VIOLA\",\"COURTNEY\",\"MARIAN\",\"STELLA\",\"CAROLINE\",\"DORA\",\"JO\",\"VICKIE\",\"MATTIE\",\"TERRY\",\"MAXINE\",\"IRMA\",\"MABEL\",\"MARSHA\",\"MYRTLE\",\"LENA\",\"CHRISTY\",\"DEANNA\",\"PATSY\",\"HILDA\",\"GWENDOLYN\",\"JENNIE\",\"NORA\",\"MARGIE\",\"NINA\",\"CASSANDRA\",\"LEAH\",\"PENNY\",\"KAY\",\"PRISCILLA\",\"NAOMI\",\"CAROLE\",\"BRANDY\",\"OLGA\",\"BILLIE\",\"DIANNE\",\"TRACEY\",\"LEONA\",\"JENNY\",\"FELICIA\",\"SONIA\",\"MIRIAM\",\"VELMA\",\"BECKY\",\"BOBBIE\",\"VIOLET\",\"KRISTINA\",\"TONI\",\"MISTY\",\"MAE\",\"SHELLY\",\"DAISY\",\"RAMONA\",\"SHERRI\",\"ERIKA\",\"KATRINA\",\"CLAIRE\",\"LINDSEY\",\"LINDSAY\",\"GENEVA\",\"GUADALUPE\",\"BELINDA\",\"MARGARITA\",\"SHERYL\",\"CORA\",\"FAYE\",\"ADA\",\"NATASHA\",\"SABRINA\",\"ISABEL\",\"MARGUERITE\",\"HATTIE\",\"HARRIET\",\"MOLLY\",\"CECILIA\",\"KRISTI\",\"BRANDI\",\"BLANCHE\",\"SANDY\",\"ROSIE\",\"JOANNA\",\"IRIS\",\"EUNICE\",\"ANGIE\",\"INEZ\",\"LYNDA\",\"MADELINE\",\"AMELIA\",\"ALBERTA\",\"GENEVIEVE\",\"MONIQUE\",\"JODI\",\"JANIE\",\"MAGGIE\",\"KAYLA\",\"SONYA\",\"JAN\",\"LEE\",\"KRISTINE\",\"CANDACE\",\"FANNIE\",\"MARYANN\",\"OPAL\",\"ALISON\",\"YVETTE\",\"MELODY\",\"LUZ\",\"SUSIE\",\"OLIVIA\",\"FLORA\",\"SHELLEY\",\"KRISTY\",\"MAMIE\",\"LULA\",\"LOLA\",\"VERNA\",\"BEULAH\",\"ANTOINETTE\",\"CANDICE\",\"JUANA\",\"JEANNETTE\",\"PAM\",\"KELLI\",\"HANNAH\",\"WHITNEY\",\"BRIDGET\",\"KARLA\",\"CELIA\",\"LATOYA\",\"PATTY\",\"SHELIA\",\"GAYLE\",\"DELLA\",\"VICKY\",\"LYNNE\",\"SHERI\",\"MARIANNE\",\"KARA\",\"JACQUELYN\",\"ERMA\",\"BLANCA\",\"MYRA\",\"LETICIA\",\"PAT\",\"KRISTA\",\"ROXANNE\",\"ANGELICA\",\"JOHNNIE\",\"ROBYN\",\"FRANCIS\",\"ADRIENNE\",\"ROSALIE\",\"ALEXANDRA\",\"BROOKE\",\"BETHANY\",\"SADIE\",\"BERNADETTE\",\"TRACI\",\"JODY\",\"KENDRA\",\"JASMINE\",\"NICHOLE\",\"RACHAEL\",\"CHELSEA\",\"MABLE\",\"ERNESTINE\",\"MURIEL\",\"MARCELLA\",\"ELENA\",\"KRYSTAL\",\"ANGELINA\",\"NADINE\",\"KARI\",\"ESTELLE\",\"DIANNA\",\"PAULETTE\",\"LORA\",\"MONA\",\"DOREEN\",\"ROSEMARIE\",\"ANGEL\",\"DESIREE\",\"ANTONIA\",\"HOPE\",\"GINGER\",\"JANIS\",\"BETSY\",\"CHRISTIE\",\"FREDA\",\"MERCEDES\",\"MEREDITH\",\"LYNETTE\",\"TERI\",\"CRISTINA\",\"EULA\",\"LEIGH\",\"MEGHAN\",\"SOPHIA\",\"ELOISE\",\"ROCHELLE\",\"GRETCHEN\",\"CECELIA\",\"RAQUEL\",\"HENRIETTA\",\"ALYSSA\",\"JANA\",\"KELLEY\",\"GWEN\",\"KERRY\",\"JENNA\",\"TRICIA\",\"LAVERNE\",\"OLIVE\",\"ALEXIS\",\"TASHA\",\"SILVIA\",\"ELVIRA\",\"CASEY\",\"DELIA\",\"SOPHIE\",\"KATE\",\"PATTI\",\"LORENA\",\"KELLIE\",\"SONJA\",\"LILA\",\"LANA\",\"DARLA\",\"MAY\",\"MINDY\",\"ESSIE\",\"MANDY\",\"LORENE\",\"ELSA\",\"JOSEFINA\",\"JEANNIE\",\"MIRANDA\",\"DIXIE\",\"LUCIA\",\"MARTA\",\"FAITH\",\"LELA\",\"JOHANNA\",\"SHARI\",\"CAMILLE\",\"TAMI\",\"SHAWNA\",\"ELISA\",\"EBONY\",\"MELBA\",\"ORA\",\"NETTIE\",\"TABITHA\",\"OLLIE\",\"JAIME\",\"WINIFRED\",\"KRISTIE\",\"MARINA\",\"ALISHA\",\"AIMEE\",\"RENA\",\"MYRNA\",\"MARLA\",\"TAMMIE\",\"LATASHA\",\"BONITA\",\"PATRICE\",\"RONDA\",\"SHERRIE\",\"ADDIE\",\"FRANCINE\",\"DELORIS\",\"STACIE\",\"ADRIANA\",\"CHERI\",\"SHELBY\",\"ABIGAIL\",\"CELESTE\",\"JEWEL\",\"CARA\",\"ADELE\",\"REBEKAH\",\"LUCINDA\",\"DORTHY\",\"CHRIS\",\"EFFIE\",\"TRINA\",\"REBA\",\"SHAWN\",\"SALLIE\",\"AURORA\",\"LENORA\",\"ETTA\",\"LOTTIE\",\"KERRI\",\"TRISHA\",\"NIKKI\",\"ESTELLA\",\"FRANCISCA\",\"JOSIE\",\"TRACIE\",\"MARISSA\",\"KARIN\",\"BRITTNEY\",\"JANELLE\",\"LOURDES\",\"LAUREL\",\"HELENE\",\"FERN\",\"ELVA\",\"CORINNE\",\"KELSEY\",\"INA\",\"BETTIE\",\"ELISABETH\",\"AIDA\",\"CAITLIN\",\"INGRID\",\"IVA\",\"EUGENIA\",\"CHRISTA\",\"GOLDIE\",\"CASSIE\",\"MAUDE\",\"JENIFER\",\"THERESE\",\"FRANKIE\",\"DENA\",\"LORNA\",\"JANETTE\",\"LATONYA\",\"CANDY\",\"MORGAN\",\"CONSUELO\",\"TAMIKA\",\"ROSETTA\",\"DEBORA\",\"CHERIE\",\"POLLY\",\"DINA\",\"JEWELL\",\"FAY\",\"JILLIAN\",\"DOROTHEA\",\"NELL\",\"TRUDY\",\"ESPERANZA\",\"PATRICA\",\"KIMBERLEY\",\"SHANNA\",\"HELENA\",\"CAROLINA\",\"CLEO\",\"STEFANIE\",\"ROSARIO\",\"OLA\",\"JANINE\",\"MOLLIE\",\"LUPE\",\"ALISA\",\"LOU\",\"MARIBEL\",\"SUSANNE\",\"BETTE\",\"SUSANA\",\"ELISE\",\"CECILE\",\"ISABELLE\",\"LESLEY\",\"JOCELYN\",\"PAIGE\",\"JONI\",\"RACHELLE\",\"LEOLA\",\"DAPHNE\",\"ALTA\",\"ESTER\",\"PETRA\",\"GRACIELA\",\"IMOGENE\",\"JOLENE\",\"KEISHA\",\"LACEY\",\"GLENNA\",\"GABRIELA\",\"KERI\",\"URSULA\",\"LIZZIE\",\"KIRSTEN\",\"SHANA\",\"ADELINE\",\"MAYRA\",\"JAYNE\",\"JACLYN\",\"GRACIE\",\"SONDRA\",\"CARMELA\",\"MARISA\",\"ROSALIND\",\"CHARITY\",\"TONIA\",\"BEATRIZ\",\"MARISOL\",\"CLARICE\",\"JEANINE\",\"SHEENA\",\"ANGELINE\",\"FRIEDA\",\"LILY\",\"ROBBIE\",\"SHAUNA\",\"MILLIE\",\"CLAUDETTE\",\"CATHLEEN\",\"ANGELIA\",\"GABRIELLE\",\"AUTUMN\",\"KATHARINE\",\"SUMMER\",\"JODIE\",\"STACI\",\"LEA\",\"CHRISTI\",\"JIMMIE\",\"JUSTINE\",\"ELMA\",\"LUELLA\",\"MARGRET\",\"DOMINIQUE\",\"SOCORRO\",\"RENE\",\"MARTINA\",\"MARGO\",\"MAVIS\",\"CALLIE\",\"BOBBI\",\"MARITZA\",\"LUCILE\",\"LEANNE\",\"JEANNINE\",\"DEANA\",\"AILEEN\",\"LORIE\",\"LADONNA\",\"WILLA\",\"MANUELA\",\"GALE\",\"SELMA\",\"DOLLY\",\"SYBIL\",\"ABBY\",\"LARA\",\"DALE\",\"IVY\",\"DEE\",\"WINNIE\",\"MARCY\",\"LUISA\",\"JERI\",\"MAGDALENA\",\"OFELIA\",\"MEAGAN\",\"AUDRA\",\"MATILDA\",\"LEILA\",\"CORNELIA\",\"BIANCA\",\"SIMONE\",\"BETTYE\",\"RANDI\",\"VIRGIE\",\"LATISHA\",\"BARBRA\",\"GEORGINA\",\"ELIZA\",\"LEANN\",\"BRIDGETTE\",\"RHODA\",\"HALEY\",\"ADELA\",\"NOLA\",\"BERNADINE\",\"FLOSSIE\",\"ILA\",\"GRETA\",\"RUTHIE\",\"NELDA\",\"MINERVA\",\"LILLY\",\"TERRIE\",\"LETHA\",\"HILARY\",\"ESTELA\",\"VALARIE\",\"BRIANNA\",\"ROSALYN\",\"EARLINE\",\"CATALINA\",\"AVA\",\"MIA\",\"CLARISSA\",\"LIDIA\",\"CORRINE\",\"ALEXANDRIA\",\"CONCEPCION\",\"TIA\",\"SHARRON\",\"RAE\",\"DONA\",\"ERICKA\",\"JAMI\",\"ELNORA\",\"CHANDRA\",\"LENORE\",\"NEVA\",\"MARYLOU\",\"MELISA\",\"TABATHA\",\"SERENA\",\"AVIS\",\"ALLIE\",\"SOFIA\",\"JEANIE\",\"ODESSA\",\"NANNIE\",\"HARRIETT\",\"LORAINE\",\"PENELOPE\",\"MILAGROS\",\"EMILIA\",\"BENITA\",\"ALLYSON\",\"ASHLEE\",\"TANIA\",\"TOMMIE\",\"ESMERALDA\",\"KARINA\",\"EVE\",\"PEARLIE\",\"ZELMA\",\"MALINDA\",\"NOREEN\",\"TAMEKA\",\"SAUNDRA\",\"HILLARY\",\"AMIE\",\"ALTHEA\",\"ROSALINDA\",\"JORDAN\",\"LILIA\",\"ALANA\",\"GAY\",\"CLARE\",\"ALEJANDRA\",\"ELINOR\",\"MICHAEL\",\"LORRIE\",\"JERRI\",\"DARCY\",\"EARNESTINE\",\"CARMELLA\",\"TAYLOR\",\"NOEMI\",\"MARCIE\",\"LIZA\",\"ANNABELLE\",\"LOUISA\",\"EARLENE\",\"MALLORY\",\"CARLENE\",\"NITA\",\"SELENA\",\"TANISHA\",\"KATY\",\"JULIANNE\",\"JOHN\",\"LAKISHA\",\"EDWINA\",\"MARICELA\",\"MARGERY\",\"KENYA\",\"DOLLIE\",\"ROXIE\",\"ROSLYN\",\"KATHRINE\",\"NANETTE\",\"CHARMAINE\",\"LAVONNE\",\"ILENE\",\"KRIS\",\"TAMMI\",\"SUZETTE\",\"CORINE\",\"KAYE\",\"JERRY\",\"MERLE\",\"CHRYSTAL\",\"LINA\",\"DEANNE\",\"LILIAN\",\"JULIANA\",\"ALINE\",\"LUANN\",\"KASEY\",\"MARYANNE\",\"EVANGELINE\",\"COLETTE\",\"MELVA\",\"LAWANDA\",\"YESENIA\",\"NADIA\",\"MADGE\",\"KATHIE\",\"EDDIE\",\"OPHELIA\",\"VALERIA\",\"NONA\",\"MITZI\",\"MARI\",\"GEORGETTE\",\"CLAUDINE\",\"FRAN\",\"ALISSA\",\"ROSEANN\",\"LAKEISHA\",\"SUSANNA\",\"REVA\",\"DEIDRE\",\"CHASITY\",\"SHEREE\",\"CARLY\",\"JAMES\",\"ELVIA\",\"ALYCE\",\"DEIRDRE\",\"GENA\",\"BRIANA\",\"ARACELI\",\"KATELYN\",\"ROSANNE\",\"WENDI\",\"TESSA\",\"BERTA\",\"MARVA\",\"IMELDA\",\"MARIETTA\",\"MARCI\",\"LEONOR\",\"ARLINE\",\"SASHA\",\"MADELYN\",\"JANNA\",\"JULIETTE\",\"DEENA\",\"AURELIA\",\"JOSEFA\",\"AUGUSTA\",\"LILIANA\",\"YOUNG\",\"CHRISTIAN\",\"LESSIE\",\"AMALIA\",\"SAVANNAH\",\"ANASTASIA\",\"VILMA\",\"NATALIA\",\"ROSELLA\",\"LYNNETTE\",\"CORINA\",\"ALFREDA\",\"LEANNA\",\"CAREY\",\"AMPARO\",\"COLEEN\",\"TAMRA\",\"AISHA\",\"WILDA\",\"KARYN\",\"CHERRY\",\"QUEEN\",\"MAURA\",\"MAI\",\"EVANGELINA\",\"ROSANNA\",\"HALLIE\",\"ERNA\",\"ENID\",\"MARIANA\",\"LACY\",\"JULIET\",\"JACKLYN\",\"FREIDA\",\"MADELEINE\",\"MARA\",\"HESTER\",\"CATHRYN\",\"LELIA\",\"CASANDRA\",\"BRIDGETT\",\"ANGELITA\",\"JANNIE\",\"DIONNE\",\"ANNMARIE\",\"KATINA\",\"BERYL\",\"PHOEBE\",\"MILLICENT\",\"KATHERYN\",\"DIANN\",\"CARISSA\",\"MARYELLEN\",\"LIZ\",\"LAURI\",\"HELGA\",\"GILDA\",\"ADRIAN\",\"RHEA\",\"MARQUITA\",\"HOLLIE\",\"TISHA\",\"TAMERA\",\"ANGELIQUE\",\"FRANCESCA\",\"BRITNEY\",\"KAITLIN\",\"LOLITA\",\"FLORINE\",\"ROWENA\",\"REYNA\",\"TWILA\",\"FANNY\",\"JANELL\",\"INES\",\"CONCETTA\",\"BERTIE\",\"ALBA\",\"BRIGITTE\",\"ALYSON\",\"VONDA\",\"PANSY\",\"ELBA\",\"NOELLE\",\"LETITIA\",\"KITTY\",\"DEANN\",\"BRANDIE\",\"LOUELLA\",\"LETA\",\"FELECIA\",\"SHARLENE\",\"LESA\",\"BEVERLEY\",\"ROBERT\",\"ISABELLA\",\"HERMINIA\",\"TERRA\",\"CELINA\",\"TORI\",\"OCTAVIA\",\"JADE\",\"DENICE\",\"GERMAINE\",\"SIERRA\",\"MICHELL\",\"CORTNEY\",\"NELLY\",\"DORETHA\",\"SYDNEY\",\"DEIDRA\",\"MONIKA\",\"LASHONDA\",\"JUDI\",\"CHELSEY\",\"ANTIONETTE\",\"MARGOT\",\"BOBBY\",\"ADELAIDE\",\"NAN\",\"LEEANN\",\"ELISHA\",\"DESSIE\",\"LIBBY\",\"KATHI\",\"GAYLA\",\"LATANYA\",\"MINA\",\"MELLISA\",\"KIMBERLEE\",\"JASMIN\",\"RENAE\",\"ZELDA\",\"ELDA\",\"MA\",\"JUSTINA\",\"GUSSIE\",\"EMILIE\",\"CAMILLA\",\"ABBIE\",\"ROCIO\",\"KAITLYN\",\"JESSE\",\"EDYTHE\",\"ASHLEIGH\",\"SELINA\",\"LAKESHA\",\"GERI\",\"ALLENE\",\"PAMALA\",\"MICHAELA\",\"DAYNA\",\"CARYN\",\"ROSALIA\",\"SUN\",\"JACQULINE\",\"REBECA\",\"MARYBETH\",\"KRYSTLE\",\"IOLA\",\"DOTTIE\",\"BENNIE\",\"BELLE\",\"AUBREY\",\"GRISELDA\",\"ERNESTINA\",\"ELIDA\",\"ADRIANNE\",\"DEMETRIA\",\"DELMA\",\"CHONG\",\"JAQUELINE\",\"DESTINY\",\"ARLEEN\",\"VIRGINA\",\"RETHA\",\"FATIMA\",\"TILLIE\",\"ELEANORE\",\"CARI\",\"TREVA\",\"BIRDIE\",\"WILHELMINA\",\"ROSALEE\",\"MAURINE\",\"LATRICE\",\"YONG\",\"JENA\",\"TARYN\",\"ELIA\",\"DEBBY\",\"MAUDIE\",\"JEANNA\",\"DELILAH\",\"CATRINA\",\"SHONDA\",\"HORTENCIA\",\"THEODORA\",\"TERESITA\",\"ROBBIN\",\"DANETTE\",\"MARYJANE\",\"FREDDIE\",\"DELPHINE\",\"BRIANNE\",\"NILDA\",\"DANNA\",\"CINDI\",\"BESS\",\"IONA\",\"HANNA\",\"ARIEL\",\"WINONA\",\"VIDA\",\"ROSITA\",\"MARIANNA\",\"WILLIAM\",\"RACHEAL\",\"GUILLERMINA\",\"ELOISA\",\"CELESTINE\",\"CAREN\",\"MALISSA\",\"LONA\",\"CHANTEL\",\"SHELLIE\",\"MARISELA\",\"LEORA\",\"AGATHA\",\"SOLEDAD\",\"MIGDALIA\",\"IVETTE\",\"CHRISTEN\",\"ATHENA\",\"JANEL\",\"CHLOE\",\"VEDA\",\"PATTIE\",\"TESSIE\",\"TERA\",\"MARILYNN\",\"LUCRETIA\",\"KARRIE\",\"DINAH\",\"DANIELA\",\"ALECIA\",\"ADELINA\",\"VERNICE\",\"SHIELA\",\"PORTIA\",\"MERRY\",\"LASHAWN\",\"DEVON\",\"DARA\",\"TAWANA\",\"OMA\",\"VERDA\",\"CHRISTIN\",\"ALENE\",\"ZELLA\",\"SANDI\",\"RAFAELA\",\"MAYA\",\"KIRA\",\"CANDIDA\",\"ALVINA\",\"SUZAN\",\"SHAYLA\",\"LYN\",\"LETTIE\",\"ALVA\",\"SAMATHA\",\"ORALIA\",\"MATILDE\",\"MADONNA\",\"LARISSA\",\"VESTA\",\"RENITA\",\"INDIA\",\"DELOIS\",\"SHANDA\",\"PHILLIS\",\"LORRI\",\"ERLINDA\",\"CRUZ\",\"CATHRINE\",\"BARB\",\"ZOE\",\"ISABELL\",\"IONE\",\"GISELA\",\"CHARLIE\",\"VALENCIA\",\"ROXANNA\",\"MAYME\",\"KISHA\",\"ELLIE\",\"MELLISSA\",\"DORRIS\",\"DALIA\",\"BELLA\",\"ANNETTA\",\"ZOILA\",\"RETA\",\"REINA\",\"LAURETTA\",\"KYLIE\",\"CHRISTAL\",\"PILAR\",\"CHARLA\",\"ELISSA\",\"TIFFANI\",\"TANA\",\"PAULINA\",\"LEOTA\",\"BREANNA\",\"JAYME\",\"CARMEL\",\"VERNELL\",\"TOMASA\",\"MANDI\",\"DOMINGA\",\"SANTA\",\"MELODIE\",\"LURA\",\"ALEXA\",\"TAMELA\",\"RYAN\",\"MIRNA\",\"KERRIE\",\"VENUS\",\"NOEL\",\"FELICITA\",\"CRISTY\",\"CARMELITA\",\"BERNIECE\",\"ANNEMARIE\",\"TIARA\",\"ROSEANNE\",\"MISSY\",\"CORI\",\"ROXANA\",\"PRICILLA\",\"KRISTAL\",\"JUNG\",\"ELYSE\",\"HAYDEE\",\"ALETHA\",\"BETTINA\",\"MARGE\",\"GILLIAN\",\"FILOMENA\",\"CHARLES\",\"ZENAIDA\",\"HARRIETTE\",\"CARIDAD\",\"VADA\",\"UNA\",\"ARETHA\",\"PEARLINE\",\"MARJORY\",\"MARCELA\",\"FLOR\",\"EVETTE\",\"ELOUISE\",\"ALINA\",\"TRINIDAD\",\"DAVID\",\"DAMARIS\",\"CATHARINE\",\"CARROLL\",\"BELVA\",\"NAKIA\",\"MARLENA\",\"LUANNE\",\"LORINE\",\"KARON\",\"DORENE\",\"DANITA\",\"BRENNA\",\"TATIANA\",\"SAMMIE\",\"LOUANN\",\"LOREN\",\"JULIANNA\",\"ANDRIA\",\"PHILOMENA\",\"LUCILA\",\"LEONORA\",\"DOVIE\",\"ROMONA\",\"MIMI\",\"JACQUELIN\",\"GAYE\",\"TONJA\",\"MISTI\",\"JOE\",\"GENE\",\"CHASTITY\",\"STACIA\",\"ROXANN\",\"MICAELA\",\"NIKITA\",\"MEI\",\"VELDA\",\"MARLYS\",\"JOHNNA\",\"AURA\",\"LAVERN\",\"IVONNE\",\"HAYLEY\",\"NICKI\",\"MAJORIE\",\"HERLINDA\",\"GEORGE\",\"ALPHA\",\"YADIRA\",\"PERLA\",\"GREGORIA\",\"DANIEL\",\"ANTONETTE\",\"SHELLI\",\"MOZELLE\",\"MARIAH\",\"JOELLE\",\"CORDELIA\",\"JOSETTE\",\"CHIQUITA\",\"TRISTA\",\"LOUIS\",\"LAQUITA\",\"GEORGIANA\",\"CANDI\",\"SHANON\",\"LONNIE\",\"HILDEGARD\",\"CECIL\",\"VALENTINA\",\"STEPHANY\",\"MAGDA\",\"KAROL\",\"GERRY\",\"GABRIELLA\",\"TIANA\",\"ROMA\",\"RICHELLE\",\"RAY\",\"PRINCESS\",\"OLETA\",\"JACQUE\",\"IDELLA\",\"ALAINA\",\"SUZANNA\",\"JOVITA\",\"BLAIR\",\"TOSHA\",\"RAVEN\",\"NEREIDA\",\"MARLYN\",\"KYLA\",\"JOSEPH\",\"DELFINA\",\"TENA\",\"STEPHENIE\",\"SABINA\",\"NATHALIE\",\"MARCELLE\",\"GERTIE\",\"DARLEEN\",\"THEA\",\"SHARONDA\",\"SHANTEL\",\"BELEN\",\"VENESSA\",\"ROSALINA\",\"ONA\",\"GENOVEVA\",\"COREY\",\"CLEMENTINE\",\"ROSALBA\",\"RENATE\",\"RENATA\",\"MI\",\"IVORY\",\"GEORGIANNA\",\"FLOY\",\"DORCAS\",\"ARIANA\",\"TYRA\",\"THEDA\",\"MARIAM\",\"JULI\",\"JESICA\",\"DONNIE\",\"VIKKI\",\"VERLA\",\"ROSELYN\",\"MELVINA\",\"JANNETTE\",\"GINNY\",\"DEBRAH\",\"CORRIE\",\"ASIA\",\"VIOLETA\",\"MYRTIS\",\"LATRICIA\",\"COLLETTE\",\"CHARLEEN\",\"ANISSA\",\"VIVIANA\",\"TWYLA\",\"PRECIOUS\",\"NEDRA\",\"LATONIA\",\"LAN\",\"HELLEN\",\"FABIOLA\",\"ANNAMARIE\",\"ADELL\",\"SHARYN\",\"CHANTAL\",\"NIKI\",\"MAUD\",\"LIZETTE\",\"LINDY\",\"KIA\",\"KESHA\",\"JEANA\",\"DANELLE\",\"CHARLINE\",\"CHANEL\",\"CARROL\",\"VALORIE\",\"LIA\",\"DORTHA\",\"CRISTAL\",\"SUNNY\",\"LEONE\",\"LEILANI\",\"GERRI\",\"DEBI\",\"ANDRA\",\"KESHIA\",\"IMA\",\"EULALIA\",\"EASTER\",\"DULCE\",\"NATIVIDAD\",\"LINNIE\",\"KAMI\",\"GEORGIE\",\"CATINA\",\"BROOK\",\"ALDA\",\"WINNIFRED\",\"SHARLA\",\"RUTHANN\",\"MEAGHAN\",\"MAGDALENE\",\"LISSETTE\",\"ADELAIDA\",\"VENITA\",\"TRENA\",\"SHIRLENE\",\"SHAMEKA\",\"ELIZEBETH\",\"DIAN\",\"SHANTA\",\"MICKEY\",\"LATOSHA\",\"CARLOTTA\",\"WINDY\",\"SOON\",\"ROSINA\",\"MARIANN\",\"LEISA\",\"JONNIE\",\"DAWNA\",\"CATHIE\",\"BILLY\",\"ASTRID\",\"SIDNEY\",\"LAUREEN\",\"JANEEN\",\"HOLLI\",\"FAWN\",\"VICKEY\",\"TERESSA\",\"SHANTE\",\"RUBYE\",\"MARCELINA\",\"CHANDA\",\"CARY\",\"TERESE\",\"SCARLETT\",\"MARTY\",\"MARNIE\",\"LULU\",\"LISETTE\",\"JENIFFER\",\"ELENOR\",\"DORINDA\",\"DONITA\",\"CARMAN\",\"BERNITA\",\"ALTAGRACIA\",\"ALETA\",\"ADRIANNA\",\"ZORAIDA\",\"RONNIE\",\"NICOLA\",\"LYNDSEY\",\"KENDALL\",\"JANINA\",\"CHRISSY\",\"AMI\",\"STARLA\",\"PHYLIS\",\"PHUONG\",\"KYRA\",\"CHARISSE\",\"BLANCH\",\"SANJUANITA\",\"RONA\",\"NANCI\",\"MARILEE\",\"MARANDA\",\"CORY\",\"BRIGETTE\",\"SANJUANA\",\"MARITA\",\"KASSANDRA\",\"JOYCELYN\",\"IRA\",\"FELIPA\",\"CHELSIE\",\"BONNY\",\"MIREYA\",\"LORENZA\",\"KYONG\",\"ILEANA\",\"CANDELARIA\",\"TONY\",\"TOBY\",\"SHERIE\",\"OK\",\"MARK\",\"LUCIE\",\"LEATRICE\",\"LAKESHIA\",\"GERDA\",\"EDIE\",\"BAMBI\",\"MARYLIN\",\"LAVON\",\"HORTENSE\",\"GARNET\",\"EVIE\",\"TRESSA\",\"SHAYNA\",\"LAVINA\",\"KYUNG\",\"JEANETTA\",\"SHERRILL\",\"SHARA\",\"PHYLISS\",\"MITTIE\",\"ANABEL\",\"ALESIA\",\"THUY\",\"TAWANDA\",\"RICHARD\",\"JOANIE\",\"TIFFANIE\",\"LASHANDA\",\"KARISSA\",\"ENRIQUETA\",\"DARIA\",\"DANIELLA\",\"CORINNA\",\"ALANNA\",\"ABBEY\",\"ROXANE\",\"ROSEANNA\",\"MAGNOLIA\",\"LIDA\",\"KYLE\",\"JOELLEN\",\"ERA\",\"CORAL\",\"CARLEEN\",\"TRESA\",\"PEGGIE\",\"NOVELLA\",\"NILA\",\"MAYBELLE\",\"JENELLE\",\"CARINA\",\"NOVA\",\"MELINA\",\"MARQUERITE\",\"MARGARETTE\",\"JOSEPHINA\",\"EVONNE\",\"DEVIN\",\"CINTHIA\",\"ALBINA\",\"TOYA\",\"TAWNYA\",\"SHERITA\",\"SANTOS\",\"MYRIAM\",\"LIZABETH\",\"LISE\",\"KEELY\",\"JENNI\",\"GISELLE\",\"CHERYLE\",\"ARDITH\",\"ARDIS\",\"ALESHA\",\"ADRIANE\",\"SHAINA\",\"LINNEA\",\"KAROLYN\",\"HONG\",\"FLORIDA\",\"FELISHA\",\"DORI\",\"DARCI\",\"ARTIE\",\"ARMIDA\",\"ZOLA\",\"XIOMARA\",\"VERGIE\",\"SHAMIKA\",\"NENA\",\"NANNETTE\",\"MAXIE\",\"LOVIE\",\"JEANE\",\"JAIMIE\",\"INGE\",\"FARRAH\",\"ELAINA\",\"CAITLYN\",\"STARR\",\"FELICITAS\",\"CHERLY\",\"CARYL\",\"YOLONDA\",\"YASMIN\",\"TEENA\",\"PRUDENCE\",\"PENNIE\",\"NYDIA\",\"MACKENZIE\",\"ORPHA\",\"MARVEL\",\"LIZBETH\",\"LAURETTE\",\"JERRIE\",\"HERMELINDA\",\"CAROLEE\",\"TIERRA\",\"MIRIAN\",\"META\",\"MELONY\",\"KORI\",\"JENNETTE\",\"JAMILA\",\"ENA\",\"ANH\",\"YOSHIKO\",\"SUSANNAH\",\"SALINA\",\"RHIANNON\",\"JOLEEN\",\"CRISTINE\",\"ASHTON\",\"ARACELY\",\"TOMEKA\",\"SHALONDA\",\"MARTI\",\"LACIE\",\"KALA\",\"JADA\",\"ILSE\",\"HAILEY\",\"BRITTANI\",\"ZONA\",\"SYBLE\",\"SHERRYL\",\"RANDY\",\"NIDIA\",\"MARLO\",\"KANDICE\",\"KANDI\",\"DEB\",\"DEAN\",\"AMERICA\",\"ALYCIA\",\"TOMMY\",\"RONNA\",\"NORENE\",\"MERCY\",\"JOSE\",\"INGEBORG\",\"GIOVANNA\",\"GEMMA\",\"CHRISTEL\",\"AUDRY\",\"ZORA\",\"VITA\",\"VAN\",\"TRISH\",\"STEPHAINE\",\"SHIRLEE\",\"SHANIKA\",\"MELONIE\",\"MAZIE\",\"JAZMIN\",\"INGA\",\"HOA\",\"HETTIE\",\"GERALYN\",\"FONDA\",\"ESTRELLA\",\"ADELLA\",\"SU\",\"SARITA\",\"RINA\",\"MILISSA\",\"MARIBETH\",\"GOLDA\",\"EVON\",\"ETHELYN\",\"ENEDINA\",\"CHERISE\",\"CHANA\",\"VELVA\",\"TAWANNA\",\"SADE\",\"MIRTA\",\"LI\",\"KARIE\",\"JACINTA\",\"ELNA\",\"DAVINA\",\"CIERRA\",\"ASHLIE\",\"ALBERTHA\",\"TANESHA\",\"STEPHANI\",\"NELLE\",\"MINDI\",\"LU\",\"LORINDA\",\"LARUE\",\"FLORENE\",\"DEMETRA\",\"DEDRA\",\"CIARA\",\"CHANTELLE\",\"ASHLY\",\"SUZY\",\"ROSALVA\",\"NOELIA\",\"LYDA\",\"LEATHA\",\"KRYSTYNA\",\"KRISTAN\",\"KARRI\",\"DARLINE\",\"DARCIE\",\"CINDA\",\"CHEYENNE\",\"CHERRIE\",\"AWILDA\",\"ALMEDA\",\"ROLANDA\",\"LANETTE\",\"JERILYN\",\"GISELE\",\"EVALYN\",\"CYNDI\",\"CLETA\",\"CARIN\",\"ZINA\",\"ZENA\",\"VELIA\",\"TANIKA\",\"PAUL\",\"CHARISSA\",\"THOMAS\",\"TALIA\",\"MARGARETE\",\"LAVONDA\",\"KAYLEE\",\"KATHLENE\",\"JONNA\",\"IRENA\",\"ILONA\",\"IDALIA\",\"CANDIS\",\"CANDANCE\",\"BRANDEE\",\"ANITRA\",\"ALIDA\",\"SIGRID\",\"NICOLETTE\",\"MARYJO\",\"LINETTE\",\"HEDWIG\",\"CHRISTIANA\",\"CASSIDY\",\"ALEXIA\",\"TRESSIE\",\"MODESTA\",\"LUPITA\",\"LITA\",\"GLADIS\",\"EVELIA\",\"DAVIDA\",\"CHERRI\",\"CECILY\",\"ASHELY\",\"ANNABEL\",\"AGUSTINA\",\"WANITA\",\"SHIRLY\",\"ROSAURA\",\"HULDA\",\"EUN\",\"BAILEY\",\"YETTA\",\"VERONA\",\"THOMASINA\",\"SIBYL\",\"SHANNAN\",\"MECHELLE\",\"LUE\",\"LEANDRA\",\"LANI\",\"KYLEE\",\"KANDY\",\"JOLYNN\",\"FERNE\",\"EBONI\",\"CORENE\",\"ALYSIA\",\"ZULA\",\"NADA\",\"MOIRA\",\"LYNDSAY\",\"LORRETTA\",\"JUAN\",\"JAMMIE\",\"HORTENSIA\",\"GAYNELL\",\"CAMERON\",\"ADRIA\",\"VINA\",\"VICENTA\",\"TANGELA\",\"STEPHINE\",\"NORINE\",\"NELLA\",\"LIANA\",\"LESLEE\",\"KIMBERELY\",\"ILIANA\",\"GLORY\",\"FELICA\",\"EMOGENE\",\"ELFRIEDE\",\"EDEN\",\"EARTHA\",\"CARMA\",\"BEA\",\"OCIE\",\"MARRY\",\"LENNIE\",\"KIARA\",\"JACALYN\",\"CARLOTA\",\"ARIELLE\",\"YU\",\"STAR\",\"OTILIA\",\"KIRSTIN\",\"KACEY\",\"JOHNETTA\",\"JOEY\",\"JOETTA\",\"JERALDINE\",\"JAUNITA\",\"ELANA\",\"DORTHEA\",\"CAMI\",\"AMADA\",\"ADELIA\",\"VERNITA\",\"TAMAR\",\"SIOBHAN\",\"RENEA\",\"RASHIDA\",\"OUIDA\",\"ODELL\",\"NILSA\",\"MERYL\",\"KRISTYN\",\"JULIETA\",\"DANICA\",\"BREANNE\",\"AUREA\",\"ANGLEA\",\"SHERRON\",\"ODETTE\",\"MALIA\",\"LORELEI\",\"LIN\",\"LEESA\",\"KENNA\",\"KATHLYN\",\"FIONA\",\"CHARLETTE\",\"SUZIE\",\"SHANTELL\",\"SABRA\",\"RACQUEL\",\"MYONG\",\"MIRA\",\"MARTINE\",\"LUCIENNE\",\"LAVADA\",\"JULIANN\",\"JOHNIE\",\"ELVERA\",\"DELPHIA\",\"CLAIR\",\"CHRISTIANE\",\"CHAROLETTE\",\"CARRI\",\"AUGUSTINE\",\"ASHA\",\"ANGELLA\",\"PAOLA\",\"NINFA\",\"LEDA\",\"LAI\",\"EDA\",\"SUNSHINE\",\"STEFANI\",\"SHANELL\",\"PALMA\",\"MACHELLE\",\"LISSA\",\"KECIA\",\"KATHRYNE\",\"KARLENE\",\"JULISSA\",\"JETTIE\",\"JENNIFFER\",\"HUI\",\"CORRINA\",\"CHRISTOPHER\",\"CAROLANN\",\"ALENA\",\"TESS\",\"ROSARIA\",\"MYRTICE\",\"MARYLEE\",\"LIANE\",\"KENYATTA\",\"JUDIE\",\"JANEY\",\"IN\",\"ELMIRA\",\"ELDORA\",\"DENNA\",\"CRISTI\",\"CATHI\",\"ZAIDA\",\"VONNIE\",\"VIVA\",\"VERNIE\",\"ROSALINE\",\"MARIELA\",\"LUCIANA\",\"LESLI\",\"KARAN\",\"FELICE\",\"DENEEN\",\"ADINA\",\"WYNONA\",\"TARSHA\",\"SHERON\",\"SHASTA\",\"SHANITA\",\"SHANI\",\"SHANDRA\",\"RANDA\",\"PINKIE\",\"PARIS\",\"NELIDA\",\"MARILOU\",\"LYLA\",\"LAURENE\",\"LACI\",\"JOI\",\"JANENE\",\"DOROTHA\",\"DANIELE\",\"DANI\",\"CAROLYNN\",\"CARLYN\",\"BERENICE\",\"AYESHA\",\"ANNELIESE\",\"ALETHEA\",\"THERSA\",\"TAMIKO\",\"RUFINA\",\"OLIVA\",\"MOZELL\",\"MARYLYN\",\"MADISON\",\"KRISTIAN\",\"KATHYRN\",\"KASANDRA\",\"KANDACE\",\"JANAE\",\"GABRIEL\",\"DOMENICA\",\"DEBBRA\",\"DANNIELLE\",\"CHUN\",\"BUFFY\",\"BARBIE\",\"ARCELIA\",\"AJA\",\"ZENOBIA\",\"SHAREN\",\"SHAREE\",\"PATRICK\",\"PAGE\",\"MY\",\"LAVINIA\",\"KUM\",\"KACIE\",\"JACKELINE\",\"HUONG\",\"FELISA\",\"EMELIA\",\"ELEANORA\",\"CYTHIA\",\"CRISTIN\",\"CLYDE\",\"CLARIBEL\",\"CARON\",\"ANASTACIA\",\"ZULMA\",\"ZANDRA\",\"YOKO\",\"TENISHA\",\"SUSANN\",\"SHERILYN\",\"SHAY\",\"SHAWANDA\",\"SABINE\",\"ROMANA\",\"MATHILDA\",\"LINSEY\",\"KEIKO\",\"JOANA\",\"ISELA\",\"GRETTA\",\"GEORGETTA\",\"EUGENIE\",\"DUSTY\",\"DESIRAE\",\"DELORA\",\"CORAZON\",\"ANTONINA\",\"ANIKA\",\"WILLENE\",\"TRACEE\",\"TAMATHA\",\"REGAN\",\"NICHELLE\",\"MICKIE\",\"MAEGAN\",\"LUANA\",\"LANITA\",\"KELSIE\",\"EDELMIRA\",\"BREE\",\"AFTON\",\"TEODORA\",\"TAMIE\",\"SHENA\",\"MEG\",\"LINH\",\"KELI\",\"KACI\",\"DANYELLE\",\"BRITT\",\"ARLETTE\",\"ALBERTINE\",\"ADELLE\",\"TIFFINY\",\"STORMY\",\"SIMONA\",\"NUMBERS\",\"NICOLASA\",\"NICHOL\",\"NIA\",\"NAKISHA\",\"MEE\",\"MAIRA\",\"LOREEN\",\"KIZZY\",\"JOHNNY\",\"JAY\",\"FALLON\",\"CHRISTENE\",\"BOBBYE\",\"ANTHONY\",\"YING\",\"VINCENZA\",\"TANJA\",\"RUBIE\",\"RONI\",\"QUEENIE\",\"MARGARETT\",\"KIMBERLI\",\"IRMGARD\",\"IDELL\",\"HILMA\",\"EVELINA\",\"ESTA\",\"EMILEE\",\"DENNISE\",\"DANIA\",\"CARL\",\"CARIE\",\"ANTONIO\",\"WAI\",\"SANG\",\"RISA\",\"RIKKI\",\"PARTICIA\",\"MUI\",\"MASAKO\",\"MARIO\",\"LUVENIA\",\"LOREE\",\"LONI\",\"LIEN\",\"KEVIN\",\"GIGI\",\"FLORENCIA\",\"DORIAN\",\"DENITA\",\"DALLAS\",\"CHI\",\"BILLYE\",\"ALEXANDER\",\"TOMIKA\",\"SHARITA\",\"RANA\",\"NIKOLE\",\"NEOMA\",\"MARGARITE\",\"MADALYN\",\"LUCINA\",\"LAILA\",\"KALI\",\"JENETTE\",\"GABRIELE\",\"EVELYNE\",\"ELENORA\",\"CLEMENTINA\",\"ALEJANDRINA\",\"ZULEMA\",\"VIOLETTE\",\"VANNESSA\",\"THRESA\",\"RETTA\",\"PIA\",\"PATIENCE\",\"NOELLA\",\"NICKIE\",\"JONELL\",\"DELTA\",\"CHUNG\",\"CHAYA\",\"CAMELIA\",\"BETHEL\",\"ANYA\",\"ANDREW\",\"THANH\",\"SUZANN\",\"SPRING\",\"SHU\",\"MILA\",\"LILLA\",\"LAVERNA\",\"KEESHA\",\"KATTIE\",\"GIA\",\"GEORGENE\",\"EVELINE\",\"ESTELL\",\"ELIZBETH\",\"VIVIENNE\",\"VALLIE\",\"TRUDIE\",\"STEPHANE\",\"MICHEL\",\"MAGALY\",\"MADIE\",\"KENYETTA\",\"KARREN\",\"JANETTA\",\"HERMINE\",\"HARMONY\",\"DRUCILLA\",\"DEBBI\",\"CELESTINA\",\"CANDIE\",\"BRITNI\",\"BECKIE\",\"AMINA\",\"ZITA\",\"YUN\",\"YOLANDE\",\"VIVIEN\",\"VERNETTA\",\"TRUDI\",\"SOMMER\",\"PEARLE\",\"PATRINA\",\"OSSIE\",\"NICOLLE\",\"LOYCE\",\"LETTY\",\"LARISA\",\"KATHARINA\",\"JOSELYN\",\"JONELLE\",\"JENELL\",\"IESHA\",\"HEIDE\",\"FLORINDA\",\"FLORENTINA\",\"FLO\",\"ELODIA\",\"DORINE\",\"BRUNILDA\",\"BRIGID\",\"ASHLI\",\"ARDELLA\",\"TWANA\",\"THU\",\"TARAH\",\"SUNG\",\"SHEA\",\"SHAVON\",\"SHANE\",\"SERINA\",\"RAYNA\",\"RAMONITA\",\"NGA\",\"MARGURITE\",\"LUCRECIA\",\"KOURTNEY\",\"KATI\",\"JESUS\",\"JESENIA\",\"DIAMOND\",\"CRISTA\",\"AYANA\",\"ALICA\",\"ALIA\",\"VINNIE\",\"SUELLEN\",\"ROMELIA\",\"RACHELL\",\"PIPER\",\"OLYMPIA\",\"MICHIKO\",\"KATHALEEN\",\"JOLIE\",\"JESSI\",\"JANESSA\",\"HANA\",\"HA\",\"ELEASE\",\"CARLETTA\",\"BRITANY\",\"SHONA\",\"SALOME\",\"ROSAMOND\",\"REGENA\",\"RAINA\",\"NGOC\",\"NELIA\",\"LOUVENIA\",\"LESIA\",\"LATRINA\",\"LATICIA\",\"LARHONDA\",\"JINA\",\"JACKI\",\"HOLLIS\",\"HOLLEY\",\"EMMY\",\"DEEANN\",\"CORETTA\",\"ARNETTA\",\"VELVET\",\"THALIA\",\"SHANICE\",\"NETA\",\"MIKKI\",\"MICKI\",\"LONNA\",\"LEANA\",\"LASHUNDA\",\"KILEY\",\"JOYE\",\"JACQULYN\",\"IGNACIA\",\"HYUN\",\"HIROKO\",\"HENRY\",\"HENRIETTE\",\"ELAYNE\",\"DELINDA\",\"DARNELL\",\"DAHLIA\",\"COREEN\",\"CONSUELA\",\"CONCHITA\",\"CELINE\",\"BABETTE\",\"AYANNA\",\"ANETTE\",\"ALBERTINA\",\"SKYE\",\"SHAWNEE\",\"SHANEKA\",\"QUIANA\",\"PAMELIA\",\"MIN\",\"MERRI\",\"MERLENE\",\"MARGIT\",\"KIESHA\",\"KIERA\",\"KAYLENE\",\"JODEE\",\"JENISE\",\"ERLENE\",\"EMMIE\",\"ELSE\",\"DARYL\",\"DALILA\",\"DAISEY\",\"CODY\",\"CASIE\",\"BELIA\",\"BABARA\",\"VERSIE\",\"VANESA\",\"SHELBA\",\"SHAWNDA\",\"SAM\",\"NORMAN\",\"NIKIA\",\"NAOMA\",\"MARNA\",\"MARGERET\",\"MADALINE\",\"LAWANA\",\"KINDRA\",\"JUTTA\",\"JAZMINE\",\"JANETT\",\"HANNELORE\",\"GLENDORA\",\"GERTRUD\",\"GARNETT\",\"FREEDA\",\"FREDERICA\",\"FLORANCE\",\"FLAVIA\",\"DENNIS\",\"CARLINE\",\"BEVERLEE\",\"ANJANETTE\",\"VALDA\",\"TRINITY\",\"TAMALA\",\"STEVIE\",\"SHONNA\",\"SHA\",\"SARINA\",\"ONEIDA\",\"MICAH\",\"MERILYN\",\"MARLEEN\",\"LURLINE\",\"LENNA\",\"KATHERIN\",\"JIN\",\"JENI\",\"HAE\",\"GRACIA\",\"GLADY\",\"FARAH\",\"ERIC\",\"ENOLA\",\"EMA\",\"DOMINQUE\",\"DEVONA\",\"DELANA\",\"CECILA\",\"CAPRICE\",\"ALYSHA\",\"ALI\",\"ALETHIA\",\"VENA\",\"THERESIA\",\"TAWNY\",\"SONG\",\"SHAKIRA\",\"SAMARA\",\"SACHIKO\",\"RACHELE\",\"PAMELLA\",\"NICKY\",\"MARNI\",\"MARIEL\",\"MAREN\",\"MALISA\",\"LIGIA\",\"LERA\",\"LATORIA\",\"LARAE\",\"KIMBER\",\"KATHERN\",\"KAREY\",\"JENNEFER\",\"JANETH\",\"HALINA\",\"FREDIA\",\"DELISA\",\"DEBROAH\",\"CIERA\",\"CHIN\",\"ANGELIKA\",\"ANDREE\",\"ALTHA\",\"YEN\",\"VIVAN\",\"TERRESA\",\"TANNA\",\"SUK\",\"SUDIE\",\"SOO\",\"SIGNE\",\"SALENA\",\"RONNI\",\"REBBECCA\",\"MYRTIE\",\"MCKENZIE\",\"MALIKA\",\"MAIDA\",\"LOAN\",\"LEONARDA\",\"KAYLEIGH\",\"FRANCE\",\"ETHYL\",\"ELLYN\",\"DAYLE\",\"CAMMIE\",\"BRITTNI\",\"BIRGIT\",\"AVELINA\",\"ASUNCION\",\"ARIANNA\",\"AKIKO\",\"VENICE\",\"TYESHA\",\"TONIE\",\"TIESHA\",\"TAKISHA\",\"STEFFANIE\",\"SINDY\",\"SANTANA\",\"MEGHANN\",\"MANDA\",\"MACIE\",\"LADY\",\"KELLYE\",\"KELLEE\",\"JOSLYN\",\"JASON\",\"INGER\",\"INDIRA\",\"GLINDA\",\"GLENNIS\",\"FERNANDA\",\"FAUSTINA\",\"ENEIDA\",\"ELICIA\",\"DOT\",\"DIGNA\",\"DELL\",\"ARLETTA\",\"ANDRE\",\"WILLIA\",\"TAMMARA\",\"TABETHA\",\"SHERRELL\",\"SARI\",\"REFUGIO\",\"REBBECA\",\"PAULETTA\",\"NIEVES\",\"NATOSHA\",\"NAKITA\",\"MAMMIE\",\"KENISHA\",\"KAZUKO\",\"KASSIE\",\"GARY\",\"EARLEAN\",\"DAPHINE\",\"CORLISS\",\"CLOTILDE\",\"CAROLYNE\",\"BERNETTA\",\"AUGUSTINA\",\"AUDREA\",\"ANNIS\",\"ANNABELL\",\"YAN\",\"TENNILLE\",\"TAMICA\",\"SELENE\",\"SEAN\",\"ROSANA\",\"REGENIA\",\"QIANA\",\"MARKITA\",\"MACY\",\"LEEANNE\",\"LAURINE\",\"KYM\",\"JESSENIA\",\"JANITA\",\"GEORGINE\",\"GENIE\",\"EMIKO\",\"ELVIE\",\"DEANDRA\",\"DAGMAR\",\"CORIE\",\"COLLEN\",\"CHERISH\",\"ROMAINE\",\"PORSHA\",\"PEARLENE\",\"MICHELINE\",\"MERNA\",\"MARGORIE\",\"MARGARETTA\",\"LORE\",\"KENNETH\",\"JENINE\",\"HERMINA\",\"FREDERICKA\",\"ELKE\",\"DRUSILLA\",\"DORATHY\",\"DIONE\",\"DESIRE\",\"CELENA\",\"BRIGIDA\",\"ANGELES\",\"ALLEGRA\",\"THEO\",\"TAMEKIA\",\"SYNTHIA\",\"STEPHEN\",\"SOOK\",\"SLYVIA\",\"ROSANN\",\"REATHA\",\"RAYE\",\"MARQUETTA\",\"MARGART\",\"LING\",\"LAYLA\",\"KYMBERLY\",\"KIANA\",\"KAYLEEN\",\"KATLYN\",\"KARMEN\",\"JOELLA\",\"IRINA\",\"EMELDA\",\"ELENI\",\"DETRA\",\"CLEMMIE\",\"CHERYLL\",\"CHANTELL\",\"CATHEY\",\"ARNITA\",\"ARLA\",\"ANGLE\",\"ANGELIC\",\"ALYSE\",\"ZOFIA\",\"THOMASINE\",\"TENNIE\",\"SON\",\"SHERLY\",\"SHERLEY\",\"SHARYL\",\"REMEDIOS\",\"PETRINA\",\"NICKOLE\",\"MYUNG\",\"MYRLE\",\"MOZELLA\",\"LOUANNE\",\"LISHA\",\"LATIA\",\"LANE\",\"KRYSTA\",\"JULIENNE\",\"JOEL\",\"JEANENE\",\"JACQUALINE\",\"ISAURA\",\"GWENDA\",\"EARLEEN\",\"DONALD\",\"CLEOPATRA\",\"CARLIE\",\"AUDIE\",\"ANTONIETTA\",\"ALISE\",\"ALEX\",\"VERDELL\",\"VAL\",\"TYLER\",\"TOMOKO\",\"THAO\",\"TALISHA\",\"STEVEN\",\"SO\",\"SHEMIKA\",\"SHAUN\",\"SCARLET\",\"SAVANNA\",\"SANTINA\",\"ROSIA\",\"RAEANN\",\"ODILIA\",\"NANA\",\"MINNA\",\"MAGAN\",\"LYNELLE\",\"LE\",\"KARMA\",\"JOEANN\",\"IVANA\",\"INELL\",\"ILANA\",\"HYE\",\"HONEY\",\"HEE\",\"GUDRUN\",\"FRANK\",\"DREAMA\",\"CRISSY\",\"CHANTE\",\"CARMELINA\",\"ARVILLA\",\"ARTHUR\",\"ANNAMAE\",\"ALVERA\",\"ALEIDA\",\"AARON\",\"YEE\",\"YANIRA\",\"VANDA\",\"TIANNA\",\"TAM\",\"STEFANIA\",\"SHIRA\",\"PERRY\",\"NICOL\",\"NANCIE\",\"MONSERRATE\",\"MINH\",\"MELYNDA\",\"MELANY\",\"MATTHEW\",\"LOVELLA\",\"LAURE\",\"KIRBY\",\"KACY\",\"JACQUELYNN\",\"HYON\",\"GERTHA\",\"FRANCISCO\",\"ELIANA\",\"CHRISTENA\",\"CHRISTEEN\",\"CHARISE\",\"CATERINA\",\"CARLEY\",\"CANDYCE\",\"ARLENA\",\"AMMIE\",\"YANG\",\"WILLETTE\",\"VANITA\",\"TUYET\",\"TINY\",\"SYREETA\",\"SILVA\",\"SCOTT\",\"RONALD\",\"PENNEY\",\"NYLA\",\"MICHAL\",\"MAURICE\",\"MARYAM\",\"MARYA\",\"MAGEN\",\"LUDIE\",\"LOMA\",\"LIVIA\",\"LANELL\",\"KIMBERLIE\",\"JULEE\",\"DONETTA\",\"DIEDRA\",\"DENISHA\",\"DEANE\",\"DAWNE\",\"CLARINE\",\"CHERRYL\",\"BRONWYN\",\"BRANDON\",\"ALLA\",\"VALERY\",\"TONDA\",\"SUEANN\",\"SORAYA\",\"SHOSHANA\",\"SHELA\",\"SHARLEEN\",\"SHANELLE\",\"NERISSA\",\"MICHEAL\",\"MERIDITH\",\"MELLIE\",\"MAYE\",\"MAPLE\",\"MAGARET\",\"LUIS\",\"LILI\",\"LEONILA\",\"LEONIE\",\"LEEANNA\",\"LAVONIA\",\"LAVERA\",\"KRISTEL\",\"KATHEY\",\"KATHE\",\"JUSTIN\",\"JULIAN\",\"JIMMY\",\"JANN\",\"ILDA\",\"HILDRED\",\"HILDEGARDE\",\"GENIA\",\"FUMIKO\",\"EVELIN\",\"ERMELINDA\",\"ELLY\",\"DUNG\",\"DOLORIS\",\"DIONNA\",\"DANAE\",\"BERNEICE\",\"ANNICE\",\"ALIX\",\"VERENA\",\"VERDIE\",\"TRISTAN\",\"SHAWNNA\",\"SHAWANA\",\"SHAUNNA\",\"ROZELLA\",\"RANDEE\",\"RANAE\",\"MILAGRO\",\"LYNELL\",\"LUISE\",\"LOUIE\",\"LOIDA\",\"LISBETH\",\"KARLEEN\",\"JUNITA\",\"JONA\",\"ISIS\",\"HYACINTH\",\"HEDY\",\"GWENN\",\"ETHELENE\",\"ERLINE\",\"EDWARD\",\"DONYA\",\"DOMONIQUE\",\"DELICIA\",\"DANNETTE\",\"CICELY\",\"BRANDA\",\"BLYTHE\",\"BETHANN\",\"ASHLYN\",\"ANNALEE\",\"ALLINE\",\"YUKO\",\"VELLA\",\"TRANG\",\"TOWANDA\",\"TESHA\",\"SHERLYN\",\"NARCISA\",\"MIGUELINA\",\"MERI\",\"MAYBELL\",\"MARLANA\",\"MARGUERITA\",\"MADLYN\",\"LUNA\",\"LORY\",\"LORIANN\",\"LIBERTY\",\"LEONORE\",\"LEIGHANN\",\"LAURICE\",\"LATESHA\",\"LARONDA\",\"KATRICE\",\"KASIE\",\"KARL\",\"KALEY\",\"JADWIGA\",\"GLENNIE\",\"GEARLDINE\",\"FRANCINA\",\"EPIFANIA\",\"DYAN\",\"DORIE\",\"DIEDRE\",\"DENESE\",\"DEMETRICE\",\"DELENA\",\"DARBY\",\"CRISTIE\",\"CLEORA\",\"CATARINA\",\"CARISA\",\"BERNIE\",\"BARBERA\",\"ALMETA\",\"TRULA\",\"TEREASA\",\"SOLANGE\",\"SHEILAH\",\"SHAVONNE\",\"SANORA\",\"ROCHELL\",\"MATHILDE\",\"MARGARETA\",\"MAIA\",\"LYNSEY\",\"LAWANNA\",\"LAUNA\",\"KENA\",\"KEENA\",\"KATIA\",\"JAMEY\",\"GLYNDA\",\"GAYLENE\",\"ELVINA\",\"ELANOR\",\"DANUTA\",\"DANIKA\",\"CRISTEN\",\"CORDIE\",\"COLETTA\",\"CLARITA\",\"CARMON\",\"BRYNN\",\"AZUCENA\",\"AUNDREA\",\"ANGELE\",\"YI\",\"WALTER\",\"VERLIE\",\"VERLENE\",\"TAMESHA\",\"SILVANA\",\"SEBRINA\",\"SAMIRA\",\"REDA\",\"RAYLENE\",\"PENNI\",\"PANDORA\",\"NORAH\",\"NOMA\",\"MIREILLE\",\"MELISSIA\",\"MARYALICE\",\"LARAINE\",\"KIMBERY\",\"KARYL\",\"KARINE\",\"KAM\",\"JOLANDA\",\"JOHANA\",\"JESUSA\",\"JALEESA\",\"JAE\",\"JACQUELYNE\",\"IRISH\",\"ILUMINADA\",\"HILARIA\",\"HANH\",\"GENNIE\",\"FRANCIE\",\"FLORETTA\",\"EXIE\",\"EDDA\",\"DREMA\",\"DELPHA\",\"BEV\",\"BARBAR\",\"ASSUNTA\",\"ARDELL\",\"ANNALISA\",\"ALISIA\",\"YUKIKO\",\"YOLANDO\",\"WONDA\",\"WEI\",\"WALTRAUD\",\"VETA\",\"TEQUILA\",\"TEMEKA\",\"TAMEIKA\",\"SHIRLEEN\",\"SHENITA\",\"PIEDAD\",\"OZELLA\",\"MIRTHA\",\"MARILU\",\"KIMIKO\",\"JULIANE\",\"JENICE\",\"JEN\",\"JANAY\",\"JACQUILINE\",\"HILDE\",\"FE\",\"FAE\",\"EVAN\",\"EUGENE\",\"ELOIS\",\"ECHO\",\"DEVORAH\",\"CHAU\",\"BRINDA\",\"BETSEY\",\"ARMINDA\",\"ARACELIS\",\"APRYL\",\"ANNETT\",\"ALISHIA\",\"VEOLA\",\"USHA\",\"TOSHIKO\",\"THEOLA\",\"TASHIA\",\"TALITHA\",\"SHERY\",\"RUDY\",\"RENETTA\",\"REIKO\",\"RASHEEDA\",\"OMEGA\",\"OBDULIA\",\"MIKA\",\"MELAINE\",\"MEGGAN\",\"MARTIN\",\"MARLEN\",\"MARGET\",\"MARCELINE\",\"MANA\",\"MAGDALEN\",\"LIBRADA\",\"LEZLIE\",\"LEXIE\",\"LATASHIA\",\"LASANDRA\",\"KELLE\",\"ISIDRA\",\"ISA\",\"INOCENCIA\",\"GWYN\",\"FRANCOISE\",\"ERMINIA\",\"ERINN\",\"DIMPLE\",\"DEVORA\",\"CRISELDA\",\"ARMANDA\",\"ARIE\",\"ARIANE\",\"ANGELO\",\"ANGELENA\",\"ALLEN\",\"ALIZA\",\"ADRIENE\",\"ADALINE\",\"XOCHITL\",\"TWANNA\",\"TRAN\",\"TOMIKO\",\"TAMISHA\",\"TAISHA\",\"SUSY\",\"SIU\",\"RUTHA\",\"ROXY\",\"RHONA\",\"RAYMOND\",\"OTHA\",\"NORIKO\",\"NATASHIA\",\"MERRIE\",\"MELVIN\",\"MARINDA\",\"MARIKO\",\"MARGERT\",\"LORIS\",\"LIZZETTE\",\"LEISHA\",\"KAILA\",\"KA\",\"JOANNIE\",\"JERRICA\",\"JENE\",\"JANNET\",\"JANEE\",\"JACINDA\",\"HERTA\",\"ELENORE\",\"DORETTA\",\"DELAINE\",\"DANIELL\",\"CLAUDIE\",\"CHINA\",\"BRITTA\",\"APOLONIA\",\"AMBERLY\",\"ALEASE\",\"YURI\",\"YUK\",\"WEN\",\"WANETA\",\"UTE\",\"TOMI\",\"SHARRI\",\"SANDIE\",\"ROSELLE\",\"REYNALDA\",\"RAGUEL\",\"PHYLICIA\",\"PATRIA\",\"OLIMPIA\",\"ODELIA\",\"MITZIE\",\"MITCHELL\",\"MISS\",\"MINDA\",\"MIGNON\",\"MICA\",\"MENDY\",\"MARIVEL\",\"MAILE\",\"LYNETTA\",\"LAVETTE\",\"LAURYN\",\"LATRISHA\",\"LAKIESHA\",\"KIERSTEN\",\"KARY\",\"JOSPHINE\",\"JOLYN\",\"JETTA\",\"JANISE\",\"JACQUIE\",\"IVELISSE\",\"GLYNIS\",\"GIANNA\",\"GAYNELLE\",\"EMERALD\",\"DEMETRIUS\",\"DANYELL\",\"DANILLE\",\"DACIA\",\"CORALEE\",\"CHER\",\"CEOLA\",\"BRETT\",\"BELL\",\"ARIANNE\",\"ALESHIA\",\"YUNG\",\"WILLIEMAE\",\"TROY\",\"TRINH\",\"THORA\",\"TAI\",\"SVETLANA\",\"SHERIKA\",\"SHEMEKA\",\"SHAUNDA\",\"ROSELINE\",\"RICKI\",\"MELDA\",\"MALLIE\",\"LAVONNA\",\"LATINA\",\"LARRY\",\"LAQUANDA\",\"LALA\",\"LACHELLE\",\"KLARA\",\"KANDIS\",\"JOHNA\",\"JEANMARIE\",\"JAYE\",\"HANG\",\"GRAYCE\",\"GERTUDE\",\"EMERITA\",\"EBONIE\",\"CLORINDA\",\"CHING\",\"CHERY\",\"CAROLA\",\"BREANN\",\"BLOSSOM\",\"BERNARDINE\",\"BECKI\",\"ARLETHA\",\"ARGELIA\",\"ARA\",\"ALITA\",\"YULANDA\",\"YON\",\"YESSENIA\",\"TOBI\",\"TASIA\",\"SYLVIE\",\"SHIRL\",\"SHIRELY\",\"SHERIDAN\",\"SHELLA\",\"SHANTELLE\",\"SACHA\",\"ROYCE\",\"REBECKA\",\"REAGAN\",\"PROVIDENCIA\",\"PAULENE\",\"MISHA\",\"MIKI\",\"MARLINE\",\"MARICA\",\"LORITA\",\"LATOYIA\",\"LASONYA\",\"KERSTIN\",\"KENDA\",\"KEITHA\",\"KATHRIN\",\"JAYMIE\",\"JACK\",\"GRICELDA\",\"GINETTE\",\"ERYN\",\"ELINA\",\"ELFRIEDA\",\"DANYEL\",\"CHEREE\",\"CHANELLE\",\"BARRIE\",\"AVERY\",\"AURORE\",\"ANNAMARIA\",\"ALLEEN\",\"AILENE\",\"AIDE\",\"YASMINE\",\"VASHTI\",\"VALENTINE\",\"TREASA\",\"TORY\",\"TIFFANEY\",\"SHERYLL\",\"SHARIE\",\"SHANAE\",\"SAU\",\"RAISA\",\"PA\",\"NEDA\",\"MITSUKO\",\"MIRELLA\",\"MILDA\",\"MARYANNA\",\"MARAGRET\",\"MABELLE\",\"LUETTA\",\"LORINA\",\"LETISHA\",\"LATARSHA\",\"LANELLE\",\"LAJUANA\",\"KRISSY\",\"KARLY\",\"KARENA\",\"JON\",\"JESSIKA\",\"JERICA\",\"JEANELLE\",\"JANUARY\",\"JALISA\",\"JACELYN\",\"IZOLA\",\"IVEY\",\"GREGORY\",\"EUNA\",\"ETHA\",\"DREW\",\"DOMITILA\",\"DOMINICA\",\"DAINA\",\"CREOLA\",\"CARLI\",\"CAMIE\",\"BUNNY\",\"BRITTNY\",\"ASHANTI\",\"ANISHA\",\"ALEEN\",\"ADAH\",\"YASUKO\",\"WINTER\",\"VIKI\",\"VALRIE\",\"TONA\",\"TINISHA\",\"THI\",\"TERISA\",\"TATUM\",\"TANEKA\",\"SIMONNE\",\"SHALANDA\",\"SERITA\",\"RESSIE\",\"REFUGIA\",\"PAZ\",\"OLENE\",\"NA\",\"MERRILL\",\"MARGHERITA\",\"MANDIE\",\"MAN\",\"MAIRE\",\"LYNDIA\",\"LUCI\",\"LORRIANE\",\"LORETA\",\"LEONIA\",\"LAVONA\",\"LASHAWNDA\",\"LAKIA\",\"KYOKO\",\"KRYSTINA\",\"KRYSTEN\",\"KENIA\",\"KELSI\",\"JUDE\",\"JEANICE\",\"ISOBEL\",\"GEORGIANN\",\"GENNY\",\"FELICIDAD\",\"EILENE\",\"DEON\",\"DELOISE\",\"DEEDEE\",\"DANNIE\",\"CONCEPTION\",\"CLORA\",\"CHERILYN\",\"CHANG\",\"CALANDRA\",\"BERRY\",\"ARMANDINA\",\"ANISA\",\"ULA\",\"TIMOTHY\",\"TIERA\",\"THERESSA\",\"STEPHANIA\",\"SIMA\",\"SHYLA\",\"SHONTA\",\"SHERA\",\"SHAQUITA\",\"SHALA\",\"SAMMY\",\"ROSSANA\",\"NOHEMI\",\"NERY\",\"MORIAH\",\"MELITA\",\"MELIDA\",\"MELANI\",\"MARYLYNN\",\"MARISHA\",\"MARIETTE\",\"MALORIE\",\"MADELENE\",\"LUDIVINA\",\"LORIA\",\"LORETTE\",\"LORALEE\",\"LIANNE\",\"LEON\",\"LAVENIA\",\"LAURINDA\",\"LASHON\",\"KIT\",\"KIMI\",\"KEILA\",\"KATELYNN\",\"KAI\",\"JONE\",\"JOANE\",\"JI\",\"JAYNA\",\"JANELLA\",\"JA\",\"HUE\",\"HERTHA\",\"FRANCENE\",\"ELINORE\",\"DESPINA\",\"DELSIE\",\"DEEDRA\",\"CLEMENCIA\",\"CARRY\",\"CAROLIN\",\"CARLOS\",\"BULAH\",\"BRITTANIE\",\"BOK\",\"BLONDELL\",\"BIBI\",\"BEAULAH\",\"BEATA\",\"ANNITA\",\"AGRIPINA\",\"VIRGEN\",\"VALENE\",\"UN\",\"TWANDA\",\"TOMMYE\",\"TOI\",\"TARRA\",\"TARI\",\"TAMMERA\",\"SHAKIA\",\"SADYE\",\"RUTHANNE\",\"ROCHEL\",\"RIVKA\",\"PURA\",\"NENITA\",\"NATISHA\",\"MING\",\"MERRILEE\",\"MELODEE\",\"MARVIS\",\"LUCILLA\",\"LEENA\",\"LAVETA\",\"LARITA\",\"LANIE\",\"KEREN\",\"ILEEN\",\"GEORGEANN\",\"GENNA\",\"GENESIS\",\"FRIDA\",\"EWA\",\"EUFEMIA\",\"EMELY\",\"ELA\",\"EDYTH\",\"DEONNA\",\"DEADRA\",\"DARLENA\",\"CHANELL\",\"CHAN\",\"CATHERN\",\"CASSONDRA\",\"CASSAUNDRA\",\"BERNARDA\",\"BERNA\",\"ARLINDA\",\"ANAMARIA\",\"ALBERT\",\"WESLEY\",\"VERTIE\",\"VALERI\",\"TORRI\",\"TATYANA\",\"STASIA\",\"SHERISE\",\"SHERILL\",\"SEASON\",\"SCOTTIE\",\"SANDA\",\"RUTHE\",\"ROSY\",\"ROBERTO\",\"ROBBI\",\"RANEE\",\"QUYEN\",\"PEARLY\",\"PALMIRA\",\"ONITA\",\"NISHA\",\"NIESHA\",\"NIDA\",\"NEVADA\",\"NAM\",\"MERLYN\",\"MAYOLA\",\"MARYLOUISE\",\"MARYLAND\",\"MARX\",\"MARTH\",\"MARGENE\",\"MADELAINE\",\"LONDA\",\"LEONTINE\",\"LEOMA\",\"LEIA\",\"LAWRENCE\",\"LAURALEE\",\"LANORA\",\"LAKITA\",\"KIYOKO\",\"KETURAH\",\"KATELIN\",\"KAREEN\",\"JONIE\",\"JOHNETTE\",\"JENEE\",\"JEANETT\",\"IZETTA\",\"HIEDI\",\"HEIKE\",\"HASSIE\",\"HAROLD\",\"GIUSEPPINA\",\"GEORGANN\",\"FIDELA\",\"FERNANDE\",\"ELWANDA\",\"ELLAMAE\",\"ELIZ\",\"DUSTI\",\"DOTTY\",\"CYNDY\",\"CORALIE\",\"CELESTA\",\"ARGENTINA\",\"ALVERTA\",\"XENIA\",\"WAVA\",\"VANETTA\",\"TORRIE\",\"TASHINA\",\"TANDY\",\"TAMBRA\",\"TAMA\",\"STEPANIE\",\"SHILA\",\"SHAUNTA\",\"SHARAN\",\"SHANIQUA\",\"SHAE\",\"SETSUKO\",\"SERAFINA\",\"SANDEE\",\"ROSAMARIA\",\"PRISCILA\",\"OLINDA\",\"NADENE\",\"MUOI\",\"MICHELINA\",\"MERCEDEZ\",\"MARYROSE\",\"MARIN\",\"MARCENE\",\"MAO\",\"MAGALI\",\"MAFALDA\",\"LOGAN\",\"LINN\",\"LANNIE\",\"KAYCE\",\"KAROLINE\",\"KAMILAH\",\"KAMALA\",\"JUSTA\",\"JOLINE\",\"JENNINE\",\"JACQUETTA\",\"IRAIDA\",\"GERALD\",\"GEORGEANNA\",\"FRANCHESCA\",\"FAIRY\",\"EMELINE\",\"ELANE\",\"EHTEL\",\"EARLIE\",\"DULCIE\",\"DALENE\",\"CRIS\",\"CLASSIE\",\"CHERE\",\"CHARIS\",\"CAROYLN\",\"CARMINA\",\"CARITA\",\"BRIAN\",\"BETHANIE\",\"AYAKO\",\"ARICA\",\"AN\",\"ALYSA\",\"ALESSANDRA\",\"AKILAH\",\"ADRIEN\",\"ZETTA\",\"YOULANDA\",\"YELENA\",\"YAHAIRA\",\"XUAN\",\"WENDOLYN\",\"VICTOR\",\"TIJUANA\",\"TERRELL\",\"TERINA\",\"TERESIA\",\"SUZI\",\"SUNDAY\",\"SHERELL\",\"SHAVONDA\",\"SHAUNTE\",\"SHARDA\",\"SHAKITA\",\"SENA\",\"RYANN\",\"RUBI\",\"RIVA\",\"REGINIA\",\"REA\",\"RACHAL\",\"PARTHENIA\",\"PAMULA\",\"MONNIE\",\"MONET\",\"MICHAELE\",\"MELIA\",\"MARINE\",\"MALKA\",\"MAISHA\",\"LISANDRA\",\"LEO\",\"LEKISHA\",\"LEAN\",\"LAURENCE\",\"LAKENDRA\",\"KRYSTIN\",\"KORTNEY\",\"KIZZIE\",\"KITTIE\",\"KERA\",\"KENDAL\",\"KEMBERLY\",\"KANISHA\",\"JULENE\",\"JULE\",\"JOSHUA\",\"JOHANNE\",\"JEFFREY\",\"JAMEE\",\"HAN\",\"HALLEY\",\"GIDGET\",\"GALINA\",\"FREDRICKA\",\"FLETA\",\"FATIMAH\",\"EUSEBIA\",\"ELZA\",\"ELEONORE\",\"DORTHEY\",\"DORIA\",\"DONELLA\",\"DINORAH\",\"DELORSE\",\"CLARETHA\",\"CHRISTINIA\",\"CHARLYN\",\"BONG\",\"BELKIS\",\"AZZIE\",\"ANDERA\",\"AIKO\",\"ADENA\",\"YER\",\"YAJAIRA\",\"WAN\",\"VANIA\",\"ULRIKE\",\"TOSHIA\",\"TIFANY\",\"STEFANY\",\"SHIZUE\",\"SHENIKA\",\"SHAWANNA\",\"SHAROLYN\",\"SHARILYN\",\"SHAQUANA\",\"SHANTAY\",\"SEE\",\"ROZANNE\",\"ROSELEE\",\"RICKIE\",\"REMONA\",\"REANNA\",\"RAELENE\",\"QUINN\",\"PHUNG\",\"PETRONILA\",\"NATACHA\",\"NANCEY\",\"MYRL\",\"MIYOKO\",\"MIESHA\",\"MERIDETH\",\"MARVELLA\",\"MARQUITTA\",\"MARHTA\",\"MARCHELLE\",\"LIZETH\",\"LIBBIE\",\"LAHOMA\",\"LADAWN\",\"KINA\",\"KATHELEEN\",\"KATHARYN\",\"KARISA\",\"KALEIGH\",\"JUNIE\",\"JULIEANN\",\"JOHNSIE\",\"JANEAN\",\"JAIMEE\",\"JACKQUELINE\",\"HISAKO\",\"HERMA\",\"HELAINE\",\"GWYNETH\",\"GLENN\",\"GITA\",\"EUSTOLIA\",\"EMELINA\",\"ELIN\",\"EDRIS\",\"DONNETTE\",\"DONNETTA\",\"DIERDRE\",\"DENAE\",\"DARCEL\",\"CLAUDE\",\"CLARISA\",\"CINDERELLA\",\"CHIA\",\"CHARLESETTA\",\"CHARITA\",\"CELSA\",\"CASSY\",\"CASSI\",\"CARLEE\",\"BRUNA\",\"BRITTANEY\",\"BRANDE\",\"BILLI\",\"BAO\",\"ANTONETTA\",\"ANGLA\",\"ANGELYN\",\"ANALISA\",\"ALANE\",\"WENONA\",\"WENDIE\",\"VERONIQUE\",\"VANNESA\",\"TOBIE\",\"TEMPIE\",\"SUMIKO\",\"SULEMA\",\"SPARKLE\",\"SOMER\",\"SHEBA\",\"SHAYNE\",\"SHARICE\",\"SHANEL\",\"SHALON\",\"SAGE\",\"ROY\",\"ROSIO\",\"ROSELIA\",\"RENAY\",\"REMA\",\"REENA\",\"PORSCHE\",\"PING\",\"PEG\",\"OZIE\",\"ORETHA\",\"ORALEE\",\"ODA\",\"NU\",\"NGAN\",\"NAKESHA\",\"MILLY\",\"MARYBELLE\",\"MARLIN\",\"MARIS\",\"MARGRETT\",\"MARAGARET\",\"MANIE\",\"LURLENE\",\"LILLIA\",\"LIESELOTTE\",\"LAVELLE\",\"LASHAUNDA\",\"LAKEESHA\",\"KEITH\",\"KAYCEE\",\"KALYN\",\"JOYA\",\"JOETTE\",\"JENAE\",\"JANIECE\",\"ILLA\",\"GRISEL\",\"GLAYDS\",\"GENEVIE\",\"GALA\",\"FREDDA\",\"FRED\",\"ELMER\",\"ELEONOR\",\"DEBERA\",\"DEANDREA\",\"DAN\",\"CORRINNE\",\"CORDIA\",\"CONTESSA\",\"COLENE\",\"CLEOTILDE\",\"CHARLOTT\",\"CHANTAY\",\"CECILLE\",\"BEATRIS\",\"AZALEE\",\"ARLEAN\",\"ARDATH\",\"ANJELICA\",\"ANJA\",\"ALFREDIA\",\"ALEISHA\",\"ADAM\",\"ZADA\",\"YUONNE\",\"XIAO\",\"WILLODEAN\",\"WHITLEY\",\"VENNIE\",\"VANNA\",\"TYISHA\",\"TOVA\",\"TORIE\",\"TONISHA\",\"TILDA\",\"TIEN\",\"TEMPLE\",\"SIRENA\",\"SHERRIL\",\"SHANTI\",\"SHAN\",\"SENAIDA\",\"SAMELLA\",\"ROBBYN\",\"RENDA\",\"REITA\",\"PHEBE\",\"PAULITA\",\"NOBUKO\",\"NGUYET\",\"NEOMI\",\"MOON\",\"MIKAELA\",\"MELANIA\",\"MAXIMINA\",\"MARG\",\"MAISIE\",\"LYNNA\",\"LILLI\",\"LAYNE\",\"LASHAUN\",\"LAKENYA\",\"LAEL\",\"KIRSTIE\",\"KATHLINE\",\"KASHA\",\"KARLYN\",\"KARIMA\",\"JOVAN\",\"JOSEFINE\",\"JENNELL\",\"JACQUI\",\"JACKELYN\",\"HYO\",\"HIEN\",\"GRAZYNA\",\"FLORRIE\",\"FLORIA\",\"ELEONORA\",\"DWANA\",\"DORLA\",\"DONG\",\"DELMY\",\"DEJA\",\"DEDE\",\"DANN\",\"CRYSTA\",\"CLELIA\",\"CLARIS\",\"CLARENCE\",\"CHIEKO\",\"CHERLYN\",\"CHERELLE\",\"CHARMAIN\",\"CHARA\",\"CAMMY\",\"BEE\",\"ARNETTE\",\"ARDELLE\",\"ANNIKA\",\"AMIEE\",\"AMEE\",\"ALLENA\",\"YVONE\",\"YUKI\",\"YOSHIE\",\"YEVETTE\",\"YAEL\",\"WILLETTA\",\"VONCILE\",\"VENETTA\",\"TULA\",\"TONETTE\",\"TIMIKA\",\"TEMIKA\",\"TELMA\",\"TEISHA\",\"TAREN\",\"TA\",\"STACEE\",\"SHIN\",\"SHAWNTA\",\"SATURNINA\",\"RICARDA\",\"POK\",\"PASTY\",\"ONIE\",\"NUBIA\",\"MORA\",\"MIKE\",\"MARIELLE\",\"MARIELLA\",\"MARIANELA\",\"MARDELL\",\"MANY\",\"LUANNA\",\"LOISE\",\"LISABETH\",\"LINDSY\",\"LILLIANA\",\"LILLIAM\",\"LELAH\",\"LEIGHA\",\"LEANORA\",\"LANG\",\"KRISTEEN\",\"KHALILAH\",\"KEELEY\",\"KANDRA\",\"JUNKO\",\"JOAQUINA\",\"JERLENE\",\"JANI\",\"JAMIKA\",\"JAME\",\"HSIU\",\"HERMILA\",\"GOLDEN\",\"GENEVIVE\",\"EVIA\",\"EUGENA\",\"EMMALINE\",\"ELFREDA\",\"ELENE\",\"DONETTE\",\"DELCIE\",\"DEEANNA\",\"DARCEY\",\"CUC\",\"CLARINDA\",\"CIRA\",\"CHAE\",\"CELINDA\",\"CATHERYN\",\"CATHERIN\",\"CASIMIRA\",\"CARMELIA\",\"CAMELLIA\",\"BREANA\",\"BOBETTE\",\"BERNARDINA\",\"BEBE\",\"BASILIA\",\"ARLYNE\",\"AMAL\",\"ALAYNA\",\"ZONIA\",\"ZENIA\",\"YURIKO\",\"YAEKO\",\"WYNELL\",\"WILLOW\",\"WILLENA\",\"VERNIA\",\"TU\",\"TRAVIS\",\"TORA\",\"TERRILYN\",\"TERICA\",\"TENESHA\",\"TAWNA\",\"TAJUANA\",\"TAINA\",\"STEPHNIE\",\"SONA\",\"SOL\",\"SINA\",\"SHONDRA\",\"SHIZUKO\",\"SHERLENE\",\"SHERICE\",\"SHARIKA\",\"ROSSIE\",\"ROSENA\",\"RORY\",\"RIMA\",\"RIA\",\"RHEBA\",\"RENNA\",\"PETER\",\"NATALYA\",\"NANCEE\",\"MELODI\",\"MEDA\",\"MAXIMA\",\"MATHA\",\"MARKETTA\",\"MARICRUZ\",\"MARCELENE\",\"MALVINA\",\"LUBA\",\"LOUETTA\",\"LEIDA\",\"LECIA\",\"LAURAN\",\"LASHAWNA\",\"LAINE\",\"KHADIJAH\",\"KATERINE\",\"KASI\",\"KALLIE\",\"JULIETTA\",\"JESUSITA\",\"JESTINE\",\"JESSIA\",\"JEREMY\",\"JEFFIE\",\"JANYCE\",\"ISADORA\",\"GEORGIANNE\",\"FIDELIA\",\"EVITA\",\"EURA\",\"EULAH\",\"ESTEFANA\",\"ELSY\",\"ELIZABET\",\"ELADIA\",\"DODIE\",\"DION\",\"DIA\",\"DENISSE\",\"DELORAS\",\"DELILA\",\"DAYSI\",\"DAKOTA\",\"CURTIS\",\"CRYSTLE\",\"CONCHA\",\"COLBY\",\"CLARETTA\",\"CHU\",\"CHRISTIA\",\"CHARLSIE\",\"CHARLENA\",\"CARYLON\",\"BETTYANN\",\"ASLEY\",\"ASHLEA\",\"AMIRA\",\"AI\",\"AGUEDA\",\"AGNUS\",\"YUETTE\",\"VINITA\",\"VICTORINA\",\"TYNISHA\",\"TREENA\",\"TOCCARA\",\"TISH\",\"THOMASENA\",\"TEGAN\",\"SOILA\",\"SHILOH\",\"SHENNA\",\"SHARMAINE\",\"SHANTAE\",\"SHANDI\",\"SEPTEMBER\",\"SARAN\",\"SARAI\",\"SANA\",\"SAMUEL\",\"SALLEY\",\"ROSETTE\",\"ROLANDE\",\"REGINE\",\"OTELIA\",\"OSCAR\",\"OLEVIA\",\"NICHOLLE\",\"NECOLE\",\"NAIDA\",\"MYRTA\",\"MYESHA\",\"MITSUE\",\"MINTA\",\"MERTIE\",\"MARGY\",\"MAHALIA\",\"MADALENE\",\"LOVE\",\"LOURA\",\"LOREAN\",\"LEWIS\",\"LESHA\",\"LEONIDA\",\"LENITA\",\"LAVONE\",\"LASHELL\",\"LASHANDRA\",\"LAMONICA\",\"KIMBRA\",\"KATHERINA\",\"KARRY\",\"KANESHA\",\"JULIO\",\"JONG\",\"JENEVA\",\"JAQUELYN\",\"HWA\",\"GILMA\",\"GHISLAINE\",\"GERTRUDIS\",\"FRANSISCA\",\"FERMINA\",\"ETTIE\",\"ETSUKO\",\"ELLIS\",\"ELLAN\",\"ELIDIA\",\"EDRA\",\"DORETHEA\",\"DOREATHA\",\"DENYSE\",\"DENNY\",\"DEETTA\",\"DAINE\",\"CYRSTAL\",\"CORRIN\",\"CAYLA\",\"CARLITA\",\"CAMILA\",\"BURMA\",\"BULA\",\"BUENA\",\"BLAKE\",\"BARABARA\",\"AVRIL\",\"AUSTIN\",\"ALAINE\",\"ZANA\",\"WILHEMINA\",\"WANETTA\",\"VIRGIL\",\"VI\",\"VERONIKA\",\"VERNON\",\"VERLINE\",\"VASILIKI\",\"TONITA\",\"TISA\",\"TEOFILA\",\"TAYNA\",\"TAUNYA\",\"TANDRA\",\"TAKAKO\",\"SUNNI\",\"SUANNE\",\"SIXTA\",\"SHARELL\",\"SEEMA\",\"RUSSELL\",\"ROSENDA\",\"ROBENA\",\"RAYMONDE\",\"PEI\",\"PAMILA\",\"OZELL\",\"NEIDA\",\"NEELY\",\"MISTIE\",\"MICHA\",\"MERISSA\",\"MAURITA\",\"MARYLN\",\"MARYETTA\",\"MARSHALL\",\"MARCELL\",\"MALENA\",\"MAKEDA\",\"MADDIE\",\"LOVETTA\",\"LOURIE\",\"LORRINE\",\"LORILEE\",\"LESTER\",\"LAURENA\",\"LASHAY\",\"LARRAINE\",\"LAREE\",\"LACRESHA\",\"KRISTLE\",\"KRISHNA\",\"KEVA\",\"KEIRA\",\"KAROLE\",\"JOIE\",\"JINNY\",\"JEANNETTA\",\"JAMA\",\"HEIDY\",\"GILBERTE\",\"GEMA\",\"FAVIOLA\",\"EVELYNN\",\"ENDA\",\"ELLI\",\"ELLENA\",\"DIVINA\",\"DAGNY\",\"COLLENE\",\"CODI\",\"CINDIE\",\"CHASSIDY\",\"CHASIDY\",\"CATRICE\",\"CATHERINA\",\"CASSEY\",\"CAROLL\",\"CARLENA\",\"CANDRA\",\"CALISTA\",\"BRYANNA\",\"BRITTENY\",\"BEULA\",\"BARI\",\"AUDRIE\",\"AUDRIA\",\"ARDELIA\",\"ANNELLE\",\"ANGILA\",\"ALONA\",\"ALLYN\",\"DOUGLAS\",\"ROGER\",\"JONATHAN\",\"RALPH\",\"NICHOLAS\",\"BENJAMIN\",\"BRUCE\",\"HARRY\",\"WAYNE\",\"STEVE\",\"HOWARD\",\"ERNEST\",\"PHILLIP\",\"TODD\",\"CRAIG\",\"ALAN\",\"PHILIP\",\"EARL\",\"DANNY\",\"BRYAN\",\"STANLEY\",\"LEONARD\",\"NATHAN\",\"MANUEL\",\"RODNEY\",\"MARVIN\",\"VINCENT\",\"JEFFERY\",\"JEFF\",\"CHAD\",\"JACOB\",\"ALFRED\",\"BRADLEY\",\"HERBERT\",\"FREDERICK\",\"EDWIN\",\"DON\",\"RICKY\",\"RANDALL\",\"BARRY\",\"BERNARD\",\"LEROY\",\"MARCUS\",\"THEODORE\",\"CLIFFORD\",\"MIGUEL\",\"JIM\",\"TOM\",\"CALVIN\",\"BILL\",\"LLOYD\",\"DEREK\",\"WARREN\",\"DARRELL\",\"JEROME\",\"FLOYD\",\"ALVIN\",\"TIM\",\"GORDON\",\"GREG\",\"JORGE\",\"DUSTIN\",\"PEDRO\",\"DERRICK\",\"ZACHARY\",\"HERMAN\",\"GLEN\",\"HECTOR\",\"RICARDO\",\"RICK\",\"BRENT\",\"RAMON\",\"GILBERT\",\"MARC\",\"REGINALD\",\"RUBEN\",\"NATHANIEL\",\"RAFAEL\",\"EDGAR\",\"MILTON\",\"RAUL\",\"BEN\",\"CHESTER\",\"DUANE\",\"FRANKLIN\",\"BRAD\",\"RON\",\"ROLAND\",\"ARNOLD\",\"HARVEY\",\"JARED\",\"ERIK\",\"DARRYL\",\"NEIL\",\"JAVIER\",\"FERNANDO\",\"CLINTON\",\"TED\",\"MATHEW\",\"TYRONE\",\"DARREN\",\"LANCE\",\"KURT\",\"ALLAN\",\"NELSON\",\"GUY\",\"CLAYTON\",\"HUGH\",\"MAX\",\"DWAYNE\",\"DWIGHT\",\"ARMANDO\",\"FELIX\",\"EVERETT\",\"IAN\",\"WALLACE\",\"KEN\",\"BOB\",\"ALFREDO\",\"ALBERTO\",\"DAVE\",\"IVAN\",\"BYRON\",\"ISAAC\",\"MORRIS\",\"CLIFTON\",\"WILLARD\",\"ROSS\",\"ANDY\",\"SALVADOR\",\"KIRK\",\"SERGIO\",\"SETH\",\"KENT\",\"TERRANCE\",\"EDUARDO\",\"TERRENCE\",\"ENRIQUE\",\"WADE\",\"STUART\",\"FREDRICK\",\"ARTURO\",\"ALEJANDRO\",\"NICK\",\"LUTHER\",\"WENDELL\",\"JEREMIAH\",\"JULIUS\",\"OTIS\",\"TREVOR\",\"OLIVER\",\"LUKE\",\"HOMER\",\"GERARD\",\"DOUG\",\"KENNY\",\"HUBERT\",\"LYLE\",\"MATT\",\"ALFONSO\",\"ORLANDO\",\"REX\",\"CARLTON\",\"ERNESTO\",\"NEAL\",\"PABLO\",\"LORENZO\",\"OMAR\",\"WILBUR\",\"GRANT\",\"HORACE\",\"RODERICK\",\"ABRAHAM\",\"WILLIS\",\"RICKEY\",\"ANDRES\",\"CESAR\",\"JOHNATHAN\",\"MALCOLM\",\"RUDOLPH\",\"DAMON\",\"KELVIN\",\"PRESTON\",\"ALTON\",\"ARCHIE\",\"MARCO\",\"WM\",\"PETE\",\"RANDOLPH\",\"GARRY\",\"GEOFFREY\",\"JONATHON\",\"FELIPE\",\"GERARDO\",\"ED\",\"DOMINIC\",\"DELBERT\",\"COLIN\",\"GUILLERMO\",\"EARNEST\",\"LUCAS\",\"BENNY\",\"SPENCER\",\"RODOLFO\",\"MYRON\",\"EDMUND\",\"GARRETT\",\"SALVATORE\",\"CEDRIC\",\"LOWELL\",\"GREGG\",\"SHERMAN\",\"WILSON\",\"SYLVESTER\",\"ROOSEVELT\",\"ISRAEL\",\"JERMAINE\",\"FORREST\",\"WILBERT\",\"LELAND\",\"SIMON\",\"CLARK\",\"IRVING\",\"BRYANT\",\"OWEN\",\"RUFUS\",\"WOODROW\",\"KRISTOPHER\",\"MACK\",\"LEVI\",\"MARCOS\",\"GUSTAVO\",\"JAKE\",\"LIONEL\",\"GILBERTO\",\"CLINT\",\"NICOLAS\",\"ISMAEL\",\"ORVILLE\",\"ERVIN\",\"DEWEY\",\"AL\",\"WILFRED\",\"JOSH\",\"HUGO\",\"IGNACIO\",\"CALEB\",\"TOMAS\",\"SHELDON\",\"ERICK\",\"STEWART\",\"DOYLE\",\"DARREL\",\"ROGELIO\",\"TERENCE\",\"SANTIAGO\",\"ALONZO\",\"ELIAS\",\"BERT\",\"ELBERT\",\"RAMIRO\",\"CONRAD\",\"NOAH\",\"GRADY\",\"PHIL\",\"CORNELIUS\",\"LAMAR\",\"ROLANDO\",\"CLAY\",\"PERCY\",\"DEXTER\",\"BRADFORD\",\"DARIN\",\"AMOS\",\"MOSES\",\"IRVIN\",\"SAUL\",\"ROMAN\",\"RANDAL\",\"TIMMY\",\"DARRIN\",\"WINSTON\",\"BRENDAN\",\"ABEL\",\"DOMINICK\",\"BOYD\",\"EMILIO\",\"ELIJAH\",\"DOMINGO\",\"EMMETT\",\"MARLON\",\"EMANUEL\",\"JERALD\",\"EDMOND\",\"EMIL\",\"DEWAYNE\",\"WILL\",\"OTTO\",\"TEDDY\",\"REYNALDO\",\"BRET\",\"JESS\",\"TRENT\",\"HUMBERTO\",\"EMMANUEL\",\"STEPHAN\",\"VICENTE\",\"LAMONT\",\"GARLAND\",\"MILES\",\"EFRAIN\",\"HEATH\",\"RODGER\",\"HARLEY\",\"ETHAN\",\"ELDON\",\"ROCKY\",\"PIERRE\",\"JUNIOR\",\"FREDDY\",\"ELI\",\"BRYCE\",\"ANTOINE\",\"STERLING\",\"CHASE\",\"GROVER\",\"ELTON\",\"CLEVELAND\",\"DYLAN\",\"CHUCK\",\"DAMIAN\",\"REUBEN\",\"STAN\",\"AUGUST\",\"LEONARDO\",\"JASPER\",\"RUSSEL\",\"ERWIN\",\"BENITO\",\"HANS\",\"MONTE\",\"BLAINE\",\"ERNIE\",\"CURT\",\"QUENTIN\",\"AGUSTIN\",\"MURRAY\",\"JAMAL\",\"ADOLFO\",\"HARRISON\",\"TYSON\",\"BURTON\",\"BRADY\",\"ELLIOTT\",\"WILFREDO\",\"BART\",\"JARROD\",\"VANCE\",\"DENIS\",\"DAMIEN\",\"JOAQUIN\",\"HARLAN\",\"DESMOND\",\"ELLIOT\",\"DARWIN\",\"GREGORIO\",\"BUDDY\",\"XAVIER\",\"KERMIT\",\"ROSCOE\",\"ESTEBAN\",\"ANTON\",\"SOLOMON\",\"SCOTTY\",\"NORBERT\",\"ELVIN\",\"WILLIAMS\",\"NOLAN\",\"ROD\",\"QUINTON\",\"HAL\",\"BRAIN\",\"ROB\",\"ELWOOD\",\"KENDRICK\",\"DARIUS\",\"MOISES\",\"FIDEL\",\"THADDEUS\",\"CLIFF\",\"MARCEL\",\"JACKSON\",\"RAPHAEL\",\"BRYON\",\"ARMAND\",\"ALVARO\",\"JEFFRY\",\"DANE\",\"JOESPH\",\"THURMAN\",\"NED\",\"RUSTY\",\"MONTY\",\"FABIAN\",\"REGGIE\",\"MASON\",\"GRAHAM\",\"ISAIAH\",\"VAUGHN\",\"GUS\",\"LOYD\",\"DIEGO\",\"ADOLPH\",\"NORRIS\",\"MILLARD\",\"ROCCO\",\"GONZALO\",\"DERICK\",\"RODRIGO\",\"WILEY\",\"RIGOBERTO\",\"ALPHONSO\",\"TY\",\"NOE\",\"VERN\",\"REED\",\"JEFFERSON\",\"ELVIS\",\"BERNARDO\",\"MAURICIO\",\"HIRAM\",\"DONOVAN\",\"BASIL\",\"RILEY\",\"NICKOLAS\",\"MAYNARD\",\"SCOT\",\"VINCE\",\"QUINCY\",\"EDDY\",\"SEBASTIAN\",\"FEDERICO\",\"ULYSSES\",\"HERIBERTO\",\"DONNELL\",\"COLE\",\"DAVIS\",\"GAVIN\",\"EMERY\",\"WARD\",\"ROMEO\",\"JAYSON\",\"DANTE\",\"CLEMENT\",\"COY\",\"MAXWELL\",\"JARVIS\",\"BRUNO\",\"ISSAC\",\"DUDLEY\",\"BROCK\",\"SANFORD\",\"CARMELO\",\"BARNEY\",\"NESTOR\",\"STEFAN\",\"DONNY\",\"ART\",\"LINWOOD\",\"BEAU\",\"WELDON\",\"GALEN\",\"ISIDRO\",\"TRUMAN\",\"DELMAR\",\"JOHNATHON\",\"SILAS\",\"FREDERIC\",\"DICK\",\"IRWIN\",\"MERLIN\",\"CHARLEY\",\"MARCELINO\",\"HARRIS\",\"CARLO\",\"TRENTON\",\"KURTIS\",\"HUNTER\",\"AURELIO\",\"WINFRED\",\"VITO\",\"COLLIN\",\"DENVER\",\"CARTER\",\"LEONEL\",\"EMORY\",\"PASQUALE\",\"MOHAMMAD\",\"MARIANO\",\"DANIAL\",\"LANDON\",\"DIRK\",\"BRANDEN\",\"ADAN\",\"BUFORD\",\"GERMAN\",\"WILMER\",\"EMERSON\",\"ZACHERY\",\"FLETCHER\",\"JACQUES\",\"ERROL\",\"DALTON\",\"MONROE\",\"JOSUE\",\"EDWARDO\",\"BOOKER\",\"WILFORD\",\"SONNY\",\"SHELTON\",\"CARSON\",\"THERON\",\"RAYMUNDO\",\"DAREN\",\"HOUSTON\",\"ROBBY\",\"LINCOLN\",\"GENARO\",\"BENNETT\",\"OCTAVIO\",\"CORNELL\",\"HUNG\",\"ARRON\",\"ANTONY\",\"HERSCHEL\",\"GIOVANNI\",\"GARTH\",\"CYRUS\",\"CYRIL\",\"RONNY\",\"LON\",\"FREEMAN\",\"DUNCAN\",\"KENNITH\",\"CARMINE\",\"ERICH\",\"CHADWICK\",\"WILBURN\",\"RUSS\",\"REID\",\"MYLES\",\"ANDERSON\",\"MORTON\",\"JONAS\",\"FOREST\",\"MITCHEL\",\"MERVIN\",\"ZANE\",\"RICH\",\"JAMEL\",\"LAZARO\",\"ALPHONSE\",\"RANDELL\",\"MAJOR\",\"JARRETT\",\"BROOKS\",\"ABDUL\",\"LUCIANO\",\"SEYMOUR\",\"EUGENIO\",\"MOHAMMED\",\"VALENTIN\",\"CHANCE\",\"ARNULFO\",\"LUCIEN\",\"FERDINAND\",\"THAD\",\"EZRA\",\"ALDO\",\"RUBIN\",\"ROYAL\",\"MITCH\",\"EARLE\",\"ABE\",\"WYATT\",\"MARQUIS\",\"LANNY\",\"KAREEM\",\"JAMAR\",\"BORIS\",\"ISIAH\",\"EMILE\",\"ELMO\",\"ARON\",\"LEOPOLDO\",\"EVERETTE\",\"JOSEF\",\"ELOY\",\"RODRICK\",\"REINALDO\",\"LUCIO\",\"JERROD\",\"WESTON\",\"HERSHEL\",\"BARTON\",\"PARKER\",\"LEMUEL\",\"BURT\",\"JULES\",\"GIL\",\"ELISEO\",\"AHMAD\",\"NIGEL\",\"EFREN\",\"ANTWAN\",\"ALDEN\",\"MARGARITO\",\"COLEMAN\",\"DINO\",\"OSVALDO\",\"LES\",\"DEANDRE\",\"NORMAND\",\"KIETH\",\"TREY\",\"NORBERTO\",\"NAPOLEON\",\"JEROLD\",\"FRITZ\",\"ROSENDO\",\"MILFORD\",\"CHRISTOPER\",\"ALFONZO\",\"LYMAN\",\"JOSIAH\",\"BRANT\",\"WILTON\",\"RICO\",\"JAMAAL\",\"DEWITT\",\"BRENTON\",\"OLIN\",\"FOSTER\",\"FAUSTINO\",\"CLAUDIO\",\"JUDSON\",\"GINO\",\"EDGARDO\",\"ALEC\",\"TANNER\",\"JARRED\",\"DONN\",\"TAD\",\"PRINCE\",\"PORFIRIO\",\"ODIS\",\"LENARD\",\"CHAUNCEY\",\"TOD\",\"MEL\",\"MARCELO\",\"KORY\",\"AUGUSTUS\",\"KEVEN\",\"HILARIO\",\"BUD\",\"SAL\",\"ORVAL\",\"MAURO\",\"ZACHARIAH\",\"OLEN\",\"ANIBAL\",\"MILO\",\"JED\",\"DILLON\",\"AMADO\",\"NEWTON\",\"LENNY\",\"RICHIE\",\"HORACIO\",\"BRICE\",\"MOHAMED\",\"DELMER\",\"DARIO\",\"REYES\",\"MAC\",\"JONAH\",\"JERROLD\",\"ROBT\",\"HANK\",\"RUPERT\",\"ROLLAND\",\"KENTON\",\"DAMION\",\"ANTONE\",\"WALDO\",\"FREDRIC\",\"BRADLY\",\"KIP\",\"BURL\",\"WALKER\",\"TYREE\",\"JEFFEREY\",\"AHMED\",\"WILLY\",\"STANFORD\",\"OREN\",\"NOBLE\",\"MOSHE\",\"MIKEL\",\"ENOCH\",\"BRENDON\",\"QUINTIN\",\"JAMISON\",\"FLORENCIO\",\"DARRICK\",\"TOBIAS\",\"HASSAN\",\"GIUSEPPE\",\"DEMARCUS\",\"CLETUS\",\"TYRELL\",\"LYNDON\",\"KEENAN\",\"WERNER\",\"GERALDO\",\"COLUMBUS\",\"CHET\",\"BERTRAM\",\"MARKUS\",\"HUEY\",\"HILTON\",\"DWAIN\",\"DONTE\",\"TYRON\",\"OMER\",\"ISAIAS\",\"HIPOLITO\",\"FERMIN\",\"ADALBERTO\",\"BO\",\"BARRETT\",\"TEODORO\",\"MCKINLEY\",\"MAXIMO\",\"GARFIELD\",\"RALEIGH\",\"LAWERENCE\",\"ABRAM\",\"RASHAD\",\"KING\",\"EMMITT\",\"DARON\",\"SAMUAL\",\"MIQUEL\",\"EUSEBIO\",\"DOMENIC\",\"DARRON\",\"BUSTER\",\"WILBER\",\"RENATO\",\"JC\",\"HOYT\",\"HAYWOOD\",\"EZEKIEL\",\"CHAS\",\"FLORENTINO\",\"ELROY\",\"CLEMENTE\",\"ARDEN\",\"NEVILLE\",\"EDISON\",\"DESHAWN\",\"NATHANIAL\",\"JORDON\",\"DANILO\",\"CLAUD\",\"SHERWOOD\",\"RAYMON\",\"RAYFORD\",\"CRISTOBAL\",\"AMBROSE\",\"TITUS\",\"HYMAN\",\"FELTON\",\"EZEQUIEL\",\"ERASMO\",\"STANTON\",\"LONNY\",\"LEN\",\"IKE\",\"MILAN\",\"LINO\",\"JAROD\",\"HERB\",\"ANDREAS\",\"WALTON\",\"RHETT\",\"PALMER\",\"DOUGLASS\",\"CORDELL\",\"OSWALDO\",\"ELLSWORTH\",\"VIRGILIO\",\"TONEY\",\"NATHANAEL\",\"DEL\",\"BENEDICT\",\"MOSE\",\"JOHNSON\",\"ISREAL\",\"GARRET\",\"FAUSTO\",\"ASA\",\"ARLEN\",\"ZACK\",\"WARNER\",\"MODESTO\",\"FRANCESCO\",\"MANUAL\",\"GAYLORD\",\"GASTON\",\"FILIBERTO\",\"DEANGELO\",\"MICHALE\",\"GRANVILLE\",\"WES\",\"MALIK\",\"ZACKARY\",\"TUAN\",\"ELDRIDGE\",\"CRISTOPHER\",\"CORTEZ\",\"ANTIONE\",\"MALCOM\",\"LONG\",\"KOREY\",\"JOSPEH\",\"COLTON\",\"WAYLON\",\"VON\",\"HOSEA\",\"SHAD\",\"SANTO\",\"RUDOLF\",\"ROLF\",\"REY\",\"RENALDO\",\"MARCELLUS\",\"LUCIUS\",\"KRISTOFER\",\"BOYCE\",\"BENTON\",\"HAYDEN\",\"HARLAND\",\"ARNOLDO\",\"RUEBEN\",\"LEANDRO\",\"KRAIG\",\"JERRELL\",\"JEROMY\",\"HOBERT\",\"CEDRICK\",\"ARLIE\",\"WINFORD\",\"WALLY\",\"LUIGI\",\"KENETH\",\"JACINTO\",\"GRAIG\",\"FRANKLYN\",\"EDMUNDO\",\"SID\",\"PORTER\",\"LEIF\",\"JERAMY\",\"BUCK\",\"WILLIAN\",\"VINCENZO\",\"SHON\",\"LYNWOOD\",\"JERE\",\"HAI\",\"ELDEN\",\"DORSEY\",\"DARELL\",\"BRODERICK\",\"ALONSO\"";
        string[] allNamesArray = allNamesString.Replace("\"", "").Split(',').OrderBy(a => a).ToArray();
        // Also - define a character array with an English alphabet, which we will reference to get the position of any given character.
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // Also, we will utilize two dictionaries:
        // Both will store names, sorted alphabetically as their KEYS, however:
        //      First will simply store names' position as its VALUE.
        //      Second dictionary will store each names' alphabetical value as its VALUE. (It will be calculated for each word)
        var alphabeticalPosition = new Dictionary<string, int>();
        var alphabeticalValue = new Dictionary<string, int>();

        // Since our 'All names' variable is an already alphabetically sorted array, we can simply iterate over it, and add entries to both dictionary with proper VALUES.
        for (int i = 0; i < allNamesArray.Length; i++)
        {
            // Add current word as the KEY, and its position plus one, as the VALUE to the Positions dictionary.
            alphabeticalPosition.Add(allNamesArray[i], i + 1);

            // Initialize a variable to hold the alphabetic value of a given word.
            var valueOfWord = 0;
            // Iterate over the word's length, and calculate its alphabetic value - we do this by summing the value of each individual characters' index in the alphabet plus one
            for (int j = 0; j < allNamesArray[i].Length; j++)
                valueOfWord += alphabet.IndexOf(allNamesArray[i][j]) + 1;

            // Add current words as the KEY, and its alphabetic value as the VALUE to the 'Values' dictionary.
            alphabeticalValue.Add(allNamesArray[i], valueOfWord);
        }

        // Initialize a variable to hold the total name scores' value.
        var totalNameScores = 0;
        // Iterate over either of the dictionaries, since they are both same length, and sum the product of multiplication of VALUES of same indexed element from both dictionaries.
        for (int i = 0; i < alphabeticalPosition.Count; i++)
            totalNameScores += alphabeticalPosition.ElementAt(i).Value * alphabeticalValue.ElementAt(i).Value;

        // Display the results to the console window
        Console.WriteLine($"Total value of all names is equal to {totalNameScores}");
        return totalNameScores;
    }
}