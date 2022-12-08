using Services.Interfaces;
using System;

namespace Services;

public class NumbersService : INumbersService
{
    /// <summary>
    /// A prime number (or a prime) is a natural number greater than 1 that is not a product (result of multiplication) of two smaller natural numbers.
    /// </summary>
    public bool CheckIfNumberIsPrime(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number between 1 and 100");
        number = (number == null || number <= 0) ? Random.Shared.Next(1, 100) : number;
        Console.WriteLine($"Checking whether number {number} is prime or not");

        // Create a integer iterator variable which we will be using as a incrementing divider, to check whether number and interator division leaves a remainder of zero.
        int i;
        for (i = 2; i <= number - 1; i++)   // We iterate from starting from 2, since its the first prime number, all the way up to our number minus one, because of conditional check after the loop.
        {
            if (number % i == 0)            // If the remainder of the division of our number, and the iterator is equal to zero, be break out of the loop, since that mean number is divisible by some other variable besides 1 and itself.
                break;
        }
        if (i == number)                    // If iterator and our number are equal, that means the numbers is indeed a prime number. Meaning - we've iterated over every single number from 2 up to our numbers minus one, and haven't found a single iterator that would divide our number leaving a remainder of zero.
        {
            Console.WriteLine($"Number {number} is a prime number!");
            return true;
        }
        Console.WriteLine($"Number {number} is NOT a prime number!");
        return false;
    }

    public int FindSumOfDigitsOfAPositiveNumber(int number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number between 1 and 100");
        number = number <= 0 ? Random.Shared.Next(1, 100) : number;
        Console.WriteLine($"Finding the sum of digits of {number}");

        int sumOfDigits = 0;                    // Variable to hold the total sum of digits.
        while (number != 0)                     // While our number, which we're dividing each iteration is above zero, continue iterating.
        {
            sumOfDigits += number % 10;         // Add the remaider of number being divided by 10. For example 18 / 10 has remainder of 8. That means we add 8 to our sum of digits.
            number /= 10;                       // Divide our remaining number by 10. Because its integer, it rounds up. So 8 / 10 = .8, and after rounding its = 1. Next iteration 1 / 10 = .1, and after rounding its equal to zero, and our loop ends.
        }

        Console.WriteLine($"Sum of all digits in the input number is equal to {sumOfDigits}");
        return sumOfDigits;
    }

    public int FindSumOfDigitsOfAPositiveNumberParsingThroughEveryDigit(int number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number between 1 and 100");
        number = number <= 0 ? Random.Shared.Next(1, 100) : number;
        Console.WriteLine($"Finding the sum of digits of {number}");

        int sumOfDigits = 0;                                    // Variable to hold the total sum of digits.
        foreach (char digit in number.ToString())               // Iterate through every digit, after converting our input number to a string type.
            sumOfDigits += (int)char.GetNumericValue(digit);    // Get the numeric value of our char, and add it as a integer variable to total sum.

        Console.WriteLine($"Sum of all digits in the input number is equal to {sumOfDigits}");
        return sumOfDigits;
    }

    public int FindSumOfDigitsOfAPositiveNumberUsingLINQ(int number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number between 1 and 100");
        number = number <= 0 ? Random.Shared.Next(1, 100) : number;
        Console.WriteLine($"Finding the sum of digits of {number}");

        // Almost identical solution to the previous one 'FindSumOfDigitsOfAPositiveNumberParsingThroughEveryDigit' but instead of a loop, we make a LINQ one-liner.
        int sumOfDigits = (int)number.ToString().Sum(x => char.GetNumericValue(x));     // Convert our input variable to string, and the utilize LINQ to count sum of all char numeric values.

        Console.WriteLine($"Sum of all digits in the input number is equal to {sumOfDigits}");
        return sumOfDigits;
    }

    /// <summary>
    /// Tidbit of information about Factorials:
    /// As per Wikipedia documentation, found here: https://en.wikipedia.org/wiki/Factorial
    /// Factorial of a non-negative integer n, denoted by n!, is the product of all positive integers less than or equal to n
    /// For example: 5! = 5 * 4! = 5 * 4 * 3 * 2 * 1
    /// </summary>
    public int FindFactorialOfAPositiveNumber(int number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number between 1 and 10");
        number = number <= 0 ? Random.Shared.Next(1, 10) : number;
        Console.WriteLine($"Finding the factorial value of {number}");

        int factorialValue = number;            // Starting value of our factorial will be equal to the provided input integer.
        for (int i = number - 1; i >= 1; i--)   // Iterate from the starting input integer value, all the way down to 1.
            factorialValue *= i;                // Multiply our compounding factorial value variable by the loop iterator.

        Console.WriteLine($"Factorial value of input number is equal to {factorialValue}");
        return factorialValue;
    }

    /// <summary>
    /// Tidbit of information about Recursion:
    /// Recursive function is a function that calls itself until a “base condition” is true, and execution stops.
    /// Read more here: https://en.wikipedia.org/wiki/Recursion#In_computer_science
    /// </summary>
    public int? FindFactorialOfAPositiveNumberUsingRecursion(int? number, int? factorialValue)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        if (number == null || number <= 0)  // Since our method parameters are nullable, we intialize their initial values, and we're sure they wont be null when recursion recalls this method again.
        {
            Console.WriteLine("Picking a random number between 1 and 10");
            number = (number == null || number <= 0) ? Random.Shared.Next(1, 10) : number;
            Console.WriteLine($"Finding the factorial value of {number}");
            factorialValue = number;    // Starting value of our factorial will be equal to the provided input integer.
        }

        number--;   // We subtract from our initial integer BEFORE doing multiplication, to make sure we haven't reached the end, which is 1
        
        if (number == 1)    // If we've reached 1, that means our factorial calculation has come to an end. Display the answer to the console, and return null, so that 'breaks' out of the recursion loop.
        {
            Console.WriteLine($"Factorial value of input number is equal to {factorialValue}");
            return null;
        }
        else
            factorialValue *= number;            // If if condition has not been met - multiple our current factorial value, by number subtracted by one.

        return FindFactorialOfAPositiveNumberUsingRecursion(number, factorialValue);    // Continue calling the same method (itself), until If condition is met and it exits out. Pass our current number and factorial value, since we're continuing the calculation.
    }

    public int FindFactorialOfAPositiveNumberUsingWhileLoop(int number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number between 1 and 10");
        number = number <= 0 ? Random.Shared.Next(1, 10) : number;
        Console.WriteLine($"Finding the factorial value of {number}");

        int factorialValue = number;            // Starting value of our factorial will be equal to the provided input integer.
        while (true)                     
        {
            number--;                           // Subtract our initial integer by one, to eventually reach while loop's exit condition.
            if (number <= 1) break;             // Our loop's exit condition is once number, which is being subtracted by one every iteration, eventually reaches one or less.
            factorialValue *= number;           // Multiply our compounding factorial value variable by the loop iterator. 
        }

        Console.WriteLine($"Factorial value of input number is equal to {factorialValue}");
        return factorialValue;
    }

    /// <summary>
    /// Tidbit of information about Fibonacci numbers and Fibonacci sequence:
    /// Fibonacci numbers form a sequence - the Fibonacci sequence, in which each number is the sum of the two preceding ones.
    /// The sequence commonly starts from 0 and 1, although some authors start the sequence from 1 and 1 or sometimes (as did Fibonacci) from 1 and 2.
    /// Read more here: https://en.wikipedia.org/wiki/Fibonacci_number
    /// </summary>
    public int FibonacciSeriesCalculationAndDisplay(int numberOfElements)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number of elements, to display the Fibonacci sequence for between 2 and 20");
        numberOfElements = numberOfElements < 2 ? Random.Shared.Next(2, 20) : numberOfElements;
        Console.WriteLine($"Calculating and displaying Fibonacci series for {numberOfElements + 1} elements");

        int firstNumber = 0;                             // We initialize the first two values of our Fibonacci sequence which are 0 and 1, and add them to our list of integer elements.
        int secondNumber = 1;                            
        List<int> fibonacciSequence =                    
            new List<int> { firstNumber, secondNumber }; 
                                                         
        for (int i = 2; i <= numberOfElements; i++)      // Iterate from 2 (Since we've already added the first two values), all the way to the input number of elements.
        {
            var nextNumber = firstNumber + secondNumber; // Value of the next element in the sequence, is the addition of previous two.
            firstNumber = secondNumber;                  // Then - our first number gets value of the second one..
            secondNumber = nextNumber;                   // .. and our second number gets value of next number's (the one that was just calculated) value.
            fibonacciSequence.Add(nextNumber);           // And then - we add newly calculated number to the list.
        }

        // Display our full Fibonacci sequence to console output. Reason for + 1 of elements, is because list indexing starts from zero, so for visual representation, we make sure to start our sequence from 1st number, and not 0'th
        Console.WriteLine($"Displaying Fibonacci sequence elements for {numberOfElements + 1} elements:");
        fibonacciSequence.ForEach(element => Console.WriteLine($"#{fibonacciSequence.IndexOf(element) + 1}\t{element}"));

        return fibonacciSequence.Last();    // Return the last element value of our Fibonacci sequence. (For Unit tests)
    }

    public int? FibonacciSeriesCalculationAndDisplayUsingRecursion(int? firstNumber, int? secondNumber, int? numberOfElements, int counter)
    {
        if (firstNumber == null || secondNumber == null || numberOfElements == null)        // On the first method call, our values are null, so this method in only called once.
        {
            numberOfElements = (numberOfElements == null || numberOfElements < 2) ? Random.Shared.Next(2, 10) : numberOfElements;
            Console.WriteLine($"Displaying Fibonacci sequence elements for {numberOfElements} elements:");
            FibonacciSeriesCalculationAndDisplayUsingRecursion(0, 1, numberOfElements, 1);  // Call the same method with the initial values, providing the first number's and second number's initial values.
        }
        else if (counter <= numberOfElements)   // Until the counter, which indicates which number we're currently on reaches a total number of elements we want to display Fibonacci sequence for.
        {
            Console.WriteLine($"#{counter}\t{firstNumber}");
            FibonacciSeriesCalculationAndDisplayUsingRecursion(secondNumber, firstNumber + secondNumber, numberOfElements, counter + 1);    // Call this method recursively, until 'else if' condition is met.
        }
        else return null;   // Break out of the recursion, when counter reaches the number of the elements.
        return null;
    }
}