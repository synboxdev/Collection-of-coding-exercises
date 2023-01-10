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
}