//
// UIManager.cs
// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI管理クラス
/// </summary>
public class UIManager : MonoBehaviour
{

    // 「時は来た」テキストの参照
    [SerializeField]
    private Text m_comeTimeText = null;

    // ワイプエフェクト
    [SerializeField]
    private WipeEffect m_wipeEffect = null;


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        if (m_comeTimeText != null)
        {
            // 「時は来た」テキストが範囲外で削除する
            if (m_comeTimeText.rectTransform.anchoredPosition.x >= 600)
            {
                Destroy(m_comeTimeText);
            }
        }
    }

    #region プロパティ
    /// <summary>
    /// 「時は来た」テキスト
    /// </summary>
    public Text ComeTimeText
    {
        get { return m_comeTimeText; }
    }
    /// <summary>
    /// ワイプエフェクト
    /// </summary>
    public WipeEffect WipeEffect
    {
        get { return m_wipeEffect; }
    }
    #endregion
}
