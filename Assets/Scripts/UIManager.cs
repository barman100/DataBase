using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text _questionText;
    [SerializeField] TMP_Text _answerText_01;
    [SerializeField] TMP_Text _answerText_02;
    [SerializeField] TMP_Text _answerText_03;
    [SerializeField] TMP_Text _answerText_04;
    [SerializeField] TMP_Text _gameEndText;
    [SerializeField] APIManager _apiManager;
    
    private void Start()
    {
        _apiManager.GetQuestion();
    }
    public void UpdateQuestion(Question question)
    {
        _questionText.text = question.questionString;
    }
    public void UpdatAnswers(Question question)
    {
        _answerText_01.text =  question.answer_01;
        _answerText_02.text =  question.answer_02;
        _answerText_03.text =  question.answer_03;
        _answerText_04.text =  question.answer_04;
    }
    public void UpdateWinner(string name)
    {
        _gameEndText.text = (name + " Win");
    }
    public void ZeroPointsGame()
    {
        _gameEndText.text = "Both Players Got Zero points Draw";
    }
}
