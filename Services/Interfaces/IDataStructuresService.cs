namespace Services.Interfaces;

public interface IDataStructuresService
{
    public LinkedList<int> ReverseALinkedList(LinkedList<int> linkedList);
    public LinkedListNode<int>? FindNodeInLinkedList(LinkedList<int>? linkedList, int? valueToFind);
    public LinkedList<int> MergeTwoLinkedListsUsingLINQ(LinkedList<int> linkedListOne, LinkedList<int> linkedListTwo);
    public LinkedList<int> RemoveDuplicatesFromLinkedListUsingHashSet(LinkedList<int> linkedList);
    public LinkedList<int> RemoveDuplicatesFromLinkedListUsingLINQ(LinkedList<int> linkedList);
    public Stack<string> ReverseAStack(Stack<string> inputStack);
}