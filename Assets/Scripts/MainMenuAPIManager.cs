using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class MainMenuAPIManager : MonoBehaviour
{
    const string API_URL = "https://localhost:7006/api/";
    private int _count;
    public void UpdatePlayerName(string name)
    {
        StartCoroutine(UpdatePlayerNameCor(name));
    }
    public int GetPlayerCount()
    {
        StartCoroutine(GetPlayerCountCor());
        return _count;
    }
    IEnumerator UpdatePlayerNameCor(string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("Name", name);

        using (UnityWebRequest request = UnityWebRequest.Post(API_URL + "Players/", form))
        {
            yield return request.SendWebRequest();
        }
    }
    IEnumerator GetPlayerCountCor()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Players/"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                _count = int.Parse(request.downloadHandler.text);
            }
        }
    }

}
