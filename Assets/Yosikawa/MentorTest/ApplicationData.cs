using System;
using UnityEngine;

[Serializable]
public class ApplicationData
{
    [SerializeField] public UserData user;
    [SerializeField] public StyleData[] styles;
}

[Serializable]
public class UserData
{
    [SerializeField] public int id;
    [SerializeField] public string created_at;
    [SerializeField] public string updated_at;
    [SerializeField] public string startdate;
    [SerializeField] public string enddate;
    [SerializeField] public string name;
}

[Serializable]
public class StyleData
{
    [SerializeField] public int id;
    [SerializeField] public int user_id;
    [SerializeField] public float weight;
    [SerializeField] public float height;
    [SerializeField] public float bodyfat;
    [SerializeField] public float leftarm;
    [SerializeField] public float rightarm;
    [SerializeField] public float body;
    [SerializeField] public float leftleg;
    [SerializeField] public float rightleg;
    [SerializeField] public string created_at;
    [SerializeField] public string updated_at;
}