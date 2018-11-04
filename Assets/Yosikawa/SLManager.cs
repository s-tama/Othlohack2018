using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SLManager : MonoBehaviour {

    public Button next;
    public Button prev;
    //public InputField namet;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnClickN()
    {
        SceneManager.LoadScene("SampleScene");

    }

    public void OnClickP()
    {
        SceneManager.LoadScene("SetArm");


    }
}
