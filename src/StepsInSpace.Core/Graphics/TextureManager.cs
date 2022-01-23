using System.Collections.Concurrent;
using OpenTK.Graphics.OpenGL;
using StepsInSpace.Core.Abstractions.Graphics;
using StepsInSpace.Core.Abstractions.Resources;

namespace StepsInSpace.Core.Graphics;

public class TextureManager : ITextureManager
{
    private readonly IResourceManager _resourceManager;
    private readonly IGlContext _glContext;
    private readonly ConcurrentDictionary<string, int> _textures;

    public TextureManager(
        IGlContext glContext,
        IResourceManager resourceManager)
    {
        _glContext = glContext;
        _resourceManager = resourceManager;
        _textures = new ConcurrentDictionary<string, int>();
    }

    public int GetTexture(string file)
        => _textures.GetOrAdd(file, LoadTexture);
    
    private int LoadTexture(string file)
    {
        var texture = _resourceManager.GetTextureData(file);
        var textureId = _glContext.GenTextures(1);
        _glContext.BindTexture(TextureTarget.Texture2D, textureId);
        _glContext.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
        _glContext.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
        _glContext.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        _glContext.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        _glContext.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureBaseLevel, 0);
        _glContext.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMaxLevel, 0);
        _glContext.TexImage2D(
            TextureTarget.Texture2D, 
            0, 
            PixelInternalFormat.Rgba, 
            texture.Width, 
            texture.Height, 
            0, 
            PixelFormat.Rgba, 
            PixelType.UnsignedByte, 
            texture.PixelData);
        return textureId;
    }
}