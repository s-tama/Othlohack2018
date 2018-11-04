using UnityEngine;

public class TestDisplayer : MonoBehaviour
{
    private const string ApplicationDataPath = "application_deta";

    // Use this for initialization
    void Start()
    {
        var jsonAsset = Resources.Load(ApplicationDataPath) as TextAsset;
        if (jsonAsset == null)
        {
            Debug.LogError("指定されたファイルが存在しません");
            return;
        }

        var applicationData = JsonUtility.FromJson<ApplicationData>(jsonAsset.text);
        Debug.Log("bodyfat: " + applicationData.user.created_at);
        Debug.Log("bodyfat: " + applicationData.styles[0].bodyfat);
        Debug.Log("leftleg: " + applicationData.styles[1].leftleg);
    }
}