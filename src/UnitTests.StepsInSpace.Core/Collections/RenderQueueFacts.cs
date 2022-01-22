using Moq;
using OpenTK.Graphics.OpenGL;
using StepsInSpace.Core.Abstractions.Graphics;
using StepsInSpace.Core.Collections;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Collections;

public class RenderQueueFacts
{
    [Fact]
    public void Initializes_queue()
    {
        // Given
        
        // When
        var sut = new RenderQueue();
        
        // Then
        Assert.True(sut.IsEmpty);
    }

    [Fact]
    public void Updates_IsEmpty()
    {
        // Given
        var sut = new RenderQueue();
        
        // When
        sut.Enqueue(() => {});
        
        // Then
        Assert.False(sut.IsEmpty);
    }

    [Fact]
    public void Processes_actions()
    {
        // Given
        var sut = new RenderQueue();
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
}