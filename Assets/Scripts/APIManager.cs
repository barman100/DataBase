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

    public void UpdatePlayerScore(int score, int id)
    {
        StartCoroutine(UpdatePlayerScoreCor(score, id));
    }
    public void UpdatePlayerTime(float time, int id)
    {
        StartCoroutine(UpdatePlayerTimeCor(time, id));
    }
    public void UpdatePlayerQuestionCount(int count, int id)
    {
        StartCoroutine(UpdatePlayerQuestionCountCor(count, id));
    }
    public void GetScore(int id, Action<int> callback)
    {
        StartCoroutine(GetScoreCor(id, callback));
    }
    public void GetTime(int id, Action<float> callback)
    {
        StartCoroutine(GetTimeCor(id, callback));
    }
    public void GetQuestionCount(int id, Action<int> callback)
    {
        StartCoroutine(GetQuestionCountCor(id, callback));
    }
    public void GetQuestion()
    {
        StartCoroutine(GetQuestionCor());
    }
    public void GetPlayerName(int id)
    {
        StartCoroutine(GetPlayerNameCor(id));
    }
    public void DeletePlayer()
    {
        StartCoroutine(DeletePlayerCor());
    }
    IEnumerator UpdatePlayerScoreCor(int score, int id)
    {
        string url = API_URL + "Score/";


        string jsonPayload = $"{{\"Score\":{score},\"PlayerID\":{id}}}";
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonPayload);

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(jsonBytes);
            request.uploadHandler.contentType = "application/json";
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log($"Success Score {score} ID {id}");
            }
            else
            {
                Debug.Log($"Failed Score {score} ID {id}");
                Debug.Log("Response Content: " + request.downloadHandler.text);
            }
        }
    }
    IEnumerator UpdatePlayerTimeCor(float time, int id)
    {
        string url = API_URL + "Time/";

        string jsonPayload = $"{{\"Time\":{time},\"PlayerID\":{id}}}";
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonPayload);

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(jsonBytes);
            request.uploadHandler.contentType = "application/json";
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log($"Success Time {time} ID {id}");
            }
            else
            {
                Debug.Log($"Failed Time {time} ID {id}");
                Debug.Log("Response Content: " + request.downloadHandler.text);
            }
        }
    }
    IEnumerator UpdatePlayerQuestionCountCor(int count, int id)
    {
        string url = API_URL + "QuestionCount/";


        string jsonPayload = $"{{\"Count\":{count},\"PlayerID\":{id}}}";
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonPayload);

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(jsonBytes);
            request.uploadHandler.contentType = "application/json";
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log($"Success QuestionCount {count} ID {id}");
            }
            else
            {
                Debug.Log($"Failed QuestionCount {count} ID {id}");
                Debug.Log("Response Content: " + request.downloadHandler.text);
            }
        }
    }
    IEnumerator GetTimeCor(int id, Action<float> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Time/" + id))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                float time = float.Parse(request.downloadHandler.text);
                callback(time);
            }
            else
            {
                Debug.LogError("Failed to retrieve the time.");
            }
        }
    }
    IEnumerator GetScoreCor(int id, Action<int> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Score/" + id))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                int score = int.Parse(request.downloadHandler.text);
                callback(score);
            }
            else
            {
                Debug.LogError("Failed to retrieve the score.");
            }

        }
    }
    IEnumerator GetQuestionCountCor(int id, Action<int> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "QuestionCount/" + id))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                int count = int.Parse(request.downloadHandler.text);
                callback(count);
                Debug.Log($"Success QuestionCount {count}");
            }
            else
            {
                Debug.LogError("Failed to retrieve the QuestionCount.");
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
    IEnumerator GetPlayerNameCor(int id)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Players/" + id))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                string playerName = request.downloadHandler.text;
                uIManager.UpdateWinner(playerName);
            }
            else
            {
                Debug.LogError("Failed to retrieve the name.");
            }
        }
    }
    IEnumerator DeletePlayerCor()
    {
        using (UnityWebRequest request = UnityWebRequest.Delete(API_URL + "Players/"))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Player deleted successfully.");
            }
            else
            {
                Debug.LogError("Failed to delete player. Error: " + request.error);
            }
        }
    }
}