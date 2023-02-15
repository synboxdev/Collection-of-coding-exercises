using Data.Utility;
using Services.Interfaces;

namespace Services;

public class NumbersService : INumbersService
{
    /// <summary>
    /// A prime number (or a prime) is a natural number greater than 1 that is not a product (result of multiplication) of two smaller natural numbers.
    /// </summary>
    public bool CheckIfNumberIsPrime(int? number, bool muteConsoleOutput)
    {
        // Since this method is sometimes utilized by other solutions, I've modified it, to accept a boolean variable that will mute the Console output, when all we need is simply the boolean output of the method.
        TextWriter tw = Console.Out;
        if (muteConsoleOutput)
            Console.SetOut(TextWriter.Null);

        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number between 1 and 100");
        number = (number == null || number <= 0) ? Random.Shared.Next(1, 100) : number;
        Console.WriteLine($"Checking whether number {number} is prime or not");

        // Create a integer iterator variable which we will be using as a incrementing divider, to check whether number and iterator division leaves a remainder of zero.
        int i;
        bool IsNumberPrime = false;
        for (i = 2; i <= number - 1; i++)   // We iterate from starting from 2, since its the first prime number, all the way up to our number minus one, because of conditional check after the loop.
        {
            if (number % i == 0)            // If the remainder of the division of our number, and the iterator is equal to zero, be break out of the loop, since that mean number is divisible by some other variable besides 1 and itself.
                break;
        }
        if (i == number)                    // If iterator and our number are equal, that means the numbers is indeed a prime number. Meaning - we've iterated over every single number from 2 up to our numbers minus one, and haven't found a single iterator that would divide our number leaving a remainder of zero.
            IsNumberPrime = !IsNumberPrime;

        Console.WriteLine($"Our input number {(IsNumberPrime ? "is" : "is NOT")} a Prime number!");
        Console.SetOut(tw);                 // 'Unmute' the Console window output.
        return IsNumberPrime;
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
            sumOfDigits += number % 10;         // Add the remainder of number being divided by 10. For example 18 / 10 has remainder of 8. That means we add 8 to our sum of digits.
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
        if (number == null || number <= 0)  // Since our method parameters are nullable, we initialize their initial values, and we're sure they wont be null when recursion recalls this method again.
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
            factorialValue *= number;            // If condition has not been met - multiple our current factorial value, by number subtracted by one.

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

    /// <summary>
    /// Tidbit of information about Armstrong (or also known as Narcissistic number)
    /// In number theory, a narcissistic number in a given number base b is a number that is the sum of its own digits each raised to the power of the number of digits.
    /// Read more here: https://en.wikipedia.org/wiki/Narcissistic_number
    /// </summary>
    public bool CheckIfNumberIsArmstrong(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number of elements, to check whether its an Armstrong number or not.");
        number = (number == null || number <= 0) ? Random.Shared.Next(1, 1000) : number;
        Console.WriteLine($"Checking whether number {number} is Armstrong or not");

        bool isNumberArmstrong = false;                 // A boolean variable that will be determine whether sum of cubes is equal to our input number.
        int sumOfCubes = 0;                             // Variable to hold our sum of cubic values of each digit of out input string.
        foreach (var num in number.ToString())          // Convert our input variable to a string type, so that we can iterate over every single digit in our input number
        {
            int n = (int)char.GetNumericValue(num);     // Get the numeric value out of a digit (which is converted to char type when iterating over a string)
            sumOfCubes += n * n * n;                    // Add a cubic multiplication value of the digit to the total sum of cubes. 
        }

        isNumberArmstrong = sumOfCubes == number ? true : false;    // If our sum of cubes (Each digit being raised to the power of three) is equal to the input number value, our input number is, in fact, an Armstrong number!
        Console.WriteLine($"Number {number} is{(isNumberArmstrong ? string.Empty : " NOT")} an Armstrong number!");

        return isNumberArmstrong;
    }

    public bool CheckIfNumberIsArmstrongUsingRemainder(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number of elements, to check whether its an Armstrong number or not.");
        number = (number == null || number <= 0) ? Random.Shared.Next(1, 1000) : number;
        Console.WriteLine($"Checking whether number {number} is Armstrong or not");

        bool isNumberArmstrong = false;                 // A boolean variable that will be determine whether sum of cubes is equal to our input number.
        int sumOfCubes = 0;                             // Variable to hold our sum of cubic values of each digit of out input string.

        for (int i = (int)number; i > 0; i /= 10)            // Iteration loop start from our input number, until it reaches zero. Each iteration is divided out of 10.
        {
            int remainder = i % 10;                          // Remainder, as you might have guessed, is the remaining value after division of 10, of our loop iterator, which start of, being equal to our input number.
            sumOfCubes += remainder * remainder * remainder; // Add a cubic multiplication value of the digit to the total sum of cubes.
        }
        // So, for example:
        // First iteration if our number is 371, its remainder after division of 10 is 1. 1^3 = 1
        // Next iteration, 371 / 10 = 37.1, which then rounds up to 37 because i is integer type, its remainder after division of 10 is 7. 7^3 = 343
        // Next iteration (our last one), 37 / 10 = 3 (Because i is integer type), its remainder after division is 3 (because it cant divide out of 10, the remainder is the entire number 3. 3^3 = 27
        // Sum of cubes is 1 + 343 + 27 = 371, which is exactly our input number.

        isNumberArmstrong = sumOfCubes == number ? true : false;    // If our sum of cubes (Each digit being raised to the power of three) is equal to the input number value, our input number is, in fact, an Armstrong number!
        Console.WriteLine($"Number {number} is{(isNumberArmstrong ? string.Empty : " NOT")} an Armstrong number!");

        return isNumberArmstrong;
    }

    /// <summary>
    /// Palindrome is a word (Or a number, in this case) that has the same spelling from front to back and vice versa
    /// </summary>
    public bool NumberIsPalindrome(int? number)
    {
        // Practically identical solution to what we used in 'StringIsPalindrome' in StringsService. We simply cast our number to a string, and cast the comparing numbers to string, and do equality comparison.
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number of elements, to check whether its a palindrome or not.");
        number = (number == null || number <= 0) ? Random.Shared.Next(1, 1000) : number;
        Console.WriteLine($"Checking whether number {number} is a palindrome or not");

        bool isNumberPalindrome = true;                 // A boolean variable that will be determine whether our input number is a palindrome or not.

        for (int i = 0, j = number.ToString().Length - 1; i < number.ToString().Length / 2; i++, j--)   // Iterate using two variables, from start of the word to the end, and from the end to start, simultaneously.
        {                                                                                               // Explanation of the exit condition - If word has 5 symbols, exit condition triggers once i reaches 3, because there's no reason to check the exact middle of the string, since there's nothing to compare it to.
            if (number.ToString()[i] != number.ToString()[j])                                           // Compare each letter from start and the end, all the way to the very middle of the input string. If at least a single comparison is NOT equal, that means a given string is NOT a palindrome.
            {
                isNumberPalindrome = false;     // If two numbers, both cast as strings, are NOT equal, that means number is NOT a palindrome.
                break;
            }
        }
        Console.WriteLine($"{number} is" + $"{(isNumberPalindrome ? string.Empty : " NOT")}" + " a palindrome!");

        return isNumberPalindrome;
    }

    public bool NumberIsPalindromeUsingRemaider(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number of elements, to check whether its a palindrome or not.");
        number = (number == null || number <= 0) ? Random.Shared.Next(1, 1000) : number;
        Console.WriteLine($"Checking whether number {number} is a palindrome or not");

        bool isNumberPalindrome = true;                 // A boolean variable that will be determine whether our input number is a palindrome or not.
        int temporaryNumber = (int)number;              // We define a few variables, that we'll be using during the solution.
        int remainder, reversedNumber = 0;              // temporaryNumber will start out being equal to our input number, which we'll be continuously dividing, to form a reversed number.
                                                        // remainder variable will be necessary to hold our remaining value after division. Reversed number will be formed during each iteration of the loop, and later on, will be compared to our input number.

        while (temporaryNumber > 0)                             // Iterate until our temporaryNumber becomes equal to zero.
        {
            remainder = temporaryNumber % 10;                   // Remainder is equal to the remaining value after dividing the number out of 10.
            reversedNumber = reversedNumber * 10 + remainder;   // Reversed number will be 'glued' together, by multiplying it from itself, and adding the remainder value.
            temporaryNumber /= 10;                              // Temporary number is divided out of 10, every iteration.
        }
        // For example, if input number is 636, on first iteration reversedNumber is zero, remainder is 8. So 0 * 10 + 6 = 6, Next iteration 6 * 10 + 3 = 63, And last iteration 63 * 10 + 6 = 636.
        if (reversedNumber != number)
            isNumberPalindrome = false;

        Console.WriteLine($"{number} is" + $"{(isNumberPalindrome ? string.Empty : " NOT")}" + " a palindrome!");

        return isNumberPalindrome;
    }

    public int? FindAngleBetweenClockArrows(int hours, int minutes)
    {
        Console.WriteLine("Picking random hour and minutes, to find the angle between the arrows positioned on a clock.");
        hours = hours <= 0 ? Random.Shared.Next(1, 24) : hours;                             // If hour isn't provided, we pick a random number between 1 and 24.
        minutes = minutes <= 0 ? Random.Shared.Next(0, 60) : minutes;                       // If minute isn't provided, we pick a random number between 0 and 60
        Console.WriteLine($"Finding the angle between arrows, when the time is {hours}:" +  // Based on whether hour is above 12, we indicate whether a given time is AM or PM
                            string.Format("{0:00}", minutes) +
                            $"{(hours > 12 ? " PM" : " AM")}");

        float hoursAngle = ((hours - 12) * 30f) + (minutes * .5f);          // Calculate hours angle. First convert time back to 12-hour clock, then multiply it by 30 degrees (because that's how much the arrow moves in a single hour). Also, add the degree that the minutes make up - which is .5 degree for every single minute.
        float minutesAngle = (float)(minutes * 6f);                         // Each individual minute, moves the minute arrow by exactly 6 degrees.

        float angle = hoursAngle > minutesAngle ?                           // Based on which angle is greater - subtract greater value from lower value, and calculate the absolute of it.
                      Math.Abs(hoursAngle - minutesAngle) :
                      Math.Abs(minutesAngle - hoursAngle);
        angle = angle > 180 ? 360 - angle : angle;                          // If the angle is greater than 180 degrees, we subtract it from 360. Which basically means we want to calculate and display the 'smaller' half of the divided angle.

        Console.WriteLine($"Angle between the hour and minute clock arrows is equal to {angle}");
        return (int)angle;
    }

    /// <summary>
    /// Tidbit of information about Factors:
    /// The factor of a number, in math, is a divisor of the given number that divides it completely, without leaving any remainder.
    /// </summary>
    public List<int>? FindFactorsOfANumber(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random positive integer, to find and display all of its factors.");
        number = (number == null || number <= 0) ? Random.Shared.Next(1, 100) : number;
        Console.WriteLine($"Finding all factors of number {number}.");

        List<int>? factors = new List<int>();   // Create a list of integer type, which we'll be using to store a list of factors of a given input number

        for (int i = 1; i <= number; i++)       // Iterate from 1 to the value of our number (So if our number is 20, we loop from 1 to 20, increasing iterator i by one, each iteration). 
            if (number % i == 0)                // If our number, divides out of iterator i, and leaves a remainder of 0, that means its a factor of our number, so we add it to the list.
                factors.Add(i);

        Console.WriteLine($"Factors of our number {number} are the following:");    // Print out all the factors that we've found to the console window.
        factors.ForEach(Console.WriteLine);

        return factors;
    }

    /// <summary>
    /// Tidbit of information about Fizz buzz word game:
    /// Fizz buzz is a group word game for children to teach them about division. Fizz buzz (often spelled FizzBuzz in this context) has been used as an interview screening device for computer programmers.
    /// Read more here: https://en.wikipedia.org/wiki/Fizz_buzz
    /// </summary>
    public int? FizzBuzzWordGame(int? lastNumber)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Playing out the FizzBuzz word game, starting from 1, all the way to a randomly selected, positive integer.");
        lastNumber = (lastNumber == null || lastNumber <= 0) ? Random.Shared.Next(1, 100) : lastNumber;
        Console.WriteLine($"Fizz Buzz game starts, playing until number {lastNumber} is reached.");

        for (int i = 1; i <= lastNumber; i++)   // Iterate starting from 1 all the way to the last number. 
        {
            // For the conditions that print out a text, instead of a number, we'll print out number in brackets for easier understanding.
            string whatToDisplay = (i % 3 == 0) && (i % 5 == 0) ? $"FizzBuzz ({i})" :   // If the number is divisible by both 3 and 5 - display 'FizzBuzz'
                                   (i % 3 == 0) ? $"Fizz ({i})" :                       // If the number is divisible only by 3 - display 'Fizz'
                                   (i % 5 == 0) ? $"Buzz ({i})" :                       // If the number is divisible only by 5 - display 'Buzz'
                                   i.ToString();                                        // If none of the above conditions are met - display the number itself.

            Console.WriteLine(whatToDisplay);
        }

        Console.WriteLine("Fizz Buzz game has finished!");
        return lastNumber;
    }

    /// <summary>
    /// This is one of rare exceptions where we utilize a previously created function/solution - in this case, its simply calling to check whether a given positive integer number is Prime or not.
    /// A prime number is BALANCED if it is equidistant from the prime before it and the prime after it. It is therefore the arithmetic mean of those primes. For example, 5 is a balanced prime, two units away from 3, and two from 7.
    /// A prime that is greater than the arithmetic mean of the primes before and after it is called a strong prime. It is closer to the prime after it than the one before it. For example, the strong prime 17 is closer to 19 than it is to 13
    /// A prime that is lesser than the arithmetic mean of the primes before and after it is called weak prime. For example, 19.
    /// </summary>
    public string? PrimeNumberStrength(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        number = (number == null || number <= 0) ? Random.Shared.Next(10, 200) : number;
        Console.WriteLine($"Will be determining strength of our selected number {number}");

        // Utilize our previously created solution to get a boolean value whether a given variable is PRIME or not.
        if (!CheckIfNumberIsPrime(number, true))
        {
            Console.WriteLine("Randomly selected number happens to NOT be PRIME number itself, therefor we can't determine its strength");
            return null;
        }

        // If our selected input variable is indeed a PRIME number - we can proceed with the solution.
        // First we must find the closest previous, and closest next primes, and calculate the distance to both, from our input number.
        int closestPreviousPrime = (int)number;
        for (int i = closestPreviousPrime - 1; i >= 2; i--)     // Iterate from our input number, to 2, check whether a given iterator i happens to be a PRIME number or not - if so, assign its value to our closestPreviousPrime variable, and break out of the loop.
        {
            if (!CheckIfNumberIsPrime(i, true))
                continue;
            else
            {
                closestPreviousPrime = i;
                break;
            }
        }
        Console.WriteLine($"Closest previous prime to our number is {closestPreviousPrime}");

        // Next loop - we will be determining the next, closest prime number, starting from our current prime number.
        int closestNextPrime = (int)number + 1;
        for (int i = 2; i < closestNextPrime; i++)  // Iterate from 2 to our current prime number - if its remainder after division of i is equal to zero - increase our closestNextPrime by one, and reset iterator back to 2.
        {
            if (closestNextPrime % i == 0)
            {
                closestNextPrime++;
                i = 2;
            }
        }
        Console.WriteLine($"Closest next prime to our number is {closestNextPrime}");

        // Calculate the distance (non-negative) to both of our closest primes.
        double distanceToPrevious = Math.Abs((double)number - closestPreviousPrime);
        double distanceToNext = Math.Abs((double)number - closestNextPrime);

        // Based on whether our current number is closer to previous or next prime - its either WEAK or STRONG, accordingly. If distance to both is equal (For example prime 5 is same distance(2) to previous prime 3 and next prime 7)
        if (distanceToPrevious == distanceToNext)
        {
            Console.WriteLine($"Distance to BOTH nearest primes is the same ({distanceToNext}). That means our selected prime number {number} is BALANCED!");
            return "Balanced";
        }
        else if (distanceToPrevious < distanceToNext)
        {
            Console.WriteLine($"Distance to previous prime is smaller ({distanceToPrevious}) than the distance to next ({distanceToNext}) prime. That means our selected prime number {number} is WEAK!");
            return "Weak";
        }
        else if (distanceToPrevious > distanceToNext)
        {
            Console.WriteLine($"Distance to next prime is smaller ({distanceToNext}) than the distance to our previous prime ({distanceToPrevious}). That means our selected prime number {number} is STRONG!");
            return "Strong";
        }

        return null;
    }

    /// <summary>
    /// Tidbit of information about Ulam Sequence (Also might be known as Ulam number):
    /// Ulam number is defined to be the smallest integer that is the sum of two distinct earlier terms in exactly one way and larger than all earlier terms.
    /// The standard Ulam sequence (the (1, 2)-Ulam sequence) starts with U1 = 1 and U2 = 2
    /// Read more here: https://en.wikipedia.org/wiki/Ulam_number
    /// </summary>
    public int? FindNthElementOfUlamSequence(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number between 5 and 25, and finding the value of it in Ulam Sequence!");
        number = (number == null || number <= 0) ? Random.Shared.Next(5, 25) : number;
        Console.WriteLine($"Number of our choice is {number}");

        int[] ulamArray = new int[(int)number]; // Initialize an integer type array, size of N. Our N'th element will simply be the last element of this sequence.
        ulamArray[0] = 1;                       // First two element of Ulam Sequence are 1 and 2, so we add them to the array right away.
        ulamArray[1] = 2;
        int startingPoint = 3;                  // Since we have first two elements of our Ulam Sequence, we define starting point from where we will be looking for next element of the sequence. This is our so-called 'Next Potential Element'

        // Continually iterate, until the last element of our array is NOT a zero. (In a newly initialized non-nullable integer array, all element are zero).
        while (ulamArray[ulamArray.Length - 1] == 0)
        {
            int count = 0;                      // Placeholder counter which will iterate once we find a combination of two unique elements whose summed value is equal to our next potential element's value.
            // First loop iterates from 1st element, to second to last element of the first element in the array, whose value is currently 0.
            for (int i = 0; i < Array.IndexOf(ulamArray, ulamArray.FirstOrDefault(x => x == 0)) - 1; i++)
            {
                // Second loop iterates from 2nd element, to exactly the first element in the array, whose value is currently 0.
                for (int j = i + 1; j < Array.IndexOf(ulamArray, ulamArray.FirstOrDefault(x => x == 0)); j++)
                {
                    if (ulamArray[i] + ulamArray[j] == startingPoint)
                        count++;
                    if (count > 1) break;       // If there is more than one combination of unique elements whose sum make up our next potential element - break out of the loops and increase the potential element value by one.
                }
                if (count > 1) break;           // If there is more than one combination of unique elements whose sum make up our next potential element - break out of the loops and increase the potential element value by one.
            }
            if (count == 1)                     // If there is exactly one combination of two elements whose sum is equal to our next potential element's value - set it as new value of our array's first element whose current value is 0.
                ulamArray[Array.IndexOf(ulamArray, ulamArray.FirstOrDefault(x => x == 0))] = startingPoint;

            startingPoint++;                    // We increase our next potential element's value by one. Always.
        }
        // For example, we start out with an array that is [1, 2, 0, 0, 0].
        // After first iteration our array will be [1, 2, 3, 0, 0]. After second iteration - [1, 2, 3, 4, 0]. After third iteration - [1, 2, 3, 4, 6]. And the next iteration - our while loop condition will break out of the loop, since the very last element of the array is no longer a zero.

        Console.WriteLine($"Displaying first {number} elements of Ulam Sequence:");
        ulamArray.ToList().ForEach(x => Console.Write($"{x}  "));

        Console.WriteLine();
        Console.WriteLine($"Value of {number}'th element of the Ulam Sequence is {ulamArray[ulamArray.Length - 1]}");
        return ulamArray[ulamArray.Length - 1];
    }

    /// <summary>
    /// Tidbit of information about Collatz conjecture:
    /// The Collatz conjecture is one of the most famous unsolved problems in mathematics. 
    /// The conjecture asks whether repeating two simple arithmetic operations will eventually transform every positive integer into 1.
    /// Read more here: https://en.wikipedia.org/wiki/Collatz_conjecture
    /// </summary>
    public int? CollatzConjectureProblem(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number between 1 and 100, and finding out how many steps it will take for it to reach 1, following Collatz's Conjecture!");
        number = (number == null || number <= 0) ? Random.Shared.Next(1, 100) : number;
        Console.WriteLine($"Number of our choice is {number}");

        int stepsToOne = 0;

        while (number != 1)
        {
            number = (number % 2 == 0) ?
                     (number / 2) :
                     (number * 3) + 1;
            stepsToOne++;
        }

        Console.WriteLine($"It has taken us {stepsToOne} steps to reach final value of one!");
        return stepsToOne;
    }

    /// <summary>
    /// Tidbit of information about Harshad number:
    /// In mathematics, a harshad number (or Niven number) in a given number base is an integer that is divisible by the sum of its digits when written in that base. 
    /// A subset of the Harshad numbers are the Moran numbers. Moran numbers yield a prime when divided by the sum of their digits.
    /// For example: 132 is divisible by 6 (1+3+2) and equals to 22, which is NOT a prime, but it's divisible without remainder, so - its a Harshad number.
    ///              133 is also divisible by 7 (1+3+3) and equal to 19, which IS a prime number, so - its a Moran number.
    ///              134 when divided from sum of its digits equal to a number with a remainder (16.75), so its neither Harshad, nor Moran number.
    /// Read more here: https://en.wikipedia.org/wiki/Harshad_number
    /// </summary>
    public string? IsNumberHarshadOrMoran(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number between 1 and 250, to find out whether that number is Harshad number, Moran number or neither");
        number = (number == null || number <= 0) ? Random.Shared.Next(1, 250) : number;
        Console.WriteLine($"Number of our choice is {number}");

        char[]? individualDigits = number?.ToString().ToCharArray();                // Firstly, we must split the input number, into an array of individual digits.
        int? sumOfDigits = 0;                                                       // Declare a temporary integer variable, to hold the sum of the individual digits of our input number.
        foreach (var digit in individualDigits)                                     // Iterate of all the individual digits of our input number, and get numeric value out of the char type variable, get their absolute value and add it to the sum variable.
            sumOfDigits += Convert.ToInt32(Math.Abs(char.GetNumericValue(digit)));

        int? resultNumber = number / sumOfDigits;

        // Utilize our previously created solution to get a boolean value whether a given variable is PRIME or not.
        bool IsResultAPrimeNumber = CheckIfNumberIsPrime(resultNumber, true);

        if (number % sumOfDigits == 0 && IsResultAPrimeNumber)  // If the division of our number and sum of digits leaves not remainder AND the result of the division is a prime number - we've out ourselves a Moran number!
        {
            Console.WriteLine($"Our input number {number} is a Moran number!");
            return "Moran";
        }
        else if (number % sumOfDigits == 0)                     // If the division of our number and sum of digits leaves no remainder but its NOT a prime number, we've got ourselves a Harshad number!
        {
            Console.WriteLine($"Our input number {number} is a Harshad number!");
            return "Harshad";
        }
        else    // In all other cases - the input number is neither Harshad, nor Moran number.
        {
            Console.WriteLine($"Our input number {number} is neither Harshad, nor Moran number!");
            return "Neither";
        }
    }

    /// <summary>
    /// A number has a breakpoint if it can be split in a way where the digits on the left side and the digits on the right side sum to the same number.
    /// </summary>
    public bool? CheckIfNumberHasABreakpoint(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number between 1 and 100000, to find out whether it has a breakpoint or not!");
        number = (number == null || number <= 0) ? Random.Shared.Next(1, 100000) : number;
        Console.WriteLine($"Number of our choice is {number}");

        string? numberAsString = number.ToString();         // First we create a string variable, since we'll realistically treat our input number as a string type variable for ease of solving this problem.
        bool numberHasBreakpoint = false;                   // Also - define a boolean type variable which will be our 'switch' for indicating whether a given number has or has NOT a breakpoint.

        // Iterate over the number, starting from 1st position (2nd digit) all the way to second to last, since we must compare either side, and if one side has no numbers - there's nothing to compare.
        for (int i = 1; i < numberAsString.Length; i++)
        {
            // Here, we 'chop' the number in half by sub-stringing from 0th position to i'th, and from i'th to the end of the number.
            var leftSide = numberAsString.Substring(0, i);
            var rightSide = numberAsString.Substring(i);

            // Then we check a conditional check - whether the sum of digits of both side, equate to same number - if so, our number DOES have a breakpoint, otherwise - default boolean value of FALSE will remain.
            if (leftSide.Select(x => int.Parse(x.ToString())).Sum() == rightSide.Select(x => int.Parse(x.ToString())).Sum())
            {
                numberHasBreakpoint = true;
                break;
            }
        }

        // Output our solutions' results to the console window.
        Console.WriteLine($"Our input number {(numberHasBreakpoint ? "DOES" : "DOES NOT")} have a breakpoint!");
        return numberHasBreakpoint;
    }

    /// <summary>
    /// Tidbit of information about Look-and-say sequence:
    /// In mathematics, the look-and-say sequence is the sequence of integers, which is generated as follows (an example):
    ///     1 is read off as "one 1" or 11.
    ///     11 is read off as "two 1s" or 21.
    ///     21 is read off as "one 2, one 1" or 1211.
    ///     and so on, until we get to the n'th iteration of our sequence.
    /// Read more here: https://en.wikipedia.org/wiki/Look-and-say_sequence
    /// </summary>
    public string? LookAndSaySequence(int? number, int? iterations)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine($"Picking a random number between 1 and 1000, to find to find out its value after {iterations} iterations!");
        number = (number == null || number <= 0) ? Random.Shared.Next(1, 1000) : number;
        iterations = (iterations == null || iterations <= 0) ? Random.Shared.Next(1, 10) : iterations;
        Console.WriteLine($"Number of our choice is {number}, and we'll find the value after {iterations} iterations");

        // Initialize the list of sequence elements, and place the first element, since we need it to form subsequent elements.
        List<string> sequenceElements = new List<string>
        {
            number.ToString()
        };

        // Do as many iterations, as we've provided.
        for (int i = 0; i < iterations; i++)
        {
            // Initialize the base variable for our next element, which initially will be an empty string, and the number of occurrences will start at 1.
            string nextElement = string.Empty;
            int occurences = 1;

            // In case the number that was initially provided is length of one (A single digit number) - we manually add it as the 2nd element of the sequence.
            if (sequenceElements[i].Length == 1)
            {
                sequenceElements.Add($"1{sequenceElements[i]}");    // Add it to the list, and break out of the loop, since we must move on to the next iteration.
                continue;
            }
            else
            {
                // Iterate over the length of the number.
                for (int j = 0; j < sequenceElements[i].Length; j++)
                {
                    // If the NEXT character does NOT exceed the length of number (we don't go outside the bounds of the length of the string), and its value is same as the current characters value - we increase the number of occurrences of that number.
                    if (j + 1 < sequenceElements[i].Length && sequenceElements[i][j] == sequenceElements[i][j + 1])
                        occurences++;
                    // Otherwise - we've either encountered the end of the string (number), or the NEXT character is not the same as our current character - therefor we must start forming next element of our sequence.
                    else
                    {
                        nextElement += $"{occurences}{sequenceElements[i][j]}";     // Next element is formed by appending it with the Occurrence counter and the number (of which we counted occurrences).
                        occurences = 1;                                             // Since our NEXT character is a different number, and we'll be counting it from start - we must restart the occurrence counter.
                    }
                }
            }
            // One the next element of the sequence has been formed, add it to the sequence list, and move on to the next iteration.
            sequenceElements.Add(nextElement);
        }

        // Return the LAST element of the sequence list, which will simply be the n'th element of the sequence (where n = iterations i.e. variable we provide into the method). 
        return sequenceElements.Last();
    }

    /// <summary>
    /// Tidbit of information about Kaprekar's Constant or 6174 (number):
    /// 6174 is known as Kaprekar's constant after the Indian mathematician D. R. Kaprekar.
    ///  1. Take any four-digit number, using at least two different digits (leading zeros are allowed).
    ///  2. Arrange the digits in descending and then in ascending order to get two four-digit numbers, adding leading zeros if necessary.
    ///  3. Subtract the smaller number from the bigger number.
    ///  4. Go back to step 2 and repeat.
    /// The above process, known as Kaprekar's routine, will always reach its fixed point, 6174, in at most 7 iterations.
    /// Read more here: https://en.wikipedia.org/wiki/6174_(number)
    /// </summary>
    public int? KaprekarsConstantProblem(int? fourDigitNumber)
    {
        // If input four digit is invalid (Has less or more than exactly four digits, does NOT have a value entirely, or has less than two distinct digits) - we simply initialize our own.
        if (fourDigitNumber.ToString().Length != 4 &&
            !fourDigitNumber.HasValue &&
            fourDigitNumber.ToString().Distinct().Count() < 2)
        {
            fourDigitNumber = 1459;
        }
        Console.WriteLine($"Here's our input four digit number - {fourDigitNumber}, which we'll use trying to follow Kaprekar's routine");

        int numberOfSteps = 0;                      // Initialize a variable to save the number of steps it takes us to reach number 6174
        int resultNumber = (int)fourDigitNumber;    // Initialize our result number, which will be re-calculated every cycle, and its initial value is equivalent to our input four digit number.

        // Iterate until we reach our final number, which is specifically 6174
        while (resultNumber != 6174)
        {
            // Instantiate two variable - which is our input number, converted to string type variable, and reordered in ascending and descending manner respectively.
            int rearrangedAscending = Convert.ToInt32(string.Concat(resultNumber.ToString().OrderBy(x => x)));
            int rearrangedDescending = Convert.ToInt32(string.Concat(resultNumber.ToString().OrderByDescending(x => x)));

            // As third step of Kaprekar's routine tells us - we must subtract smaller number from the bigger number. Also - we've just completed one iteration - which is means add one more step to total number of steps.
            resultNumber = rearrangedDescending - rearrangedAscending;
            numberOfSteps++;
        }

        // Print out the result - which is the number of steps it has taken us, to reach number 6174.
        Console.WriteLine($"It has taken {numberOfSteps} steps, to reach number 6174");
        return numberOfSteps;
    }

    /// <summary>
    /// A number is said to be Disarium if the sum of its digits raised to their respective positions is the number itself.
    /// For example if we have a number 518. To determine whether its a Disarium number we do the following calculation:
    /// (5 ^ 1) + (1 ^ 2) + (8 ^ 3) = 5 + 1 + 512 = 518. Which means, 518 IS a Disarium number!
    /// </summary>
    public bool CheckIfNumberIsDisarium(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine($"Picking a random number between 1 and 10000, to determine whether its a Disarium number or not!");
        number = (number == null || number <= 0) ? Random.Shared.Next(1, 10000) : number;
        Console.WriteLine($"Number of our choice is {number}");

        Dictionary<int, int> digitAndPositionDictionary = new Dictionary<int, int>();   // Initialize a Dictionary, to hold value of a given digit's position, and its numeric value.
        var numberAsCharArray = number.ToString().ToCharArray();                        // Convert a given number to char array, so its easier to iterate over it, and populate our Dictionary, which we initialized above.

        // Iterate over every digit in our number (which we converted to char array).
        // Each entry of our dictionary - KEY is the position of the digit with +1, since we can't define 0'th position and use Disarium rules later on. VALUE is going to be numeric value of a given char.
        for (int i = 0; i < numberAsCharArray.Length; i++)
            digitAndPositionDictionary.Add(i + 1, (int)Char.GetNumericValue(numberAsCharArray[i]));

        // Instantiate a variable to hold the sum of digits after Disarium rule-set calculation.
        double sumOfDigits = 0;
        foreach (var element in digitAndPositionDictionary)
            sumOfDigits += Math.Pow(element.Value, element.Key);    // Each digit is raised to the power of its position in the number.

        // If our sum (by Disarium rules) is equal to the input number itself - that mean our input number IS a Disarium number.
        bool IsNumberDisarium = sumOfDigits == number ? true : false;
        Console.WriteLine($"Our given input number {(IsNumberDisarium ? "is" : "is NOT")} a Disarium number!");

        return IsNumberDisarium;
    }

    /// <summary>
    /// A slight variation to the standard Fibonacci Series sequence, where we calculate and display the sequence by combining the previous two numbers.
    /// In this exercise - we're going to define number of elements we want to display the sequence for, as well as, how many previous terms we're going to use, to calculate the next number of the sequence.
    /// For example, initial 10 elements of the sequence, of the first 3 N-bonacci sequences are as follows:
    ///     1-bonacci = 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, ...
    ///     2-bonacci = 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, ...
    ///     3-bonacci = 0, 0, 1, 1, 2, 4, 7, 13, 24, 44, ...
    /// </summary>
    public int NBonacciNumberSequenceCalculationAndDisplay(int numberOfElements, int numberOfTerms)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine("Picking a random number of elements, to display the Fibonacci sequence for between 5 and 20");
        numberOfElements = numberOfElements < 5 ? Random.Shared.Next(5, 20) : numberOfElements;
        Console.WriteLine("Picking a random number of terms, using which we'll calculate the Fibonacci sequence:");
        numberOfTerms = numberOfTerms < 2 ? Random.Shared.Next(2, 5) : numberOfTerms;
        Console.WriteLine($"Calculating and displaying Fibonacci series for {numberOfElements + 1} elements, by {numberOfTerms} terms");

        // We initialize the first few values of our Fibonacci sequence, and add them to our list of integer elements.
        // For the sake of simplicity, we're going to add zero's for first n-1 number of elements, and last element will be a 1.
        // So if we generate (or provide into the method, as a parameter) number of terms to be 5, the first four elements are going to be zero's, and the 5th - one.
        List<int> fibonacciSequence = new List<int>();
        for (int i = 0; i < numberOfTerms - 1; i++)
            fibonacciSequence.Add(0);
        fibonacciSequence.Add(1);

        // We must iterate until we fill up our list with as many elements, as is provided to the method, or we generated
        // We start out from the number of elements that is already in our list, all the way until we reach our desired number of elements.
        for (int i = fibonacciSequence.Count; i <= numberOfElements; i++)
            fibonacciSequence.Add(fibonacciSequence.TakeLast(numberOfTerms).Sum());     // We utilize an extremely helpful LINQ function - TakeLast, and we input our number of terms into the function, and Sum all these elements.

        // Display our full Fibonacci sequence to console output. Reason for + 1 of elements, is because list indexing starts from zero, so for visual representation, we make sure to start our sequence from 1st number, and not 0'th
        Console.WriteLine($"Displaying Fibonacci sequence elements for {numberOfElements + 1} elements:");
        fibonacciSequence.ForEach(element => Console.WriteLine($"#{fibonacciSequence.IndexOf(element) + 1}\t{element}"));

        return fibonacciSequence.Last();    // Return the last element value of our Fibonacci sequence. (For Unit tests)
    }

    /// <summary>
    /// Tidbit of information about Gapful numbers:
    /// Gapful Number is a number N of at least 3 digits such that it is divisible by the concatenation of it’s first and last digit.
    /// </summary>
    public bool CheckIfNumberIsGapful(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, three digit, positive integer number.
        Console.WriteLine("Picking a random, three digit number, to determine whether its a Gapful number or not!");
        number = number == null || number < 100 ? Random.Shared.Next(100, 10000) : number;
        Console.WriteLine($"Number of our choice is - {number}");

        // Retrieve first, and last digits of our input number, by converting our input number to string, and retrieving the Char values of first and last elements.
        char firstDigit = number.ToString()[0];
        char lastDigit = number.ToString()[number.ToString().Length - 1];

        // Our boolean variable, determining whether a given number is Gapful or not is instantly defined and formed by the following:
        // Utilizing the remainder operator, which returns a remainder AFTER dividing first number (which is our input number), from another number (which is combination of our first and last digits).
        // If the remainder is 0, which means our input number divides nicely, without any remainder - our input number IS is in fact, a Gapful number!
        bool IsNumberGapful = number % (Char.GetNumericValue(firstDigit) + Char.GetNumericValue(lastDigit)) == 0;
        Console.WriteLine($"We have determined, that number {number} {(IsNumberGapful ? "is" : "is NOT")} a Gapful number!");

        return IsNumberGapful;
    }

    /// <summary>
    /// In this simple exercise, we must establish whether a given number is Alternating or not.
    /// To be alternating, number must be positive and every digit in its sequence must have a different parity than its next and its previous digit.
    /// For example, number 123 is Alternating, because looking at individual digits - 1 is odd, 2 is even, 3 is odd.
    /// </summary>
    public bool CheckIfNumberIsAlternating(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine($"Picking a random number between 1 and 10000, to determine whether its Alternating number or not!");
        number = (number == null || number <= 0) ? Random.Shared.Next(1, 10000) : number;
        Console.WriteLine($"Number of our choice is {number}");

        // Initialize a boolean variable, with default value of True, which will be inverted if necessary, if Alternating conditions are not met when iterating over the digits.
        bool IsNumberAlternating = true;
        // Create an array of digits from the input number, to ease the process of iteration.
        int[] arrayOfDigits = number.ToString().ToCharArray().Select(digit => Convert.ToInt32(Char.GetNumericValue(digit))).ToArray();

        // Iterate over all the digits in our int number and check a single condition, which is:
        // If the current digits AND the next digit are both Even, or both Odd - that means our condition of alternating digits is NOT met.
        // We invert the boolean value to false, and break out of the loop, since there's no need to check further elements of the array.
        for (int i = 0; i < arrayOfDigits.Length - 1; i++)
        {
            if ((arrayOfDigits[i] % 2 == 0 && arrayOfDigits[i + 1] % 2 == 0) ||
                (arrayOfDigits[i] % 2 == 0 && arrayOfDigits[i + 1] % 2 == 0))
            {
                IsNumberAlternating = !IsNumberAlternating;
                break;
            }
        }

        Console.WriteLine($"Our given input number {(IsNumberAlternating ? "is" : "is NOT")} an Alternating number!");
        return IsNumberAlternating;
    }

    /// <summary>
    /// Two exercises combined into one, since they are structurally almost identical.
    /// The additive persistence of an integer, n, is the number of times you have to replace n with the sum of its digits until n becomes a single digit integer.
    /// The multiplicative persistence of an integer, n, is the number of times you have to replace n with the product of its digits until n becomes a single digit integer.
    /// Our goal, is to determine the number of steps it will take for the number to reach a single digit value, when processing it through Additive or Multiplicative persistence pattern.
    /// </summary>
    public int NumberPersistenceProblem(NumberPersistence? persistenceType, int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, three digit, positive integer number.
        Console.WriteLine("Picking a random number, to determine how many steps it will take to reach a single digit");
        number = number == null || number == 0 ? Random.Shared.Next(10, 100000) : number;
        Console.WriteLine($"Number of our choice is - {number}");

        // If persistence type is not provided, we're going to pick a random one.
        persistenceType = (NumberPersistence?)((!persistenceType.HasValue || persistenceType == null) ?
            Enum.GetValues(typeof(NumberPersistence)).GetValue(Random.Shared.Next(0, Enum.GetValues(typeof(NumberPersistence)).Length)) :
            persistenceType);
        Console.WriteLine($"We will be processing the number with {Enum.GetName(typeof(NumberPersistence), persistenceType)} pattern");

        // Create variable to hold number of steps, and a List of digits from the input number, to ease the process of iteration.
        int numberOfSteps = 0;
        List<int> listOfDigits = number?.ToString().ToCharArray().Select(digit => Convert.ToInt32(Char.GetNumericValue(digit))).ToList();

        // Based on which persistence type is provided (or randomly selected) - we apply slightly different rule-set pattern.
        // Here's logic for following Additive pattern:
        if (persistenceType == NumberPersistence.Additive)
        {
            while (listOfDigits.Count > 1)
            {
                // Our additive number, is the sum of all individual elements of the list.
                var additiveNumber = listOfDigits.Sum();
                // After we've calculated the additive number - we split it into individual digits, and re-assign the new list of digits to our initial list.
                listOfDigits = additiveNumber.ToString().ToCharArray().Select(digit => Convert.ToInt32(Char.GetNumericValue(digit))).ToList();
                // Iterate a single step.
                numberOfSteps++;
            }
        }

        // And here's logic for following Multiplicative pattern:
        if (persistenceType == NumberPersistence.Multiplicative)
        {
            while (listOfDigits.Count > 1)
            {
                // Our additive number, is the product (multiplication of all individual digits) of our list elements.
                var multiplicativeNumber = listOfDigits.Aggregate((a, b) => a * b);
                // After we've calculated the multiplicative number - we split it into individual digits, and re-assign the new list of digits to our initial list.
                listOfDigits = multiplicativeNumber.ToString().ToCharArray().Select(digit => Convert.ToInt32(Char.GetNumericValue(digit))).ToList();
                // Iterate a single step.
                numberOfSteps++;
            }
        }

        Console.WriteLine($"It has taken us {numberOfSteps} steps to reach a single digit, following {Enum.GetName(typeof(NumberPersistence), persistenceType)} pattern, from the input number of {number}");
        return numberOfSteps;
    }

    /// <summary>
    /// Very simple, yet an interesting exercise.
    /// Tidbit of information about Pronic numbers (also called oblong numbers, heterometric numbers, or rectangular numbers):
    /// A pronic number is a number that is the product of two consecutive integers, that is, a number of the form n * ( n + 1 ).
    /// The study of these numbers dates back to Aristotle.
    /// Read more here: https://en.wikipedia.org/wiki/Pronic_number
    /// </summary>
    public bool CheckIfNumberIsPronic(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random, positive integer number.
        Console.WriteLine($"Picking a random number between 1 and 10000, to determine whether its Pronic number or not!");
        number = (number == null || number <= 0) ? Random.Shared.Next(1, 10000) : number;
        Console.WriteLine($"Number of our choice is {number}");

        // Initialize a boolean variable, with default value of False, which will be inverted if necessary, if Pronic number conditions are not met.
        bool IsNumberPronic = false;

        for (int i = 0; i <= (int)Math.Sqrt((double)number); i++)
            IsNumberPronic = number == i * (i + 1);

        Console.WriteLine($"Our given input number {(IsNumberPronic ? "is" : "is NOT")} a Pronic number!");
        return IsNumberPronic;
    }

    /// <summary>
    /// Tidbit of information about Pandigital number:
    /// In mathematics, a pandigital number is an integer that in a given base has among its significant digits each digit used in the base at least once.
    /// In other words - A pandigital number contains all digits (0-9) at least once.
    /// Our solutions will be under the assumption of a given number being base 10 (digits 0-9).
    /// Read more here: https://en.wikipedia.org/wiki/Pandigital_number
    /// </summary>
    public bool CheckIfNumberIsPandigital(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random integer between a zero and integer maximum value.
        Console.WriteLine($"Picking a random number, to determine whether its a Pandigital number or not!");
        number = (number == null || number <= 0) ? Random.Shared.Next(0, Int32.MaxValue) : number;
        Console.WriteLine($"Number of our choice is {number}");

        // For this solution we're going to utilize a HashSet.
        // Reason for it is rather simple - HashSet will store a single occurrence of each individual digit.
        HashSet<int> digits = new HashSet<int>();
        foreach (var digit in number.ToString().ToCharArray())
            digits.Add((int)Char.GetNumericValue(digit));

        // Our input number will be a Pandigital number, if each digits 0 through 9 appears at least once. That means our HashSet must have exactly 10 elements.
        bool IsNumberPandigital = digits.Count == 10;

        Console.WriteLine($"Our given input number {(IsNumberPandigital ? "is" : "is NOT")} a Pandigital number!");
        return IsNumberPandigital;
    }

    public bool CheckIfNumberIsPandigitalUsingLINQ(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random integer between a zero and integer maximum value.
        Console.WriteLine($"Picking a random number, to determine whether its a Pandigital number or not!");
        number = (number == null || number <= 0) ? Random.Shared.Next(0, Int32.MaxValue) : number;
        Console.WriteLine($"Number of our choice is {number}");

        // Our second solution is essentially a one-liner, which utilizes LINQ functions Distinct and Count.
        // First we convert the input number to a string type, remove duplicate characters (digits) by using Distinct, and then equating the total Count of digits to 10 (which is how many unique digits our number should have).
        bool IsNumberPandigital = number?.ToString().Distinct().Count() == 10;

        Console.WriteLine($"Our given input number {(IsNumberPandigital ? "is" : "is NOT")} a Pandigital number!");
        return IsNumberPandigital;
    }

    /// <summary>
    /// Extremely simple exercise.
    /// A number is considered slidey if for every digit in the number, the next digit from that has an absolute difference of one.
    /// </summary>
    public bool CheckIfNumberIsSlidey(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random integer between a zero and integer maximum value.
        Console.WriteLine($"Picking a random number, to determine whether its a Slidey number or not!");
        number = (number == null || number <= 0) ? Random.Shared.Next(0, Int32.MaxValue) : number;
        Console.WriteLine($"Number of our choice is {number}");

        // Initialize a boolean variable, with default value of true, which will be inverted if necessary, if Slidey number conditions are not met.
        bool IsNumberSlidey = true;
        // Iterate over every single digit in a given number all the way until the second to last one, since we check the current digit, with its neighboring next element.
        for (int i = 0; i < number.ToString().Length - 1; i++)
        {
            // If the absolute value difference between the current digit and the second digits is NOT equal to exactly one - our input number is NOT a Slidey number, we invert the boolean variable and break out of the loop.
            if (Math.Abs((int)(char.GetNumericValue(number.ToString()[i]) - char.GetNumericValue(number.ToString()[i + 1]))) != 1)
            {
                IsNumberSlidey = !IsNumberSlidey;
                break;
            }
        }

        Console.WriteLine($"Our given input number {(IsNumberSlidey ? "is" : "is NOT")} a Slidey number!");
        return IsNumberSlidey;
    }

    /// <summary>
    /// A fun exercise/game called 'Digits Battle'.
    /// Here's how its played:
    ///     1. Starting from the left side of an integer, adjacent digits pair up in "battle" and the larger digit wins. 
    ///     2. If two digits are the same, they both lose. 
    ///     3. A lone digit automatically wins.
    /// </summary>
    public int? DigitsBattle(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random integer between double type minimum value and maximum value.
        Console.WriteLine($"Picking a random number, to play out the 'Digits Battle' exercise");
        number = (number == null || number <= 0) ? Random.Shared.Next(0, Int32.MaxValue) : number;
        Console.WriteLine($"Number of our choice is {number}");

        // First, we initialize a list of integer arrays, into which we'll store pairs of two digits, from the input number.
        List<int[]> listOfPairs = new List<int[]>();
        // Convert the input number into an array of digits, that way we can pair them up, and prepare for the game!
        int[] inputDigits = number.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();

        // Iterate over the digits, initialize an integer array with size of 2, copy two digits from the array of digits, into our temporary pair array, and add that pair of two digits array into our list of digit arrays.
        for (int i = 0; i < inputDigits.Length; i += 2)
        {
            int[] digitPair = new int[2];
            Array.Copy(inputDigits, i, digitPair, 0, inputDigits.Length - i == 1 ? 1 : 2);      // If the iterator i, subtracted from Length is equal to 1, that means our input array has odd number of elements, so our last pair will simply have a single digit added.
            listOfPairs.Add(digitPair);
        }

        // Initialize a string type variable (for now), which will be concatenated when processing all the individual pairs of digits
        string finalNumber = string.Empty;

        // Iterate over all the digit pairs, and apply the game's rules.
        foreach (var digitPair in listOfPairs)
            finalNumber += digitPair.Distinct().Count() != 1 ?  // If the amount of DISTINCT elements is NOT equal to one..
                           digitPair.Max().ToString() :         // .. that means we must take largest one.
                           string.Empty;                        // Otherwise - both digits lose, and neither is added to our final number.

        Console.WriteLine($"Our final number, after playing out 'Digits Battle' game is {finalNumber}");
        return !string.IsNullOrEmpty(finalNumber) ? Convert.ToInt32(finalNumber) : null;
    }

    /// <summary>
    /// Tidbit of information about Zygodrome numbers:
    /// A number is Zygodrome if it can be partitioned into clusters of repeating digits with a length equals or greater than two.
    ///     As to say that repeating digits need to be placed as an adjacent pair or a greater group, and that no single digits are allowed.
    /// For example, numbers 112233 or 7777333, would be considered Zygodrome numbers, where 2251153 would NOT fit the conditions of being a Zygodrome number.
    /// </summary>
    public bool CheckIfNumberIsZygodrome(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random integer between a zero and integer maximum value.
        Console.WriteLine($"Picking a number, to determine whether its a Zygodrome number or not!");
        number = (number == null || number <= 0) ? Random.Shared.Next(0, Int32.MaxValue) : number;
        Console.WriteLine($"Number of our choice is {number}");

        // Initialize three variable that will help us in this solution:
        //  A boolean variable to act as a 'flag' for whether a given input number is Zygodrome number or not.
        //  An occurrence counter variable that will help us keep track of number of occurrences of each individual digit.
        //  A placeholder char type variable to hold the actual value of a given char, whose occurrences we'll count.
        bool IsNumberZygodrome = true;
        int occurrenceCounter = 0;
        char? placeholderDigit = number.ToString()[0];  // Set the value of this variable to the very first digit of the input number.

        // Iterate over every single element (digit) in our input number.
        for (int i = 0; i < number.ToString().Length; i++)
        {
            // If the current element's value is equivalent to our placeholder digit variable - increase the occurrence counter by one.
            if (number.ToString()[i] == placeholderDigit)
                occurrenceCounter++;
            else
            {
                // Otherwise (If current element is NOT equivalent to our placeholder digit variable) - check whether there were at least two occurrences of a given digit.
                // If not - invert the boolean and break out of the loop, since our number simply does not fit the condition to be a Zygodrome number.
                if (occurrenceCounter < 2)
                {
                    IsNumberZygodrome = !IsNumberZygodrome;
                    break;
                }
                // If there WERE at least two occurrences of the previous digit - we're still good to go, just set the current digit's value to current element, and reset the occurrence counter to one (since we will move on to the next element with next iteration).
                placeholderDigit = number.ToString()[i];
                occurrenceCounter = 1;
            }

            // The very last check that we must do, on the last iteration of the array, is to check the occurrence counter one more time, and set our boolean variable value to correct value.
            // We must do this, because after we check the last element, and possibly increase the occurrence counter - we exit the loop afterwards.
            if (i == number.ToString().Length - 1 && occurrenceCounter < 2)
                IsNumberZygodrome = !IsNumberZygodrome;
        }

        Console.WriteLine($"Our given input number {(IsNumberZygodrome ? "is" : "is NOT")} a Zygodrome number!");
        return IsNumberZygodrome;
    }

    /// <summary>
    /// Tidbit of information about Polydivisible numbers:
    /// In mathematics a polydivisible number (or magic number) is a number in a given number base with digits abcde... that has the following properties:
    ///     1. Its first digit a is not 0.
    ///     2. The number formed by its first two digits 'AB' is a multiple of 2.
    ///     3. The number formed by its first three digits 'ABC' is a multiple of 3.
    ///     4. The number formed by its first four digits 'ACCD' is a multiple of 4.
    ///     5.   etc.
    /// Read more here: https://en.wikipedia.org/wiki/Polydivisible_number
    /// </summary>
    public bool CheckIfNumberIsPolydivisible(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random integer between a zero and integer maximum value.
        Console.WriteLine($"Picking a number, to determine whether its a Polydivisible number or not!");
        number = (number == null || number <= 0) ? Random.Shared.Next(0, Int32.MaxValue) : number;
        Console.WriteLine($"Number of our choice is {number}");

        // Initialize a boolean variable, with default value of True, which will be inverted if necessary, if Polydivisible number conditions are not met.
        bool IsNumberPolydivisible = true;

        // Iterate over every single digit in the given input number, starting from the second digit, all the way to the last one.
        for (int i = 1; i <= number.ToString().Length; i++)
        {
            // If the first X amount of numbers, 'cutting' them from the start, to the i'th position DO leave a remainder after dividing it from the number of digits - the number is NOT Polydivisible. So invert the bool 'flag' and break out of the loop.
            if (Convert.ToInt32(number.ToString().Substring(0, i)) % i != 0)
            {
                IsNumberPolydivisible = !IsNumberPolydivisible;
                break;
            }
        }

        // Display the results to the console window.
        Console.WriteLine($"Our given input number {(IsNumberPolydivisible ? "is" : "is NOT")} a Polydivisible number!");
        return IsNumberPolydivisible;
    }

    /// <summary>
    /// 'Super-d Numbers'. Here's the premise of the exercise:
    /// A number n becomes a super-d number when, for any digit d from 2 up to 9, the result of d * n^d contains d consecutive digits equal to d.
    /// Given a positive integer n, implement a function that returns:
    ///     1. "Super-d Number" if n is a super-d number, replacing the letter 'd' with the digit (any from 2 up to 9) that makes it super.
    ///     2. "Normal Number" if n is not a super-d number.
    /// For example, given number = 19, result would be "Super-2 Number":
    ///     2 * 19^2 = 722, because There are two (d) consecutive digits equal to 2 (d)
    /// If there are multiple digits using which our given input number becomes 'Super' - return the first one.
    /// </summary>
    public string SuperdNumber(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random integer between a zero and integer maximum value.
        Console.WriteLine($"Picking a number, to determine whether its a Zygodrome number or not!");
        number = (number == null || number <= 0) ? Random.Shared.Next(0, 10000) : number;
        Console.WriteLine($"Number of our choice is {number}");

        // Normally, I would name variables with reasonable names, however, this will be an exception for this exercise.
        int? d = 0;
        for (int i = 2; i <= 9; i++)
        {
            // Result is equivalent to (d * number ^ d)
            string result = (i * Math.Pow((double)number, i)).ToString();
            int consecutiveCounter = 1;
            // Iterate over the result as string, and attempt to count consecutive occurrences of i'th iterator.
            for (int j = 0; j < result.Length; j++)
            {
                for (int k = j + 1; k < result.Length; k++)
                {
                    // If the NEXT element is not the same as the current element, check whether consecutive occurrences is exactly equal to i'th iterator - set d to consecutive counter. Also - break out of the loop.
                    if (result[j] != result[k])
                    {
                        if (consecutiveCounter == i)
                            d = consecutiveCounter;

                        break;
                    }
                    // if the CURRENT element is equivalent to i'th iterator - increase the consecutive counter.
                    else if (result[j].ToString() == i.ToString())
                        consecutiveCounter++;
                }

                // If consecutive occurrence counter is exactly equal to i'th iterator - set d to consecutive counter. This might happen if the i'th iterator is the last element in the result string, and it wasn't set and broken out of the loop previously.
                if (consecutiveCounter == i)
                {
                    d = consecutiveCounter;
                    break;
                }
            }

            // If d is equal to i'th iterator, we can break out of the loop entirely, since we've already found the first 'Super' of a given number.
            if (d == i)
                break;
        }

        // If 'd' variable does not remain null or zero, that mean our number can be 'Super'. Regardless - display the results to the console window, and return stringified version of the answer.
        if (d != null)
            Console.WriteLine($"Our input number has a 'Super' version! It's a Super-{d} Number!");
        else
            Console.WriteLine($"Our input number unfortunately can not become a 'Super' number.");

        return $"Super-{d} Number";
    }

    /// <summary>
    /// An exercise in which we'll determine whether a given positive integer is a 'Happy' number or not.
    /// A happy number is a number which yields a 1 by repeatedly summing up the square of its digits.
    /// If such a process results in an endless cycle of numbers, the number will be considered an unhappy number.
    /// </summary>
    public bool CheckIfNumberIsHappy(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random integer between zero and 10000.
        Console.WriteLine($"Picking a random number, to figure out whether its a 'Happy' number or not");
        number = (number == null || number <= 0) ? Random.Shared.Next(0, 10000) : number;
        Console.WriteLine($"Number of our choice is {number}");

        // Initialize a boolean variable which will remain null until we find the solution to the exercise.
        bool? IsNumberHappy = null;
        // We'll initialize a dictionary, to hold the unique characters, and the index of their first occurrence.
        Dictionary<int, int> uniqueNumberDictionary = new Dictionary<int, int>();

        // Continue looping, while nullable boolean value remains NULL. In other words - proceed, until the solution is found.
        while (IsNumberHappy == null)
        {
            // Convert our input number into a List of individual digits, since we'll need to get each of their squared values.
            List<int> digits = number.ToString().Select(character => int.Parse(character.ToString())).ToList();

            // Re-calculate the number, by summing the squared values of each individual digit.
            number = (int)digits.Sum(digit => Math.Pow(digit, 2));

            // If our 'new' number is specifically 1 - that means our input number is a 'Happy' number - we can set the boolean variable to true, and break out of the loop.
            if (number == 1)
            {
                IsNumberHappy = true;
                break;
            }
            else
            {
                // Attempt to add the 'new' number into our Dictionary.
                // If our Dictionary already contains such number - .Add function will throw an exception, saying that the Dictionary already contains an element with such Key,
                //      which in our case means our input number has started to repeat the sequence, and will continue to loop over X amount of variations, until it reaches the same number AGAIN.
                // That automatically means that the input number is NOT a 'Happy' number - In this case, we can set boolean variable to 'false' and break out of the loop.
                try
                {
                    uniqueNumberDictionary.Add((int)number, (int)number);    // KEY value will be set to the unique number. VALUE number doesn't really matter for us, so we'll just set it to the number itself as well.
                }
                catch
                {
                    IsNumberHappy = false;
                    break;
                }
            }
        }

        // Display the results to the console window.
        Console.WriteLine($"Our given input number {((bool)IsNumberHappy ? "is" : "is NOT")} a 'Happy' number!");
        return (bool)IsNumberHappy;
    }

    /// <summary>
    /// An exercise that is a variation to Prime numbers' exercises.
    /// In this exercise you have to establish if an integer is an Unprimeable number.
    /// A given number will be considered 'Unprimeable', when a single digit of a composite number is exchanged with any digit from 0 up to 9, the new number obtained must not be a prime.
    ///     For example - say we have a number 14.
    ///     Numbers obtained changing the first digit (1):
    ///     04 (4), 14, 24, 34, 44, 54, 64, 74, 84, 94      (Leading zeros are not considered)
    ///     Numbers obtained changing the second digit (4):
    ///     10, 11, 12, 13, 14, 15, 16, 17, 18, 19
    ///     Among the two series, 11, 13, 17 and 19 are primes. Therefor - our input number 14 is NOT an 'Unprimeable'
    /// </summary>
    public bool CheckIfNumberIsUnprimeable(int? number)
    {
        // In this exercise, on a rare occasion, we'll be re-using one of our previously solved exercise solution - that is, to check whether a given number is Prime or not.

        // If a number isn't provided to the method or is invalid, we pick a random integer between zero and 10000.
        Console.WriteLine($"Picking a random number, to figure out whether its an 'Unprimeable' number or not");
        number = (number == null || number <= 0) ? Random.Shared.Next(0, 10000) : number;
        Console.WriteLine($"Number of our choice is {number}");

        // Utilize our previously created solution to get a boolean value whether a given variable is PRIME or not.
        var numberAsDigits = number.ToString().ToCharArray();
        bool IsNumberUnprimeable = false;
        for (int i = 0; i < numberAsDigits.Length; i++)         // Iterate over every digit in out input number.
        {
            for (int j = 0; j < 10; j++)                        // Each individual digit will be swapped out with a digit from 0 to 9, and then whole number will be checked whether its Prime or not.
            {
                var newNumber = numberAsDigits;                 // Create a placeholder variable for our newly formed digit.
                newNumber[i] = Convert.ToChar(j.ToString());    // Swap out the i'th digit, with the j'th number (0-9)

                if (CheckIfNumberIsPrime(Convert.ToInt32(new string(newNumber)), true))   // Call out 'CheckIfNumberIsPrime' method, that will return TRUE if our newly formed number (after being converted to Integer type) is a Prime number or not.
                {
                    IsNumberUnprimeable = !IsNumberUnprimeable;         // If our new number IS a prime number - invert the bool, and then break out of the loop.
                    break;
                }
            }
            numberAsDigits = number.ToString().ToCharArray();           // After each individual digit was swapped out (0-9), we must reset the input number back to its original value, otherwise we'll end up with each digit remaining at the last value, which is 9.
        }

        // Display the results to the console window.
        Console.WriteLine($"Our given input number {(IsNumberUnprimeable ? "is NOT" : "is")} an 'Unprimeable' number!");
        return IsNumberUnprimeable;
    }

    /// <summary>
    /// Here's the premise of an exercise we can call 'Good, Evil & Neutral numbers':
    ///     A positive number's 'population' is the sum of 1's in its binary representation
    ///     1. The input number is considered 'Good' if it has an even numbered population.
    ///     2. The input number is considered 'Evil' if it has an odd numbered population.
    ///     3. The input number is considered 'Neutral' if its population is a prime number. This can occur at the same time as the other two options.
    /// The input number will be a positive integer number, and the result should be a string - either "Good", "Evil" or "Neutral"
    /// </summary>
    public string GoodEvilOrNeutralNumber(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random integer between zero and 10000.
        Console.WriteLine($"Picking a random number, to figure out whether its 'Good', 'Evil' or 'Neutral'.");
        number = (number == null || number <= 0) ? Random.Shared.Next(0, 10000) : number;
        Console.WriteLine($"Number of our choice is {number}");

        // In order to get a binary representation of our integer, we must Convert it to string type and specify to what base. 
        string binaryRepresentation = Convert.ToString((int)number, 2);

        // Define a variable to hold the 'population' of our number.
        int population = 0;
        // Iterate over the binary representation string, and if a given character is '1', then increase the population by one.
        for (int i = 0; i < binaryRepresentation.Length; i++)
            population += binaryRepresentation[i] == '1' ? 1 : 0;

        string numberType = string.Empty;
        if (population % 2 == 0)            // If number has an even numbered population - its considered to be 'Good'
        {
            numberType = CheckIfNumberIsPrime(population, true) ? "Neutral Good" : "Good";
            Console.WriteLine($"Our input number is a '{numberType}' number, " +
                              $"since it has population if {population}, which is an even number{(CheckIfNumberIsPrime(population, true) ? " and its a Prime number" : "")}!");
        }
        else if (population % 2 != 0)       // If number has an odd numbered population - its considered to be 'Evil'
        {
            numberType = CheckIfNumberIsPrime(population, true) ? "Neutral Evil" : "Evil";
            Console.WriteLine($"Our input number is a '{numberType}' number, " +
                              $"since it has population if {population}, which is an even number{(CheckIfNumberIsPrime(population, true) ? " and its a Prime number" : "")}!");
        }

        return numberType;
    }

    /// <summary>
    /// Here's the premise of an exercise we can call 'Apocalyptic number':
    ///     A number n is apocalyptic if 2^n contains a string of 3 consecutive 6s (666 being the presumptive "number of the beast").
    ///     Our solution must determine whether a given positive integer is an 'Apocalyptic number or not.
    ///     If the number is NOT an 'Apocalyptic' number, our solution should return 'null' and inform the user about the result.
    ///     If the number IS an 'Apocalyptic' number, our solution should return the index of the first occurrence of 6, which forms an exact consecutive '666', and inform the user about the result.
    /// If you wish to read more about this so-called 'Number of the beast', read here: https://en.wikipedia.org/wiki/Number_of_the_beast
    /// </summary>
    public int? CheckIfNumberIsApocalyptic(double? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random integer between zero and 500. Higher numbers might cause overflow.
        Console.WriteLine($"Picking a random number, to figure out whether its an 'Apocalyptic' number or not");
        number = (number == null || number <= 0) ? Random.Shared.Next(0, 500) : number;
        Console.WriteLine($"Number of our choice is {number}");

        // Define a nullable integer that will (potentially) hold value of the index for the consecutive '666'
        int? indexOfNumberOfTheBeast = null;
        // Attempt to calculate the 'Apocalyptic' number by raising 2 by the power of our number. We utilize fixed-point format specifier for our ToString function, to get the 'full' number, without exponent or decimal values.

        string? numberPowered = Math.Pow(2, (double)number).ToString("F0");

        // We must ensure that our 'powered' number is not null, an empty string, or an 'infinity'.
        // Since double type, just as well as all other data type have numeric limitations, this function MAY return the infinity or '∞' symbol as the result.
        if (!string.IsNullOrEmpty(numberPowered) || numberPowered != "∞")
            // All we need to check for, is whether our powered number (as string), contains '666', if so - take its index, otherwise, our index of number of the beast remains a null.
            indexOfNumberOfTheBeast = numberPowered.IndexOf("666") != -1 ?
                                      numberPowered.IndexOf("666") : null;

        // Display the results to the console window.
        Console.WriteLine($"Our given input number {(indexOfNumberOfTheBeast != null ? "is" : "is NOT")} an 'Apocalyptic' number!");
        return indexOfNumberOfTheBeast;
    }

    /// <summary>
    /// Here's the premise of an exercise we can call 'Hole number sequence':
    ///     Hole numbers are numbers with holes in their shapes (8 is special in that it contains two holes)
    ///     For example - 14 is a hole number with one hole. 88 is a hole number with four holes.
    ///     Our goal for this exercise is to count the sum of the holes for the integers n in the range of range 0 < n <= N.
    ///     For example - Sum of holes for N = 14 would be equal to 5, because there are 5 holes in 4, 6, 8, 9, 10 and 14
    ///     One imporant thing to note is that we're going to interpret 'holes' for the default font of Visual Studio 2022, without any font-altering extensions or third-party variations. In this case - only number 6, 8, 9 and 0 have holes. Note - number 8 has two holes.
    /// </summary>
    public int? HoleNumberSequenceSum(int? number)
    {
        // If a number isn't provided to the method or is invalid, we pick a random integer between zero and 10000.
        Console.WriteLine($"Picking a random positive integer and counting holes from zero to our selected number.");
        number = (number == null || number <= 0) ? Random.Shared.Next(0, 10000) : number;
        Console.WriteLine($"Number of our choice is {number}");

        int? numberOfHoles = 0;

        // Iterate from zero to our input number, and count number of 'holes' in each individual number, and add it to the total sum of 'holes'.
        for (int i = 0; i <= number; i++)
        {
            // An interesting thing we utilize is 'pattern matching' where we utilize keywords 'is' and 'or' for evaluating each character
            var sumOfSingleHoles = i.ToString().Count(character => character is '6' or '9' or '0');
            var sumOfDoubleHoles = i.ToString().Count(character => character is '8');

            numberOfHoles += sumOfSingleHoles + (sumOfDoubleHoles * 2);
        }

        // Display the results to the console window.
        Console.WriteLine($"Starting from zero to {number}, there are total of {numberOfHoles} holes, in all of the numbers!");
        return numberOfHoles;
    }

    /// <summary>
    /// This exercise is an interesting variation of prime numbers. We can call this exercise - 'Truncatable Primes'. Here's the premise:
    /// A number can be considered a 'Truncatable prime' if that number contains no 0 digits and, when the first (or last) digit is successively removed, the result is always prime.
    ///     1. A left-truncatable prime is a prime number that contains no 0 digits and, when the first digit is successively removed, the result is always prime.
    ///     2. A right-truncatable prime is a prime number that contains no 0 digits and, when the last digit is successively removed, the result is always prime.
    /// If a given integer:
    ///     1. Only a left-truncatable prime, we must return 'Left' as a result of our solution.
    ///     2. Only a right-truncatable prime, we must return 'Right' as a result of our solution.
    ///     3. Is both LEFT and RIGHT - we return 'Both'
    ///     4. Is neither LEFT or RIGHT - we return a null value.
    /// Here's few examples:
    ///     Given an integer 5939, its considered to be RIGHT 'Truncatable prime', because 5939, 593, 59 and 5 are all prime
    ///     Given an integer 317, its considered to be BOTH 'Truncatable prime', because 317, 17 and 7 are all prime (Successively taken from the left) and 317, 31 and 3 (Successively taken from the right) are all prime.
    /// </summary>
    public string? CheckIfNumberIsTruncatablePrime(int number)
    {
        // For this exercise, we'll be reusing our beloved 'CheckIfNumberIsPrime' solution, to simplify the process of solving this exercise, and not having to repeat ourselves by re-writing the same logic.
        // If a number isn't provided to the method or is invalid, we pick a random integer between zero and 10000.
        Console.WriteLine($"Picking a random positive integer to determine whether its a 'Truncatable' prime or not.");
        number = (number == null || number <= 0) ? Random.Shared.Next(0, 10000) : number;
        Console.WriteLine($"Number of our choice is {number}");

        // First condition that we must check, before any other logic - is whether our input number contains zeros or not. If it does - it automatically is not compatible for further logic, and we must return null value.
        if (number.ToString().Contains('0'))
        {
            Console.WriteLine($"Unfortunately, our input number {number} contains zeros");
            return null;
        }

        // Initialize two Lists of type integer, to store numbers successively removing one-by-one from the left, and from the right
        List<int> numbersFromLeft = new List<int>();
        List<int> numbersFromRight = new List<int>();

        // Run two separate loops, one that substrings the number from i'th position, all the way to the end, this way we get all successive numbers from the left.
        for (int i = 0; i < number.ToString().Length; i++)
            numbersFromLeft.Add(Convert.ToInt32(number.ToString().Substring(i)));

        // Second loop simply substrings the number from 0'th position, by length of i. This way we get all successive numbers from the right.
        for (int i = 1; i <= number.ToString().Length; i++)
            numbersFromRight.Add(Convert.ToInt32(number.ToString().Substring(0, i)));

        // Then - utilize a combination of LINQ .All function to determine whether ALL elements in each list ARE primes or not. This will yield us the result we want for our exercise.
        bool IsNumberLeftTruncatable = numbersFromLeft.All(number => CheckIfNumberIsPrime(number, true));
        bool IsNumberRightTruncatable = numbersFromRight.All(number => CheckIfNumberIsPrime(number, true));

        // Once we've determined the solutions for our exercise - display the results to the console window, and return a valid answer.
        if (IsNumberLeftTruncatable && IsNumberRightTruncatable)
        {
            Console.WriteLine($"Our input number {number} is both LEFT and RIGHT 'Truncatable' number!");
            return "Both";
        }
        else if (IsNumberLeftTruncatable)
        {
            Console.WriteLine($"Our input number {number} is only LEFT 'Truncatable' number!");
            return "Left";
        }
        else if (IsNumberRightTruncatable)
        {
            Console.WriteLine($"Our input number {number} is only RIGHT 'Truncatable' number!");
            return "Right";
        }
        else
        {
            Console.WriteLine($"Unfortunately, our input number {number} is not a prime number at all.");
            return null;
        }
    }
}