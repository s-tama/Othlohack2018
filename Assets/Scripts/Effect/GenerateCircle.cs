//
// GenerateCircle.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アバター生成サークル
/// </summary>
public class GenerateCircle : MonoBehaviour
{

    // 絶対座標
    private Vector3 m_fixedPosition;


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {
        m_fixedPosition = this.transform.position;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update ()
    {
	}

    #region プロパティ
    /// <summary>
    /// 絶対座標
    /// </summary>
    public Vector3 FixedPosition
    {
        get { return m_fixedPosition; }
    }
    #endregion
}
