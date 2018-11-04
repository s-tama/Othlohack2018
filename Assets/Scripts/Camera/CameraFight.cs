//
// CameraFight.cs
//

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラ停止状態
/// </summary>
public class CameraFight : CameraState
{

    // インスタンス
    private static CameraFight m_instance = null;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    private CameraFight() { }

    /// <summary>
    /// クラスのインスタンス
    /// </summary>
    public static CameraFight Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new CameraFight();
            return m_instance;
        }
    }

    /// <summary>
    /// 実行処理
    /// </summary>
    public override void Execute()
    {
        Player p = GameObject.Find("Player").GetComponent<Player>();
        m_camera.transform.position = new Vector3(
                p.transform.position.x + 0.8f,
                m_camera.transform.position.y,
                p.transform.position.z - 2
            );
    }
}
