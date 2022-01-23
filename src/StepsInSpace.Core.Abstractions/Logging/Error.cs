using Microsoft.Extensions.Logging;

namespace StepsInSpace.Core.Abstractions.Logging;

public static class Error
{
    public static readonly EventId ShaderIdIsNotRegistered = new EventId(1, "ERR#000.001");
}