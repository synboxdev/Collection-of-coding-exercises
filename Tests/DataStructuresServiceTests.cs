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
}