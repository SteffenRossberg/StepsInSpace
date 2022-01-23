using OpenTK.Graphics.OpenGL;

namespace StepsInSpace.Core.Abstractions.Graphics;

public interface IShaderManager
{
    int GetCompiledShader(string file, ShaderType type);

    int GetProgram(params int[] compiledShaders);
}