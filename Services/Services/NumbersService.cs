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
}