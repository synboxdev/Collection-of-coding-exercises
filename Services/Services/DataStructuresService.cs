using Data.Utility;
using Services.Interfaces;

namespace Services;

public class DataStructuresService : IDataStructuresService
{
    /// <summary>
    /// A very simple generic type helper method, to reduce bloat of each solution method.
    /// This method simply prints out a given generic type LinkedList, either inline (all nodes in same console line) or new line for each node element. Also takes case of spacing of output data.
    /// </summary>
    private void ConsoleOutputLinkedList<T>(ConsoleOutputType outputType, LinkedList<T> linkedList)
    {
        if (outputType == ConsoleOutputType.Inline)
        {
            for (int i = 0; i < linkedList.Count; i++)
                Console.Write($"{linkedList.ElementAt(i)}  ");
            Console.WriteLine();
        }
        if (outputType == ConsoleOutputType.NewLine)
        {
            for (int i = 0; i < linkedList.Count; i++)
                Console.WriteLine($"{linkedList.ElementAt(i)}");
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
        ConsoleOutputLinkedList(ConsoleOutputType.Inline, linkedList);

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
        ConsoleOutputLinkedList(ConsoleOutputType.Inline, reversedLinkedList);

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
        ConsoleOutputLinkedList(ConsoleOutputType.Inline, linkedList);

        // We utilize LinkedList's function Find that returns a LinkedListNode with a given value. If no such node if found - null is returned.
        var foundNode = linkedList.Find((int)valueToFind);
        Console.WriteLine($"{(foundNode?.Value != valueToFind ? "No such node was found!" : "Node found successfully!")}");

        return foundNode != null ? foundNode : null;
    }
}