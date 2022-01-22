using System;
using System.Collections.Generic;

namespace StepsInSpace.Core.Abstractions.States;

public interface IStateManager : IDisposable
{
    IReadOnlyList<IState> States { get; }
    IState Current { get; }

    void Add(StateId id, IState state);
    void Remove(StateId id);
    void Switch(StateId id);
    void Update(double elapsedTime);
    void Render();
}