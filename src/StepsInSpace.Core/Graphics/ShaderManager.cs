using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using OpenTK.Graphics.OpenGL;
using StepsInSpace.Core.Abstractions.Graphics;
using StepsInSpace.Core.Abstractions.Logging;
using StepsInSpace.Core.Abstractions.Resources;

namespace StepsInSpace.Core.Graphics;

public class ShaderManager : IShaderManager
{
    public ShaderManager(
        ILogger<ShaderManager> logger,
        IGlContext glContext,
        IResourceManager resourceManager)
    {
        _logger = logger;
        _glContext = glContext;
        _resourceManager = resourceManager;
        _compiledShaders = new();
        _compiledShaderIds = new();
        _programs = new();
    }

    public int GetCompiledShader(string file, ShaderType type)
        => _compiledShaders.GetOrAdd((file, type), key => CompileShader(key.File, key.Type));

    public int GetProgram(params int[] compiledShaders)
        => _programs.GetOrAdd(new ShaderIdsKey(compiledShaders), CreateProgram);
    
    private int CreateProgram(ShaderIdsKey shaderIds)
    {
        var programId = _glContext.CreateProgram();
        for (var index = 0; index < shaderIds.Ids.Count; ++index)
        {
            var shaderId = shaderIds.Ids[index];
            if (!_compiledShaderIds.ContainsKey(shaderId))
            {
                var ex = new InvalidOperationException();
                _logger.LogError(
                    Error.ShaderIdIsNotRegistered, 
                    ex, 
                    "Shader with id '{0}' is not registered.", 
                    shaderId);
                throw ex;
            }
            _glContext.AttachShader(programId, shaderId);
        }
        _glContext.LinkProgram(programId);
        var programInfo = _glContext.GetProgramInfoLog(programId);
        _logger.LogInformation(Information.ProgramInfoLog, "Program Info Log: {0}", programInfo);
        return programId;
    }

    private int CompileShader(string file, ShaderType type)
    {
        var shaderCode = string.Join("\n", _resourceManager.GetTextLines(file));
        var shaderId = _glContext.CreateShader(type);
        _glContext.ShaderSource(shaderId, shaderCode);
        _glContext.CompileShader(shaderId);
        if (_glContext.GetShader(shaderId, ShaderParameter.CompileStatus) != 1)
        {
            throw new InvalidOperationException(
                $"Shader {file} not compiled. Error: {_glContext.GetShaderInfoLog(shaderId)}");
        }
        _compiledShaderIds[shaderId] = (file, type);
        return shaderId;
    }

    private readonly ILogger<ShaderManager> _logger;
    private readonly IGlContext _glContext;
    private readonly IResourceManager _resourceManager;
    private readonly ConcurrentDictionary<(string File, ShaderType Type), int> _compiledShaders;
    private readonly ConcurrentDictionary<int, (string File, ShaderType Type)> _compiledShaderIds;
    private readonly ConcurrentDictionary<ShaderIdsKey, int> _programs;

    private readonly struct ShaderIdsKey
    {
        public readonly IReadOnlyList<int> Ids;

        public ShaderIdsKey(int[] shaderIds) => Ids = shaderIds;
        
        public override bool Equals(object? obj) => obj is ShaderIdsKey other && Ids.SequenceEqual(other.Ids);

        public override int GetHashCode()
        {
            switch (Ids.Count)
            {
                case 1: return Ids[0].GetHashCode();
                case 2: return HashCode.Combine(Ids[0], Ids[1]);
                case 3: return HashCode.Combine(Ids[0], Ids[1], Ids[2]);
                case 4: return HashCode.Combine(Ids[0], Ids[1], Ids[2], Ids[3]);
                case 5: return HashCode.Combine(Ids[0], Ids[1], Ids[2], Ids[3], Ids[4]);
                case 6: return HashCode.Combine(Ids[0], Ids[1], Ids[2], Ids[3], Ids[4], Ids[5]);
                case 7: return HashCode.Combine(Ids[0], Ids[1], Ids[2], Ids[3], Ids[4], Ids[5], Ids[6]);
                case 8: return HashCode.Combine(Ids[0], Ids[1], Ids[2], Ids[3], Ids[4], Ids[5], Ids[6], Ids[7]);
                default: throw new NotImplementedException();
            }
        }
    }
}