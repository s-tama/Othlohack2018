//
// EffectManager.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム内エフェクト管理クラス
/// </summary>
public class EffectManager : MonoBehaviour
{

    // フラグ用定数
    private readonly byte PLAY_GENERATE = 1 << 7;       // 生成エフェクト再生フラグ
    private readonly byte FADE_BACKGROUND = 1 << 6;     // 背景フェードフラグ


    // 風エフェクトへの参照
    [SerializeField]
    private GameObject m_windEffect;

    // アバター生成エフェクトへの参照
    [SerializeField]
    private GenerateCircle m_generateCircle = null;

    // 背景エフェクトへの参照
    [SerializeField]
    private BackgroundEffect m_backgroundEffect = null;

    // メディエーター
    private Mediator m_mediator;

    // フラグ
    private Flag m_flag = new Flag();


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {
        // メディエーターの作成
        m_mediator = GameObject.FindGameObjectWithTag("Mediator").GetComponent<Mediator>();
        m_generateCircle.gameObject.SetActive(false);
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        UIManager uiManager = m_mediator.UIManager;
        if (m_windEffect != null)
        {
            // 「時は来た」テキストが範囲外で風エフェクトを破棄
            if (uiManager.ComeTimeText.rectTransform.position.x >= 500)
            {
                // 風エフェクトを破棄する
                Destroy(m_windEffect);
                // アバター生成エフェクトを「活動中」にする
                m_generateCircle.gameObject.SetActive(true);
                // アバター生成エフェクトを再生する
                m_flag.On(PLAY_GENERATE);
            }
        }

        if (m_generateCircle != null)
        {
            if (m_flag.Check(PLAY_GENERATE) == true)
            {
                // 生成エフェクトを動かす
                m_generateCircle.transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }

            // 絶対座標との距離が1を超えた
            bool isDist = (Vector3.Distance(m_generateCircle.transform.position, m_generateCircle.FixedPosition) > 1);
            if (isDist)
            {
                // 生成エフェクトを削除
                m_generateCircle.gameObject.SetActive(false);
                m_generateCircle.transform.position = new Vector3(0, 20, 0); 
                // 背景をフェードする
                m_flag.On(FADE_BACKGROUND);
            }
        }

        if (m_flag.Check(FADE_BACKGROUND) == true)
        {
            // 背景をフェードする
            if (m_mediator.EffectManager.BackgroundEffect.Fade < 1)
            {
                m_mediator.EffectManager.BackgroundEffect.Fade += 0.2f * Time.deltaTime;
            }
        }

        // フェード値が1以上
        if (m_mediator.EffectManager.BackgroundEffect.Fade >= 1)
        {
            // 戦いフラグをオンにする
            m_mediator.GameDirector.Flag.On(m_mediator.GameDirector.FIGHT);
        }
    }

    #region プロパティ
    /// <summary>
    /// 生成エフェクト
    /// </summary>
    public GenerateCircle GenerateCircle
    {
        get { return m_generateCircle; }
    }
    /// <summary>
    /// 背景エフェクト
    /// </summary>
    public BackgroundEffect BackgroundEffect
    {
        get { return m_backgroundEffect; }
    }
    #endregion
}
