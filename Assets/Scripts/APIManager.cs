using System.Collections;
using System;
using UnityEngine.Networking;
using UnityEngine;

public class APIManager : MonoBehaviour
{
    [SerializeField] UIManager _uiManager;
    const string API_URL = "https://localhost:7006/api/";

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
                    _uiManager.UpdateQuestion(question);
                    _uiManager.UpdatAnswers(question);
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
                _uiManager.UpdateWinner(playerName);
            }
        }
    }
    IEnumerator DeletePlayerCor()
    {
        using (UnityWebRequest request = UnityWebRequest.Delete(API_URL + "Players/"))
        {
            yield return request.SendWebRequest();
        }
    }
}