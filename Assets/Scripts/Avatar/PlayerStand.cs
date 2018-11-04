//
// PlayerStand.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 「立ち」状態
/// </summary>
public class PlayerStand : PlayerState
{

    // インスタンス
    private static PlayerStand m_instance = null;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    private PlayerStand() { }

    /// <summary>
    /// クラスのインスタンス
    /// </summary>
    public static PlayerStand Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new PlayerStand();
            return m_instance;
        }
    }

    /// <summary>
    /// 実行処理
    /// </summary>
    public override void Execute()
    {
        // アニメーター
        Animator animator = m_player.GetComponent<Animator>();

        // 「立ち」状態を再生する
        animator.SetBool("standing", true);

        if (SceneManager.GetActiveScene().name == "FightScene")
        {
            // 「戦闘」状態に移行
            animator.SetBool("standing", false);
            m_player.PlayerState = PlayerFight.Instance;
        }
    }
}
