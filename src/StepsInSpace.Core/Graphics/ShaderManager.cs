using System;
using System.Collections.Concurrent;
using OpenTK.Graphics.OpenGL;
using StepsInSpace.Core.Abstractions.Graphics;
using StepsInSpace.Core.Abstractions.Resources;

namespace StepsInSpace.Core.Graphics;

public class ShaderManager : IShaderManager
{
    public ShaderManager(
        IGlContext glContext,
        IResourceManager resourceManager)
    {
        _glContext = glContext;
        _resourceManager = resourceManager;
        _compiledShaders = new();
    }

    public int GetCompiledShader(string file, ShaderType type)
        => _compiledShaders.GetOrAdd((file, type), key => CompileShader(key.File, key.Type));

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
        return shaderId;
    }
    
    private readonly IGlContext _glContext;
    private readonly IResourceManager _resourceManager;
    private readonly ConcurrentDictionary<(string File, ShaderType Type), int> _compiledShaders;
}