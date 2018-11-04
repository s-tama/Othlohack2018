using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{

    // カメラへの参照
    protected Player m_player;


    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="player">プレイヤーの参照</param>
    public void Initialize(Player player)
    {
        m_player = player;
    }

    /// <summary>
    /// 実行処理
    /// </summary>
    public abstract void Execute();
}
