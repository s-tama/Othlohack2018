using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ReadParam : MonoBehaviour {

    
    //public Text height;
    public Text weight;
    public Text bfp;
    public Text ra;
    public Text la;
    public Text st;
    public Text rl;
    public Text ll;

    public Text day;

    DateTime s_date;
    DateTime g_date;

    int s_date_y, s_date_m, s_date_d, g_date_y, g_date_m, g_date_d;



    //配列
    Dictionary<string, string> myTable;
    string username = "KItahama";
    //Json
    string url = "https://vigfy5-s0x0s.c9users.io/users/1";
    WWW www;

    string json;
    ApplicationData item;// = JsonUtility.FromJson<Item>(json);

    /// <summary>
    /// Startメソッド
    /// InputFieldコンポーネントの取得および初期化メソッドの実行
    /// </summary>
    void Start()
    {


        /*
        logRead();
        StartCoroutine(DelayMethod(3.0f, () =>
        {
            Debug.Log("Delay call");
            
            
            
            setText();
            
        }));*/


        www = new WWW(url);
        myTable = new Dictionary<string, string>();

        StartCoroutine(DelayMethod(5.0f, () =>
        {
            Debug.Log(www.text);

            json = www.text;
            item = JsonUtility.FromJson<ApplicationData>(json);

            jsonRoad();

            Debug.Log("item id " + item.user.id);



        }));


    }

    void Update() {
        

    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

    public void setText() {

        foreach (KeyValuePair<string, string> item in myTable)
        {
            Debug.Log(item.Key + "を" + item.Value);
            //if (item.Key == "InputField(h)") { height.text = height.text+"　"+item.Value+"cm"; }
            //else 
            if (item.Key == "s_Date.y") { s_date_y = Convert.ToInt32(item.Value); Debug.Log(item.Value); }
            if (item.Key == "s_Date.m") { s_date_m = Convert.ToInt32(item.Value); Debug.Log(s_date_m); }
            if (item.Key == "s_Date.d") { s_date_d = Convert.ToInt32(item.Value); Debug.Log(s_date_d); }
            if (item.Key == "g_Date.y") { g_date_y = Convert.ToInt32(item.Value); Debug.Log(g_date_y); }
            if (item.Key == "g_Date.m") { g_date_m = Convert.ToInt32(item.Value); Debug.Log(g_date_m); }
            if (item.Key == "g_Date.d") { g_date_d = Convert.ToInt32(item.Value); Debug.Log(g_date_d); }
            if (item.Key == "InputField(w)") { weight.text = weight.text + "　" + item.Value + "kg"; Debug.Log("w"); }
            if (item.Key == "InputField(bfp)") { bfp.text = bfp.text + "　" + item.Value + "%"; Debug.Log("bfp"); }
            if (item.Key == "InputField(ra)") { ra.text = ra.text + "　" + item.Value + "kg"; Debug.Log("ra"); }
            if (item.Key == "InputField(la)") { la.text = la.text + "　" + item.Value + "kg"; Debug.Log("la"); }
            if (item.Key == "InputField(st)") { st.text = st.text + "　" + item.Value + "kg"; Debug.Log("st"); }
            if (item.Key == "InputField(rl)") { rl.text = rl.text + "　" + item.Value + "kg"; Debug.Log("rl"); }
            if (item.Key == "InputField(ll)") { ll.text = ll.text + "　" + item.Value + "kg"; Debug.Log("ll"); }
        }

        s_date = new DateTime(s_date_y,s_date_m,s_date_d);
        g_date = new DateTime(g_date_y, g_date_m, g_date_d);


        Debug.Log(s_date.ToString());
        Debug.Log(g_date.ToString());

        TimeSpan span_ns = DateTime.Now - s_date;
        TimeSpan span_sg = g_date - s_date;
        if (span_ns.Days >= 0)
        {
            day.text = "目標日まで後" + span_sg.Days.ToString() + "日";
        }
        else if (span_ns.Days < 0)
        {
            day.text = "開始まで後" + (span_ns.Days * (-1)).ToString() + "日";
        }






    }

    // 読み込み
    void logRead()
    {
        
        // csvファイル名
        var fileName = "FileName";

 

        // Resourcesのcsvフォルダ内のcsvファイルをTextAssetとして取得
        TextAsset csvFile = Resources.Load(fileName) as TextAsset;

        Debug.Log(csvFile);
        // csvファイルの内容をStringReaderに変換
        StringReader reader = new StringReader(csvFile.text);

        // csvファイルの内容を一行ずつ末尾まで取得しリストを作成
        while (reader.Peek() > -1)
        {
            // 一行読み込む
            string lineData = reader.ReadLine();
            Debug.Log(lineData);
            // カンマ(,)区切りのデータを文字列の配列に変換
            string[] address = lineData.Split(',');
            // リストに追加
            Debug.Log(address[0]);
            Debug.Log(address[1]);
            myTable.Add(address[0], address[1]);
            // 末尾まで繰り返し...
        }


        foreach (KeyValuePair<string, string> item in myTable)
        {
            Debug.Log(item.Key + "の" + item.Value);
        }
        /*
    
        if (!File.Exists(Application.dataPath + " / Resources / FileName.csv")){
            Debug.Log("NOT EXIST");
        }

        
        using (StreamReader streamReader = new StreamReader(Application.dataPath + "/Resources/FileName.csv"))
        {
            List<string> newLists = new List<string>();

            while (!streamReader.EndOfStream)
            {
                newLists.AddRange(streamReader.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }

            foreach (var newList in newLists)
            {
                Debug.Log("再読み込みリスト： " + newList);


                myTable.Add(newLists[0], newLists[1]);

            }
        }

    */



    }


    void jsonRoad() {
        // 現在の日付と時刻を取得する
        DateTime dtNow = DateTime.Now;


        // 一行読み込む
        string lineData = item.user.startdate;
        // カンマ(,)区切りのデータを文字列の配列に変換
        string[] address = lineData.Split(',');
        s_date_y = Convert.ToInt32(address[0]);
        s_date_m = Convert.ToInt32(address[1]);
        s_date_d = Convert.ToInt32(address[2]);


        // 一行読み込む
        lineData = item.user.enddate;
        // カンマ(,)区切りのデータを文字列の配列に変換
        address = lineData.Split(',');
        g_date_y = Convert.ToInt32(address[0]);
        g_date_m = Convert.ToInt32(address[1]);
        g_date_d = Convert.ToInt32(address[2]);


        s_date = new DateTime(s_date_y, s_date_m, s_date_d);
        g_date = new DateTime(g_date_y, g_date_m, g_date_d);


        Debug.Log(s_date.ToString());
        Debug.Log(g_date.ToString());

        TimeSpan span_ns = DateTime.Now - s_date;
        TimeSpan span_sg = g_date - s_date;
        if (span_ns.Days >= 0)
        {
            day.text = span_sg.Days.ToString();
        }
        else if (span_ns.Days < 0)
        {
            day.text = ""+(span_ns.Days * (-1));
        }


        

        myTable.Add("Date", dtNow.ToString());
        myTable.Add("s_Date.y", item.user.name);
        myTable.Add("s_Date.m", s_date.Month.ToString());
        myTable.Add("s_Date.d", s_date.Day.ToString());
        myTable.Add("g_Date.y", g_date.Year.ToString());
        myTable.Add("g_Date.m", g_date.Month.ToString());
        myTable.Add("g_Date.d", g_date.Day.ToString());

        myTable.Add("Name", username);


        weight.text = weight.text + "　" + item.styles[0].weight; 

        bfp.text = bfp.text + "　" + item.styles[0].bodyfat*100; 
        ra.text = ra.text + "　" + item.styles[0].rightarm; 
        la.text = la.text + "　" + item.styles[0].leftarm; 
        st.text = st.text + "　" + item.styles[0].body; 
        rl.text = rl.text + "　" + item.styles[0].rightleg; 
        ll.text = ll.text + "　" + item.styles[0].leftleg; 





    }





}
