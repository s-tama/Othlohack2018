using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アバター管理クラス
/// </summary>
public class AvatarManager : MonoBehaviour
{

    // 敵への参照
    [SerializeField]
    private Enemy m_enemy = null;

    // プレイヤーへの参照
    [SerializeField]
    private Player m_player = null;

    // メディエーターへの参照
    private Mediator m_mediator = null;


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {
        // メディエーターの作成
        m_mediator = GameObject.FindGameObjectWithTag("Mediator").GetComponent<Mediator>();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        if (m_enemy.transform.position.z > 20)
        {
            m_mediator.GameDirector.Flag.On(m_mediator.GameDirector.NEXT);
        }
    }


    #region プロパティ
    /// <summary>
    /// 敵
    /// </summary>
    public Enemy Enemy
    {
        get { return m_enemy; }
    }
    /// <summary>
    /// プレイヤー
    /// </summary>
    public Player Player
    {
        get { return m_player; }
    }
    #endregion
}
