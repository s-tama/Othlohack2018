//
// AvaterMaterial.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アバターマテリアル
/// </summary>
public class AvatarMaterial : MonoBehaviour
{

    // メッシュ
    private SkinnedMeshRenderer m_skinnedMeshRenderer;

    // メディエーター
    private Mediator m_mediator;


	/// <summary>
    /// 開始処理
    /// </summary>
	private void Start ()
    {
        // メディエーターの作成
        m_mediator = GameObject.FindGameObjectWithTag("Mediator").GetComponent<Mediator>();
        // スキンメッシュレンダラーの作成
        m_skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
	}
	
	/// <summary>
    /// 更新処理
    /// </summary>
	private void Update ()
    {
        if (m_mediator.EffectManager.GenerateCircle != null)
        {
            for (int i = 0; i < m_skinnedMeshRenderer.materials.Length; i++)
            {
                // マテリアルの値を設定する
                m_skinnedMeshRenderer.materials[i].SetFloat("_AppearPos", 
                    m_mediator.EffectManager.GenerateCircle.transform.position.y);
            }
        }
    }
}
