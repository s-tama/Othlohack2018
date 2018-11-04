using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DaySet : MonoBehaviour
{
    public Dropdown year;
    public Dropdown month;
    public Dropdown day;
    /*
    public Dropdown tyear;
    public Dropdown tmonth;
    public Dropdown tday;*/


    bool monthok;
    bool dayok;
    /*
    bool tmonthok;
    bool tdayok;*/

    


    // Use this for initialization
    void Start()
    {
        setLong(year, month, 0);
        //setLong(tyear, tmonth, 0);
        month.interactable = false;
        day.interactable = false;
        //tmonth.interactable = false;
        //tday.interactable = false;

        monthok = false;
        dayok = false;
        //tmonthok = false;
        //tdayok = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (year.value != 0 && !monthok)
        {
            month.interactable = true;
            monthok = true;
            setLong(month, day, 1);
        }
        /*
        if (tyear.value != 0 && !tmonthok)
        {
            tmonth.interactable = true;
            tmonthok = true;
            setLong(tmonth, tday, 1);


        }*/
        if (month.value != 0 && !dayok)
        {
            day.interactable = true;
            dayok = true;
            setLong(day, month, 2);
        }
        /*
        if (tmonth.value != 0 && !tdayok)
        {
            tday.interactable = true;
            tdayok = true;
            setLong(tday, tmonth, 2);
        }*/






    }



    void setLong(Dropdown dropdown, Dropdown dropdown_m, int st)
    {
        if (st == 0)//year
        {
            if (dropdown)
            {
                int dtNow = DateTime.Now.Year;
                dropdown.ClearOptions();    //現在の要素をクリアする
                List<string> list = new List<string>();
                list.Add("選択");
                list.Add((dtNow - 1).ToString());
                list.Add(dtNow.ToString());
                list.Add((dtNow + 1).ToString());
                dropdown.AddOptions(list);  //新しく要素のリストを設定する
                dropdown.value = 0;         //デフォルトを設定(0～n-1)
            }

        }
        else if (st == 1)//month
        {
            if (dropdown)
            {
                dropdown.ClearOptions();    //現在の要素をクリアする
                List<string> list = new List<string>();
                list.Add("選択");
                list.Add("1");
                list.Add("2");
                list.Add("3");
                list.Add("4");
                list.Add("5");
                list.Add("6");
                list.Add("7");
                list.Add("8");
                list.Add("9");
                list.Add("10");
                list.Add("11");
                list.Add("12");
                dropdown.AddOptions(list);  //新しく要素のリストを設定する
                dropdown.value = 0;         //デフォルトを設定(0～n-1)
            }
        }
        else if (st == 2)//day
        {
            if (dropdown)
            {
                int dtNow = DateTime.Now.Year;
                int days;
                if (DateTime.IsLeapYear(dtNow) && dropdown_m.value == 2)
                {
                    days = 29;
                }
                else if (dropdown_m.value == 4 || dropdown_m.value == 6 || dropdown_m.value == 9 || dropdown_m.value == 11)
                {
                    days = 30;
                }
                else if (dropdown_m.value == 2)
                {
                    days = 28;

                }
                else
                {
                    days = 31;
                }

                dropdown.ClearOptions();    //現在の要素をクリアする
                List<string> list = new List<string>();
                list.Add("選択");
                for (int i = 1; i <= days; i++)
                {
                    list.Add(i.ToString());
                }
                dropdown.AddOptions(list);  //新しく要素のリストを設定する
                dropdown.value = 0;         //デフォルトを設定(0～n-1)
            }



        }



    }


    

}