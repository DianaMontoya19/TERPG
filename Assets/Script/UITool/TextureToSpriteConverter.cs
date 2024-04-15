using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureToSpriteConverter : MonoBehaviour
{
    
    
    public Texture2D RenderTextureToTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
    
    public RenderTexture[] renderTextures; // Asigna tus RenderTextures aquí en el inspector de Unity

    public Sprite[] ConvertRenderTexturesToSprites()
    {
        Sprite[] sprites = new Sprite[renderTextures.Length];

        for (int i = 0; i < renderTextures.Length; i++)
        {
            Texture2D tex = RenderTextureToTexture2D(renderTextures[i]);
            sprites[i] = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        }

        return sprites;
    }
}
