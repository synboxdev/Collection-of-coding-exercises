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

    public int[,] Convert1DArrayInto2DArrayRowWise(int[]? array1D, int? rows, int? columns)
    {
        // If a 2D array isn't provided to the method or is invalid, we create a very simple array of integers.
        array1D = (array1D == null || array1D.Count() == 0) ?
            new int[] { 1, 2, 3, 4, 5, 6 } : array1D;
        // If provided rows and/or columns are invalid, OR their multiplied value isn't equal to length of our 1D array (which means basically means we dont have enough slots in rows and columns, to take up all 1D array values) - We initiate our own values.
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
        array1D = (array1D == null || array1D.Count() == 0) ?
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
        array = (array == null || array.Count() == 0) ? new int[] { 1, 2, 3, 4, 5 } : array;
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
        array = (array == null || array.Count() == 0) ? new int[] { 1, 2, 3, 4, 5 } : array;
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
        array = (array == null || array.Count() == 0) ? new int[] { 12, 0, 0, 24, 32, 14, 54 } : array;
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
        array = (array == null || array.Count() == 0) ? new int[] { 12, 0, 0, 24, 32, 14, 54 } : array;
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
        array = (array == null || array.Count() == 0) ? new int[] { 12, 12, 0, 12, 12, 14, 54 } : array;
        Console.WriteLine("Here's our input array, in which we will move all zeros, to the end of the array:");
        array.ToList().ForEach(x => Console.Write($"{x}\t"));
        Console.WriteLine();

        int elementAmount = 0;                                          // Simply to NOT use LINQ functions that indicate length/size of a given collection, such as .Count() or .Length, we'll simply have a counter to indicate us with the total amount of elements.
        int? majorityElement = null;                                    // Nullable integer variable which will either remain null, if there is no majority element, or will be equal to the value of majority element, if there is one.
        Dictionary<int, int> frequencies = new Dictionary<int, int>();  // Dictionary using which we'll keep track of each unique element, and its frequency occurence.

        // Iterate over every element in a given array - if our dictionary does NOT contain such key - add it to our dictionary, otherwise - simply increase the occurence (Value) by one.
        foreach (int element in array)
        {
            if (!frequencies.ContainsKey(element))
                frequencies.Add(element, 1);
            else
                frequencies[element]++;

            elementAmount++;
        }

        // Iterate over every element in our dictionary, and check whether its Value (Number of occurences) is greater than HALF of total of our elements
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
        array = (array == null || array.Count() == 0) ? new int[] { 12, 0, 0, 12, 12, 14, 54 } : array;
        Console.WriteLine("Here's our input array, in which we will move all zeros, to the end of the array:");
        array.ToList().ForEach(x => Console.Write($"{x}\t"));
        Console.WriteLine();

        // Instantiate a var type variable, and instantly assign a value to it, which will be a result of our LINQ query:
        // We're grouping the array by each element, and then returning FirstOrDefault (which means first that meets our condition, or default value if no element meets our condition) element whose .Count(), which is occurence, is greater than HALF of the length of the array.
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
        array = (array == null || array.Count() == 0) ? new int[] { 0, 1, 0, 0, 0, 0, 0, 1 } : array;
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
}