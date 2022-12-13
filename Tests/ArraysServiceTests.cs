﻿using Services;

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
}
