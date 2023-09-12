using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

public class APIManager : MonoBehaviour
{
    [SerializeField] UIManager uIManager;
    const string API_URL = "https://localhost:7014/api/";


    /*public void GetPlayerName(string id)
    {
        StartCoroutine(GetPlayerNameCor(id));
    }*/

    public void GetQuestion(string categoryID)
    {
        StartCoroutine(GetQuestionCor(categoryID));
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
