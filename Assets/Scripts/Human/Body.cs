//
// Body.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボディクラス
/// </summary>
public class Body : MonoBehaviour 
{

    // 体脂肪　
    [SerializeField][Header("体脂肪")][Range(1, 100)]
    private int m_fat = 20;


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {

    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        float scaleX = 5 - (100 / m_fat);
        float scaleY = this.transform.localScale.y;
        float scaleZ = 5 - (100 / m_fat);
        this.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    }
}
