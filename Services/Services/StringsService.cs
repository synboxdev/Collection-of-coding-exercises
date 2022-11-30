using Services.Interfaces;
using System.Text;

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

    /// <summary>
    /// Palindrome is a word that has the same spelling from front to back and vice versa
    /// </summary>
    public string StringIsPalindrome(string? inputString)
    {
        // If provided input string is null or empty, we pick 'rAdar' as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "rAdar" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        bool equalityCheck = true;
        for (int i = 0, j = inputString.Length - 1; i < inputString.Length / 2; i++, j--)   // Iterate using two variables, from start of the word to the end, and from the end to start, simultaneously.
        {                                                                                   // Explanation of the exit condition - If word has 5 symbols, exit conditon triggers once i reaches 3, because there's no reason to check the exact middle of the string, since there's nothing to compare it to.
            if (inputString[i] != inputString[j])                                           // Compare each letter from start and the end, all the way to the very middle of the input string. If at least a single comparison is NOT equal, that means a given string is NOT a palindrome.
            {
                equalityCheck = false;
                break;
            }
        }
        Console.WriteLine($"{inputString} is" + $"{(equalityCheck ? string.Empty : " NOT")}" + " a palindrome!");
        return inputString;
    }

    public string StringIsPalindromeUsingLINQ(string? inputString)
    {
        // If provided input string is null or empty, we pick 'racecar' as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "racecar" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        if (inputString.SequenceEqual(inputString.Reverse()))
            Console.WriteLine($"{inputString} is a palindrome");
        else
            Console.WriteLine($"{inputString} is NOT a palindrome");

        return inputString;
    }

    public string ReverseOrderOfWordsInSentence(string? inputString)
    {
        // If provided input string is null or empty, we pick 'Collection of coding exercises' as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "  Collection  of coding exercises" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        // Define a starting point of iteration - which is the very end of input string, a placeholder iteration variable, and define a new instance of StringBuilder which we will be using to append and form a new, output string.
        int Start = inputString.Length - 1;
        int End = inputString.Length - 1;
        int i;
        StringBuilder reversedSentence = new StringBuilder();

        // Loop until 'Start' variable reaches the start of the string.
        while (Start > 0)
        {
            if (inputString[Start] == ' ')                      // With each iteration, we check if a given character is a space, if so - we must reverse it.
            {
                i = Start + 1;                                  // Starting point is the character BEFORE the space.             
                while (i <= End)                                // Iterate from the starting point (mentioned above), all the way to the end. For the first word (last in the sentence) End point be end of the entire string, for second word, end will be last letter of the second word itself.
                {
                    reversedSentence.Append(inputString[i]);    // Form our reversed sentence by appending each character from Start to End.
                    i++;                                        // Iterate until we reach End.
                }
                reversedSentence.Append(' ');                   // After we've appended the word, add a space afterwards, since we jumped over it with our indexes. 
                End = Start - 1;                                // Define our new End point - which is the last character of the next word.
            }
            Start--;                                            // Loop backwards until a if condition is met.
        }

        for (i = 0; i <= End; i++)                              // When we reach the beginning of the initial input string - we must add the last word (1st word of the input string).
        {
            reversedSentence.Append(inputString[i]);
        }
        Console.WriteLine($"Reversed string : {reversedSentence}");

        return reversedSentence.ToString();
    }

    public string ReverseOrderOfWordsInSentenceUsingSplitAndStringBuilder(string? inputString)
    {
        // If provided input string is null or empty, we pick 'Collection of coding exercises' as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "  Collection    of coding exercises" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        StringBuilder reversedSentence = new StringBuilder();                        // Instantiate StringBuilder which we will be using to form a new, reversed sentence.
        var splitStringList = inputString.Split(" ").ToList();                       // Split input string by spaces.
                                                                                     
        for (int i = splitStringList.Count - 1; i >= 0; i--)                         // Loop over the list of strings, backwards.
        {                                                                            
            reversedSentence.Append(splitStringList[i] +                             // Form our new, reversed sentence by adding each element of split list, starting from the end of it.
                (i - 1 >= 0 && splitStringList[i - 1] != " " ? " " : string.Empty)); // If next element in line (going backwards, so if current is 7th, we check 6th) is NOT a space (variable over which we split the entire sentence), we add an extra space.
        }                                                                                   // Reason for this is - If two words have a singular space between then, after Split, we "lose" that space, same goes for multiple space - we result in having n-1 amount of spaces.

        Console.WriteLine($"Reversed string : {reversedSentence}");
        return reversedSentence.ToString();
    }
}