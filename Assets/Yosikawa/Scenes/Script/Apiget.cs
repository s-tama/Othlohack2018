using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
//using System.Diagnostics;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System;

public class Apiget : MonoBehaviour {
    string url = "https://vigfy5-s0x0s.c9users.io/users/1";
    WWW www;

    string json;

    void Start() {

        //StartCoroutine(Connect());
        www = new WWW(url);
        
        StartCoroutine(DelayMethod(5.0f, () =>
        {
            Debug.Log(www.text);

            json = www.text;
            Item item = JsonUtility.FromJson<Item>(json);
            Debug.Log("item id " + item.user.id);
            
          

        }));

    }

    // Update is called once per frame
    void Update()
    {

    }

    

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        
        Debug.Log(www.text);

        action();
    }

    

}

[Serializable]
    public class Item
    {
    [SerializeField]
    public User user;

        [Serializable]
        public class User
        {
            [SerializeField]
            public string id;
            public string name;




        }
    }