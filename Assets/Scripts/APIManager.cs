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

    public int score;
    public int time;

    public void UpdatePlayerScore(int score, int id)
    {
        StartCoroutine(UpdatePlayerScoreCor(score, id));
    }
    public void UpdatePlayerTime(int time, int id)
    {
        StartCoroutine(UpdatePlayerTimeCor(time, id));
    }
    public int GetScore(int id)
    {
        StartCoroutine(GetScoreCor(id));
        return score;
    }
    public int GetTime(int id)
    {
        StartCoroutine(GetTimeCor(id));
        return time;
    }
    public void GetQuestion()
    {
        StartCoroutine(GetQuestionCor());
    }
    
    IEnumerator UpdatePlayerScoreCor(int score, int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("Score", score);
        form.AddField("PlayerID", id);

        using (UnityWebRequest request = UnityWebRequest.Post(API_URL + "Score/", form))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log($"Success Score {score} ID {id}");
            }
            else
            {
                Debug.Log($"Failed Score {score} ID {id}");
                Debug.Log("Respond Content" + request.downloadHandler.text);
            }
        }
    }
    IEnumerator UpdatePlayerTimeCor(int time, int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("Time", time);
        form.AddField("PlayerID", id);

        using (UnityWebRequest request = UnityWebRequest.Post(API_URL + "Time/", form))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log($"Success Time {time} ID {id}");
            }
            else
            {
                Debug.Log($"Failed Time {time} ID {id}");
                Debug.Log("Respond Content" + request.downloadHandler.text);
            }
        }
    }
    IEnumerator GetTimeCor(int id)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Time/" + id))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                time = int.Parse(request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Failed to retrieve the score.");
            }
        }
    }
    IEnumerator GetScoreCor(int id)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Score/" + id))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                score = int.Parse(request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Failed to retrieve the score.");
            }

        }
    }
    IEnumerator GetQuestionCor()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Questions/"))
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
