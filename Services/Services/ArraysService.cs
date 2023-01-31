using Data.Utility;
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
        array = (array == null || array.Length == 0) ? new int[] { 1, 2, 3, 4, 5 } : array;
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
        // We're going to rotate the array TWICE to the left side, display the results, and then rotate THRICE to the right side, and display the results again.
        array = (array == null || array.Length == 0) ? new int[] { 1, 2, 3, 4, 5 } : array;
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
        array = (array == null || array.Length == 0) ? new int[] { 1, 2, 3, 4, 5 } : array;
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
        array = (array == null || array.Length == 0) ? new int[] { 1, 2, 3, 4, 5 } : array;
        Console.WriteLine("Here's out input array that we will be rotating:");
        array.ToList().ForEach(Console.WriteLine);
        pivot = (pivot == null || pivot == 0) ? Random.Shared.Next(1, array.Length - 1) : pivot;
        Console.WriteLine($"Pivot from which we'll be rotating the array is {pivot}:");

        // Here, we simply utilize powerful functionality of LINQ which does the following:
        // We instantiate a new array, and instantly form it by:
        // Skipping the first PIVOT amount of values (based of pivot), which means we get all remaining value from a given PIVOT point to the end, and then we Concatenate ('glue') the first PIVOT amount of values, from the start of the input array.
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

    public int[,] Convert1DArrayInto2DArrayRowWise(int[]? array1D, int? rows, int? columns)
    {
        // If a 2D array isn't provided to the method or is invalid, we create a very simple array of integers.
        array1D = (array1D == null || array1D.Length == 0) ?
            new int[] { 1, 2, 3, 4, 5, 6 } : array1D;
        // If provided rows and/or columns are invalid, OR their multiplied value isn't equal to length of our 1D array (which means basically means we don't have enough slots in rows and columns, to take up all 1D array values) - We initiate our own values.
        rows = (rows == null || rows == 0 || rows * columns < array1D.Length) ? 2 : rows;
        columns = (columns == null || columns == 0 || rows * columns < array1D.Length) ? 3 : columns;
        Console.WriteLine("Here's our input 1D array that we will be converting into 2D array, ROW wise:");
        array1D.ToList().ForEach(x => Console.Write(x + "\t"));
        Console.WriteLine();

        // Initialize a 2D array, and an indexing variable, using which we'll know which element from our 1D array, we must enter into a 2D array.
        int[,] array2D = new int[(int)rows, (int)columns];
        int index = 0;

        for (int i = 0; i < array2D.GetLength(0); i++)
        {
            for (int j = 0; j < array2D.GetLength(1); j++)
            {
                array2D[i, j] = array1D[index];
                index++;
            }
        }

        Console.WriteLine($"Displaying our newly formed, 2D array that has {rows} Rows and {columns} Columns:");
        for (int i = 0; i < array2D.GetLength(0); i++)      // Iterate over columns (Which is 1st dimension of our array)
        {
            for (int j = 0; j < array2D.GetLength(1); j++)  // Iterate over rows (Which is our 2nd dimension of our array)
            {
                Console.Write($"{array2D[i, j]}\t");        // Print out and display the initial, 2D array to the console window.
            }
            Console.WriteLine();
        }

        return array2D;
    }

    /// <summary>
    /// Practically identical solution as the previous one (Convert1DArrayInto2DArrayRowWise), we simply iterate over columns, and then over rows.
    /// </summary>
    public int[,] Convert1DArrayInto2DArrayColumnWise(int[]? array1D, int? rows, int? columns)
    {
        // If a 2D array isn't provided to the method or is invalid, we create a very simple array of integers.
        array1D = (array1D == null || array1D.Length == 0) ?
            new int[] { 1, 2, 3, 4, 5, 6 } : array1D;
        rows = (rows == null || rows == 0 || rows * columns < array1D.Length) ? 2 : rows;
        columns = (columns == null || columns == 0 || rows * columns < array1D.Length) ? 3 : columns;
        Console.WriteLine("Here's our input 1D array that we will be converting into 2D array, COLUMN wise:");
        array1D.ToList().ForEach(x => Console.Write(x + "\t"));
        Console.WriteLine();

        int[,] array2D = new int[(int)rows, (int)columns];
        int index = 0;

        for (int i = 0; i < array2D.GetLength(1); i++)
        {
            for (int j = 0; j < array2D.GetLength(0); j++)
            {
                array2D[j, i] = array1D[index];
                index++;
            }
        }

        Console.WriteLine($"Displaying our newly formed, 2D array that has {rows} Rows and {columns} Columns:");
        for (int i = 0; i < array2D.GetLength(1); i++)      // Iterate over columns (Which is 1st dimension of our array)
        {
            for (int j = 0; j < array2D.GetLength(0); j++)  // Iterate over rows (Which is our 2nd dimension of our array)
            {
                Console.Write($"{array2D[j, i]}\t");        // Print out and display the initial, 2D array to the console window.
            }
            Console.WriteLine();
        }

        return array2D;
    }

    /// <summary>
    /// Brute force method, that iterates over each element, using two loops, and find the first two separate elements, whose sum is equal to a given sum that we are looking for. Complexity is O(n^2).
    /// </summary>
    public int[]? FindTwoIntegersInArrayThatEqualToAGivenSum(int[]? array, int? sumToFind)
    {
        // If a an array isn't provided to the method or is invalid, we create a very simple array of integers.
        array = (array == null || array.Length == 0) ? new int[] { 1, 2, 3, 4, 5 } : array;
        sumToFind = (sumToFind == null || sumToFind == 0) ? 6 : sumToFind;  // If sum to find isn't provided either - we set a value to it ourselves.
        Console.WriteLine($"Here's out input array in which we will look for a two integers, that equal to {sumToFind}:");
        array.ToList().ForEach(Console.WriteLine);

        List<int> integersEqualToSum = new List<int>();             // Create a integer type list, into which we will store (if we find) two integers, from a given array, that are equal to a given sum.
        for (int i = 0; i < array.Length; i++)                      // Utilize two loops, to check each element, with each element, and if they aren't the same exact element, and their sum is equal to sum that we're looking for - add these two values to our list.
        {
            for (int j = 0; j < array.Length; j++)
            {
                if (i != j && array[i] + array[j] == sumToFind)
                {
                    integersEqualToSum.AddRange(new int[] { array[i], array[j] });
                    // If we've successfully found and added two values to our list - display results to console window, and break out of the entire method by simply returning the expected result.
                    Console.WriteLine($"Two integers that are equal to our input sum of {sumToFind} are the following: {integersEqualToSum[0]} and {integersEqualToSum[1]}");
                    return integersEqualToSum.ToArray();
                }
            }
        }

        Console.WriteLine("Unfortunately, no two integers are equal to sum that we were looking for.");
        return integersEqualToSum.ToArray();
    }

    /// <summary>
    /// Complexity wise this solution is the same as the previous one, however we utilize a Dictionary, and do conditional check based on Dictionary key/value pairs.
    /// </summary>
    public int[]? FindTwoIntegersInArrayThatEqualToAGivenSumUsingLINQ(int[]? array, int? sumToFind)
    {
        // If a an array isn't provided to the method or is invalid, we create a very simple array of integers.
        array = (array == null || array.Length == 0) ? new int[] { 1, 2, 3, 4, 5 } : array;
        sumToFind = (sumToFind == null || sumToFind == 0) ? 6 : sumToFind;  // If sum to find isn't provided either - we set a value to it ourselves.
        Console.WriteLine($"Here's out input array in which we will look for a two integers, that equal to {sumToFind}:");
        array.ToList().ForEach(Console.WriteLine);

        List<int> integersEqualToSum = new List<int>();                 // Create a integer type list, into which we will store (if we find) two integers, from a given array, that are equal to a given sum.
        Dictionary<int, int> dictionary = new Dictionary<int, int>();   // First - we form a Dictionary for each array's element.
        for (int i = 0; i < array.Length; i++)
            dictionary.Add(i, array[i]);

        // Iterate through every element of the dictionary.
        // If sum of its value and ANY other value (whose key isn't same as the given element's key) in the dictionary are equal to sum that we're looking for - add those two values to the list and break out of the loop.
        foreach (var entry in dictionary)
        {
            int? dictValue = dictionary.FirstOrDefault(x => x.Value + entry.Value == sumToFind &&
                                          x.Key != entry.Key).Value;
            if (dictValue != null && dictValue != 0)
            {
                integersEqualToSum.Add(entry.Value);
                integersEqualToSum.Add((int)dictValue);
                break;                                  // Since we've found the result - two integer value whose sum is equal to sum that we're looking for - we can break out of the loop.
            }
        }

        // If we've successfully found and added two values to our list - display results to console window.
        if (integersEqualToSum.Count > 0)
            Console.WriteLine($"Two integers that are equal to our input sum of {sumToFind} are the following: {integersEqualToSum[0]} and {integersEqualToSum[1]}");
        else
            Console.WriteLine("Unfortunately, no two integers are equal to sum that we were looking for.");
        return integersEqualToSum.ToArray();
    }

    public int[]? MoveZerosToEndOfArray(int[]? array)
    {
        // If a an array isn't provided to the method or is invalid, we create a very simple array of integers.
        array = (array == null || array.Length == 0) ? new int[] { 12, 0, 0, 24, 32, 14, 54 } : array;
        Console.WriteLine("Here's our input array, in which we will move all zeros, to the end of the array:");
        array.ToList().ForEach(x => Console.Write($"{x}\t"));
        Console.WriteLine();

        int NonZeroBuffer = 0;                              // Variable which will increased by one, for each non-zero element we encounter.
        for (int i = 0; i < array.Length; i++)              // Iterate throughout the array
        {
            if (array[i] != 0)                              // If a given array's element is NOT a zero..
            {
                array[NonZeroBuffer] = array[i];            // Write that element into position of 'NonZeroBuffer', which will start off as 0
                NonZeroBuffer++;                            // Increase our buffer variable by one.
            }
        }
        // After this loop, all non-zero variable will be 'pushed' towards the front of the array, replacing positions of variable that were zero.
        // For example - our input array { 12, 0, 0, 24, 32, 14, 54 }, Will look like { 12, 24, 32, 14, 54, 14, 54 }, and NonZeroBuffer will be equal to 5

        // This loop will start FROM NonZeroBuffer value (In our case - 5) and iterate to the end of the array, and replace all values with zeros, since we 'pushed' all non-zero variable to the front.
        for (int i = NonZeroBuffer; i < array.Length; i++)
            array[i] = 0;

        Console.WriteLine("Here's array, with all zeros moved to the end of it:");
        array.ToList().ForEach(x => Console.Write($"{x}\t"));
        Console.WriteLine();

        return array;
    }

    /// <summary>
    /// Probably the most straight-forward and simple solution to this exercise is to simply utilize LINQ functionality, to sort the array in descending order, which will inherently reposition all zeros to the end of it.
    /// </summary>
    public int[]? MoveZerosToEndOfArrayUsingLINQ(int[]? array)
    {
        // If a an array isn't provided to the method or is invalid, we create a very simple array of integers.
        array = (array == null || array.Length == 0) ? new int[] { 12, 0, 0, 24, 32, 14, 54 } : array;
        Console.WriteLine("Here's our input array, in which we will move all zeros, to the end of the array:");
        array.ToList().ForEach(x => Console.Write($"{x}\t"));
        Console.WriteLine();

        // Simply call the LINQ function, which will re-order the array in descending manner.
        array = array.OrderByDescending(x => x).ToArray();

        Console.WriteLine("Here's array, with all zeros moved to the end of it:");
        array.ToList().ForEach(x => Console.Write($"{x}\t"));
        Console.WriteLine();

        return array;
    }

    /// <summary>
    /// This is rather inefficient and bloated solution to a relatively simple exercise, yet just for the sake of variety we can solve it without using LINQ functions.
    /// </summary>
    public int? FindMajorityElementInAnArray(int[]? array)
    {
        // If a an array isn't provided to the method or is invalid, we create a very simple array of integers.
        array = (array == null || array.Length == 0) ? new int[] { 12, 12, 0, 12, 12, 14, 54 } : array;
        Console.WriteLine("Here's our input array, in which we will move all zeros, to the end of the array:");
        array.ToList().ForEach(x => Console.Write($"{x}\t"));
        Console.WriteLine();

        int elementAmount = 0;                                          // Simply to NOT use LINQ functions that indicate length/size of a given collection, such as .Count() or .Length, we'll simply have a counter to indicate us with the total amount of elements.
        int? majorityElement = null;                                    // Nullable integer variable which will either remain null, if there is no majority element, or will be equal to the value of majority element, if there is one.
        Dictionary<int, int> frequencies = new Dictionary<int, int>();  // Dictionary using which we'll keep track of each unique element, and its frequency occurrence.

        // Iterate over every element in a given array - if our dictionary does NOT contain such key - add it to our dictionary, otherwise - simply increase the occurrence (Value) by one.
        foreach (int element in array)
        {
            if (!frequencies.ContainsKey(element))
                frequencies.Add(element, 1);
            else
                frequencies[element]++;

            elementAmount++;
        }

        // Iterate over every element in our dictionary, and check whether its Value (Number of occurrences) is greater than HALF of total of our elements
        foreach (var element in frequencies)
        {
            if (element.Value > elementAmount / 2)
                majorityElement = element.Key;
        }

        // If we had found a majority element - display it in the console window.
        if (majorityElement != null)
            Console.WriteLine($"Majority element of the given array is {majorityElement}");
        else
            Console.WriteLine($"The given array does NOT contain a majority element!");

        return majorityElement;
    }

    public int? FindMajorityElementInAnArrayUsingLINQ(int[]? array)
    {
        // If a an array isn't provided to the method or is invalid, we create a very simple array of integers.
        array = (array == null || array.Length == 0) ? new int[] { 12, 0, 0, 12, 12, 14, 54 } : array;
        Console.WriteLine("Here's our input array, in which we will move all zeros, to the end of the array:");
        array.ToList().ForEach(x => Console.Write($"{x}\t"));
        Console.WriteLine();

        // Instantiate a var type variable, and instantly assign a value to it, which will be a result of our LINQ query:
        // We're grouping the array by each element, and then returning FirstOrDefault (which means first that meets our condition, or default value if no element meets our condition) element whose .Count(), which is occurrence, is greater than HALF of the length of the array.
        var majorityElement = array.GroupBy(a => a).FirstOrDefault(a => a.Count() > array.Length / 2);

        // If we had found a majority element - display it in the console window.
        if (majorityElement != null)
            Console.WriteLine($"Majority element of the given array is {majorityElement.Key}");
        else
            Console.WriteLine($"The given array does NOT contain a majority element!");

        return majorityElement != null ? majorityElement.Key : null;
    }

    /// <summary>
    /// Tidbit of information about Farey sequence:
    /// In mathematics, the Farey sequence of order n is the sequence of completely reduced fractions, either between 0 and 1, or without this restriction, which when in lowest terms have denominators less than or equal to n, arranged in order of increasing size.
    /// Read more here: https://en.wikipedia.org/wiki/Farey_sequence
    /// </summary>
    public double[] FindFareySequenceToAGivenOrder(int? order)
    {
        // If order of Farey Sequence is not defined or provided, we assign a value of 4 to be able to proceed with the exercise.
        order = order == null || order == 0 ? 4 : order;
        Console.WriteLine($"We will be forming and displayed Farey Sequence of order {order}.");

        // Initialize a dictionary into which we will enter element of Farey Sequence.
        // KEY will be string interpretation of our fraction, and VALUE will be fraction value itself.
        Dictionary<string, double> sequenceElements = new Dictionary<string, double>
        {
            { "0/1", 0f },
            { "1/1", 1f }
        };

        // We will be utilizing two loops, to iterate through all possible variations of the fraction.
        // First loop will start from the order's value, and loop until it reaches 1 (since we've already added 1/1), and decrease by one after each iteration.
        for (int i = (int)order; i > 0; i--)
        {
            // Second loop will start at 1, and iterate until i, which will start at 4, next iteration be 3, etc.
            // So first iteration will yield us 1/4, 2/4 (which will result into 1/2), 3/4. Next iteration will yield us 1/3, 2/3
            for (int j = 1; j < i; j++)
            {
                int numerator = j;          // Our numerator (Number at the top of the fraction) will be iterator variable j
                int denominator = i;        // Our numerator (Number at the bottom of the fraction) will be iterator variable i
                int gcd = 0;                // gcd stands for Greatest common divisor.

                if (denominator % 2 == 0 && numerator % 2 == 0) // If remainder of both number individually, is equal to zero, that means can and MUST find GCD, so that we don't have overlapping fractions that equate to same value, such as 1/2 and 2/4
                {
                    // Continually loop, until denominator is equal to zero, then assign numerator value to GCD, and break out of the loop. Normally you would use a separate recursive method to get this value, but we want our solutions to be completely self-contained.
                    while (denominator != 0)
                    {
                        denominator = numerator % denominator;
                        if (denominator == 0)
                        {
                            gcd = numerator;
                            break;
                        }
                    }
                }

                // Define and form our KEY and VALUE variable, which we will put into our dictionary.
                // If GCD is greater than one, we must divide both numerator and denominator by that GCD.
                // For example, if we have fraction 2/4, and their GCD is 2, our fraction really is 1/2
                string key = gcd > 1 ? $"{j / gcd}/{i / gcd}" : $"{j}/{i}";
                var value = gcd > 1 ? Math.Round((double)(j / gcd) / (i / gcd), 2) : Math.Round((double)j / i, 2);

                // If our dictionary DOES NOT contain a key (string interpretation of our fraction) or VALUE equal to the fraction - add it.
                // This is an extra layer of protection that prevents a fraction such as 2/4 to be placed into the dictionary, if we already have 1/2, that has value of 0.5 (same as 2/4 = 0.5)
                if (!sequenceElements.ContainsKey(key) && !sequenceElements.ContainsValue(value))
                    sequenceElements.Add(key, value);
            }
        }

        // Order our dictionary by VALUE, and display the results into console window.
        sequenceElements.OrderBy(a => a.Value).ToList().ForEach(element => Console.WriteLine($"{element.Key}\t{(element.Value > 0 ? element.Value.ToString("#.##") : element.Value)}"));

        return sequenceElements.Values.OrderBy(a => a).ToArray();
    }

    /// <summary>
    /// A fun and simple problem to solve:
    /// A stretch of sea loungers is represented by an array of characters 0 - free, 1 - occupied.
    /// There must be one free place between two people lounging on the beach.
    /// Create a function to compute how many new people at most can settle in on the available sea loungers.
    /// </summary>
    public int? SunLoungerProblem(int[]? array)
    {
        // If a an array isn't provided to the method or is invalid, we create our own.
        array = (array == null || array.Length == 0) ? new int[] { 0, 1, 0, 0, 0, 0, 0, 1 } : array;
        Console.WriteLine("Here's our input array, which represents free and occupied seats on sun loungers:");
        array.ToList().ForEach(x => Console.Write($"{x} "));
        Console.WriteLine();

        int[] occupiedArray = array;    // We create a replica of our initial array, in case we need to 'mock' occupied seats, to correctly count available empty seats.
        int freePlaces = 0;             // Also, we create an integer variable, which will be our counter for empty available seats.

        // First, we must check two conditions, which would instantly result in returning value:
        // If the array length is one (there's a singular seat) and its empty, OR there are two seats, and NEITHER of them are occupied (i.e. both are available) - that means we have one singular available seat.
        if ((occupiedArray.Length == 1 && occupiedArray[0] == 0) ||
            (occupiedArray.Length == 2 && !occupiedArray.Any(x => x == 1)))
        {
            freePlaces = 1;
            Console.WriteLine("There one singular available sea lounger!");
        }
        // If there are two sea loungers, and at least one of them is occupied, unfortunately, we can't sit at the other one - since we must adhere to the initially set rules (see Summary tab above the method).
        else if (occupiedArray.Length == 2 && occupiedArray.Any(x => x == 1))
        {
            freePlaces = 1;
            Console.WriteLine("Unfortunately, there are no empty sea loungers available.");
        }
        // If neither condition above was met, we simply count available seats.
        // Rules are relatively simple - iterate over the array, if a given seat is empty, and seats before it, and after it (if its not the first or the last seat) are empty - we have an available seat.
        // So then - 'mock' that a seat is occupied, and continue counting. Another thing we check, if the index of seat before or after a given seat is not exceeding our array bounds, so we don't run into ArgumentOutOfBounds exception.
        else
        {
            for (int i = 0; i < occupiedArray.Length; i++)
            {
                if (((i == 0 && occupiedArray[i] == 0 && occupiedArray[i + 1] == 0)) ||
                    (i == occupiedArray.Length - 1 && occupiedArray[i] == 0 && occupiedArray[i - 1] == 0) ||
                    ((i > 0 && i < occupiedArray.Length - 1) && (occupiedArray[i - 1] == 0 && occupiedArray[i] == 0 && occupiedArray[i + 1] == 0)))
                {
                    occupiedArray[i] = 1;
                    freePlaces++;
                }
            }
        }

        Console.WriteLine($"There are a total of {freePlaces} available sea loungers, whilst complying to the rule of leaving one empty space in between every visitor.");
        return freePlaces;
    }

    /// <summary>
    /// Tidbit of information about Sudoku puzzle:
    /// Sudoku (originally called Number Place) - is a logic-based, combinatorial number-placement puzzle. 
    /// In classic Sudoku, the objective is to fill a 9 × 9 grid with digits so that each column, each row, and each of the nine 3 × 3 sub-grids that compose the grid (also called "boxes", "blocks", or "regions") contain all of the digits from 1 to 9.
    /// Read more here: https://en.wikipedia.org/wiki/Sudoku
    /// </summary>
    public bool IsSudokuSolutionValid(int[,] sudokuGrid)
    {
        // If a given solution grid is invalid, we'll instantiate our own. To visualize and see it better - I've added extra space between sections in between 3 rows and columns.
        sudokuGrid = (sudokuGrid != null && sudokuGrid.GetLength(0) == 9 && sudokuGrid.GetLength(1) == 9) ?
                              sudokuGrid :
                              new int[,]
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
                              };

        // Just for the sake of visibility in the console, as well as in the code above, I've went an extra mile to format the Sudoku a bit nicer - extra spacing between every 3rd row and column.
        Console.WriteLine("We're going to determine, whether this Sudoku is solved correctly:");
        for (int columnIndex = 0; columnIndex < sudokuGrid.GetLength(0); columnIndex++)
        {
            for (int rowIndex = 0; rowIndex < sudokuGrid.GetLength(1); rowIndex++)
            {
                Console.Write($"{(rowIndex > 0 && rowIndex % 3 == 0 ? "\t" : "")}" + $"{sudokuGrid[columnIndex, rowIndex]}  ");
            }
            Console.Write($"{(columnIndex > 0 && (columnIndex + 1) % 3 == 0 ? "\n\n" : "\n")}");
        }

        // Instantiate a List of integer arrays, where we'll store each set of elements - all rows, all columns, and all individual 9 element small squares.
        List<int[]> allSudokuSets = new List<int[]>();

        // Iterate over every column, and add all elements of each individual column as a subset into our list of subsets.
        for (int columnIndex = 0; columnIndex < sudokuGrid.GetLength(0); columnIndex++)
        {
            allSudokuSets.Add(Enumerable.Range(0, sudokuGrid.GetLength(0))
                                        .Select(columnElement => sudokuGrid[columnElement, columnIndex])
                                        .ToArray());
        }

        // Iterate over every row, and add all elements of each individual row as a subset into our list of subsets.
        for (int rowIndex = 0; rowIndex < sudokuGrid.GetLength(1); rowIndex++)
        {
            allSudokuSets.Add(Enumerable.Range(0, sudokuGrid.GetLength(1))
                                        .Select(rowElement => sudokuGrid[rowIndex, rowElement])
                                        .ToArray());
        }

        // This is the tricky part, where we must get all individual small squares from our Sudoku. Here's how we do it.
        // Iterate over each 'big' column. There are three 'big' columns, and each has three small squares inside it.
        for (int i = 0; i < 9; i += 3)
        {
            // Define a list of integers, which will hold a singular square's values.
            List<int> smallSquare = new List<int>();
            // Iterate over every single line, inside out 'big' column.
            for (int rowIndex = 0; rowIndex < sudokuGrid.GetLength(1); rowIndex++)
            {
                // Add all elements from i'th position (which starts at 0, next iteration it starts at 3, and last iteration - at 6), and take THREE elements.
                smallSquare.AddRange(Enumerable.Range(i, 3)
                           .Select(rowElement => sudokuGrid[rowIndex, rowElement])
                           .ToList());
                // Once we reach exactly 9 elements inside out List - that mean we've went over three rows, and gathered all values of a singular small square.
                // That means we must add it to our list of all subsets, and reset it, which we do by simply calling Clear function which wipes all data from our list.
                if (smallSquare.Count == 9)
                {
                    allSudokuSets.Add(smallSquare.ToArray());
                    smallSquare.Clear();
                }
            }
        }

        // Instantiate a boolean variable which will act as a trigger, informing us whether a given subset is NOT valid, which would invalidate the entire solution of Sudoku.
        bool IsSudokuSolutionValid = true;
        // Iterate over every single subset in our list of subsets.
        foreach (var subSet in allSudokuSets)
        {
            // If the number of distinct values is NOT equal to total number of values in a given subset,
            //      That means we have repeating digits, which in turn - invalidates the entire Sudoku solution.
            //      We switch our boolean to false and break out of the loop, since there's no more need to check other subsets.
            if (subSet.Distinct().Count() != subSet.Length)
            {
                IsSudokuSolutionValid = !IsSudokuSolutionValid;
                break;
            }
        }

        Console.WriteLine($"Our input Sudoku {(IsSudokuSolutionValid ? "is" : "is NOT")} solved correctly!");
        return IsSudokuSolutionValid;
    }

    /// <summary>
    /// Goal of this exercise is to traverse an array of positive integers starting at the first item and using each value as a pointer of what item to visit next.
    /// For example, an array [1, 4, 3, 0, 2] would be considered to have a Full Position Cycle,
    ///     Because starting at position 0, element's value is 1, we traverse the array, following the VALUE of an element, to go to the position of index of that value, meaning - next step would get us to position 1 (value = 4), next step is position 4 (value = 2), etc.
    /// Array has Full Position Cycle if we start at the very first element, visit all other elements exactly once, and at the end - go back to the very first element.
    /// </summary>
    public bool DoesArrayContainFullPositionCycle(int[]? array)
    {
        // If a an array isn't provided to the method or is invalid, we create our own - containing positive integers.
        array = (array == null || array.Length == 0) ? new int[] { 5, 3, 4, 2, 0, 1 } : array;
        Console.WriteLine("Here's our input array, which contains only positive integer elements:");
        array.ToList().ForEach(x => Console.Write($"{x} "));
        Console.WriteLine();

        // Define a boolean variable, which will act as our indicator and return value.
        bool ArrayHasFullCycle = true;
        // Instantiate a list which will hold indexes of the elements in our input array, which we've already visited.
        List<int> traversedIndexes = new List<int>();
        // Also - we'll define a starting position of traversal.
        int indexPosition = 0;

        // Iterate over our input array, until our traversed index list reaches same number of elements as our input array, or a condition is met that indicates that we do NOT have Full Position Cycle, and we cut off iteration.
        while (traversedIndexes.Count != array.Length)
        {
            // Two conditions must be met for an element to be 'traversed' - such element may not already exist in our list of traversed indexes, and its value may not point outside of our input array.
            // Meaning - if our array contains 5 elements, and one of them has value of 25, which is outside the bounds of the array - that means our array simply does not have a Full Position Cycle
            if ((indexPosition >= 0 && indexPosition < array.Length) &&
                !traversedIndexes.Contains(array[indexPosition]))
            {
                traversedIndexes.Add(array[indexPosition]);     // Add a given element's value to the array of traversed elements.
                indexPosition = array[indexPosition];           // Set the next position to the value of current element

                if (traversedIndexes.Count == array.Length &&   // Last condition of our exercise that must be met - last element that we traverse must point back to the beginning of the array, which is exactly position 0
                    indexPosition != 0)
                {
                    ArrayHasFullCycle = !ArrayHasFullCycle;
                    break;
                }
            }
            // If either condition mentioned above is met - our input array does NOT have a Full Position Cycle - which means we simply inform the user in the console window and break out of the loop.
            else
            {
                ArrayHasFullCycle = !ArrayHasFullCycle;
                break;
            }
        }

        Console.WriteLine($"Our input array {(ArrayHasFullCycle ? "does" : "does NOT")} have a Full Position Cycle");
        return ArrayHasFullCycle;
    }

    /// <summary>
    /// A rather simple, but an interesting exercise:
    /// Find the length of the longest sub-sequence of numbers whose difference is 1. 
    /// </summary>
    public int? AlmostUniformSequence(int[]? array)
    {
        // If a an array isn't provided to the method or is invalid, we create our own.
        array = (array == null || array.Length < 2) ? new int[] { 1, -1, 3, 2, 1, 5, 2, 3, 7 } : array;
        Console.WriteLine("Here's our input array:");
        array.ToList().ForEach(x => Console.Write($"{x} "));
        Console.WriteLine();

        // Define a list of sequences lengths, as well as variable to hold a temporary length of a given sequence that fits our condition.
        List<int> longestSequences = new List<int>();
        int temporarySequenceLength = 1;

        // Iterate from the first element, to second to last. Since we compare a given element to its next element.
        for (int i = 0; i < array.Length - 1; i++)
        {
            // If current element is NOT same as the next one, and their difference is equal to exactly one - increase our temporary sequence length by one.
            if (array[i] != array[i + 1] && Math.Abs(array[i] - array[i + 1]) == 1)
                temporarySequenceLength++;
            // If condition above is not met - add current temporary sequence length to the list, and reset it back to one.
            else
            {
                longestSequences.Add(temporarySequenceLength);
                temporarySequenceLength = 1;
            }
        }
        // In case we exist the loop without ever adding the element inside it - we must check whether temporary sequence length is above one - if so - add it the list.
        // Such occurrence may happen if the entire array is one big sequence, for example [ -1, 0, 1, 0 ] would yield an answer 4.
        if (temporarySequenceLength > 1)
            longestSequences.Add(temporarySequenceLength);

        Console.WriteLine($"Length of the longest sub-sequence of numbers whose difference is 1, is equivalent to {longestSequences.Max()}");
        return longestSequences.Max();
    }

    /// <summary>
    /// 'Popping Blocks' is a rather fun little exercise. Here's how it works and we should approach it:
    ///     1. When two blocks of the same "type" are adjacent to each other, the entire contiguous block disappears (pops off).
    ///     2. If this occurs, this can allow previously separated blocks to be in contact with each other, setting off a chain reaction.
    ///     3. This will continue until each block is surrounded by a different block.
    ///  For example:
    ///     1. ["A", "B", "C", "C", "B", "D", "A"]  - The two adjacent Cs pop off
    ///     2. ["A", "B", "B", "D", "A"]            - Two adjacent Bs pop off
    ///     3. ["A", "D", "A"]                      - No more blocks pop off, and this is our final result.
    /// </summary>
    public string[] PoppingBlocks(string[] array)
    {
        // If a an array isn't provided to the method or is invalid, we create our own - containing positive integers.
        array = (array == null || array.Length == 0) ? new string[] { "A", "B", "C", "C", "B", "D", "A" } : array;
        Console.WriteLine("Here's our input array, which we'll use to solve 'Popping Blocks' exercise:");
        array.ToList().ForEach(x => Console.Write($"{x} "));
        Console.WriteLine();

        // Initially - we instantiate a List type collection, since its easier to add/remove elements in comparison to an array type collection.
        List<string>? arrayElements = array.ToList();

        // Iterate over the entire list (all the elements)
        for (int i = 0; i < arrayElements.Count; i++)
        {
            // If the NEXT element is NOT outside the bounds of our collection, AND its equal to our current element - we've found matching blocks.
            if (i + 1 < arrayElements.Count && arrayElements[i + 1] == arrayElements[i])
            {
                // Save the index of our current element, and instantiate a counter variable for all the upcoming elements.
                int currentElementIndex = i;
                int nextElementIndex = 1;

                // Iterate, until the next element is NOT outside the bounds of our collection, AND its equivalent to our current element
                //      If the condition fits - change that element's value to NULL, and increase our counter variable by one.
                while (currentElementIndex + nextElementIndex < arrayElements.Count &&
                       arrayElements[currentElementIndex + nextElementIndex] == arrayElements[i])
                {
                    arrayElements[currentElementIndex + nextElementIndex] = null;
                    nextElementIndex++;
                }
                // After all the next variables have been iterated over, and if they are equivalent - changed to NULLs, we can change our current element to NULL.
                arrayElements[currentElementIndex] = null;

                // Re-instantiate the list, by collection all non-null values from our initial list - this will 'pop off' the contiguous block of matching elements. 
                arrayElements = arrayElements.Where(x => x != null).ToList();
                // Also - very important - we must restart the initial loop, by setting iterator to 0, since we've removed some elements, and indexes have shifted.
                i = 0;
            }
        }

        // Display the final list of elements to the console window:
        Console.WriteLine("Here's our array, after 'Popping Blocks' logic:");
        arrayElements.ForEach(x => Console.Write($"{x} "));
        Console.WriteLine();

        return arrayElements.ToArray();
    }

    /// <summary>
    /// Tidbit of information about The Josephus Problem:
    /// In computer science and mathematics, the Josephus problem (or Josephus permutation) is a theoretical problem related to a certain counting-out game.
    ///     Here's the basic rule-set of the problem:
    ///     1. A number of people are standing in a circle waiting to be executed.
    ///     2. Counting begins at a specified point in the circle and proceeds around the circle in a specified direction.
    ///     3. After a specified number of people are skipped, the next person is executed.
    ///     4. The procedure is repeated with the remaining people, starting with the next person, going in the same direction and skipping the same number of people, until only one person remains, and is freed.
    /// Read more here: https://en.wikipedia.org/wiki/Josephus_problem
    /// </summary>
    public int TheJosephusProblem(int[]? array, int? killIndex)
    {
        // If an array isn't provided to the method or is invalid, we create our own - containing some elements '1' (Which indicate an alive person).
        array = (array == null || array.Length == 0) ? new int[] { 1, 1, 1, 1, 1, 1, 1, 1 } : array;
        Console.WriteLine("Here's our input array, which represents a circle of unfortunate people, who are about to be executed, until there's only a single survivor left");
        array.ToList().ForEach(x => Console.Write($"{x} "));
        Console.WriteLine();
        killIndex = killIndex == null || killIndex == 0 ? Random.Shared.Next(1, 5) : killIndex;
        Console.WriteLine($"Every {killIndex} person will be executed.");

        // Initialize an integer type variable, to keep count alive people, when this number is equivalent to kill index - that person is killed and the counter is reset.
        int counter = 0;

        // Iterate over the entire array (circle of people). This is reset when we reach the end, because real exit condition is define within the loop itself.
        for (int i = 0; i < array.Length; i++)
        {
            // This is real exit condition of the loop - when the number of Survivors (which are indicated by 1) is equal to 1, meaning - we have a single person left alive - we exit the loop.
            if (array.Where(x => x == 1).Count() == 1)
                break;

            // Is the current person alive? If so - increase the counter by one.
            if (array[i] == 1)
                counter++;

            // Is the counter (number of counted alive people) equal to kill index? If so - this person is killed, and counter is reset back to zero.
            if (counter == killIndex)
            {
                array[i] = 0;
                counter = 0;
            }

            // If next person (next element in the array) is already outside the bounds of the array - reset array iterator i to -1 (Since it will be increased by one in the next iteration).
            if (i + 1 == array.Length)
                i = -1;
        }

        // Last person alive is set free. That means our result is the index (position) of first element equivalent to 1. (Which is the last person alive).
        Console.WriteLine($"Index (safe position) is equal to {Array.FindIndex(array, x => x == 1)}. That's where the last survivor is.");
        return Array.FindIndex(array, x => x == 1);
    }

    /// <summary>
    /// An introduction to the exercises:
    /// A fulcrum of an array is an integer such that all elements to the left of it and all elements to the right of it sum to the same value.
    /// </summary>
    public int? FindFulcrumPosition(int[]? array)
    {
        // If a an array isn't provided to the method or is invalid, we create our own.
        array = (array == null || array.Length < 2) ? new int[] { 8, 8, 8, 8 } : array;
        Console.WriteLine("Here's our input array:");
        array.ToList().ForEach(x => Console.Write($"{x} "));
        Console.WriteLine();

        // Initialize a integer variable, with default value of NULL, which will be set to the value of an element, which is a Fulcrum position,
        // Otherwise - it will remain null, indicating to us, that our array does NOT contain a Fulcrum position element.
        int? FulcrumPosition = null;

        // Iterate over the array, starting at second element (position 1), all the way to second to last element. Reason for this lies in the underlying condition of Fulcrum number - we must compare sum of left side elements to the sum of right side elements.
        for (int i = 1; i < array.Length - 1; i++)
        {
            // If the sum of left sided elements is equivalent to sum of right sided elements - we have found a Fulcrum positioned element, take its value, and break out of the loop.
            // Reason for TakeLast being calculated as it is - once we subtract iterator from the length of the array, we get the position of our CURRENT element, that's why we must subtract 1, to get the right sided element FROM our current element.
            if (array.Take(i).Sum() == array.TakeLast(array.Length - i - 1).Sum())
            {
                FulcrumPosition = array[i];
                break;
            }
        }

        // Display the findings of our solution to the console window:
        Console.WriteLine($"{(FulcrumPosition != null ?
                          $"Fulcrum position of our array is the element {FulcrumPosition}" :
                           "Our input array does NOT contain a Fulcrum position element!")}");
        return FulcrumPosition;
    }

    /// <summary>
    /// Here's an interesting exercise to try out:
    /// Find the total sum of missing number from a given array of integers.
    /// Small note - The minimum and maximum value of the given array are the exclusive bounds of the numeric range to consider when searching for missing numbers.
    ///     Meaning - if our array contains elements 2, 5, 8, missing numbers would be 3 + 4 + 6 + 7.
    /// </summary>
    public int? FindSumOfMissingNumbers(int[]? array)
    {
        // If a an array isn't provided to the method or is invalid, we create our own with some random integer values.
        array = (array == null || array.Length < 2) ? new int[] { -5, -3, 2, 1 } : array;
        Console.WriteLine("Here's our input array, which we'll use to determine the total sum of missing numbers:");
        array.ToList().ForEach(x => Console.Write($"{x} "));
        Console.WriteLine();

        // Define an integer variable that will hold the total sum of missing numbers.
        int? totalSum = 0;

        // Iterate from the lowest number of the array (inclusively), to the very last element (inclusively), and just add ALL element value to the total sum.
        for (int i = array.Min(); i <= array.Max(); i++)
            totalSum += i;

        // Iterate over the input array element specifically, and add the inverted value of each element to the same total sum.
        // Reason for this - is to 're-calculate' the total sum, by excluding the input array element that we not supposed to be summed in the first place.
        foreach (int arrayElement in array)
            totalSum += arrayElement * -1;

        // Display the total calculated sum to the console window.
        Console.WriteLine($"Total sum of missing numbers from our input array is equal to {totalSum}");
        return totalSum;
    }

    public int? FindSumOfMissingNumbersUsingHashSet(int[]? array)
    {
        // If a an array isn't provided to the method or is invalid, we create our own with some random integer values.
        array = (array == null || array.Length < 2) ? new int[] { -5, -3, 2, 1 } : array;
        Console.WriteLine("Here's our input array, which we'll use to determine the total sum of missing numbers:");
        array.ToList().ForEach(x => Console.Write($"{x} "));
        Console.WriteLine();

        // Define a HashSet of type integer, into which we immediately store the array - reason for this, is to hold unique numbers which we must NOT sum to the total amount.
        // And an integer variable that will hold the total sum of missing numbers.
        HashSet<int> hashsetArray = array.ToHashSet();
        int? totalSum = 0;

        // Iterate from the lowest numbers of the HashSet + 1 (since we use exclusive bounds on both ends), to the very last element.
        for (int i = hashsetArray.Min() + 1; i < hashsetArray.Max(); i++)
            totalSum += !hashsetArray.Contains(i) ? i : 0;                  // If the HashSet does NOT contain such element - add it to the total sum.

        // Display the total calculated sum to the console window.
        Console.WriteLine($"Total sum of missing numbers from our input array is equal to {totalSum}");
        return totalSum;
    }
}