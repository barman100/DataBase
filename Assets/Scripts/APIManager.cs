using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

public class APIManager : MonoBehaviour
{
    [SerializeField] UIManager uIManager;
    const string API_URL = "https://localhost:7014/api/";

    public void UpdatePlayerName(string name)
    {
        StartCoroutine(UpdatePlayerNameCor(name));
    }
    /*public void GetPlayerName(string id)
    {
        StartCoroutine(GetPlayerNameCor(id));
    }*/

    public void GetQuestion(string categoryID)
    {
        StartCoroutine(GetQuestionCor(categoryID));
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
                Debug.Log("Success" + name);
            }
            else
            {
                Debug.Log("Failed" + name);
                Debug.Log("Respond Content" + request.downloadHandler.text);
            }
        }
    }

    /*IEnumerator GetPlayerNameCor(string id)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Players/" + id))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    uIManager.UpdatePlayerName(request.downloadHandler.text);
                    break;
            }
        }
    }*/
    IEnumerator GetQuestionCor(string categoryID)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Questions/" + categoryID))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    string jsonQuestion = request.downloadHandler.text;
                    Question question = JsonUtility.FromJson<Question>(jsonQuestion);
                    uIManager.UpdateQuestion(question);
                    uIManager.UpdatAnswers(question);
                    GameManager.CurrentQuestion = question;
                    break;
            }
        }
    }
}
