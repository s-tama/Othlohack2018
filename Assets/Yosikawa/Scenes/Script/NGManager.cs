using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class NGManager : MonoBehaviour {

    public Button next;
    public Button prev;
    //public InputField namet;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnClickN() {
        SceneManager.LoadScene("SetWeight");

    }

    public void OnClickP()
    {
        SceneManager.LoadScene("StartPage");


    }




}
