using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director1103 : MonoBehaviour
{

    // ワイプエフェクトへの参照を保つ
    [SerializeField]
    private WipeEffect m_wipeEffect;


	// Use this for initialization
	void Start ()
    {
        m_wipeEffect.Fade = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_wipeEffect.Fade += 2 * Time.deltaTime;
	}
}
