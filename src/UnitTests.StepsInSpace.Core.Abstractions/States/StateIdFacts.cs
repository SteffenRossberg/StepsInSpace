using StepsInSpace.Core.Abstractions.States;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Abstractions.States;

public class StateIdFacts
{
    [Fact]
    public void Initializes_id()
    {
        // Given
        
        // When
        var sut = TestStates.Main;
        
        // Then
        Assert.Equal(nameof(TestStates.Main), sut.Id);
        
        // When
        sut = TestStates.Intro;
        
        // Then
        Assert.Equal(nameof(TestStates.Intro), sut.Id);
        
        // When
        sut = TestStates.Game;
        
        // Then
        Assert.Equal(nameof(TestStates.Game), sut.Id);
    }

    private class TestStates : StateId
    {
        private TestStates(string id)
            : base(id)
        {
        }

        public static TestStates Main { get; } = new TestStates(nameof(Main));
        public static TestStates Intro { get; } = new TestStates(nameof(Intro));
        public static TestStates Game { get; } = new TestStates(nameof(Game));
    }
}