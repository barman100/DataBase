using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //public TMP_InputField playerId;
    //public TMP_Text playerName;
    public TMP_InputField questionId;
    public TMP_Text questiontext;
    public TMP_Text answer1text;
    public TMP_Text answer2text;
    public TMP_Text answer3text;
    public TMP_Text answer4text;
    public APIManager _APIManager;

    /*public void GetPlayerButtonClicked()
    {
        _APIManager.GetPlayerName(playerId.text);
    }*/
    public void GetQuestionButtonClicked()
    {
        _APIManager.GetQuestion(questionId.text);
    }
    /*public void UpdatePlayerName(string name)
    {
        playerName.text = name;
    }*/
    public void UpdateQuestion(Question question)
    {
        questiontext.text = question.question;
    }
    public void UpdatAnswers(Question question)
    {
        answer1text.text = "1." + question.ans1;
        answer2text.text = "2." + question.ans2;
        answer3text.text = "3." + question.ans3;
        answer4text.text = "4." + question.ans4;
    }
}
