using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PeriodCalc : MonoBehaviour {

    public Button Button;

    // 測定日
    public Text year;
    public Text month;
    public Text day;

    // 開始日
    /*
    public Text tyear;
    public Text tmonth;
    public Text tday;*/

    public int year_s;
    public int month_s;
    public int day_s;
    public int tyear_s;
    public int tmonth_s;
    public int tday_s;

    public InputField name;
    public string uname;



    //public Dropdown dropdown;    //操作するオブジェクトを設定する

    void InitInputField(InputField inputField)
    {   // 値をリセット
        inputField.text = "";

        // フォーカス
        inputField.ActivateInputField();

    }


    public void InputLogger(InputField inputField)
    {
        //string inputValue = inputField.text;
        uname = inputField.text;
        //Debug.Log(inputField.name + "の" + inputValue);
        //myTable.Add(inputField.name, inputValue);

        InitInputField(inputField);

    }
    // Use this for initialization
    void Start()
    {
        InitInputField(name);
    }





    
	
	// Update is called once per frame
	void Update () {
		
	}

    // 押下
    public void OnClick() {
        year_s = Convert.ToInt32(year.text);
        month_s = Convert.ToInt32(month.text);
        day_s = Convert.ToInt32(day.text);
        /*
        tyear_s = Convert.ToInt32(tyear.text);
        tmonth_s = Convert.ToInt32(tmonth.text);
        tday_s = Convert.ToInt32(tday.text);
        */

        tyear_s = DateTime.Now.Year;
        tmonth_s = DateTime.Now.Month;
        tday_s = DateTime.Now.Day;

        InputLogger(name);


        //TimeSpan span;
        Debug.Log("click");

        if (year_s != 0 || month_s != 0 || day_s != 0 || tyear_s != 0 || tmonth_s != 0 || tday_s != 0)
        {

            TimeSpan span = new DateTime(year_s,month_s,day_s) - new DateTime(tyear_s, tmonth_s, tday_s);

            Debug.Log(span.Days.ToString()); //差の日数が出力される

            //period.text = span.Days.ToString() + "日";
            StartCoroutine(DelayMethod(5.0f, () =>
            {
                Debug.Log("Delay call");
                //SceneManager.LoadScene("SampleScene");
                //SceneManager.LoadScene("ParameterSetting");
                SceneManager.LoadSceneAsync("SetWeight").AsObservable()
                    .Subscribe(_ => {
                        var sm = FindObjectOfType<SetParam>() as SetParam;
                        sm.s_date = new DateTime(tyear_s, tmonth_s, tday_s);
                        sm.g_date = new DateTime(year_s, month_s, day_s);
                        sm.username = this.uname;
                    });

            }));

        }
        else {
            Debug.Log("Error"); 


        }


        




    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }


}
