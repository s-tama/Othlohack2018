using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ワイプエフェクト
/// </summary>
public class WipeEffect : MonoBehaviour
{

    // レンダラー
    private Image m_renderer;

    // フェード値
    private float m_fade;


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {
        // レンダラーの作成
        m_renderer = GetComponent<Image>();
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
