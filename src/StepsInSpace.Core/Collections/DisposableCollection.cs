using System;
using System.Collections.Generic;
using StepsInSpace.Core.Abstractions.Collections;

namespace StepsInSpace.Core.Collections;

public class DisposableCollection : IDisposableCollection
{
    public DisposableCollection()
    {
        _itemsToDispose = new();
    }
    
    public void Add(IDisposable item) => _itemsToDispose.Add(item);

    public void AddRange(IEnumerable<IDisposable> items) => _itemsToDispose.AddRange(items);

    private void DisposeCollection()
    {
        for (var index = _itemsToDispose.Count - 1; index >= 0; --index)
        {
            _itemsToDispose[index].Dispose();
        }
        _itemsToDispose.Clear();
    }
    
    public void Dispose()
    {
        DisposeCollection();
        GC.SuppressFinalize(this);
    }

    ~DisposableCollection() => DisposeCollection();

    private readonly List<IDisposable> _itemsToDispose;
}