//
// PlayerStand.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 「立ち」状態
/// </summary>
public class EnemyStand : EnemyState
{

    // インスタンス
    private static EnemyStand m_instance = null;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    private EnemyStand() { }

    /// <summary>
    /// クラスのインスタンス
    /// </summary>
    public static EnemyStand Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new EnemyStand();
            return m_instance;
        }
    }

    /// <summary>
    /// 実行処理
    /// </summary>
    public override void Execute()
    {
        // アニメーター
        Animator animator = m_enemy.GetComponent<Animator>();

        // 「立ち」状態を再生する
        animator.SetBool("standing", true);
    }
}
