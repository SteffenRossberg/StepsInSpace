using StepsInSpace.Core.States;
using Xunit;

namespace UnitTests.StepsInSpace.Core.States;

public class EmptyStateFacts
{
    [Fact]
    public void Throws_no_exception_on_Load()
    {
        // Given
        var sut = new EmptyState();
        
        // When
        sut.Load();
        
        // Then
        
    }
    
    [Fact]
    public void Throws_no_exception_on_Unload()
    {
        // Given
        var sut = new EmptyState();
        
        // When
        sut.Unload();
        
        // Then
        
    }
    
    [Fact]
    public void Throws_no_exception_on_Update()
    {
        // Given
        var sut = new EmptyState();
        
        // When
        sut.Update(default);
        
        // Then
        
    }
    
    [Fact]
    public void Throws_no_exception_on_Render()
    {
        // Given
        var sut = new EmptyState();
        
        // When
        sut.Render();
        
        // Then
        
    }
    
    [Fact]
    public void Throws_no_exception_on_Dispose()
    {
        // Given
        var sut = new EmptyState();
        
        // When
        sut.Dispose();
        
        // Then
        
    }
}