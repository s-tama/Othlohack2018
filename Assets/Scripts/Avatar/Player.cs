//
// Player.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// プレイヤー（自分）クラス
/// </summary>
public class Player : MonoBehaviour
{

    // フラグ用定数
    public readonly byte ACTION_END = 1 << 7;


    // 現在の状態
    private PlayerState m_currentState;

    // フラグ
    private Flag m_flag = new Flag();


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {
        // 状態を初期化
        PlayerStand.Instance.Initialize(this);
        PlayerFight.Instance.Initialize(this);

        // 初期状態を設定する
        m_currentState = PlayerStand.Instance;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        // 現在の状態を実行する
        if (m_currentState != null)
        {
            m_currentState.Execute();
        }
    }

    /// <summary>
    /// 状態の情報
    /// </summary>
    public PlayerState PlayerState
    {
        get { return m_currentState; }
        set { m_currentState = value; }
    }

    /// <summary>
    /// フラグ
    /// </summary>
    public Flag Flag
    {
        get { return m_flag; }
    }
}
