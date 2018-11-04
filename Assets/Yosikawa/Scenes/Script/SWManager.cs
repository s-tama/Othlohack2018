using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SWManager : MonoBehaviour {

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
        SceneManager.LoadScene("SetBody");

    }

    public void OnClickP()
    {
        SceneManager.LoadScene("SetNameGoal");


    }

}
