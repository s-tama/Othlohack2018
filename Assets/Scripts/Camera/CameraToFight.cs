//
// CameraToFight.cs
//

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 戦闘状態の位置へ移動状態
/// </summary>
public class CameraToFight : CameraState
{

    // インスタンス
    private static CameraToFight m_instance = null;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    private CameraToFight() { }

    /// <summary>
    /// クラスのインスタンス
    /// </summary>
    public static CameraToFight Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new CameraToFight();
            return m_instance;
        }
    }

    /// <summary>
    /// 実行処理
    /// </summary>
    public override void Execute()
    {
        // アニメーター
        Animator animator = m_camera.GetComponent<Animator>();

        // 「戦闘位置」アニメーションを再生
        animator.SetBool("toFighting", true);

        // アニメーションの終了判定
        if (m_camera.transform.position == new Vector3(0.8f, 1, -14))
        {
            // 「戦闘」状態に変更
            animator.SetBool("toFighting", false);
            m_camera.CameraState = CameraFight.Instance;
        }
    }
}
