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
}