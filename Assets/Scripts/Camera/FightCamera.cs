//
// FightCamera.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 戦いシーンのカメラクラス
/// </summary>
public class FightCamera : MonoBehaviour
{

    // 現在の状態
    private CameraState m_currentState;

    // メディエーター
    private Mediator m_mediator;

    // 振動時間
    private float m_vibrationCount = 0;


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {
        // メディエーターの作成
        m_mediator = GameObject.FindGameObjectWithTag("Mediator").GetComponent<Mediator>();

        // 状態を初期化
        CameraStop.Instance.Initialize(this);
        CameraToFight.Instance.Initialize(this);
        CameraFight.Instance.Initialize(this);

        // 初期状態を設定する
        m_currentState = CameraStop.Instance;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        // 現在の状態を実行する
        if (m_currentState != null)
        {
            m_currentState.Execute();
        }
    }


    /// <summary>
    /// カメラを揺らす
    /// </summary>
    /// <param name="time">揺らす時間</param>
    public void VibrationCamera(float time)
    {
        m_vibrationCount += Time.deltaTime;

        if (m_vibrationCount < time)
        {
            float randomX = Random.Range(-1.5f, 1.5f);
            float randomY = Random.Range(-1.5f, 1.5f);
            this.transform.position += new Vector3(randomX, randomY, 0) * Time.deltaTime;
        }
    }

    /// <summary>
    /// 状態の情報
    /// </summary>
    public CameraState CameraState
    {
        get { return m_currentState; }
        set { m_currentState = value; }
    }

    /// <summary>
    /// メディエーター
    /// </summary>
    public Mediator Mediator
    {
        get { return m_mediator; }
    }
}
