using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 戦闘態勢クラス
/// </summary>
public class PlayerFight : PlayerState
{

    // フラグ用定数
    private readonly byte GO_TO_ENEMY = 1 << 7;
    private readonly byte PUNCH = 1 << 6;


    // インスタンス
    private static PlayerFight m_instance = null;

    // フラグ
    private Flag m_flag = new Flag();

    // 次のアクションまでのカウント
    private int m_nextAction = 0;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    private PlayerFight() { }

    /// <summary>
    /// クラスのインスタンス
    /// </summary>
    public static PlayerFight Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new PlayerFight();
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

        if (Camera.main.transform.position.z <= -14)
        {
            m_nextAction++;
        }

        if (m_nextAction >= 120)
        {
            m_nextAction = 0;
            animator.SetBool("fighting", false);
            animator.SetBool("walking", true);
            Camera.main.GetComponent<Animator>().applyRootMotion = true;
            m_flag.On(GO_TO_ENEMY);
        }

        if ((m_flag.Check(GO_TO_ENEMY) && !m_flag.Check(PUNCH)))
        {
            GameObject enemy = GameObject.Find("Enemy");
            if (m_player.transform.position.z < -9)
            {
                m_player.transform.Translate(0, 0, 2 * Time.deltaTime);
            }
            else
            {
                animator.SetBool("walking", false);
                
                m_flag.On(PUNCH);
            }
        }
        else
        {
            // 「立ち」状態を再生する
            animator.SetBool("fighting", true);
        }

        if (m_flag.Check(PUNCH))
        {
            animator.SetBool("punching", true);
            m_nextAction++;
            
            if(m_nextAction > 60)
            {
                Camera.main.GetComponent<FightCamera>().VibrationCamera(20);
            }
            if (m_nextAction > 80)
            {
                m_player.Flag.On(m_player.ACTION_END);
            }
        }
    }
}
