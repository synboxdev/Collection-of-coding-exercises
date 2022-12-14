﻿using Data.Utility;
using Services.Interfaces;

namespace Services;

public class ArraysService : IArraysService
{
    /// <summary>
    /// This solution is quite cluttered, but inherently its rather simplistic. Half the solution is under the assumption that we didn't provide any valid parameters to the method, so we generate some random ones, to be able to execute the functionality.
    /// Another thing to note - this method facilitates multiple rotations as well as rotation to either side (left or right)
    /// Also - this solution utilized Tuples feature, more about which you can read here: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
    /// </summary>
    public int[]? RotateArray(int[]? array, int? rotationAmount, RotationDirection? rotationDirection)
    {
        // If a an array isn't provided to the method or is invalid, we create a very simple array of integers.
        Console.WriteLine("Creating a simple integer array");
        array = (array == null || array.Count() == 0) ? new int[] { 1, 2, 3, 4, 5 } : array;
        Console.WriteLine("Here's out input array that we will be rotating:");
        array.ToList().ForEach(Console.WriteLine);
        // If rotation amount is not provided, we simply pick a random number.
        // If direction is not provided, we will also pick a direction.
        rotationAmount = (rotationAmount == null || rotationAmount == 0) ? Random.Shared.Next(1, 5) : rotationAmount;
        rotationDirection = (RotationDirection?)((!rotationDirection.HasValue || rotationDirection == null) ?
            Enum.GetValues(typeof(RotationDirection)).GetValue(Random.Shared.Next(0, Enum.GetValues(typeof(RotationDirection)).Length)) :
            rotationDirection);
        Console.WriteLine($"We will be rotating the array {rotationAmount} times, to the {Enum.GetName(typeof(RotationDirection), rotationDirection).ToUpper()} side.");

        // When rotating the array to the left side, we iterate from last element, all the way to the element of index 1 (which is second element of the array),
        // And we reposition the last element, with 2nd to last, and then next iteration - last with 3rd to last, and so on, until we reach the element, index of 1.
        if (rotationDirection == RotationDirection.Left)
        {
            for (int i = 0; i < rotationAmount; i++)
            {
                for (int j = array.Length - 1; j > 0; j--)
                    (array[array.Length - 1], array[j - 1]) = (array[j - 1], array[array.Length - 1]);
            }
        }

        // When rotating the array to the left side, we iterate from the 1st element (0th), all the way to the second to last of the array.
        // And we reposition 1st element, with the 2nd, and then next iteration - 1st with 3rd, and so on, until we reach the 2nd to last.
        if (rotationDirection == RotationDirection.Right)
        {
            for (int i = 0; i < rotationAmount; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                    (array[0], array[j + 1]) = (array[j + 1], array[0]);
            }
        }

        Console.WriteLine("Here's the result of the rotation:");
        array.ToList().ForEach(Console.WriteLine);

        return array;
    }

    public int[]? RotateArrayUsingPlaceholderVariable(int[]? array)
    {
        // For the sake of simplicity, and not inflating this solution like the previous one - we're going to keep it simple:
        // We're going to rotate the array TWICE to the left side, diplay the results, and then rotate THRICE to the right side, and display the results again.
        array = (array == null || array.Count() == 0) ? new int[] { 1, 2, 3, 4, 5 } : array;
        Console.WriteLine("Here's out input array that we will be rotating:");
        array.ToList().ForEach(Console.WriteLine);

        // First - we rotate twice to the left side, and display the results.
        // Logic is the exact same as in the previous (RotateArray) - however, here, instead of using Tuples, we simply use a placeholder variable to hold the value, while we replace element values with one another.
        for (int i = 0; i < 2; i++)
        {
            int temp;
            for (int j = array.Length - 1; j > 0; j--)
            {
                temp = array[array.Length - 1];
                array[array.Length - 1] = array[j - 1];
                array[j - 1] = temp;
            }
        }
        Console.WriteLine("Our array, after being rotated TWICE to the left side:");
        array.ToList().ForEach(Console.WriteLine);

        // Next - we rotate the same array, to the right side, THREE times, and display the results.
        // Logic is the exact same as in the previous (RotateArray) - however, here, instead of using Tuples, we simply use a placeholder variable to hold the value, while we replace element values with one another.
        for (int i = 0; i < 3; i++)
        {
            int temp;
            for (int j = 0; j < array.Length - 1; j++)
            {
                temp = array[0];
                array[0] = array[j + 1];
                array[j + 1] = temp;
            }
        }
        Console.WriteLine("Our array, after being rotated THRICE to the right side:");
        array.ToList().ForEach(Console.WriteLine);

        return array;
    }

    public int[]? RotateArrayRightGivenAPivotUsingLoops(int[]? array, int? pivot)
    {
        // If a an array isn't provided to the method or is invalid, we create a very simple array of integers.
        array = (array == null || array.Count() == 0) ? new int[] { 1, 2, 3, 4, 5 } : array;
        Console.WriteLine("Here's out input array that we will be rotating:");
        array.ToList().ForEach(Console.WriteLine);
        pivot = (pivot == null || pivot == 0) ? Random.Shared.Next(1, array.Length - 1) : pivot;
        Console.WriteLine($"Pivot from which we'll be rotating the array is {pivot}:");

        int[] rotatedArray = new int[array.Length];             // Instantiate a new array, which will hold our rotated array. It will have same length (same number of elements) as our input array.
        int positionInRotatedArray = 0;                         // Position in the array will indicate into which position we must enter a given value.

        // We'll utilize two loops, first of which, will start from the pivot point, and run until the end of the array
        // And we'll populate our rotated array, starting from 0th position.
        for (int i = (int)pivot; i < array.Length; i++)
        {
            rotatedArray[positionInRotatedArray] = array[i];
            positionInRotatedArray++;
        }

        // Seconds loop will simply start from 1st element and iterate until the pivot point, and finish off populating our rotated array with values.
        for (int j = 0; j < pivot; j++)
        {
            rotatedArray[positionInRotatedArray] = array[j];
            positionInRotatedArray++;
        }
        // If we were to rotate the array to the left, using this same logic, all we'd have to do is start with 2nd loop's logic, and then do the 1st loop's logic.

        Console.WriteLine("Here's the result of rotated input array, to the right side, given the pivot:");
        rotatedArray.ToList().ForEach(Console.WriteLine);
        return rotatedArray;
    }

    public int[]? RotateArrayRightGivenAPivotUsingLINQ(int[]? array, int? pivot)
    {
        // If a an array isn't provided to the method or is invalid, we create a very simple array of integers.
        array = (array == null || array.Count() == 0) ? new int[] { 1, 2, 3, 4, 5 } : array;
        Console.WriteLine("Here's out input array that we will be rotating:");
        array.ToList().ForEach(Console.WriteLine);
        pivot = (pivot == null || pivot == 0) ? Random.Shared.Next(1, array.Length - 1) : pivot;
        Console.WriteLine($"Pivot from which we'll be rotating the array is {pivot}:");

        // Here, we simply utilize powerful functionality of LINQ which does the following:
        // We instantiate a new array, and instantly form it by:
        // Skipping the first PIVOT amount of values (based of pivot), which means we get all remaining value from a given PIVOT point to the end, and then we Concat ('glue') the first PIVOT amount of values, from the start of the input array.
        int[] rotatedArray = array.Skip((int)pivot).Concat(array.Take((int)pivot)).ToArray();
        Console.WriteLine("Here's the result of rotated input array, to the right side, given the pivot:");
        rotatedArray.ToList().ForEach(Console.WriteLine);

        return rotatedArray;
    }

    /// <summary>
    /// Tidbit of information about Multidimensional arrays:
    /// Arrays can have more than one dimension.
    /// As per Microsoft documentation, found here: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays
    /// </summary>
    public int[] Convert2DArrayInto1DArrayRowWise(int[,]? array2D)
    {
        // If a 2D array isn't provided to the method or is invalid, we create a very simple array of integers.
        array2D = (array2D == null || (array2D.GetLength(0) > 0 && array2D.GetLength(1) > 0)) ?
            new int[,] { { 1, 2, 3 }, { 4, 5, 6 } } : array2D;
        Console.WriteLine("Here's our input 2D array that we will be converting into 1D array, row wise:");
        for (int i = 0; i < array2D.GetLength(0); i++)      // Iterate over rows (Which is 1st dimension of our array)
        {
            for (int j = 0; j < array2D.GetLength(1); j++)  // Iterate over columns (Which is our 2nd dimension of our array)
            {
                Console.Write($"{array2D[i, j]}\t");        // Print out and display the initial, 2D array to the console window.
            }
            Console.WriteLine();
        }

        int[] array1D = new int[array2D.GetLength(0) * array2D.GetLength(1)];   // We instantiate a new, one dimensional array, whose size will be multiplication of row and column amount, to be able to store all elements of our 2D array.
        int positionInArray1D = 0;                                              // We also need a temporary variable, to indicate into which position we must enter a given element.

        for (int i = 0; i < array2D.GetLength(0); i++)
        {
            for (int j = 0; j < array2D.GetLength(1); j++)
            {
                array1D[positionInArray1D] = array2D[i, j];     // Insert i'th rows' j'th columns' element into continually increasing position index.
                positionInArray1D++;                            // After an element was inserted, we increase the position index for the next variable.
            }
        }

        Console.WriteLine("Here's our new, one dimensional array, created from input 2D array:");
        array1D.ToList().ForEach(x => Console.Write(x + "\t"));
        Console.WriteLine();

        return array1D;
    }

    /// <summary>
    /// Practically identical solution as the previous one (Convert2DArrayInto1DArrayRowWise), we simply iterate over columns, and then over rows.
    /// </summary>
    public int[] Convert2DArrayInto1DArrayColumnWise(int[,]? array2D)
    {
        // If a 2D array isn't provided to the method or is invalid, we create a very simple array of integers.
        array2D = (array2D == null || (array2D.GetLength(0) > 0 && array2D.GetLength(1) > 0)) ?
            new int[,] { { 1, 2, 3 }, { 4, 5, 6 } } : array2D;
        Console.WriteLine("Here's our input 2D array that we will be converting into 1D array, column wise:");
        for (int i = 0; i < array2D.GetLength(0); i++)
        {
            for (int j = 0; j < array2D.GetLength(1); j++)
            {
                Console.Write($"{array2D[i, j]}\t");
            }
            Console.WriteLine();
        }

        int[] array1D = new int[array2D.GetLength(0) * array2D.GetLength(1)];
        int positionInArray1D = 0;

        for (int i = 0; i < array2D.GetLength(1); i++)
        {
            for (int j = 0; j < array2D.GetLength(0); j++)
            {
                array1D[positionInArray1D] = array2D[j, i];
                positionInArray1D++;
            }
        }

        Console.WriteLine("Here's our new, one dimensional array, created from input 2D array:");
        array1D.ToList().ForEach(x => Console.Write(x + "\t"));
        Console.WriteLine();

        return array1D;
    }
}