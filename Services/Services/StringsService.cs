using Services.Interfaces;

namespace Services;

public class StringsService : IStringsService
{
    public string ReverseAString(string? inputString)
    {
        // If provided input string is null or empty, we pick 'Hello world!' as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "Hello world!" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        char[] charArray = inputString.ToCharArray();                   // Convert our string to a char array, over which we will be iterating.
        for (int i = 0, j = inputString.Length - 1; i < j; i++, j--)    // Iterate using two variables, from start of the word to the end, and from the end to start, simultaneously.
        {                                                               // In case the array has odd amount of letters for example 5 letters, after 2nd and 4th letter change places, after next iteration, exit condition is triggered - I.e. i = 2 is NOT less than j = 2, so we break out of the loop, and the 3rd letter simply stays in same place.
            charArray[i] = inputString[j];
            charArray[j] = inputString[i];
        }

        string reversedString = new string(charArray);
        Console.WriteLine($"Reversed string: {reversedString}");
        return reversedString;
    }

    public string ReverseAStringUsingArrayReverse(string? inputString)
    {
        // If provided input string is null or empty, we pick 'Hello world!' as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "Hello world!" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        char[] charArray = inputString.ToCharArray();
        Array.Reverse(charArray);                       // We use in-built Array function to reverse the char array.

        string reversedString = new string(charArray);
        Console.WriteLine($"Reversed string: {reversedString}");
        return reversedString;
    }

    public string ReverseAStringUsingLINQ(string? inputString)
    {
        // If provided input string is null or empty, we pick 'Hello world!' as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "Hello world!" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        // We use IEnumerable Reverse function to reverse the string.
        string reversedString = new string(inputString.Reverse().ToArray());

        Console.WriteLine($"Reversed string: {reversedString}");
        return reversedString;
    }
}