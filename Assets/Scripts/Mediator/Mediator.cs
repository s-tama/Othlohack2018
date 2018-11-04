//
// Mediator.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// オブジェクト仲介役クラス
/// </summary>
public class Mediator : MonoBehaviour
{

    // UIManagerへの参照
    [SerializeField]
    private UIManager m_uiManager = null;

    // EffectManagerへの参照
    [SerializeField]
    private EffectManager m_effectManager = null;

    //ゲームディレクターへの参照
    [SerializeField]
    private GameDirector m_gameDirector = null;

    // アバターマネージャー
    [SerializeField]
    private AvatarManager m_avatarManager = null;


    #region プロパティ
    /// <summary>
    /// UIマネージャー
    /// </summary>
    public UIManager UIManager
    {
        get { return m_uiManager; }
    }
    /// <summary>
    /// エフェクトマネージャー
    /// </summary>
    public EffectManager EffectManager
    {
        get { return m_effectManager; }
    }
    /// <summary>
    /// ゲームディレクター
    /// </summary>
    public GameDirector GameDirector
    {
        get { return m_gameDirector; }
    }
    /// <summary>
    /// アバターマネージャー
    /// </summary>
    public AvatarManager AvatarManager
    {
        get { return m_avatarManager; }
    }
    #endregion
}
