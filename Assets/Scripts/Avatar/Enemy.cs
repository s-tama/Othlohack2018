//
// Enemy.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵（過去の自分）クラス
/// </summary>
public class Enemy : MonoBehaviour
{

    // 現在の状態
    private EnemyState m_currentState;


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {
        // 状態を初期化
        EnemyStand.Instance.Initialize(this);
        EnemyFight.Instance.Initialize(this);
        EnemyFly.Instance.Initialize(this);

        // 初期状態を設定する
        m_currentState = EnemyFight.Instance;
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
    public EnemyState EnemyState
    {
        get { return m_currentState; }
        set { m_currentState = value; }
    }
}
