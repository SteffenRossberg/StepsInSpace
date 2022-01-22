using StepsInSpace.Core.Collections;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Collections;

public class ActionQueueBaseFacts
{
    [Fact]
    public void Initializes_queue()
    {
        // Given
        
        // When
        var sut = new TestActionQueue();
        
        // Then
        Assert.True(sut.IsEmpty);
    }

    [Fact]
    public void Updates_IsEmpty()
    {
        // Given
        var sut = new TestActionQueue();
        
        // When
        sut.Enqueue(() => {});
        
        // Then
        Assert.False(sut.IsEmpty);
    }

    [Fact]
    public void Processes_actions()
    {
        // Given
        var sut = new TestActionQueue();
        var actual = 0;
        const int expected = 5;
        for (var index = 0; index < expected; ++index)
        {
            sut.Enqueue(() => ++actual);
        }
        
        // When
        sut.Process();
        
        // Then
        Assert.Equal(expected, actual);
        Assert.True(sut.IsEmpty);
    }

    private class TestActionQueue : ActionQueueBase
    {
    }
}