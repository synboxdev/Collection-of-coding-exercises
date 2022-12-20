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
}