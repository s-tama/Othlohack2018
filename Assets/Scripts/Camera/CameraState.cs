//
// CameraState.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラ状態クラス
/// </summary>
public abstract class CameraState
{

    // カメラへの参照
    protected FightCamera m_camera;


    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="camera">カメラへの参照</param>
    public void Initialize(FightCamera camera)
    {
        m_camera = camera;
    }

    /// <summary>
    /// 実行処理
    /// </summary>
    public abstract void Execute();
}
