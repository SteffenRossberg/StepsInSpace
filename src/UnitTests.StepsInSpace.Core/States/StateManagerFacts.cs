using System;
using Moq;
using StepsInSpace.Core.Abstractions.States;
using StepsInSpace.Core.States;
using Xunit;

namespace UnitTests.StepsInSpace.Core.States;

public class StateManagerFacts
{
    private readonly Mock<IState> _introStateMock;
    private readonly Mock<IState> _mainStateMock;
    private readonly Mock<IState> _levelStateMock;
    private readonly Mock<IEmptyState> _emptyStateMock;
    private readonly Func<StateManager> _createStateManager;
    
    public StateManagerFacts()
    {
        _introStateMock = new Mock<IState>();
        _mainStateMock = new Mock<IState>();
        _levelStateMock = new Mock<IState>();
        
        _emptyStateMock = new Mock<IEmptyState>();
        _createStateManager = () => new StateManager(_emptyStateMock.Object);
    }

    [Fact]
    public void Initializes_manager()
    {
        // Given
        
        // When
        var sut = _createStateManager();
        
        // Then
        Assert.Equal(_emptyStateMock.Object, sut.Current);
    }
    
    [Fact]
    public void Adds_state()
    {
        // Given
        var sut = _createStateManager();
        sut.Add(TestStateId.Intro, _introStateMock.Object);
        sut.Add(TestStateId.Main, _mainStateMock.Object);
        
        // When
        sut.Add(TestStateId.Level, _levelStateMock.Object);
        
        // Then
        Assert.Contains(_levelStateMock.Object, sut.States);
    }

    [Fact]
    public void Switches_to_state()
    {
        // Given
        var sut = _createStateManager();
        sut.Add(TestStateId.Intro, _introStateMock.Object);
        sut.Add(TestStateId.Main, _mainStateMock.Object);
        sut.Add(TestStateId.Level, _levelStateMock.Object);
        
        // When
        sut.Switch(TestStateId.Level);
        
        // Then
        Assert.Equal(_levelStateMock.Object, sut.Current);
        _emptyStateMock.Verify(state => state.Unload(), Times.Once);
        _levelStateMock.Verify(state => state.Load(), Times.Once);
    }

    [Fact]
    public void Removes_current_state()
    {
        // Given
        var sut = _createStateManager();
        sut.Add(TestStateId.Intro, _introStateMock.Object);
        sut.Add(TestStateId.Main, _mainStateMock.Object);
        sut.Add(TestStateId.Level, _levelStateMock.Object);
        sut.Switch(TestStateId.Level);
        
        // When
        sut.Remove(TestStateId.Level);
        
        // Then
        Assert.DoesNotContain(_levelStateMock.Object, sut.States);
        _levelStateMock.Verify(state => state.Unload());
        _levelStateMock.Verify(state => state.Dispose());
        Assert.Equal(_emptyStateMock.Object, sut.Current);
    }

    [Fact]
    public void Removes_state()
    {
        // Given
        var sut = _createStateManager();
        sut.Add(TestStateId.Intro, _introStateMock.Object);
        sut.Add(TestStateId.Main, _mainStateMock.Object);
        sut.Add(TestStateId.Level, _levelStateMock.Object);
        sut.Switch(TestStateId.Level);
        
        // When
        sut.Remove(TestStateId.Main);
        
        // Then
        Assert.DoesNotContain(_mainStateMock.Object, sut.States);
        _mainStateMock.Verify(state => state.Dispose());
        Assert.Equal(_levelStateMock.Object, sut.Current);
    }

    [Fact]
    public void Updates_state()
    {
        // Given
        var sut = _createStateManager();
        sut.Add(TestStateId.Intro, _introStateMock.Object);
        sut.Add(TestStateId.Main, _mainStateMock.Object);
        sut.Add(TestStateId.Level, _levelStateMock.Object);
        sut.Switch(TestStateId.Level);
        const double elapsedTime = 1.0;
        
        // When
        sut.Update(elapsedTime);
        
        // Then
        _levelStateMock.Verify(state => state.Update(elapsedTime));
    }

    [Fact]
    public void Renders_state()
    {
        // Given
        var sut = _createStateManager();
        sut.Add(TestStateId.Intro, _introStateMock.Object);
        sut.Add(TestStateId.Main, _mainStateMock.Object);
        sut.Add(TestStateId.Level, _levelStateMock.Object);
        sut.Switch(TestStateId.Level);
        
        // When
        sut.Render();
        
        // Then
        _levelStateMock.Verify(state => state.Render());
    }

    [Fact]
    public void Disposes_states()
    {
        // Given
        var sut = _createStateManager();
        sut.Add(TestStateId.Intro, _introStateMock.Object);
        sut.Add(TestStateId.Main, _mainStateMock.Object);
        sut.Add(TestStateId.Level, _levelStateMock.Object);
        
        // When
        sut.Dispose();
        
        // Then
        _introStateMock.Verify(state => state.Dispose());
        _mainStateMock.Verify(state => state.Dispose());
        _levelStateMock.Verify(state => state.Dispose());
        Assert.Empty(sut.States);
        Assert.Equal(_emptyStateMock.Object, sut.Current);
    }

    
    private class TestStateId : StateId
    {
        private TestStateId(string id) : base(id) { }

        public static readonly TestStateId Intro = new(nameof(Intro));
        public static readonly TestStateId Main = new(nameof(Main));
        public static readonly TestStateId Level = new(nameof(Level));
    }
}