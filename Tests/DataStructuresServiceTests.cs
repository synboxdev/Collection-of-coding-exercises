using Services;

namespace Tests;

public class DataStructuresServiceTests
{
    private readonly DataStructuresService dataStructuresService;

    public DataStructuresServiceTests()
    {
        dataStructuresService = new DataStructuresService();
    }

    [Fact]
    public void ReverseALinkedList_ReverseALinkedListWithNullOrEmptyParameter_ReturnsValidAnswer()
    {
        LinkedListNode<int> sampleNode = new LinkedListNode<int>(9);

        Assert.Equal(sampleNode.Value, dataStructuresService.ReverseALinkedList(null).First.Value);
        Assert.Equal(sampleNode.Value, dataStructuresService.ReverseALinkedList(new LinkedList<int>()).First.Value);
    }

    [Fact]
    public void FindNodeInLinkedList_FindNodeInLinkedListWithValidNode_ReturnsFoundNode()
    {
        Assert.Equal(5, dataStructuresService.FindNodeInLinkedList(null, 5).Value);
    }

    [Fact]
    public void FindNodeInLinkedList_FindNodeInLinkedListWithNonExistantNode_ReturnsNull()
    {
        Assert.Null(dataStructuresService.FindNodeInLinkedList(null, 99));
    }

    [Fact]
    public void MergeTwoLinkedListsUsingLINQ_MergeTwoLinkedListsUsingLINQWithNullParameters_ResultLinkedListHasSameAmountOfElements()
    {
        Assert.Equal(10, dataStructuresService.MergeTwoLinkedListsUsingLINQ(null, null).Count);
    }

    [Fact]
    public void MergeTwoLinkedListsUsingLINQ_MergeTwoLinkedListsUsingLINQWithNullParameters_ResultLinkedListIsNotNullOrEmpty()
    {
        Assert.NotNull(dataStructuresService.MergeTwoLinkedListsUsingLINQ(null, null));
        Assert.NotEmpty(dataStructuresService.MergeTwoLinkedListsUsingLINQ(null, null));
    }

    [Fact]
    public void RemoveDuplicatesFromLinkedListUsingHashSet_RemoveDuplicatesFromLinkedListUsingHashSetWithNullParameters_ResultsDefaultLinkedListWithoutDuplicatesLength()
    {
        Assert.Equal(3, dataStructuresService.RemoveDuplicatesFromLinkedListUsingHashSet(null).Count);
    }

    [Fact]
    public void RemoveDuplicatesFromLinkedListUsingHashSet_RemoveDuplicatesFromLinkedListUsingHashSetWithNullParameters_ResultsDefaultLinkedListWithoutDuplicates()
    {
        LinkedList<int> sampleLinkedList = new LinkedList<int>();
        sampleLinkedList.AddLast(1);
        sampleLinkedList.AddLast(1);
        sampleLinkedList.AddLast(2);
        sampleLinkedList.AddLast(3);

        Assert.Equal(1, dataStructuresService.RemoveDuplicatesFromLinkedListUsingHashSet(sampleLinkedList).First.Value);
        Assert.Equal(3, dataStructuresService.RemoveDuplicatesFromLinkedListUsingHashSet(sampleLinkedList).Last.Value);
    }

    [Fact]
    public void RemoveDuplicatesFromLinkedListUsingLINQ_RemoveDuplicatesFromLinkedListUsingLINQWithNullParameters_ResultsDefaultLinkedListWithoutDuplicatesLength()
    {
        Assert.Equal(3, dataStructuresService.RemoveDuplicatesFromLinkedListUsingLINQ(null).Count);
    }

    [Fact]
    public void RemoveDuplicatesFromLinkedListUsingLINQ_RemoveDuplicatesFromLinkedListUsingLINQWithNullParameters_ResultsDefaultLinkedListWithoutDuplicates()
    {
        LinkedList<int> sampleLinkedList = new LinkedList<int>();
        sampleLinkedList.AddLast(2);
        sampleLinkedList.AddLast(2);
        sampleLinkedList.AddLast(4);
        sampleLinkedList.AddLast(4);

        Assert.Equal(2, dataStructuresService.RemoveDuplicatesFromLinkedListUsingLINQ(sampleLinkedList).First.Value);
        Assert.Equal(4, dataStructuresService.RemoveDuplicatesFromLinkedListUsingLINQ(sampleLinkedList).Last.Value);
    }

    [Fact]
    public void ReverseAStack_ReverseAStackWithNullParameters_ResultsDefaultReversedStack()
    {
        Assert.Equal("Apple", dataStructuresService.ReverseAStack(null).FirstOrDefault());
        Assert.Equal("Pear", dataStructuresService.ReverseAStack(null).LastOrDefault());
    }

    [Fact]
    public void ReverseAStack_ReverseAStackWithValidInputStack_ResultsReversedStack()
    {
        string[] sampleArr = new string[] { "Collection", "of", "coding", "exercises" };
        Stack<string> sampleStack = new Stack<string>(sampleArr);

        var reversedStack = dataStructuresService.ReverseAStack(sampleStack);
        Assert.Equal("Collection", reversedStack.FirstOrDefault());
        Assert.Equal("exercises", reversedStack.LastOrDefault());
    }
}