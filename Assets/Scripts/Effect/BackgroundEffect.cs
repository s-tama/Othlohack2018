//
// BackgroundEffect.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背景エフェクト
/// </summary>
public class BackgroundEffect : MonoBehaviour
{

    // レンダラー
    private Renderer m_renderer;

    // フェード値
    private float m_fade;


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {
        // レンダラーの作成
        m_renderer = GetComponent<Renderer>();

        // フェード値を初期化する
        m_fade = 0;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        // マテリアルの値を設定する
        m_renderer.material.SetFloat("_Threshold", m_fade);
    }

    #region プロパティ
    /// <summary>
    /// フェード値
    /// </summary>
    public float Fade
    {
        get { return m_fade; }
        set { m_fade = value; }
    }
    #endregion
}
