using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickListner : MonoBehaviour
{

    /// <summary>
    /// スタートボタンが押された
    /// </summary>
	public void OnStartButton()
    {
        SceneManager.LoadScene("FightScene");
    }
}
