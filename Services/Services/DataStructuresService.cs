using Data.Utility;
using Services.Interfaces;

namespace Services;

public class DataStructuresService : IDataStructuresService
{
    /// <summary>
    /// A very simple generic type helper method, to reduce bloat of each solution method.
    /// This method simply prints out a given generic type LinkedList, either inline (all nodes in same console line) or new line for each node element. Also takes case of spacing of output data.
    /// </summary>
    private void ConsoleOutputEnumerableCollection<T>(ConsoleOutputType outputType, IEnumerable<T> collectionToPrint)
    {
        if (outputType == ConsoleOutputType.Inline)
        {
            for (int i = 0; i < collectionToPrint.Count(); i++)
                Console.Write($"{collectionToPrint.ElementAt(i)}  ");
            Console.WriteLine();
        }
        if (outputType == ConsoleOutputType.NewLine)
        {
            for (int i = 0; i < collectionToPrint.Count(); i++)
                Console.WriteLine($"{collectionToPrint.ElementAt(i)}");
        }
    }

    public LinkedList<int> ReverseALinkedList(LinkedList<int> linkedList)
    {
        // If our provided linked list as a parameter, is null or does not have any nodes (values) inside it - we'll add a few ourselves.
        if (linkedList == null || linkedList.Count == 0)
        {
            linkedList = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
                linkedList.AddLast(i);
        }
        Console.WriteLine("Here are nodes of our input Linked List:");
        ConsoleOutputEnumerableCollection(ConsoleOutputType.Inline, linkedList);

        // Initialize a new, empty Linked List, which we will populate with values and form a reversed version of our input linked list.
        LinkedList<int> reversedLinkedList = new LinkedList<int>();
        var startNode = linkedList.Last;    // Start of our reversed linked list, will be the LAST element of our input linked list

        // While the value of our starting node is NOT null - continue iterating.
        while (startNode != null)
        {
            reversedLinkedList.AddLast(startNode.Value);    // Add the starting node's value to the END or our new linked list. Initially - the linked list is empty.
            // Assign a new value to our starting node variable.
            // Remember - we picked the Last node, as value of starting node, so .Previous will refer to the 2nd to last, and so on, until we reach first node, whose 'previous' value will be null, and we will exit out of the loop.
            startNode = startNode.Previous;
        }
        Console.WriteLine("Here are nodes of our reversed Linked List:");
        ConsoleOutputEnumerableCollection(ConsoleOutputType.Inline, reversedLinkedList);

        return reversedLinkedList;
    }

    public LinkedListNode<int>? FindNodeInLinkedList(LinkedList<int>? linkedList, int? valueToFind)
    {
        // If a node that we're supposed to find is null, we'll instantiate our own with a value of 5.
        valueToFind = valueToFind != null ? valueToFind : Random.Shared.Next(1, 20);
        Console.WriteLine($"We will be looking for a LinkedListNode with value {valueToFind}");

        // If our provided linked list as a parameter, is null or does not have any nodes (values) inside it - we'll add a few ourselves.
        if (linkedList == null || linkedList.Count == 0)
        {
            linkedList = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
                linkedList.AddLast(i);
        }
        Console.WriteLine("Here are nodes of our input Linked List:");
        ConsoleOutputEnumerableCollection(ConsoleOutputType.Inline, linkedList);

        // We utilize LinkedList's function Find that returns a LinkedListNode with a given value. If no such node if found - null is returned.
        var foundNode = linkedList.Find((int)valueToFind);
        Console.WriteLine($"{(foundNode?.Value != valueToFind ? "No such node was found!" : "Node found successfully!")}");

        return foundNode != null ? foundNode : null;
    }

    public LinkedList<int> MergeTwoLinkedListsUsingLINQ(LinkedList<int> linkedListOne, LinkedList<int> linkedListTwo)
    {
        // If our provided linked list as a parameter, is null or does not have any nodes (values) inside it - we create our own lists with some random values, since we'll output a single, sorted, linked list.
        if (linkedListOne == null || linkedListOne.Count == 0)
        {
            linkedListOne = new LinkedList<int>();
            for (int i = 0; i < 5; i++)
                linkedListOne.AddLast(Random.Shared.Next(1, 20));
        }
        Console.WriteLine("Here are nodes of our first Linked List:");
        ConsoleOutputEnumerableCollection(ConsoleOutputType.Inline, linkedListOne);

        if (linkedListTwo == null || linkedListTwo.Count == 0)
        {
            linkedListTwo = new LinkedList<int>();
            for (int i = 0; i < 5; i++)
                linkedListTwo.AddLast(Random.Shared.Next(1, 20));
        }
        Console.WriteLine("Here are nodes of our second Linked List:");
        ConsoleOutputEnumerableCollection(ConsoleOutputType.Inline, linkedListTwo);

        // Probably the most simple and elegant solution to this problem - is to utilize LINQ's Concat (Which is SQL's equivalent of UnionAll) and OrderBy functions
        LinkedList<int> mergedLinkedList = new LinkedList<int>(linkedListOne.Concat(linkedListTwo).OrderBy(x => x));
        Console.WriteLine("Here's a final, merged and sorted Linked List:");
        ConsoleOutputEnumerableCollection(ConsoleOutputType.Inline, mergedLinkedList);

        return mergedLinkedList;
    }

    public LinkedList<int> RemoveDuplicatesFromLinkedListUsingHashSet(LinkedList<int> linkedList)
    {
        // If our provided linked list as a parameter, is null or does not have any nodes (values) inside it - we create our own lists with some random values, since we'll output a single, sorted, linked list.
        if (linkedList == null || linkedList.Count == 0)
        {
            linkedList = new LinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
        }
        Console.WriteLine("Here are nodes of our first Linked List:");
        ConsoleOutputEnumerableCollection(ConsoleOutputType.Inline, linkedList);

        // Instantiate a new HashSet, iterate over every node in the input Linked List. Only unique elements will be added to HashSet, because if such element it NOT yet present inside the HashSet.
        HashSet<int> hashSetOfNodes = new HashSet<int>();
        foreach (var node in linkedList)
            hashSetOfNodes.Add(node);

        // Clear the Linked list - i.e. Delete all the nodes.
        linkedList.Clear();

        // Iterate over the HashSet, and Add all HashSet's elements, as nodes, back to the Linked List - which will now will ONLY contain unique elements.
        foreach (var hashSetNode in hashSetOfNodes)
            linkedList.AddLast(hashSetNode);

        Console.WriteLine("Here's a final Linked List, without any duplicate values:");
        ConsoleOutputEnumerableCollection(ConsoleOutputType.Inline, linkedList);
        return linkedList;
    }

    public LinkedList<int> RemoveDuplicatesFromLinkedListUsingLINQ(LinkedList<int> linkedList)
    {
        // If our provided linked list as a parameter, is null or does not have any nodes (values) inside it - we create our own lists with some random values, since we'll output a single, sorted, linked list.
        if (linkedList == null || linkedList.Count == 0)
        {
            linkedList = new LinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
        }
        Console.WriteLine("Here are nodes of our first Linked List:");
        ConsoleOutputEnumerableCollection(ConsoleOutputType.Inline, linkedList);

        // Instantiate a new LinkedList of the same type as our input Linked List;
        LinkedList<int> linkedListWithoutDuplicates = new LinkedList<int>();
        // Iterate over the input Linked List, and check if our new Linked List contains node with such value - if not, add it to the end of the Linked List. Final Linked List will now contain ONLY unique node elements.
        for (LinkedListNode<int> node = linkedList.First; node != null; node = node.Next)
        {
            if (!linkedListWithoutDuplicates.Contains(node.Value))
                linkedListWithoutDuplicates.AddLast(node.Value);
        }

        Console.WriteLine("Here's a final Linked List, without any duplicate values:");
        ConsoleOutputEnumerableCollection(ConsoleOutputType.Inline, linkedListWithoutDuplicates);
        return linkedListWithoutDuplicates;
    }

    public Stack<string> ReverseAStack(Stack<string> inputStack)
    {
        // If our provided Stack as a parameter, is null or does not have any nodes (values) inside it - we create our own Stack.
        if (inputStack == null || inputStack.Count == 0)
        {
            string[] randomElements = new string[] { "Apple", "Orange", "Banana", "Pear" };
            inputStack = new Stack<string>(randomElements);
        }
        Console.WriteLine("Here are nodes of our input Stack of strings:");
        ConsoleOutputEnumerableCollection(ConsoleOutputType.Inline, inputStack);

        // Define a new Stack collection, into which we'll stored elements in efforts of reversing the input Stack.
        Stack<string> reversedStack = new Stack<string>();
        while (inputStack.Count > 0)                // While the input Stack collection is not empty, proceed with the iteration
            reversedStack.Push(inputStack.Pop());   // Push functions Inserts a given object at the top of the Stack, while Pop function removes a given object from the top of the stack.
                                                    // So we're placing the topmost element from the input Stack, into the reversed Stack.

        Console.WriteLine("Here's reversed Stack and its elements:");
        ConsoleOutputEnumerableCollection(ConsoleOutputType.Inline, reversedStack);
        return reversedStack;
    }
}