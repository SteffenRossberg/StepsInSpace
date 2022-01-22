using System;
using Moq;
using StepsInSpace.Core.Collections;
using Xunit;

namespace UnitTests.StepsInSpace.Core.Collections;

public class DisposableCollectionFacts
{
    [Fact]
    public void Disposes_items_once()
    {
        // Given
        var sut = new DisposableCollection();
        var disposable1 = new Mock<IDisposable>();
        var disposable2 = new Mock<IDisposable>();
        var disposable3 = new Mock<IDisposable>();
        sut.Add(disposable1.Object);
        sut.AddRange(new []{disposable2.Object, disposable3.Object});
        sut.Dispose();
        
        // When
        sut.Dispose();
        
        // Then
        disposable1.Verify(item => item.Dispose(), Times.Once);
        disposable2.Verify(item => item.Dispose(), Times.Once);
        disposable3.Verify(item => item.Dispose(), Times.Once);
    }
}