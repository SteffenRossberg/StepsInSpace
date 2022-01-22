using System;

namespace StepsInSpace.Core.Abstractions.States;

public interface IState : IDisposable
{
    void Load();
    void Update(double elapsedTime);
    void Render();
    void Unload();
}