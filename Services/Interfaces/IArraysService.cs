﻿using Data.Utility;

namespace Services.Interfaces;

public interface IArraysService
{
    public int[]? RotateArray(int[]? array, int? rotationAmount, RotationDirection? rotationDirection);
    public int[]? RotateArrayUsingPlaceholderVariable(int[]? array);
    public int[]? RotateArrayRightGivenAPivotUsingLoops(int[]? array, int? pivot);
    public int[]? RotateArrayRightGivenAPivotUsingLINQ(int[]? array, int? pivot);
    public int[] Convert2DArrayInto1DArrayRowWise(int[,]? array2D);
    public int[] Convert2DArrayInto1DArrayColumnWise(int[,]? array2D);
}