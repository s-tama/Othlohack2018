//
// GameDirector.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム監督クラス
/// </summary>
public class GameDirector : MonoBehaviour
{

    // フラグ用定数
    public readonly byte FIGHT = 1 << 7;    // 戦いフラグ
    public readonly byte NEXT = 1 << 6;


    // メディエーターへの参照
    private Mediator m_mediator = null;

    // フラグ
    private Flag m_flag = new Flag();


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {
        // メディエーターの作成
        m_mediator = GameObject.FindGameObjectWithTag("Mediator").GetComponent<Mediator>();

        m_mediator.UIManager.WipeEffect.Fade = 1;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        if (m_flag.Check(NEXT))
        {
            m_mediator.UIManager.WipeEffect.Fade -= 2 * Time.deltaTime;
        }

        if (m_mediator.UIManager.WipeEffect.Fade <= 0)
        {
            SceneManager.LoadScene("1103");
        }
    }

    #region プロパティ
    /// <summary>
    /// フラグ
    /// </summary>
    public Flag Flag
    {
        get { return m_flag; }
    }
    public Mediator Meditor
    {
        get { return m_mediator; }
    }
    #endregion
}
