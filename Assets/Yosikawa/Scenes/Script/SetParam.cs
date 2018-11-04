using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class SetParam : MonoBehaviour
{
    public Button button;
    public InputField height;
    public InputField weight;
    public InputField bfp;
    public InputField ra;
    public InputField la;
    public InputField st;
    public InputField rl;
    public InputField ll;


    //配列
    Dictionary<string, string> myTable;
    public string username;// = "KItahama";

    public DateTime s_date;
    public DateTime g_date;




    public ApplicationData myObject; 

    string url = "https://vigfy5-s0x0s.c9users.io/users/1/styles";

    //Json
    // string serialisedItemJson;

    /// <summary>
    /// Startメソッド
    /// InputFieldコンポーネントの取得および初期化メソッドの実行
    /// </summary>
    void Start()
    {
        myTable = new Dictionary<string, string>();
        myObject = new ApplicationData();


        InitInputField(height);
        InitInputField(weight);
        InitInputField(bfp);
        InitInputField(ra);
        InitInputField(la);
        InitInputField(st);
        InitInputField(rl);
        InitInputField(ll);

    }



    /// <summary>
    /// Log出力用メソッド
    /// 入力値を取得してLogに出力し、初期化
    /// </summary>


    public void InputLogger(InputField inputField)
    {
        string inputValue = inputField.text;
        Debug.Log(inputField.name + "の" + inputValue);
        myTable.Add(inputField.name, inputValue);
        InitInputField(inputField);

    }

    /// <summary>
    /// InputFieldの初期化用メソッド
    /// 入力値をリセットして、フィールドにフォーカスする
    /// </summary>

    void InitInputField(InputField inputField)
    {   // 値をリセット
        inputField.text = "";

        // フォーカス
        inputField.ActivateInputField();

    }


    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }


    public void OnClick() {

        // 現在の日付と時刻を取得する
        DateTime dtNow = DateTime.Now;

        myTable.Add("Date", dtNow.ToString());
        myTable.Add("s_Date.y", s_date.Year.ToString());
        myTable.Add("s_Date.m", s_date.Month.ToString());
        myTable.Add("s_Date.d", s_date.Day.ToString());
        myTable.Add("g_Date.y", g_date.Year.ToString());
        myTable.Add("g_Date.m", g_date.Month.ToString());
        myTable.Add("g_Date.d", g_date.Day.ToString());

        myTable.Add("Name", username);

        InputLogger(height);
        InputLogger(weight);
        InputLogger(bfp);
        InputLogger(ra);
        InputLogger(la);
        InputLogger(st);
        InputLogger(rl);
        InputLogger(ll);

        foreach (KeyValuePair<string, string> item in myTable)
        {
            Debug.Log(item.Key + "の" + item.Value);
        }
        logSave(myTable);

        StartCoroutine(DelayMethod(5.0f, () =>
        {
            Debug.Log("Delay call");
            SceneManager.LoadScene("SampleScene");

        }));
        //logSave(myTable);
        //logRead();
        //SceneManager.LoadScene("SampleScene");
        //SceneManager.LoadScene("periodselect");

    }



    //csv
    public void logSave(Dictionary<string, string> dictionary)
    {
        //data
        myObject.user.id = 1;
        myObject.user.name = username;
        myObject.user.updated_at = myTable["s_Date.y"] + "," + myTable["s_Date.m"] + "," + myTable["s_Date.d"];
        myObject.user.created_at = myTable["g_Date.y"] + "," + myTable["g_Date.m"] + "," + myTable["g_Date.d"];

        myObject.styles[0].id = 1;
        myObject.styles[0].user_id = 1;
        myObject.styles[0].weight = (float)Convert.ToDouble(myTable["InputField(w)"]);
        myObject.styles[0].height = (float)Convert.ToDouble(myTable["InputField(h)"]);
        myObject.styles[0].bodyfat = (float)Convert.ToDouble(myTable["InputField(bfp)"]);
        myObject.styles[0].rightarm = (float)Convert.ToDouble(myTable["InputField(ra)"]);
        myObject.styles[0].leftarm = (float)Convert.ToDouble(myTable["InputField(la)"]);
        myObject.styles[0].body = (float)Convert.ToDouble(myTable["InputField(st)"]);
        myObject.styles[0].rightleg = (float)Convert.ToDouble(myTable["InputField(rl)"]);
        myObject.styles[0].leftleg = (float)Convert.ToDouble(myTable["InputField(ll)"]);

        myObject.styles[0].created_at = myTable["s_Date.y"] + "," + myTable["s_Date.m"] + "," + myTable["s_Date.d"];
        myObject.styles[0].updated_at = myTable["g_Date.y"] + "," + myTable["g_Date.m"] + "," + myTable["g_Date.d"];



        
        string myjson = JsonUtility.ToJson(myObject);

        byte[] postData = System.Text.Encoding.UTF8.GetBytes(myjson);
        var request = new UnityWebRequest(url, "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.Send();


        StartCoroutine(DelayMethod(5.0f, () =>
        {
            Debug.Log("Delay call");
            
            SceneManager.LoadScene("SampleScene");

        }));
    



    }



    
/*
StreamWriter sw;
FileInfo fi;
fi = new FileInfo(Application.dataPath + "/Resources/FileName.csv");
//sw = fi.AppendText();
sw = fi.CreateText();
foreach (KeyValuePair<string, string> item in myTable)
{
    sw.WriteLine(item.Key + "," + item.Value);
    sw.Flush();
}
sw.Flush();
sw.Close();
//SleepTimeout(1000);*/


/*
using (StreamWriter streamWriter = new StreamWriter(Application.dataPath + "/Resources/FileName.csv"))
{
    streamWriter.WriteLine("s_Date.y" + "," + myTable["s_Date.y"]);
    streamWriter.WriteLine("s_Date.m" + "," + myTable["s_Date.m"]);
    streamWriter.WriteLine("s_Date.d" + "," + myTable["s_Date.d"]);
    streamWriter.WriteLine("g_Date.y" + "," + myTable["g_Date.y"]);
    streamWriter.WriteLine("g_Date.m" + "," + myTable["g_Date.m"]);
    streamWriter.WriteLine("g_Date.d" + "," + myTable["g_Date.d"]);
    streamWriter.WriteLine("InputField(w)" + "," + myTable["InputField(w)"]);
    streamWriter.WriteLine("InputField(bfp)" + "," + myTable["InputField(bfp)"]);
    streamWriter.WriteLine("InputField(ra)" + "," + myTable["InputField(ra)"]);
    streamWriter.WriteLine("InputField(la)" + "," + myTable["InputField(la)"]);
    streamWriter.WriteLine("InputField(st)" + "," + myTable["InputField(st)"]);
    streamWriter.WriteLine("InputField(rl)" + "," + myTable["InputField(rl)"]);
    streamWriter.WriteLine("InputField(ll)" + "," + myTable["InputField(ll)"]);

    streamWriter.Flush();
    streamWriter.Close();

    Debug.Log(streamWriter);
}*/



/*
public ApplicationData myObject = new ApplicationData();
myObject.user.id=1;
        string myjson = JsonUtility.ToJson(myObject);*/





    // 読み込み
    void logRead()
    {
        // csvファイル名
        var fileName = "FileName";
        // Resourcesのcsvフォルダ内のcsvファイルをTextAssetとして取得
        var csvFile = Resources.Load(fileName) as TextAsset;

        Debug.Log(csvFile);
        // csvファイルの内容をStringReaderに変換
        StringReader reader = new StringReader(csvFile.text);

        // csvファイルの内容を一行ずつ末尾まで取得しリストを作成
        while (reader.Peek() > -1)
        {
            // 一行読み込む
            string lineData = reader.ReadLine();
            // カンマ(,)区切りのデータを文字列の配列に変換
            string[] address = lineData.Split(',');
            // リストに追加
            Debug.Log(address[0]);
            Debug.Log(address[1]);
            myTable.Add(address[0],address[1]);
            // 末尾まで繰り返し...
        }


        foreach (KeyValuePair<string, string> item in myTable)
        {
            Debug.Log(item.Key + "の" + item.Value);
        }
        
    }






}