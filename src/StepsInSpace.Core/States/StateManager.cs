using System.Collections.Generic;
using StepsInSpace.Core.Abstractions.States;

namespace StepsInSpace.Core.States;

public class StateManager : IStateManager
{
    public IReadOnlyList<IState> States => _states;

    private IState _current;
    public IState Current => _current;

    public StateManager(IEmptyState emptyState)
    {
        _emptyState = emptyState;
        _current = _emptyState;
        _states = new List<IState>();
        _stateRegistry = new Dictionary<StateId, IState>();
    }
    
    public void Add(StateId id, IState state)
    {
        _states.Add(state);
        _stateRegistry[id] = state;
    }

    public void Remove(StateId id)
    {
        var state = _stateRegistry.TryGetValue(id, out var s) ? s : _emptyState;
        if (state == _current)
        {
            Switch(_emptyState);
        }
        _states.Remove(state);
        _stateRegistry.Remove(id);
        state.Dispose();
    }

    public void Switch(StateId id)
    {
        var state = _stateRegistry.TryGetValue(id, out var s) ? s : _emptyState;
        Switch(state);
    }

    public void Update(double elapsedTime) => _current.Update(elapsedTime);

    public void Render() => _current.Render();
    
    public void Dispose()
    {
        _current = _emptyState;
        _states.ForEach(state => state.Dispose());
        _states.Clear();
        _stateRegistry.Clear();
    }

    private void Switch(IState state)
    {
        var old = _current;
        state.Load();
        _current = state;
        old.Unload();
    }

    private readonly IEmptyState _emptyState;
    private readonly List<IState> _states;
    private readonly Dictionary<StateId, IState> _stateRegistry;
}