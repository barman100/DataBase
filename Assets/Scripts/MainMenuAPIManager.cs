using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

public class MainMenuAPIManager : MonoBehaviour
{
    const string API_URL = "https://localhost:7014/api/";
    private int count;
    public void UpdatePlayerName(string name)
    {
        StartCoroutine(UpdatePlayerNameCor(name));
    }
    public int GetPlayerCount()
    {
        StartCoroutine(GetPlayerCountCor());
        return count;
    }
    IEnumerator UpdatePlayerNameCor(string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("Name", name);

        using (UnityWebRequest request = UnityWebRequest.Post(API_URL + "Players/", form))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Success " + name);
            }
            else
            {
                Debug.Log("Failed " + name);
                Debug.Log("Respond Content" + request.downloadHandler.text);
            }
        }
    }
    IEnumerator GetPlayerCountCor()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Players/"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                count = int.Parse(request.downloadHandler.text);
            }
        }
    }

}
