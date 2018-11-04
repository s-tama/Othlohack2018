using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 戦闘態勢クラス
/// </summary>
public class EnemyFight : EnemyState
{

    // インスタンス
    private static EnemyFight m_instance = null;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    private EnemyFight() { }

    /// <summary>
    /// クラスのインスタンス
    /// </summary>
    public static EnemyFight Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new EnemyFight();
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
        animator.SetBool("fighting", true);

        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player.Flag.Check(player.ACTION_END))
        {
            m_enemy.EnemyState = EnemyFly.Instance;
        }
    }
}
