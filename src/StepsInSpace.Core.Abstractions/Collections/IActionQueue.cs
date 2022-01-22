using System;

namespace StepsInSpace.Core.Abstractions.Collections;

public interface IActionQueue
{
    bool IsEmpty { get; }
    
    void Enqueue(Action action);

    void Process();
}