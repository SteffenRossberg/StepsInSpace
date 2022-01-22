namespace StepsInSpace.Core.Abstractions.States;

public abstract class StateId
{
    public string Id { get; }

    protected StateId(string id) => Id = id;

    public override string ToString() => Id;
}