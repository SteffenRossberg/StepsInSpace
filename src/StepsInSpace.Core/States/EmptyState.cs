using StepsInSpace.Core.Abstractions.States;

namespace StepsInSpace.Core.States;

public class EmptyState : IState
{
    public void Load()
    {
    }

    public void Update(double elapsedTime)
    {
    }

    public void Render()
    {
    }

    public void Unload()
    {
    }

    public void Dispose()
    {
    }
}
