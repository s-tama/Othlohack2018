//
// CameraStop.cs
//

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラ停止状態
/// </summary>
public class CameraStop : CameraState
{

    // インスタンス
    private static CameraStop m_instance = null;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    private CameraStop() { }

    /// <summary>
    /// クラスのインスタンス
    /// </summary>
    public static CameraStop Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new CameraStop();
            return m_instance;
        }
    }

    /// <summary>
    /// 実行処理
    /// </summary>
    public override void Execute()
    {
        // 戦いフラグが立った時点で「戦い」状態に変更
        if (m_camera.Mediator.GameDirector.Flag.Check(m_camera.Mediator.GameDirector.FIGHT))
        {
            m_camera.CameraState = CameraToFight.Instance;
        }
    }
}
