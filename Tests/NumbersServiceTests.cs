using Data.Utility;
using Services;

namespace Tests;

public class NumbersServiceTests
{
    private readonly NumbersService numbersService;

    public NumbersServiceTests()
    {
        numbersService = new NumbersService();
    }

    [Fact]
    public void CheckIfNumberIsPrime_CheckIfNumberIsPrimeWithNOTPrimeNumber_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsPrime(6, true));
    }

    [Fact]
    public void CheckIfNumberIsPrime_CheckIfNumberIsPrimeWithAPrimeNumber_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsPrime(29, true));
    }

    [Fact]
    public void FindSumOfDigitsOfAPositiveNumber_FindSumOfDigitsOfAPositiveNumberWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(9, numbersService.FindSumOfDigitsOfAPositiveNumber(18));
    }

    [Fact]
    public void FindSumOfDigitsOfAPositiveNumberParsingThroughEveryDigit_FindSumOfDigitsOfAPositiveNumberParsingThroughEveryDigitWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(2, numbersService.FindSumOfDigitsOfAPositiveNumberParsingThroughEveryDigit(11));
    }

    [Fact]
    public void FindSumOfDigitsOfAPositiveNumberUsingLINQ_FindSumOfDigitsOfAPositiveNumberUsingLINQWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(10, numbersService.FindSumOfDigitsOfAPositiveNumberUsingLINQ(91));
    }

    [Fact]
    public void FindFactorialOfAPositiveNumber_FindFactorialOfAPositiveNumberWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(120, numbersService.FindFactorialOfAPositiveNumber(5));
    }

    [Fact]
    public void FindFactorialOfAPositiveNumberUsingRecursion_FindFactorialOfAPositiveNumberUsingRecursionWithValidParameter_ExitsRecursionAndReturnsNull()
    {
        Assert.Null(numbersService.FindFactorialOfAPositiveNumberUsingRecursion(null, null));
    }

    [Fact]
    public void FindFactorialOfAPositiveNumberUsingWhileLoop_FindSumOfDigitsOfAPositiveNumberUsingLINQWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(362880, numbersService.FindFactorialOfAPositiveNumberUsingWhileLoop(9));
    }

    [Fact]
    public void FibonacciSeriesCalculationAndDisplay_FibonacciSeriesCalculationAndDisplayWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(8, numbersService.FibonacciSeriesCalculationAndDisplay(6));
    }

    [Fact]
    public void CheckIfNumberIsArmstrong_FibonacciSeriesCalculationAndDisplayWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsArmstrong(371));
    }

    [Fact]
    public void CheckIfNumberIsArmstrong_FibonacciSeriesCalculationAndDisplayWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsArmstrong(333));
    }

    [Fact]
    public void CheckIfNumberIsArmstrongUsingRemainder_FibonacciSeriesCalculationAndDisplayWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsArmstrongUsingRemainder(371));
    }

    [Fact]
    public void CheckIfNumberIsArmstrongUsingRemainder_FibonacciSeriesCalculationAndDisplayWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsArmstrongUsingRemainder(333));
    }

    [Fact]
    public void NumberIsPalindrome_NumberIsPalindromeWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.NumberIsPalindrome(636));
    }

    [Fact]
    public void NumberIsPalindrome_NumberIsPalindromeWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.NumberIsPalindrome(123));
    }

    [Fact]
    public void NumberIsPalindromeUsingRemaider_NumberIsPalindromeUsingRemaiderWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.NumberIsPalindromeUsingRemaider(636));
    }

    [Fact]
    public void NumberIsPalindromeUsingRemaider_NumberIsPalindromeUsingRemaiderWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.NumberIsPalindromeUsingRemaider(123));
    }

    [Fact]
    public void FindAngleBetweenClockArrows_FindAngleBetweenClockArrowsWithValidParameter_ReturnsTrue()
    {
        Assert.Equal(108, numbersService.FindAngleBetweenClockArrows(15, 36));
    }

    [Fact]
    public void FindFactorsOfANumber_FindFactorsOfANumberWithValidParameter_ReturnsTrue()
    {
        Assert.Equal(new List<int>() { 1, 2, 3, 5, 6, 10, 15, 30 },
            numbersService.FindFactorsOfANumber(30));
    }

    [Fact]
    public void NumberPrimeStrength_NumberPrimeStrengthWithValidParameter_ReturnsNull()
    {
        Assert.Null(numbersService.PrimeNumberStrength(66));
    }

    [Fact]
    public void NumberPrimeStrength_NumberPrimeStrengthWithValidParameterBalancedPrime_ReturnsValidAnswer()
    {
        Assert.Equal("Balanced", numbersService.PrimeNumberStrength(5));
    }

    [Fact]
    public void NumberPrimeStrength_NumberPrimeStrengthWithValidParameterWeakPrime_ReturnsValidAnswer()
    {
        Assert.Equal("Weak", numbersService.PrimeNumberStrength(83));
    }

    [Fact]
    public void NumberPrimeStrength_NumberPrimeStrengthWithValidParameterStrongPrime_ReturnsValidAnswer()
    {
        Assert.Equal("Strong", numbersService.PrimeNumberStrength(37));
    }

    [Fact]
    public void FindNthElementOfUlamSequence_FindNthElementOfUlamSequenceWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(16, numbersService.FindNthElementOfUlamSequence(9));
    }

    [Fact]
    public void CollatzConjectureProblem_CollatzConjectureProblemWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(17, numbersService.CollatzConjectureProblem(15));
        Assert.Equal(111, numbersService.CollatzConjectureProblem(27));
    }

    [Fact]
    public void IsNumberHarshadOrMoran_IsNumberHarshadOrMoranWithValidParameter_ReturnsMoran()
    {
        Assert.Equal("Moran", numbersService.IsNumberHarshadOrMoran(133));
    }

    [Fact]
    public void IsNumberHarshadOrMoran_IsNumberHarshadOrMoranWithValidParameter_ReturnsHarshad()
    {
        Assert.Equal("Harshad", numbersService.IsNumberHarshadOrMoran(102));
    }

    [Fact]
    public void IsNumberHarshadOrMoran_IsNumberHarshadOrMoranWithValidParameter_ReturnsNeither()
    {
        Assert.Equal("Neither", numbersService.IsNumberHarshadOrMoran(32));
    }

    [Fact]
    public void CheckIfNumberHasABreakpoint_CheckIfNumberHasABreakpointWithValidParameter_ReturnsHasBreakpoint()
    {
        Assert.True(numbersService.CheckIfNumberHasABreakpoint(159780));
    }

    [Fact]
    public void CheckIfNumberHasABreakpoint_CheckIfNumberHasABreakpointWithValidParameter_ReturnsDoesntHaveBreakpoint()
    {
        Assert.False(numbersService.CheckIfNumberHasABreakpoint(10));
    }

    [Fact]
    public void LookAndSaySequence_LookAndSaySequenceWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal("132117132110", numbersService.LookAndSaySequence(70, 4));
        Assert.Equal("13112221", numbersService.LookAndSaySequence(1, 6));
    }

    [Fact]
    public void KaprekarsConstantProblem_KaprekarsConstantProblemWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(3, numbersService.KaprekarsConstantProblem(4159));
    }

    [Fact]
    public void CheckIfNumberIsDisarium_CheckIfNumberIsDisariumWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsDisarium(518));
    }

    [Fact]
    public void CheckIfNumberIsDisarium_CheckIfNumberIsDisariumWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsDisarium(516));
    }

    [Fact]
    public void NBonacciNumberSequenceCalculationAndDisplay_NBonacciNumberSequenceCalculationAndDisplayWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(29, numbersService.NBonacciNumberSequenceCalculationAndDisplay(9, 4));
    }

    [Fact]
    public void CheckIfNumberIsGapful_CheckIfNumberIsGapfulWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsGapful(260));
    }

    [Fact]
    public void CheckIfNumberIsGapful_CheckIfNumberIsGapfulWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsGapful(1234));
    }

    [Fact]
    public void CheckIfNumberIsAlternating_CheckIfNumberIsAlternatingWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsAlternating(1234));
    }

    [Fact]
    public void CheckIfNumberIsAlternating_CheckIfNumberIsAlternatingWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsAlternating(5466));
    }

    [Fact]
    public void NumberPersistenceProblem_NumberPersistenceProblemMultiplicativePersistence_ReturnsValidAnswer()
    {
        Assert.Equal(4, numbersService.NumberPersistenceProblem(NumberPersistence.Multiplicative, 77));
    }

    [Fact]
    public void NumberPersistenceProblem_NumberPersistenceProblemAdditivePersistence_ReturnsValidAnswer()
    {
        Assert.Equal(3, numbersService.NumberPersistenceProblem(NumberPersistence.Additive, 1679583));
    }

    [Fact]
    public void CheckIfNumberIsPronic_CheckIfNumberIsPronicWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsPronic(156));
    }

    [Fact]
    public void CheckIfNumberIsPronic_CheckIfNumberIsPronicWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsPronic(7));
    }

    [Fact]
    public void CheckIfNumberIsPandigital_CheckIfNumberIsPandigitalWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsPandigital(1023456789));
    }

    [Fact]
    public void CheckIfNumberIsPandigital_CheckIfNumberIsPandigitalWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsPandigital(12345111));
    }

    [Fact]
    public void CheckIfNumberIsPandigitalUsingLINQ_CheckIfNumberIsPandigitalUsingLINQWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsPandigitalUsingLINQ(1023456789));
    }

    [Fact]
    public void CheckIfNumberIsPandigitalUsingLINQ_CheckIfNumberIsPandigitalUsingLINQWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsPandigitalUsingLINQ(55522131));
    }

    [Fact]
    public void CheckIfNumberIsSlidey_CheckIfNumberIsSlideyWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsSlidey(65454321));
    }

    [Fact]
    public void CheckIfNumberIsSlidey_CheckIfNumberIsSlideyWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsSlidey(123476641));
    }

    [Fact]
    public void DigitsBattle_DigitsBattleWithEquivalentPairs_ReturnsValidAnswer()
    {
        Assert.Null(numbersService.DigitsBattle(112233));
    }

    [Fact]
    public void DigitsBattle_DigitsBattleWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(7925, numbersService.DigitsBattle(578921445));
    }

    [Fact]
    public void CheckIfNumberIsZygodrome_CheckIfNumberIsZygodromeWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsZygodrome(7777333));
    }

    [Fact]
    public void CheckIfNumberIsZygodrome_CheckIfNumberIsZygodromeWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsZygodrome(2251153));
    }

    [Fact]
    public void CheckIfNumberIsPolydivisible_CheckIfNumberIsPolydivisibleWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsPolydivisible(1232));
    }

    [Fact]
    public void CheckIfNumberIsPolydivisible_CheckIfNumberIsPolydivisibleWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsPolydivisible(123220));
    }

    [Fact]
    public void SuperdNumber_SuperdNumberWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal("Super-4 Number", numbersService.SuperdNumber(1168));
    }

    [Fact]
    public void CheckIfNumberIsHappy_CheckIfNumberIsHappyWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsHappy(5659));
    }

    [Fact]
    public void CheckIfNumberIsHappy_CheckIfNumberIsHappyWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsHappy(2871));
    }

    [Fact]
    public void CheckIfNumberIsUnprimeable_CheckIfNumberIsUnprimeableWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsUnprimeable(970));
    }

    [Fact]
    public void CheckIfNumberIsUnprimeable_CheckIfNumberIsUnprimeableWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsUnprimeable(6657));
    }

    [Fact]
    public void GoodEvilOrNeutralNumber_GoodEvilOrNeutralNumberWithValidParameter_ReturnsGood()
    {
        Assert.Equal("Good", numbersService.GoodEvilOrNeutralNumber(3252));
    }

    [Fact]
    public void GoodEvilOrNeutralNumber_GoodEvilOrNeutralNumberWithValidParameter_ReturnsEvil()
    {
        Assert.Equal("Evil", numbersService.GoodEvilOrNeutralNumber(2013));
    }

    [Fact]
    public void GoodEvilOrNeutralNumber_GoodEvilOrNeutralNumberWithValidParameter_ReturnsNeutralGood()
    {
        Assert.Equal("Neutral Good", numbersService.GoodEvilOrNeutralNumber(17));
    }

    [Fact]
    public void GoodEvilOrNeutralNumber_GoodEvilOrNeutralNumberWithValidParameter_ReturnsNeutralEvil()
    {
        Assert.Equal("Neutral Evil", numbersService.GoodEvilOrNeutralNumber(7));
    }

    [Fact]
    public void CheckIfNumberIsApocalyptic_CheckIfNumberIsApocalypticWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(9, numbersService.CheckIfNumberIsApocalyptic(157));
    }

    [Fact]
    public void CheckIfNumberIsApocalyptic_CheckIfNumberIsApocalypticWithValidParameter_ReturnsNull()
    {
        Assert.Null(numbersService.CheckIfNumberIsApocalyptic(109));
    }
}