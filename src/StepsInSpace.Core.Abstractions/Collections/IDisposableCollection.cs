using System;
using System.Collections.Generic;

namespace StepsInSpace.Core.Abstractions.Collections;

public interface IDisposableCollection : IDisposable
{
    void Add(IDisposable item);
    void AddRange(IEnumerable<IDisposable> items);
}