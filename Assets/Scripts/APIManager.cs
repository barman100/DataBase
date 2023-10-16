using System.Collections;
using System.Collections.Generic;
using System;
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
    public void UpdatePlayerScore(int score)
    {
        StartCoroutine(UpdatePlayerScoreCor(score));
    }
    public void UpdatePlayerTime(int time)
    {
        StartCoroutine(UpdatePlayerTimeCor(time));
    }
    public void GetTime(string name)
    {
        StartCoroutine(GetTimeCor(name));
    }
    public void GetQuestion(string categoryID)
    {
        StartCoroutine(GetQuestionCor(categoryID));
    }
    
    IEnumerator UpdatePlayerScoreCor(int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("Score", score);

        using (UnityWebRequest request = UnityWebRequest.Post(API_URL + "Score/", form))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Success " + score);
            }
            else
            {
                Debug.Log("Failed " + score);
                Debug.Log("Respond Content" + request.downloadHandler.text);
            }
        }
    }

    IEnumerator UpdatePlayerTimeCor(int time)
    {
        WWWForm form = new WWWForm();
        form.AddField("Time", time);

        using (UnityWebRequest request = UnityWebRequest.Post(API_URL + "Time/", form))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Success " + time);
            }
            else
            {
                Debug.Log("Failed " + time);
                Debug.Log("Respond Content" + request.downloadHandler.text);
            }
        }
    }
    IEnumerator GetTimeCor(string name)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Players/" + name))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                int time = Int32.Parse(request.downloadHandler.text);
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
