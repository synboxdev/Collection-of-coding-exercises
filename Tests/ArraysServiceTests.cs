using Services;

namespace Tests;

public class ArraysServiceTests
{
    private readonly ArraysService arraysService;

    public ArraysServiceTests()
    {
        arraysService = new ArraysService();
    }

    [Fact]
    public void RotateArray_RotateArrayWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(new int[] { 7, 8, 4, 5, 6 },
            arraysService.RotateArray(new int[] { 4, 5, 6, 7, 8 }, 2, Data.Utility.RotationDirection.Right));
    }

    [Fact]
    public void RotateArrayUsingPlaceholderVariable_RotateArrayUsingPlaceholderVariableWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(new int[] { 8, 4, 5, 6, 7 },
            arraysService.RotateArrayUsingPlaceholderVariable(new int[] { 4, 5, 6, 7, 8 }));
    }

    [Fact]
    public void RotateArrayRightGivenAPivotUsingLoops_RotateArrayRightGivenAPivotUsingLoopsWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(new int[] { 6, 7, 8, 4, 5 },
            arraysService.RotateArrayRightGivenAPivotUsingLoops(new int[] { 4, 5, 6, 7, 8 }, 2));
    }

    [Fact]
    public void RotateArrayRightGivenAPivotUsingLINQ_RotateArrayRightGivenAPivotUsingLINQWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(new int[] { 0, 5, 7, 8, 9 },
            arraysService.RotateArrayRightGivenAPivotUsingLINQ(new int[] { 7, 8, 9, 0, 5 }, 3));
    }

    [Fact]
    public void Convert2DArrayInto1DArrayRowWise_Convert2DArrayInto1DArrayRowWiseWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(new int[] { 1, 2, 3, 4, 5, 6 },
            arraysService.Convert2DArrayInto1DArrayRowWise(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } }));
    }

    [Fact]
    public void Convert2DArrayInto1DArrayColumnWise_Convert2DArrayInto1DArrayColumnWiseWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(new int[] { 1, 4, 2, 5, 3, 6 },
            arraysService.Convert2DArrayInto1DArrayColumnWise(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } }));
    }

    [Fact]
    public void Convert1DArrayInto2DArrayRowWise_Convert1DArrayInto2DArrayRowWiseWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } },
            arraysService.Convert1DArrayInto2DArrayRowWise(new int[] { 1, 2, 3, 4, 5, 6 }, 3, 2));
    }

    [Fact]
    public void Convert1DArrayInto2DArrayColumnWise_Convert1DArrayInto2DArrayColumnWiseWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } },
            arraysService.Convert1DArrayInto2DArrayRowWise(new int[] { 1, 2, 3, 4, 5, 6 }, 2, 3));
    }

    [Fact]
    public void FindTwoIntegersInArrayThatEqualToAGivenSum_FindTwoIntegersInArrayThatEqualToAGivenSumWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(new int[] { 20, 100 },
            arraysService.FindTwoIntegersInArrayThatEqualToAGivenSum(new int[] { 10, 20, 30, 40, 80, 100 }, 120));
    }

    [Fact]
    public void FindTwoIntegersInArrayThatEqualToAGivenSumUsingLINQ_FindTwoIntegersInArrayThatEqualToAGivenSumUsingLINQWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(new int[] { 20, 100 },
            arraysService.FindTwoIntegersInArrayThatEqualToAGivenSumUsingLINQ(new int[] { 10, 20, 30, 40, 80, 100 }, 120));
    }

    [Fact]
    public void MoveZerosToEndOfArray_MoveZerosToEndOfArrayWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(new int[] { 12, 24, 32, 14, 54, 0, 0 },
            arraysService.MoveZerosToEndOfArray(new int[] { 12, 0, 0, 24, 32, 14, 54 }));
    }

    [Fact]
    public void MoveZerosToEndOfArrayUsingLINQ_MoveZerosToEndOfArrayUsingLINQWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(new int[] { 54, 32, 24, 14, 12, 0, 0 },
            arraysService.MoveZerosToEndOfArrayUsingLINQ(new int[] { 12, 0, 0, 24, 32, 14, 54 }));
    }

    [Fact]
    public void FindMajorityElementInAnArray_FindMajorityElementInAnArrayWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(12, arraysService.FindMajorityElementInAnArray(new int[] { 12, 12, 0, 12, 2, 12, 54 }));
    }

    [Fact]
    public void FindMajorityElementInAnArray_FindMajorityElementInAnArrayWithValidParameterValues_ReturnsNull()
    {
        Assert.Null(arraysService.FindMajorityElementInAnArray(new int[] { 12, 0, 0, 12, 2, 14, 54 }));
    }

    [Fact]
    public void FindMajorityElementInAnArrayUsingLINQ_FindMajorityElementInAnArrayUsingLINQWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(12, arraysService.FindMajorityElementInAnArrayUsingLINQ(new int[] { 12, 12, 0, 12, 2, 12, 54 }));
    }

    [Fact]
    public void FindMajorityElementInAnArrayUsingLINQ_FindMajorityElementInAnArrayUsingLINQWithValidParameterValues_ReturnsNull()
    {
        Assert.Null(arraysService.FindMajorityElementInAnArrayUsingLINQ(new int[] { 12, 0, 0, 12, 2, 14, 54 }));
    }

    [Fact]
    public void FindFareySequenceToAGivenOrder_FindFareySequenceToAGivenOrderWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(new double[] { 0, .25, .33, .5, .67, .75, 1 }, arraysService.FindFareySequenceToAGivenOrder(4));
    }

    [Fact]
    public void SunLoungerProblem_SunLoungerProblemWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(2, arraysService.SunLoungerProblem(new int[] { 0, 0, 0, 0 }));
    }

    [Fact]
    public void IsSudokuSolutionValid_IsSudokuSolutionValidWithValidSudoku_ReturnsTrue()
    {
        Assert.True(arraysService.IsSudokuSolutionValid(new int[,]
                              {
                                  { 1, 5, 2,  4, 8, 9,  3, 7, 6 },
                                  { 7, 3, 9,  2, 5, 6,  8, 4, 1 },
                                  { 4, 6, 8,  3, 7, 1,  2, 9, 5 },

                                  { 3, 8, 7,  1, 2, 4,  6, 5, 9 },
                                  { 5, 9, 1,  7, 6, 3,  4, 2, 8 },
                                  { 2, 4, 6,  8, 9, 5,  7, 1, 3 },

                                  { 9, 1, 4,  6, 3, 7,  5, 8, 2 },
                                  { 6, 2, 5,  9, 4, 8,  1, 3, 7 },
                                  { 8, 7, 3,  5, 1, 2,  9, 6, 4 }
                              }));
    }

    [Fact]
    public void IsSudokuSolutionValid_IsSudokuSolutionValidWithInvalidSudoku_ReturnsFalse()
    {
        Assert.False(arraysService.IsSudokuSolutionValid(new int[,]
                              {
                                  { 1, 5, 2,  4, 8, 9,  3, 7, 6 },
                                  { 7, 1, 9,  2, 5, 6,  8, 4, 1 },
                                  { 4, 6, 1,  3, 7, 1,  2, 9, 5 },

                                  { 3, 8, 7,  1, 2, 4,  6, 5, 9 },
                                  { 5, 9, 1,  7, 1, 3,  4, 2, 8 },
                                  { 2, 4, 6,  8, 9, 1,  7, 1, 3 },

                                  { 9, 1, 4,  6, 3, 7,  1, 8, 2 },
                                  { 6, 2, 5,  9, 4, 8,  1, 1, 7 },
                                  { 8, 7, 3,  5, 1, 2,  9, 6, 1 }
                              }));
    }

    [Fact]
    public void DoesArrayContainFullPositionCycle_DoesArrayContainFullPositionCycleWithValidParameterValues_ReturnsTrue()
    {
        Assert.True(arraysService.DoesArrayContainFullPositionCycle(new int[] { 5, 3, 4, 2, 0, 1 }));
    }

    [Fact]
    public void DoesArrayContainFullPositionCycle_DoesArrayContainFullPositionCycleWithValidParameterValues_ReturnsFalse()
    {
        Assert.False(arraysService.DoesArrayContainFullPositionCycle(new int[] { 5, 3, 4, 2, 8, 1 }));
    }

    [Fact]
    public void AlmostUniformSequence_AlmostUniformSequenceWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(4, arraysService.AlmostUniformSequence(new int[] { -1, 0, 1, 0 }));
    }

    [Fact]
    public void PoppingBlocks_PoppingBlocksWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(new string[] { "A" },
            arraysService.PoppingBlocks(new string[] { "A", "B", "A", "A", "A", "B", "B" }));
    }

    [Fact]
    public void TheJosephusProblem_TheJosephusProblemWithValidParameterValues_ReturnsValidResult()
    {
        Assert.Equal(1, arraysService.TheJosephusProblem(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 4));
    }
}