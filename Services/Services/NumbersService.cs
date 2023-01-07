using Services.Interfaces;

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

        isNumberArmstrong = sumOfCubes == number ? true : false;    // If our sum of cubes (Each digit being raised to the power of three) is equal to the input number value, our input number is, in fact, an Armstong number!
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
            int remainder = i % 10;                          // Remainder, as you might've guessed, is the remaining value after division of 10, of our loop iterator, which start of, being equal to our input number.
            sumOfCubes += remainder * remainder * remainder; // Add a cubic multiplication value of the digit to the total sum of cubes.
        }
        // So, for example:
        // First iteration if our number is 371, its remainder after division of 10 is 1. 1^3 = 1
        // Next iteration, 371 / 10 = 37.1, which then rounds up to 37 because i is integer type, its remainder after division of 10 is 7. 7^3 = 343
        // Next iteration (our last one), 37 / 10 = 3 (Because i is integer type), its remainder after division is 3 (because it cant divide out of 10, the remainder is the entire number 3. 3^3 = 27
        // Sum of cubes is 1 + 343 + 27 = 371, which is exactly our input number.

        isNumberArmstrong = sumOfCubes == number ? true : false;    // If our sum of cubes (Each digit being raised to the power of three) is equal to the input number value, our input number is, in fact, an Armstong number!
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
        {                                                                                               // Explanation of the exit condition - If word has 5 symbols, exit conditon triggers once i reaches 3, because there's no reason to check the exact middle of the string, since there's nothing to compare it to.
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
                                                        // remainder variable will be necessary to hold our remainding value after division. Reversed number will be formed during each iteration of the loop, and later on, will be compared to our input number.

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
        Console.WriteLine($"Finding the angle between arrows, when the time is {hours}:" +  // Based on whether hour is above 12, we indicate whethere a given time is AM or PM
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
        Console.WriteLine("Picking a random positive integer, to find and diplay all of its factors.");
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

        // We will utilize a System.IO library to temporarily suppress console window output, because we don't want CheckIfNumberIsPrime method output to be mixed up with this method, since we only use it to get a return boolean value determining whether a given number is PRIME or not.
        TextWriter tw = Console.Out;
        Console.SetOut(TextWriter.Null);
        if (!CheckIfNumberIsPrime(number))  // Utilize our previously created solution to get a boolean value whether a given variable is PRIME or not.
        {
            Console.SetOut(tw);
            Console.WriteLine("Randomly selected number happens to NOT be PRIME number itself, therefor we can't determine its strength");
            return null;
        }

        // If our selected input variable is indeed a PRIME number - we can proceed with the solution.
        // First we must find the closest previous, and closest next primes, and calculate the distance to both, from our input number.
        int closestPreviousPrime = (int)number;
        for (int i = closestPreviousPrime - 1; i >= 2; i--)     // Iterate from our input number, to 2, check whether a given iterator i happens to be a PRIME number or not - if so, assign its value to our closestPreviousPrime variable, and break out of the loop.
        {
            if (!CheckIfNumberIsPrime(i))
                continue;
            else
            {
                closestPreviousPrime = i;
                break;
            }
        }
        Console.SetOut(tw); // Remove the suppression of Console output, since we will not be using our CheckIfNumberIsPrime method anymore.
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
        int startingPoint = 3;                  // Since we have first two elements of our Ulam Sequence, we pre-define starting point from where we will be looking for next element of the sequence. This is our so-called 'Next Potential Element'

        // Continually interate, until the last element of our array is NOT a zero. (In a newly initialized non-nullable integer array, all element are zero).
        while (ulamArray[ulamArray.Length - 1] == 0)
        {
            int count = 0;                      // Placeholder counter which will interate once we find a combination of two unique elements whose summed value is equal to our next potential element's value.
            // First loop iterates from 1st element, to second to last element of the first element in the array, whose value is currently 0.
            for (int i = 0; i < Array.IndexOf(ulamArray, ulamArray.FirstOrDefault(x => x == 0)) - 1; i++)
            {
                // Second llop iterates from 2nd element, to exactly the first element in the array, whose value is currently 0.
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

        // We will utilize a System.IO library to temporarily suppress console window output, because we don't want CheckIfNumberIsPrime method output to be mixed up with this method, since we only use it to get a return boolean value determining whether a given number is PRIME or not.
        TextWriter tw = Console.Out;
        Console.SetOut(TextWriter.Null);
        bool IsResultAPrimeNumber = CheckIfNumberIsPrime(resultNumber);
        Console.SetOut(tw); // Remove the suppression of Console output, since we will not be using our CheckIfNumberIsPrime method anymore.

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
        else    // In all other cases - the input number is neither Harsah, nor Moran number.
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
            // Here, we 'chop' the number in half by substringing from 0th position to i'th, and from i'th to the end of the number.
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
            // Initialize the base variable for our next element, which initially will be an empty string, and the number of occurences will start at 1.
            string nextElement = string.Empty;
            int occurences = 1;

            // In case the number that was intially provided is length of one (A single digit number) - we manually add it as the 2nd element of the sequence.
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
                    // If the NEXT character does NOT exceed the length of number (we dont go outside the bounds of the length of the string), and its value is same as the current characters value - we increase the number of occurences of that number.
                    if (j + 1 < sequenceElements[i].Length && sequenceElements[i][j] == sequenceElements[i][j + 1])
                        occurences++;
                    // Otherwise - we've either encountered the end of the string (number), or the NEXT character is not the same as our current character - therefor we must start forming next element of our sequence.
                    else
                    {
                        nextElement += $"{occurences}{sequenceElements[i][j]}";     // Next element is formed by appending it with the Occurence counter and the number (of which we counted occurences).
                        occurences = 1;                                             // Since our NEXT character is a different number, and we'll be counting it from start - we must restart the occurence counter.
                    }
                }
            }
            // One the next element of the sequence has been formed, add it to the sequence list, and move on to the next iteration.
            sequenceElements.Add(nextElement);
        }

        // Return the LAST element of the sequence list, which will simply be the n'th element of the sequence (where n = iterations i.e. variable we provide into the method). 
        return sequenceElements.Last();
    }
}