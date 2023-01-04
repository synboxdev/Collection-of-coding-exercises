namespace Services.Interfaces;

public interface IStringsService
{
    public string ReverseAString(string? inputString);
    public string ReverseAStringUsingArrayReverse(string? inputString);
    public string ReverseAStringUsingLINQ(string? inputString);
    public string StringIsPalindrome(string? inputString);
    public string StringIsPalindromeUsingLINQ(string? inputString);
    public string ReverseOrderOfWordsInSentence(string? inputString);
    public string ReverseOrderOfWordsInSentenceUsingSplitAndStringBuilder(string? inputString);
    public string ReverseEachWordInAString(string? inputString);
    public string ReverseEachWordInAStringUsingSplitAndStringBuilder(string? inputString);
    public string CharacterOccurrencesInString(string? inputString);
    public string CharacterOccurrencesInStringUsingLINQ(string? inputString);
    public string CharacterOccurrencesInStringUsingASeparatePlaceholderList(string? inputString);
    public string RemoveDuplicateCharactersFromString(string? inputString);
    public string RemoveDuplicateCharactersFromStringUsingHashSet(string? inputString);
    public string RemoveDuplicateCharactersFromStringLINQ(string? inputString);
    public string FindAllSubstringsFromString(string? inputString);
    public string FindAllSubstringsFromStringUsingStringBuilder(string? inputString);
    public bool CheckIfWordsAreAnagramsOfEachOther(string[]? inputStrings);
    public bool CheckIfWordsAreAnagramsOfEachOtherUsingLINQ(string? firstWord, string? secondWord);
    public string FindLongestCommonEndingAmongStrings(string[]? inputStrings);
    public bool CheckIfStringsHaveAllUniqueCharacters(string[]? inputStrings);
    public bool CheckIfStringsHaveAllUniqueCharactersUtilizingHashSet(string[]? inputStrings);
    public string FindLongestSubstringWithoutRepeatingCharacters(string? inputString);
    public string FindLongestSubstringWithoutRepeatingCharactersByParsingAllPossibleSubstrings(string? inputString);
    public string BasicStringCompression(string? inputString);
    public string FibonacciWord(int? indexOfWord);
    public string TrueAlphabeticalOrder(string? inputString);
    public bool IsSentenceSmooth(string? inputString);
}