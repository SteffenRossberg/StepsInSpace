using System;
using System.Runtime.CompilerServices;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using StepsInSpace.Core.Abstractions.Graphics;

namespace StepsInSpace.Core.Graphics;

public class GlContext : IGlContext
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void AttachShader(int program, int shader) => GL.AttachShader(program, shader);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void BindBuffer(BufferTarget target, int buffer) => GL.BindBuffer(target, buffer);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void BindTexture(TextureTarget target, int texture) => GL.BindTexture(target, texture);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void BindVertexArray(int array) => GL.BindVertexArray(array);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void BlendFunc(BlendingFactor sFactor, BlendingFactor dFactor) => GL.BlendFunc(sFactor, dFactor);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void BufferData<T>(BufferTarget target, IntPtr size, T[] data, BufferUsageHint usage) 
        where T : struct 
        => GL.BufferData(target, size, data, usage);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Clear(ClearBufferMask mask) => GL.Clear(mask);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void ClearColor(Color4 color) => GL.ClearColor(color);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void ClearDepth(double depth) => GL.ClearDepth(depth);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void CompileShader(int shader) => GL.CompileShader(shader);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public int CreateProgram() => GL.CreateProgram();

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public int CreateShader(ShaderType type) => GL.CreateShader(type);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void DeleteBuffer(int buffers) => GL.DeleteBuffer(buffers);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void DeleteProgram(int program) => GL.DeleteProgram(program);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void DeleteTexture(int textures) => GL.DeleteTexture(textures);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void DeleteShader(int shader) => GL.DeleteShader(shader);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void DepthFunc(DepthFunction func) => GL.DepthFunc(func);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void DisableVertexAttribArray(int index) => GL.DisableVertexAttribArray(index);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void DrawArrays(PrimitiveType mode, int first, int count) => GL.DrawArrays(mode, first, count);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Enable(EnableCap cap) => GL.Enable(cap);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void EnableVertexAttribArray(int index) => GL.EnableVertexAttribArray(index);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Finish() => GL.Finish();

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void GenBuffers(int n, out int buffers) => GL.GenBuffers(n, out buffers);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void GenTextures(int n, out int textures) => GL.GenTextures(n, out textures);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void GenVertexArrays(int n, out int arrays) => GL.GenVertexArrays(n, out arrays);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string GetProgramInfoLog(int program) => GL.GetProgramInfoLog(program);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void GetShader(int shader, ShaderParameter parameterName, out int parameter) 
        => GL.GetShader(shader, parameterName, out parameter);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string GetShaderInfoLog(int shader) => GL.GetShaderInfoLog(shader);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public int GetUniformLocation(int program, string name) => GL.GetUniformLocation(program, name);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void LinkProgram(int program) => GL.LinkProgram(program);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void ShaderSource(int shader, string code) => GL.ShaderSource(shader, code);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void TexImage2D<T>(TextureTarget target, int level, PixelInternalFormat internalformat, 
        int width, int height, int border, PixelFormat format, PixelType type, T[] pixels) 
        where T : struct 
        => GL.TexImage2D(target, level, internalformat, width, height, border, format, type, pixels);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void TexParameter(TextureTarget target, TextureParameterName parameterName, int parameter) 
        => GL.TexParameter(target, parameterName, parameter);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Uniform1(int location, int v0) => GL.Uniform1(location, v0);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void UniformMatrix4(int location, bool transpose, ref Matrix4 matrix) 
        => GL.UniformMatrix4(location, transpose, ref matrix);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void UseProgram(int program) => GL.UseProgram(program);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void VertexAttribPointer(int index, int size, VertexAttribPointerType type, 
        bool normalized, int stride, IntPtr pointer) 
        => GL.VertexAttribPointer(index, size, type, normalized, stride, pointer);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Viewport(int x, int y, int width, int height) => GL.Viewport(x, y, width, height);
}