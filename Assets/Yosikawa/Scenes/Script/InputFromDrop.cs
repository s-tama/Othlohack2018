using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFromDrop : MonoBehaviour {

    public Dropdown dropdown;    //操作するオブジェクトを設定する
    public Text txt;
    


    

    // Use this for initialization
    void Start () {
        Debug.Log("Start");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnValueChanged(int result)
    {
        // 処理
        txt.text = dropdown.captionText.text;//リストからテキストを取得

    }

    
}


