using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text questiontext;
    public TMP_Text answer1text;
    public TMP_Text answer2text;
    public TMP_Text answer3text;
    public TMP_Text answer4text;
    public APIManager _APIManager;

    private void Start()
    {
        _APIManager.GetQuestion();
    }
    public void UpdateQuestion(Question question)
    {
        questiontext.text = question.question;
    }
    public void UpdatAnswers(Question question)
    {
        answer1text.text =  question.ans1;
        answer2text.text =  question.ans2;
        answer3text.text =  question.ans3;
        answer4text.text =  question.ans4;
    }
}
