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
        }                                                                                   // Reason for this is - If two words have a singular space between then, after Split, we "lose" that space, same goes for multiple space - we result in having n+1 amount of spaces.

        Console.WriteLine($"Reversed string : {reversedSentence}");
        return reversedSentence.ToString();
    }

    /// <summary>
    /// We need to reverse each word individually without changing its position in the sentence.
    /// </summary>
    public string ReverseEachWordInAString(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice (Preferably with some extra spaces, to test thouroughly) as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "Collection of   coding exercises" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        StringBuilder reversedString = new StringBuilder();                          // Instantiate StringBuilder which we will be using to form a new, reversed sentence.
        List<char> charlist = new List<char>();                                      // Char type list will be used to 'save' words that we'll be reversing.

        for (int i = 0; i < inputString.Length; i++)                                 // Simply iterate over the entire input string.
        {
            if (inputString[i] == ' ' || i == inputString.Length - 1)                // Conditional statement is triggered if we encounter a space OR the very end of the string.
            {
                if (i == inputString.Length - 1)                                     // If we're at the very last character of the string - simply add it to char list (which we will reverse)
                    charlist.Add(inputString[i]);
                for (int j = charlist.Count - 1; j >= 0; j--)                        // Iterate backwards over the char list, and append all values to newly formed reversed string.
                    reversedString.Append(charlist[j]);

                if (i != inputString.Length - 1) reversedString.Append(' ');         // If we're NOT at the very last character of the string - add a space to reverse string, because we've entered conditional if block through it.
                charlist = new List<char>();                                         // Once a given word was reversed, and extra space was added - reset char list by reinstantiating a new instance of same type list.
            }
            else
                charlist.Add(inputString[i]);                                        // If we encounter NOT a space and NOT end of the input string, and whatever character we've encountered to char list (which we will reverse)
        }

        Console.WriteLine($"Reversed string : {reversedString}");
        return reversedString.ToString();
    }

    public string ReverseEachWordInAStringUsingSplitAndStringBuilder(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice (Preferably with some extra spaces, to test thouroughly) as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? " Collection   of   exercises  " : inputString;
        Console.WriteLine($"Input string: {inputString}");

        StringBuilder reversedString = new StringBuilder();                          // Instantiate StringBuilder which we will be using to form a new, reversed sentence.
        var splitStringList = inputString.Split(" ").ToList();                       // Split input string by spaces.

        for (int i = 0; i < splitStringList.Count - 1; i++)                          // Loop over the list of strings, backwards.
        {
            char[] charArray = splitStringList[i].ToCharArray();                     // Convert our word to char array, and call Array Reverse function, later - add it to newly being formed reverse string.
            Array.Reverse(charArray);

            reversedString.Append(new string(charArray) +                            // Form our new, reversed sentence by adding newly reversed word.
                (i + 1 <= splitStringList.Count - 1 &&                               // If next element in line is NOT a space (variable over which we split the entire sentence), we add an extra space.
                splitStringList[i + 1] != " " ? " " : string.Empty));                // Reason for this is - If two words have a singular space between then, after Split, we "lose" that space, same goes for multiple space - we result in having n+1 amount of spaces.
        }

        Console.WriteLine($"Reversed string : {reversedString}");
        return reversedString.ToString();
    }

    public string CharacterOccurrencesInString(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? " Lets count the occurences !" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        Dictionary<char, int> characterCount = new Dictionary<char, int>();          // We will be using Dictionary to save characters and number of occurences in the input string.
                                                                                     // Key will be of type char, which will represent individual character, and value will be of type int, which will be total sum of occurences of that character.
        foreach (var character in inputString)                                       // Iterate over every single character, including spaces, in our input string.
        {
            if (!characterCount.ContainsKey(character))                              // If our Dictionary doesn't contain a Key (character) equal to currently 'selected' ...
                characterCount.Add(character, 1);                                    // We add that character to our Dictionary, and give Value of 1, since its the first occurence we've found.
            else
                characterCount[character]++;                                         // If our Dictionary DOES contain such Key (character), increase its Value by one, since we just encountered another occurence of it.
        }

        Console.WriteLine("Displaying characters and number of their occurences in the input string:");
        foreach (var character in characterCount)
        {
            Console.WriteLine("'{0}' - {1}", character.Key, character.Value);
        }
        return inputString;
    }

    public string CharacterOccurrencesInStringUsingLINQ(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? " Lets count the occurences !" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        var characterCount = inputString
                            .GroupBy(character => character)                // Groups our input string by characters which will represent Key values.
                            .Select(character =>                            // Select each individual character and create a new anonymous type objet, which will hold character value, and count of those characters in a given input string.
                                new
                                {
                                    Character = character.Key,
                                    OccurenceCount = character.Count()
                                });

        Console.WriteLine("Displaying characters and number of their occurences in the input string:");
        characterCount.ToList()
                      .ForEach(x =>                                         // Iterate over every single element in characterCount IEnumerable, and display its Character and OccurenceCount values.
                        Console.WriteLine("'{0}' - {1}", x.Character, x.OccurenceCount));

        return inputString;
    }

    public string CharacterOccurrencesInStringUsingASeparatePlaceholderList(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "Why would you even do this?" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        Dictionary<char, int> characterCount = new Dictionary<char, int>();          // We will be using Dictionary to save characters and number of occurences in the input string.
        List<char> charList = new List<char>();                                      // Create a separate list of chars that we'll be using as a placeholder to count occurences of characters, and simply store final values to the Dictionary.
        charList.AddRange(inputString);

        for (int i = 0; charList.Count > 0; i++)                                            // Each iteration, we increase value of i by one, and loop continues indefinitely, until our placeholder list becomes empty.
        {
            characterCount.Add(charList[0], charList.Where(x => x == charList[0]).Count()); // Every iteration we take the very FIRST character of the input string, and store it as Key to dictionary, and we set Value of that Key equal to the LINQ Count of that character's occurences in our placeholder list of chars.
            charList = charList.Where(x => x != charList[0]).ToList();                      // Afterwards - we remove ALL occurences of that character, from our placeholder list of characters, by re-creating it with a LINQ .Where condition. So our list becomes shorter, and it's length closer to zero.
        }

        Console.WriteLine("Displaying characters and number of their occurences in the input string:");
        foreach (var character in characterCount)
        {
            Console.WriteLine("'{0}' - {1}", character.Key, character.Value);
        }
        return inputString;
    }

    public string RemoveDuplicateCharactersFromString(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "Collection of coding exercises" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        string resultWithoutDuplicates = string.Empty;              // We'll be forming a new string, that will NOT contains any duplicate character values.

        for (int i = 0; i < inputString.Length; i++)                // Iterate through the entire input string.
        {
            if (!resultWithoutDuplicates.Contains(inputString[i]))  // If our result string does not have a given character - append it to our string's end.
                resultWithoutDuplicates += inputString[i];
        }

        Console.WriteLine($"Displaying input string, with duplicate characters removed: {resultWithoutDuplicates}");
        return resultWithoutDuplicates;
    }

    /// <summary>
    /// Tidbit of information about HashSets:
    /// As per Microsoft documentation, found here: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=net-7.0
    /// A HashSet<T> collection is not sorted and cannot contain duplicate elements. If order or element duplication is more important than performance for your application, consider using the List<T> class together with the Sort method.
    /// </summary>
    public string RemoveDuplicateCharactersFromStringUsingHashSet(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "Collection of coding exercises" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        HashSet<char> characters = new HashSet<char>();                 // We define a HashSet which will hold all non-duplicate character values from our input string. 
        foreach (var character in inputString)                          // Iterate through the entire input string, and add every character to the HashSet, which will add the characeter ONLY IF its not currently present in the HashSet.
            characters.Add(character);

        string resultWithoutDuplicates = string.Join("", characters);   // Create a result string, by Joining all characters in HashSet, into a singular string.

        Console.WriteLine($"Displaying input string, with duplicate characters removed: {resultWithoutDuplicates}");
        return resultWithoutDuplicates;
    }

    public string RemoveDuplicateCharactersFromStringLINQ(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "Collection of coding exercises" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        string resultWithoutDuplicates = string.Join("", inputString.ToList().DistinctBy(c => c));  // Instantiate a new string which we will form to be input string, but without duplicates.
                                                                                                    // LINQ's DistinctBy function will return us a collection of non-duplicate elements from the input string, and we'll immediately form a string out of it.
        
        Console.WriteLine($"Displaying input string, with duplicate characters removed: {resultWithoutDuplicates}");
        return resultWithoutDuplicates;
    }
}