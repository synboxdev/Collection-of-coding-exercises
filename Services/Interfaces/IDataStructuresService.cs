namespace Services.Interfaces;

public interface IDataStructuresService
{
    public LinkedList<int> ReverseALinkedList(LinkedList<int> linkedList);
    public LinkedListNode<int>? FindNodeInLinkedList(LinkedList<int>? linkedList, int? valueToFind);
    public LinkedList<int> MergeTwoLinkedListsUsingLINQ(LinkedList<int> linkedListOne, LinkedList<int> linkedListTwo);
}