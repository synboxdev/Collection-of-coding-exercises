using Data.Utility;

namespace Services.Interfaces;

public interface IArraysService
{
    public int[]? RotateArray(int[]? array, int? rotationAmount, RotationDirection? rotationDirection);
    public int[]? RotateArrayUsingPlaceholderVariable(int[]? array);
    public int[]? RotateArrayRightGivenAPivotUsingLoops(int[]? array, int? pivot);
    public int[]? RotateArrayRightGivenAPivotUsingLINQ(int[]? array, int? pivot);
    public int[] Convert2DArrayInto1DArrayRowWise(int[,]? array2D);
    public int[] Convert2DArrayInto1DArrayColumnWise(int[,]? array2D);
    public int[,] Convert1DArrayInto2DArrayRowWise(int[]? array1D, int? rows, int? columns);
    public int[,] Convert1DArrayInto2DArrayColumnWise(int[]? array1D, int? rows, int? columns);
    public int[]? FindTwoIntegersInArrayThatEqualToAGivenSum(int[]? array, int? sumToFind);
    public int[]? FindTwoIntegersInArrayThatEqualToAGivenSumUsingLINQ(int[]? array, int? sumToFind);
    public int[]? MoveZerosToEndOfArray(int[]? array);
    public int[]? MoveZerosToEndOfArrayUsingLINQ(int[]? array);
    public int? FindMajorityElementInAnArray(int[]? array);
    public int? FindMajorityElementInAnArrayUsingLINQ(int[]? array);
    public double[] FindFareySequenceToAGivenOrder(int? order);
    public int? SunLoungerProblem(int[]? array);
    public bool IsSudokuSolutionValid(int[,] sudokuGrid);
    public bool DoesArrayContainFullPositionCycle(int[]? array);
    public int? AlmostUniformSequence(int[]? array);
    public string[] PoppingBlocks(string[] array);
    public int TheJosephusProblem(int[]? array, int? killIndex);
    public int? FindFulcrumPosition(int[]? array);
}