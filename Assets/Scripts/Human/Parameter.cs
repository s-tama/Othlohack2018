//
// Parameter.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ユーザーのパラメーター保持クラス
/// </summary>
public class Parameter
{

    // インスタンス
    private static Parameter m_instance;

    // 結果数値
    private float m_resultValue;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    private Parameter() { }

    /// <summary>
    /// クラスのインスタンスを取得
    /// </summary>
    /// <value>The instance.</value>
    public static Parameter Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new Parameter();
            return m_instance;
        }
    }

    /// <summary>
    // 結果を作成する
    /// </summary>
    /// <returns>The parameter.</returns>
    private float CreateResult()
    {
        m_resultValue = 0f;
        return 0f;
    }

    #region プロパティ
    /// <summary>
    /// 結果の数値
    /// </summary>
    /// <value>The result value.</value>
    public float ResultValue
    {
        get { return m_resultValue; }
    }
    #endregion
}
