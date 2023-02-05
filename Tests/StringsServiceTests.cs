using Services;

namespace Tests;

public class StringsServiceTests
{
    private readonly StringsService stringsService;

    public StringsServiceTests()
    {
        stringsService = new StringsService();
    }

    [Fact]
    public void ReverseAString_ReverseAStringWithValidParameter_ReturnsReversedString()
    {
        Assert.Equal("!dlrow olleH", stringsService.ReverseAString("Hello world!"));
    }

    [Fact]
    public void ReverseAString_ReverseAStringWithNullParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal("!dlrow olleH", stringsService.ReverseAString(null));
    }

    [Fact]
    public void ReverseAStringUsingArrayReverse_ReverseAStringUsingArrayReverseWithValidParameter_ReturnsReversedString()
    {
        Assert.Equal("!dlrow olleH", stringsService.ReverseAStringUsingArrayReverse("Hello world!"));
    }

    [Fact]
    public void ReverseAStringUsingArrayReverse_ReverseAStringUsingArrayReverseWithNullParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal("!dlrow olleH", stringsService.ReverseAStringUsingArrayReverse(null));
    }

    [Fact]
    public void ReverseAStringUsingLINQ_ReverseAStringUsingLINQWithValidParameter_ReturnsReversedString()
    {
        Assert.Equal("!dlrow olleH", stringsService.ReverseAStringUsingLINQ("Hello world!"));
    }

    [Fact]
    public void ReverseOrderOfWordsInSentence_ReverseOrderOfWordsInSentenceWithNullParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal("exercises coding of  Collection  ", stringsService.ReverseOrderOfWordsInSentence(null));
    }

    [Fact]
    public void ReverseOrderOfWordsInSentence_ReverseOrderOfWordsInSentenceWithValidParameter_ReturnsReversedString()
    {
        Assert.Equal("great!  is Pizza", stringsService.ReverseOrderOfWordsInSentence("Pizza is  great!"));
    }

    [Fact]
    public void ReverseOrderOfWordsInSentenceUsingSplitAndStringBuilder_ReverseOrderOfWordsInSentenceWithNullParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal("exercises coding of    Collection  ", stringsService.ReverseOrderOfWordsInSentenceUsingSplitAndStringBuilder("  Collection    of coding exercises"));
    }

    [Fact]
    public void ReverseOrderOfWordsInSentenceUsingSplitAndStringBuilder_ReverseOrderOfWordsInSentenceWithValidParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal("great!  is Pizza", stringsService.ReverseOrderOfWordsInSentenceUsingSplitAndStringBuilder("Pizza is  great!"));
    }

    [Fact]
    public void ReverseEachWordInAString_ReverseEachWordInAStringWithNullParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal("noitcelloC fo   gnidoc sesicrexe", stringsService.ReverseEachWordInAString(null));
    }

    [Fact]
    public void ReverseEachWordInAString_ReverseEachWordInAStringWithValidParameter_ReturnsReversedString()
    {
        Assert.Equal("sihT   ecnetnes si rof    tinu tset  ", stringsService.ReverseEachWordInAString("This   sentence is for    unit test  "));
    }

    [Fact]
    public void ReverseEachWordInAStringUsingSplitAndStringBuilder_ReverseEachWordInAStringWithNullParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal(" noitcelloC   fo   sesicrexe  ", stringsService.ReverseEachWordInAStringUsingSplitAndStringBuilder(null));
    }

    [Fact]
    public void ReverseEachWordInAStringUsingSplitAndStringBuilder_ReverseEachWordInAStringWithValidParameter_ReturnsReversedString()
    {
        Assert.Equal("sihT   ecnetnes si rof    tinu tset  ", stringsService.ReverseEachWordInAStringUsingSplitAndStringBuilder("This   sentence is for    unit test  "));
    }

    [Fact]
    public void RemoveDuplicateCharactersFromString_RemoveDuplicateCharactersFromNullParameter_ReturnsDefaultedString()
    {
        Assert.Equal("Colectin fdgxrs", stringsService.RemoveDuplicateCharactersFromString("Collection of coding exercises"));
    }

    [Fact]
    public void RemoveDuplicateCharactersFromString_RemoveDuplicateCharactersFromValidParameter_ReturnsStringWithoutDuplicates()
    {
        Assert.Equal("Botle fwar", stringsService.RemoveDuplicateCharactersFromString("Bottle of water"));
    }

    [Fact]
    public void RemoveDuplicateCharactersFromStringUsingHashSet_RemoveDuplicateCharactersFromNullParameter_ReturnsDefaultedString()
    {
        Assert.Equal("Colectin fdgxrs", stringsService.RemoveDuplicateCharactersFromStringUsingHashSet("Collection of coding exercises"));
    }

    [Fact]
    public void RemoveDuplicateCharactersFromStringUsingHashSet_RemoveDuplicateCharactersFromValidParameter_ReturnsStringWithoutDuplicates()
    {
        Assert.Equal("Botle fwar", stringsService.RemoveDuplicateCharactersFromStringUsingHashSet("Bottle of water"));
    }

    [Fact]
    public void RemoveDuplicateCharactersFromStringLINQ_RemoveDuplicateCharactersFromNullParameter_ReturnsDefaultedString()
    {
        Assert.Equal("Colectin fdgxrs", stringsService.RemoveDuplicateCharactersFromStringLINQ("Collection of coding exercises"));
    }

    [Fact]
    public void RemoveDuplicateCharactersFromStringLINQ_RemoveDuplicateCharactersFromValidParameter_ReturnsStringWithoutDuplicates()
    {
        Assert.Equal("Botle fwar", stringsService.RemoveDuplicateCharactersFromStringLINQ("Bottle of water"));
    }

    [Fact]
    public void CheckIfWordsAreAnagramsOfEachOther_CheckIfWordsAreAnagramsOfEachOtherWithNullParameter_ReturnsTrue()
    {
        Assert.True(stringsService.CheckIfWordsAreAnagramsOfEachOther(null));
    }

    [Fact]
    public void CheckIfWordsAreAnagramsOfEachOther_CheckIfWordsAreAnagramsOfEachOtherWithValidAnagramsParameter_ReturnsTrue()
    {
        Assert.True(stringsService.CheckIfWordsAreAnagramsOfEachOther(new string[] { "aab", "baa", "aba" }));
    }

    [Fact]
    public void CheckIfWordsAreAnagramsOfEachOther_CheckIfWordsAreAnagramsOfEachOtherWithNotValidAnagramsParameter_ReturnsFalse()
    {
        Assert.False(stringsService.CheckIfWordsAreAnagramsOfEachOther(new string[] { "aaa", "bbb", "bba" }));
    }

    [Fact]
    public void CheckIfWordsAreAnagramsOfEachOtherUsingLINQ_CheckIfWordsAreAnagramsOfEachOtherWithNullParameter_ReturnsTrue()
    {
        Assert.True(stringsService.CheckIfWordsAreAnagramsOfEachOtherUsingLINQ(null, string.Empty));
    }

    [Fact]
    public void CheckIfWordsAreAnagramsOfEachOtherUsingLINQ_CheckIfWordsAreAnagramsOfEachOtherWithValidAnagramsParameter_ReturnsTrue()
    {
        Assert.True(stringsService.CheckIfWordsAreAnagramsOfEachOtherUsingLINQ("flow", "wolf"));
    }

    [Fact]
    public void CheckIfWordsAreAnagramsOfEachOtherUsingLINQ_CheckIfWordsAreAnagramsOfEachOtherWithNotValidAnagramsParameter_ReturnsFalse()
    {
        Assert.False(stringsService.CheckIfWordsAreAnagramsOfEachOtherUsingLINQ("wolf", "fox"));
    }

    [Fact]
    public void FindLongestCommonEndingAmongStrings_FindLongestCommonEndingWithNullParameter_ReturnsDefaultLongestCommonEnding()
    {
        Assert.Equal("lied", stringsService.FindLongestCommonEndingAmongStrings(null));
    }

    [Fact]
    public void FindLongestCommonEndingAmongStrings_FindLongestCommonEndingWithValidParameter_ReturnsLongestCommonEnding()
    {
        Assert.Equal("own", stringsService.FindLongestCommonEndingAmongStrings(new string[] { "own", "town", "grown" }));
    }

    [Fact]
    public void FindLongestCommonEndingAmongStrings_FindLongestCommonEndingWithValidParameterButNoCommonEnding_ReturnsStringEmpty()
    {
        Assert.Equal(string.Empty, stringsService.FindLongestCommonEndingAmongStrings(new string[] { "box", "rat", "hello" }));
    }

    [Fact]
    public void CheckIfStringsHaveAllUniqueCharacters_CheckIfStringsHaveAllUniqueCharactersWithValidParameterAndAllHaveOnlyUnique_ReturnsTrue()
    {
        Assert.True(stringsService.CheckIfStringsHaveAllUniqueCharacters(new string[] { "box", "rat", "day" }));
    }

    [Fact]
    public void CheckIfStringsHaveAllUniqueCharacters_CheckIfStringsHaveAllUniqueCharactersWithValidParameterAndNoneHaveUnique_ReturnsFalse()
    {
        Assert.False(stringsService.CheckIfStringsHaveAllUniqueCharacters(new string[] { "hello", "  ", "strings" }));
    }

    [Fact]
    public void CheckIfStringsHaveAllUniqueCharactersUtilizingHashSet_CheckIfStringsHaveAllUniqueCharactersUtilizingHashSetWithValidParameterAndAllHaveOnlyUnique_ReturnsTrue()
    {
        Assert.True(stringsService.CheckIfStringsHaveAllUniqueCharacters(new string[] { "box", "rat", "day" }));
    }

    [Fact]
    public void CheckIfStringsHaveAllUniqueCharactersUtilizingHashSet_CheckIfStringsHaveAllUniqueCharactersUtilizingHashSetWithValidParameterAndNoneHaveUnique_ReturnsFalse()
    {
        Assert.False(stringsService.CheckIfStringsHaveAllUniqueCharacters(new string[] { "hello", "  ", "strings" }));
    }

    [Fact]
    public void FindLongestSubstringWithoutRepeatingCharacters_FindLongestSubstringWithoutRepeatingCharactersWithNullParameter_ReturnsDefaultLongestSubstring()
    {
        Assert.Equal("Micros", stringsService.FindLongestSubstringWithoutRepeatingCharacters(null));
    }

    [Fact]
    public void FindLongestSubstringWithoutRepeatingCharacters_FindLongestSubstringWithoutRepeatingCharactersWithValidParameter_ReturnsLongestSubstring()
    {
        Assert.Equal("ABCDEF", stringsService.FindLongestSubstringWithoutRepeatingCharacters("ABCDEFFG"));
    }

    [Fact]
    public void FindLongestSubstringWithoutRepeatingCharactersByParsingAllPossibleSubstrings_FindLongestSubstringWithoutRepeatingCharactersByParsingAllPossibleSubstringsWithNullParameter_ReturnsDefaultLongestSubstring()
    {
        Assert.Equal("ubstring", stringsService.FindLongestSubstringWithoutRepeatingCharactersByParsingAllPossibleSubstrings(null));
    }

    [Fact]
    public void FindLongestSubstringWithoutRepeatingCharactersByParsingAllPossibleSubstrings_FindLongestSubstringWithoutRepeatingCharactersByParsingAllPossibleSubstringsWithValidParameter_ReturnsLongestSubstring()
    {
        Assert.Equal("ABCDEF", stringsService.FindLongestSubstringWithoutRepeatingCharactersByParsingAllPossibleSubstrings("ABCDEFFG"));
    }

    [Fact]
    public void BasicStringCompression_BasicStringCompressionWithValidParameter_ReturnsCompressedString()
    {
        Assert.Equal("?223k12311k243", stringsService.BasicStringCompression("??222k2221kk444"));
    }

    [Fact]
    public void FibonacciWord_FibonacciWordWithValidParameter_ReturnsCompressedString()
    {
        Assert.Equal("abbabbababbab", stringsService.FibonacciWord(6));
    }

    [Fact]
    public void TrueAlphabeticalOrder_TrueAlphabeticalOrderWithValidParameter_ReturnsOrderedString()
    {
        Assert.Equal("aaac d eehi nvy", stringsService.TrueAlphabeticalOrder("have a nice day"));
    }

    [Fact]
    public void IsSentenceSmooth_IsSentenceSmoothWithValidParameterSmoothSentence_ReturnsTrue()
    {
        Assert.True(stringsService.IsSentenceSmooth("Show was shocking"));
    }

    [Fact]
    public void IsSentenceSmooth_IsSentenceSmoothWithValidParameterNotSmoothSentence_ReturnsFalse()
    {
        Assert.False(stringsService.IsSentenceSmooth("Collection of coding exercises"));
    }

    [Fact]
    public void FindLongestAbecedarianWord_FindLongestAbecedarianWordValidParameterNoAbecedarianWords_ReturnsStringEmpty()
    {
        Assert.Equal(string.Empty, stringsService.FindLongestAbecedarianWord(new string[] { "apple", "pear", "orange" }));
    }

    [Fact]
    public void FindLongestAbecedarianWord_FindLongestAbecedarianWordValidParameter_ReturnsCorrectWord()
    {
        Assert.Equal("choppy", stringsService.FindLongestAbecedarianWord(new string[] { "forty", "choppy", "ghost" }));
    }

    [Fact]
    public void CheckIfStringContainsAdditiveNumberSequence_CheckIfStringContainsAdditiveNumberSequenceWithValidParameter_ReturnsTrue()
    {
        Assert.True(stringsService.CheckIfStringContainsAdditiveNumberSequence("11223355"));
    }

    [Fact]
    public void CheckIfStringContainsAdditiveNumberSequence_CheckIfStringContainsAdditiveNumberSequenceWithValidParameter_ReturnsFalse()
    {
        Assert.False(stringsService.CheckIfStringContainsAdditiveNumberSequence("12345678"));
    }

    [Fact]
    public void GrowingAndShrinkingPotions_GrowingAndShrinkingPotionsWithValidParameter_ReturnsValidResult()
    {
        Assert.Equal("47751", stringsService.GrowingAndShrinkingPotions("3A78B51"));
    }

    [Fact]
    public void GrowingAndShrinkingPotionsSimplified_GrowingAndShrinkingPotionsSimplifiedWithValidParameter_ReturnsValidResult()
    {
        Assert.Equal("10123", stringsService.GrowingAndShrinkingPotionsSimplified("9A123"));
    }

    [Fact]
    public void CheckIfStringsContainShadowSentences_CheckIfStringsContainShadowSentencesWithValidParameter_ReturnsTrue()
    {
        Assert.True(stringsService.CheckIfStringsContainShadowSentences(new string[] { "tea was cold", "buy the wine" }));
    }

    [Fact]
    public void CheckIfStringsContainShadowSentences_CheckIfStringsContainShadowSentencesWithValidParameterThreeSentences_ReturnsTrue()
    {
        Assert.True(stringsService.CheckIfStringsContainShadowSentences(new string[] { "ab cd ef", "cd ef ab", "ef ab cd" }));
    }

    [Fact]
    public void CheckIfStringsContainShadowSentences_CheckIfStringsContainShadowSentencesWithValidParameter_ReturnsFalse()
    {
        Assert.False(stringsService.CheckIfStringsContainShadowSentences(new string[] { "saturday the fourth", "sunday the fifth" }));
    }

    [Fact]
    public void ReplaceEveryNthInstanceOfACharacter_ReplaceEveryNthInstanceOfACharacterWithValidParameter_ReturnsValidResult()
    {
        Assert.Equal("qolleqtion of qoding exerqises", stringsService.ReplaceEveryNthInstanceOfACharacter("collection of coding exercises", 1, 'c', 'q'));
    }

    [Fact]
    public void ReplaceEveryNthInstanceOfACharacter_ReplaceEveryNthInstanceOfACharacterWithNullParameter_ReturnsValidResult()
    {
        Assert.Equal("The boxk has a lot xf pages!", stringsService.ReplaceEveryNthInstanceOfACharacter(null, null, null, null));
    }
}