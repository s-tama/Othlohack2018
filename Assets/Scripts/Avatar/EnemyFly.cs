//
// PlayerStand.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 「立ち」状態
/// </summary>
public class EnemyFly : EnemyState
{

    // インスタンス
    private static EnemyFly m_instance = null;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    private EnemyFly() { }

    /// <summary>
    /// クラスのインスタンス
    /// </summary>
    public static EnemyFly Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new EnemyFly();
            return m_instance;
        }
    }

    /// <summary>
    /// 実行処理
    /// </summary>
    public override void Execute()
    {
        m_enemy.transform.position += new Vector3(0, 0.5f, 16f) * Time.deltaTime;
        m_enemy.GetComponent<Animator>().SetBool("fighting", false);
        m_enemy.GetComponent<Animator>().SetBool("flying", true);
    }
}
