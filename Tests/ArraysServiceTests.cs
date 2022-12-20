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
}