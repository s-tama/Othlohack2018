//
// PostEffect.cs
//

using UnityEngine;

/// <summary>
/// ポストエフェクト
/// </summary>
public class PostEffect : MonoBehaviour
{

    public Material wipeCircle;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, wipeCircle);
    }
}
