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

    public string FindAllSubstringsFromString(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "cube" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        // We'll be using two overlapping loops:
        // First loop starts from 2nd character, and loops to the end of the input string. A
        // And the second, internal loop, will start from 1st character, and exit at earlier and earlier position, while simultaneously taking longer and longer 'chunks' (substrings) or our input string.

        // In other words - First iteration, we'll take one-character-long 'bites' from our input string, and 'bite' all the way to the end of the string.
        // Second iteration - we'll take two-character-long 'bites', but end our iteration one character earlier.

        Console.WriteLine("Listing all possible substrings:");
        for (int i = 1; i <= inputString.Length; i++)
        {
            for (int j = 0; j <= inputString.Length - i; j++)
            {
                Console.WriteLine(inputString.Substring(j, i));
            }
        }

        return inputString;
    }

    public string FindAllSubstringsFromStringUsingStringBuilder(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "cube" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        // We'll be using two overlapping loops:
        // First loop will simply loop from start to finish of our input string.
        // Second loop's start position will constantly will be moving one character forward. End condition is same as first loops - end of the input string.

        for (int i = 0; i < inputString.Length; i++)
        {
            StringBuilder stringBuilder = new StringBuilder();      // Instantiate StringBuilder, whose Append functionality we're going to utilize.
            for (int j = i; j < inputString.Length; j++)
            {
                stringBuilder.Append(inputString[j]);               // Inside the internal loop, we'll be continually forming the same 'string', by Appending the j'th position character to it. Next iteration, StringBuilder is going to be re-instantiated, therefore - "reset"
                Console.WriteLine(stringBuilder);                   // Display to console, an intermediate value.
            }
        }

        return inputString;
    }

    /// <summary>
    /// Words are said to be Anagrams of each other if they share the same set of letters to form the respective words.
    /// For example words 'flow' and 'wolf' are anagrams.
    /// This is a bit more complex solution.
    /// </summary>
    public bool CheckIfWordsAreAnagramsOfEachOther(string[]? inputStrings)
    {
        // If provided input string array is null OR has less than two strings - we provide our own array, which contains three strings.
        inputStrings = (inputStrings == null || inputStrings.Length < 2) ?
                        new string[] { "top", "pot", "otp" } : inputStrings;
        Console.WriteLine("Here's a list of provided strings, to check whether they are anagrams");
        inputStrings.ToList().ForEach(Console.WriteLine);

        bool AreWordsAnagrams = false;

        // Iterate through all words, and check whether they're all the same exact length. If they are not - they simply cant be anagrams.
        for (int i = 0; i < inputStrings.Length - 1; i++)
        {
            if (inputStrings[i].Length != inputStrings[i + 1].Length)
            {
                Console.WriteLine("Provided words aren't all the same length, therefore they can't be anagrams.");
                return AreWordsAnagrams;
            }
        }

        // Create a list of frequencies for each word. Reason for this - we must know how many of each character, each word has, to later determine whether they all share same characters, as well as same number of occurences of those characters.
        List<Dictionary<char, int>> frequenciesList = new List<Dictionary<char, int>>();
        foreach (var word in inputStrings)
        {
            Dictionary<char, int> frequencies = new Dictionary<char, int>();        // Create a dictionary where KEY will be character itself, and VALUE will be number of occurences of that character in a given word.
            foreach (var c in word)
            {
                if (!frequencies.ContainsKey(c))                                    // If dictionary doesn't have a given character - add it.
                {
                    frequencies.Add(c, 0);
                }
                frequencies[c]++;                                                   // Increase the occurence counter of a given character.
            }
            frequenciesList.Add(frequencies);                                       // And this 'local' dictionary to our list of frequencies for later logic to be applied.
        }

        // If all words are same length, and they must share same number of same characters - we can simply iterate over the first word's frequency list, and compare it to remaining words' frequency lists, to determine whether all of those words (2 or more) are anagrams.
        foreach (var key in frequenciesList[0].Keys)                                // Key in this case represent an individual character of a word.
        {
            // One of two conditions will instantly determine whether words are anagrams or not:
            if (!frequenciesList.All(x => x.ContainsKey(key)) ||                    // 1. ALL words must have a given character.
                !frequenciesList.Any(x => x[key] == frequenciesList[0][key]))       // 2. ALL words must have same number of occurences of that character.
            {
                Console.WriteLine("Provided words are NOT anagrams of each other.");
                return AreWordsAnagrams;                                            // If either condition is met - words are NOT anagrams.
            }
        }

        Console.WriteLine("Provided words are indeed anagrams of each other!");
        return AreWordsAnagrams = true;
    }

    public bool CheckIfWordsAreAnagramsOfEachOtherUsingLINQ(string? firstWord, string? secondWord)
    {
        // If provided input strings are null or empty, we pick strings of our choice as our input string.
        firstWord = string.IsNullOrEmpty(firstWord) ? "top" : firstWord;
        secondWord = string.IsNullOrEmpty(secondWord) ? "pot" : secondWord;
        Console.WriteLine($"Input strings are {firstWord} and {secondWord}");

        if (firstWord.OrderBy(a => a).SequenceEqual(secondWord.OrderBy(b => b)))    // We order both words, in alphabetical order, and compare them using SequenceEqual function, which compare whether two sequences of characters are equal.
        {
            Console.WriteLine("Words ARE anagrams of each other!");
            return true;
        }
        else
        {
            Console.WriteLine("Words are NOT anagrams of each other!");
            return false;
        }
    }

    public string FindLongestCommonEndingAmongStrings(string[]? inputStrings)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        // If provided input string array is null OR has less than two strings - we provide our own array, which contains three strings.
        inputStrings = (inputStrings == null || inputStrings.Length < 2) ?
                        new string[] { "allied", "multiplied", "lied" } : inputStrings;
        Console.WriteLine("Here's a list of provided strings, to what is longest common ending among them:");
        inputStrings.ToList().ForEach(Console.WriteLine);

        string longestCommonEnding = string.Empty;                              // We'll save the longest commond ending that appears in every word to a single string variable.
        Dictionary<string, int> endingLengths = new Dictionary<string, int>();  // We'll also be using a dictionary, so save every common ending that appears in every word, and its length.

        foreach (var word in inputStrings)                                      // Iterate through every word in a provided array or strings.
        {
            for (int i = 0; i < word.Length; i++)                               // Iterate through the string's length.
            {
                string ending = word.Substring(i);                              // Substring (cut off) the string from every position, starting at index 0, which creates a substring equivalent to the entire word, next iteration, word without the first letter, etc.
                if (inputStrings.All(x => x.EndsWith(ending))                   // Two conditions must be met, for us to consider the substring a valid selection - ALL words must end with that specific substring, and our dictionary does NOT contain such ending.
                    && !endingLengths.ContainsKey(ending))
                    endingLengths.Add(ending, ending.Length);                   // If condition is met - we add that ending as KEY to our dictionary, and its VALUE is equal to its length.
            }
        }

        if (endingLengths.Count > 0)                                            // If our dictionary is not empty, i.e. There's at least one common ending found between all words, we display it and its length.
        {
            longestCommonEnding = endingLengths.MaxBy(x => x.Value).Key;
            Console.WriteLine($"Longest commond ending among input words is " +
                $"'{longestCommonEnding}' with the length of '{longestCommonEnding.Length}'");
        }
        else
            Console.WriteLine("There are no common ending among the input strings!");           // Otherwise - inform the user that there were no common endings among the provided strings.

        return longestCommonEnding;
    }

    public bool CheckIfStringsHaveAllUniqueCharacters(string[]? inputStrings)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        // If provided input string array is null OR has less than two strings - we provide our own array, which contains three strings.
        inputStrings = (inputStrings == null || inputStrings.Length < 2) ?
                        new string[] { "pizza", "kebab", "taco" } : inputStrings;
        Console.WriteLine("Here's a list of provided strings, to find out whether they individually contain only unique characters:");
        inputStrings.ToList().ForEach(Console.WriteLine);

        Dictionary<string, bool> validityDictionary = new Dictionary<string, bool>();   // We'll be using a dictionary, where KEY will be word itself, and VALUE will be bool which will indicate whether word has or doesn't have ONLY unique characters.

        foreach (var word in inputStrings)                  // Iterate through every word.
        {
            validityDictionary.Add(word, true);             // Initially - add the word to dictionary, and 'temporarily' consider it that has only unique values.
            for (int i = 0; i < word.Length - 1; i++)       // Utilize two loops - first will iterate from 1st, to second to last character.
            {
                for (int j = 1; j <= word.Length - 1; j++)  // Second loop will start from 2nd character, and loop all the way to the end.
                {
                    if (word[i] == word[j] && i != j)       // If we find same character, that is NOT in the same index position - it means we found duplicate character in the same word..
                    {
                        validityDictionary[word] = false;   // In that case - VALUE field of this KEY, to false - indicating that the word, in fact, does NOT contain only unique characters.
                    }
                }
            }
        }

        // Displaying to the console, all words, and whether they do or do NOT contain only unique characters.
        foreach (var word in validityDictionary)
        {
            Console.WriteLine($"Word '{word.Key}' does{(word.Value ? string.Empty : " NOT")} contain only unique characters!");
        }

        return inputStrings.Length == validityDictionary.Where(x => x.Value).Count();   // Our method (For Unit tests) will return true, only if ALL words in the provided array contain only unique characters.
    }

    public bool CheckIfStringsHaveAllUniqueCharactersUtilizingHashSet(string[]? inputStrings)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        // If provided input string array is null OR has less than two strings - we provide our own array, which contains three strings.
        inputStrings = (inputStrings == null || inputStrings.Length < 2) ?
                        new string[] { "pizza", "kebab", "taco" } : inputStrings;
        Console.WriteLine("Here's a list of provided strings, to find out whether they individually contain only unique characters:");
        inputStrings.ToList().ForEach(Console.WriteLine);

        List<string> listOfUniqueCharacterWords = new List<string>();       // List which will hold only words that contain ONLY unique characters.

        foreach (var word in inputStrings)                                  // Iterate through every word.
        {
            HashSet<char> uniqueChars = new HashSet<char>();                // Instantiate a temporary HashSet for every word..
            word.ToList().ForEach(x => uniqueChars.Add(x));                 // And all all characters of that word, to the HashSet - which inherently will ONLY all characters that are NOT present in it.
            if (word.Length == uniqueChars.Count)                           // Which in turn means - that if word's length is equal to the length of HashSet, only then it means that the word contains only unique characters.
                listOfUniqueCharacterWords.Add(word);
        }

        return inputStrings.Length == listOfUniqueCharacterWords.Count();   // Our method (For Unit tests) will return true, only if ALL words in the provided array contain only unique characters.
    }

    public string FindLongestSubstringWithoutRepeatingCharacters(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "Microsoft" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        Dictionary<string, int> substringLengths = new Dictionary<string, int>(); // We'll store substrings, that ONLY contain unique characters.

        // We'll be forming each substring individually, using three loops.
        // First loop simply iterate through every character in a given word.
        // Second and third loop, will iterate from the index of that characters, in a word, to the end of the string, and to the start of the string, respectively.
        // By doing this, we'll check whether our newly being formed substring contains a given character or not. If it doesn't - we'll either Append that character to the end of our substring, or re-form our string by adding character at the very start.
        foreach (char character in inputString)
        {
            string tempSubstring = string.Empty;
            for (int i = inputString.IndexOf(character); i < inputString.Length; i++)   // Iterate from a given character, to the end of the string.
            {
                if (!tempSubstring.Contains(inputString[i]))
                    tempSubstring += inputString[i];
                else break;                                                             // If we found a non-unique character - break out of iteration, so that non-consecutive characters aren't checked/validated.
            }
            for (int j = inputString.IndexOf(character) - 1; j >= 0; j--)
            {
                if (j > 0 && !tempSubstring.Contains(inputString[j]))                   // Iterate from a given characters, to the 0'th index i.e. very beginning of the string.
                    tempSubstring = inputString[j] + tempSubstring;                     // If we found a non-unique character - break out of iteration, so that non-consecutive characters aren't checked/validated.
                else break;
            }
            if (!substringLengths.ContainsKey(tempSubstring))                           // If we dont have such substring in our dictionary - add it.
                substringLengths.Add(tempSubstring, tempSubstring.Length);
        }

        // Utilize LINQ functionality to order the dictionary in descending order (starting from longest strings), and pick the first entry, that contains ONLY distinct values, which will automatically mean we're getting the longest substring (from all possible substrings), that has ONLY unique characters.
        // If our word happens to have two or more substrings with same length - we'll take the first one.
        string longestSubstring = substringLengths.OrderByDescending(x => x.Value).FirstOrDefault().Key;

        Console.WriteLine($"Longest substring without repeating characters is '{longestSubstring}' with the length of {longestSubstring.Length}");

        return longestSubstring;
    }

    public string FindLongestSubstringWithoutRepeatingCharactersByParsingAllPossibleSubstrings(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "pickoutthelongestsubstring" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        Dictionary<string, int> substringLengths = new Dictionary<string, int>();   // We'll store all possible substrings in this one dictionary where KEY will be substring itself, and VALUE will be the length of that substring.

        // Here, we'll actually utilize logic from previous exercise 'Find all the substrings present in a given string' and store all unique substrings and their length as dictionary entries. 
        for (int i = 1; i <= inputString.Length; i++)
        {
            for (int j = 0; j <= inputString.Length - i; j++)
            {
                var tempSubstring = inputString.Substring(j, i);                    // Create a substring.

                if (!substringLengths.ContainsKey(tempSubstring))                   // If its not already present in the dictionary - add it.
                    substringLengths.Add(tempSubstring, tempSubstring.Length);
            }
        }

        // Utilize LINQ functionality to order the dictionary in descending order (starting from longest strings), and pick the first entry, that contains ONLY distinct values, which will automatically mean we're getting the longest substring (from all possible substrings), that has ONLY unique characters.
        // If our word happens to have two or more substrings with same length - we'll take the first one.
        string longestSubstring = substringLengths.OrderByDescending(x => x.Value)
                                                  .FirstOrDefault(p => p.Key.Distinct().Count() == p.Value).Key;
        Console.WriteLine($"Longest substring without repeating characters is '{longestSubstring}' with the length of {longestSubstring.Length}");

        return longestSubstring;
    }

    /// <summary>
    /// Extremely basic solution to an exercise of compressing a string. More complex and versatile solutions normally utilize in-built compression classes.
    /// </summary>
    public string BasicStringCompression(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "000iii?@@@12333???" : inputString;
        Console.WriteLine($"Input string: {inputString} and its byte count is {Encoding.UTF8.GetByteCount(inputString)}");
        string compressedString = string.Empty;

        int countOfOccurences = 1;                      // Variable to count occurences of a given element.
        for (int i = 0; i < inputString.Length; i++)    // Iterate throughout the entire input string
        {
            if ((i != inputString.Length - 1 &&          // If a given characters is NOT last character of the string, and its not the same as the NEXT character in line - means we must continue forming our new, compressed string.
                inputString[i] != inputString[i + 1]) ||
                i == inputString.Length - 1)
            {
                compressedString += inputString[i] +    // Compressed string is being formed by added the current characters and the number of its occurences, cast as string variable. So for example if 'ppp' will be converted to 'p3'
                                    (countOfOccurences > 1 ? countOfOccurences.ToString() : 1.ToString());  // If number of occurences is greater than one, add that number, otherwise - there was only a single occurence of a given character.
                countOfOccurences = 1;
            }
            else
                countOfOccurences++;                    // If current character and the NEXT character in line are the same - simply increase count of occurences, and continue iterating over the string.
        }

        Console.WriteLine($"Input string: {compressedString} and its byte count is {Encoding.UTF8.GetByteCount(compressedString)}");
        return compressedString;
    }

    /// <summary>
    /// Practically an identical solution to 'FibonacciSeriesCalculationAndDisplay' in Numbers category. The only difference is that we're forming an appended string, instead of calculating the numeric value of the next element.
    /// </summary>
    public string FibonacciWord(int? indexOfWord)
    {
        // If index of word isn't provided to the method or is invalid, we pick a random, positive integer number which will indicate which word of our Fibonacci Sequence to retrieve.
        Console.WriteLine("Picking a random number, which will be index of Fibonacci word that we will retrieve");
        indexOfWord = indexOfWord == null || indexOfWord < 2 ? Random.Shared.Next(2, 10) : indexOfWord;
        Console.WriteLine($"Calculating and displaying Fibonacci series for {indexOfWord + 1} elements");

        string fibonacciWord = string.Empty;
        string firstWord = "a";
        string secondWord = "b";
        List<string> fibonacciSequence = new List<string> { firstWord, secondWord };

        for (int i = 2; i <= indexOfWord; i++)
        {
            var nextWord = firstWord + secondWord;
            firstWord = secondWord;
            secondWord = nextWord;
            fibonacciSequence.Add(nextWord);
        }

        // Display our full Fibonacci sequence to console output. Reason for + 1 of elements, is because list indexing starts from zero, so for visual representation, we make sure to start our sequence from 1st number, and not 0'th
        Console.WriteLine($"Displaying Fibonacci sequence elements for {indexOfWord + 1} elements:");
        fibonacciSequence.ForEach(element => Console.WriteLine($"#{fibonacciSequence.IndexOf(element) + 1}\t{element}"));

        return fibonacciSequence.Last();    // Return the last element value of our Fibonacci sequence. (For Unit tests)
    }

    /// <summary>
    /// A simple, yet quite an interesting problem:
    /// Create a function which takes every letter in every word, and puts it in alphabetical order, however, here's the catch - original word lengths must stay the same.
    /// Few notes - All sentences will be in lowercase, and no punctuation or numbers shall be included.
    /// </summary>
    public string TrueAlphabeticalOrder(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "collection of coding exercises" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        List<int> whitespaceIndexes = new List<int>();
        for (int i = 0; i < inputString.Length; i++)
        {
            if (Char.IsWhiteSpace(inputString[i]))
                whitespaceIndexes.Add(i);
        }

        string trueAlphabeticalString = string.Concat(inputString.Replace(" ", "").OrderBy(a => a));

        foreach (int whitespaceIndex in whitespaceIndexes)
            trueAlphabeticalString = trueAlphabeticalString.Insert(whitespaceIndex, " ");

        Console.WriteLine($"New, ordered string, in 'True alphabetical order' - '{trueAlphabeticalString}'");
        return trueAlphabeticalString;
    }

    /// <summary>
    /// A fun little problem to solve - determine whether a given sentence is 'smooth' or not? (See below for details)
    /// A given sentence is considered 'smooth' if each word, starts with the same letter and the last letter of a previous word. Uppercase or lowercase of the same letter are considered to be the same.
    /// For example, a sentence 'Bob built two ornaments' would be a 'smooth' sentence.
    /// For the sake of simplicity, we're going to consider that a given sentence is 'normal' - no multiple spaces, symbols, numbers, etc.
    /// </summary>
    public bool IsSentenceSmooth(string? inputString)
    {
        // If provided input string is null or empty, we pick a string of our choice as our input string.
        inputString = string.IsNullOrEmpty(inputString) ? "Bob built two ornaments" : inputString;
        Console.WriteLine($"Input string: {inputString}");

        bool isSentenceSmooth = true;       // Initialize a boolean variable which will act as a 'switch' to indicate whether our input string is a 'smooth' sentence or not.
        string[] sentenceWords = inputString.Split(" ").ToArray();  // Split our input string, into an array of string, where each element is simply a word from the input string, so that we could iterate over it easily.

        // Loop over every element in out split sentence array, starting from the first element, to the very last one. Reason for starting at index 1, and not zero, is simply because we need to compare current word's first letter, with the previous word's last letter.
        for (int i = 1; i <= sentenceWords.Length - 1; i++)
        {
            // For the sake of simplicity and ease of undertanding - define which word is our current one, and which one is the previous one.
            string previousWord = sentenceWords[i - 1];
            string currentWord = sentenceWords[i];

            // If the current word, DOES NOT start with the same characters, and the previous word's last character - we alternate the boolean value, and break out of the loop, since there's no more need to check further.
            if (!currentWord.ToLower().StartsWith(previousWord[previousWord.Length - 1]))
            {
                isSentenceSmooth = false;
                break;
            }
        }

        // Output to the console window, whether the provided input string is a 'smooth' sentence or not
        Console.WriteLine($"Our input sentence is{(isSentenceSmooth ? "" : " NOT")} a 'smooth' sentence!");
        return isSentenceSmooth;
    }
}