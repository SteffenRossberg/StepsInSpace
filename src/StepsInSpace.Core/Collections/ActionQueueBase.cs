using System;
using System.Collections.Concurrent;
using StepsInSpace.Core.Abstractions.Collections;

namespace StepsInSpace.Core.Collections;

public class ActionQueueBase : IActionQueue
{
    protected ActionQueueBase()
    {
        _queue = new();
    }
    
    public virtual bool IsEmpty => _queue.IsEmpty;
    
    public virtual void Enqueue(Action action) => _queue.Enqueue(action);
    
    public virtual void Process()
    {
        while (_queue.TryDequeue(out var action))
        {
            action();
        }
    }
    
    private readonly ConcurrentQueue<Action> _queue;
}