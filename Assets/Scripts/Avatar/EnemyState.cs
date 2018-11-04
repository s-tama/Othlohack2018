//
// EnemyState.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の状態クラス
/// </summary>
public abstract class EnemyState
{

    // カメラへの参照
    protected Enemy m_enemy;


    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="enemy">プレイヤーの参照</param>
    public void Initialize(Enemy enemy)
    {
        m_enemy = enemy;
    }

    /// <summary>
    /// 実行処理
    /// </summary>
    public abstract void Execute();
}
