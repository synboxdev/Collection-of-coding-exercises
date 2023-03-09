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
}