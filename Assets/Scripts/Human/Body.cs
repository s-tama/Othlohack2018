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

    // メッシュ
    private Mesh m_mesh;

    // 変
    [SerializeField][Range(1, 10)]
    private float m_vertTmp = 1;


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {
        m_mesh = GetComponent<MeshFilter>().mesh;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        Vector3[] vertices = m_mesh.vertices;
        Vector3[] normals = m_mesh.normals;

        for (var i = 0; i < vertices.Length; i++)
        {
            vertices[i] += normals[i] * Mathf.Sin(Time.time);
        }

        m_mesh.vertices = vertices;
    }
}
