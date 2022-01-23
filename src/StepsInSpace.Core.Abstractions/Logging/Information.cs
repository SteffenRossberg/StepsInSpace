using Microsoft.Extensions.Logging;

namespace StepsInSpace.Core.Abstractions.Logging;

public static class Information
{
    public static readonly EventId ProgramInfoLog = new EventId(1, "INFO#000.001");
}