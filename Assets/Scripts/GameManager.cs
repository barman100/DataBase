using System;
using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] APIManager _apiManager;
    [SerializeField] GameEndManager _gameEndManager;
    [SerializeField] Timer _timer;
    [SerializeField] Canvas _gameScreen;
    [SerializeField] Canvas _waitScreen;

    private int _questionCount = 1;
    private int _score;
    private int _count1;
    private int _count2;
    public static bool _isWaiting = false;
    public static Question CurrentQuestion { get; set; }

    public static event Action<ButtonScript> OnButtonPressed;
    public static void ButtonPressed(ButtonScript button)
    {
        OnButtonPressed?.Invoke(button);
    }
    private void Start()
    {
        _gameScreen.gameObject.SetActive(true);
        _waitScreen.gameObject.SetActive(false);
        OnButtonPressed += ButtonClicked;
    }
    private void Update()
    {
        if (_isWaiting)
        {
            _apiManager.GetQuestionCount(1, Count1);
            _apiManager.GetQuestionCount(2, Count2);

            if (_count1 == 4 && _count2 == 4)
                _gameEndManager.EndGame();
        }
    }
    public void ButtonClicked(ButtonScript _button)
    {
        if (_button.AnswerText.text == GetCorrectAnswer())
        {
            _button.ChangeColor(Color.green);

            if (_timer.CurrentTime > 0)
            {
                _score = 5;
                _timer.FinalTime = (_timer.InitialTime - _timer.CurrentTime);
                _apiManager.UpdatePlayerScore(_score, MainMenuManager.PlayerID);
                _apiManager.UpdatePlayerTime(_timer.FinalTime, MainMenuManager.PlayerID);
                _apiManager.UpdatePlayerQuestionCount(_questionCount, MainMenuManager.PlayerID);
            }
            if (_timer.CurrentTime <= 0)
            {
                _score = 0;
                _apiManager.UpdatePlayerScore(_score, MainMenuManager.PlayerID);
                _apiManager.UpdatePlayerQuestionCount(_questionCount, MainMenuManager.PlayerID);
            }
        }
        else
        {
            _button.ChangeColor(Color.red);
            _apiManager.UpdatePlayerQuestionCount(_questionCount, MainMenuManager.PlayerID);
        }

        if (_questionCount <= 3)
        {
            StartCoroutine(GetNewQuestion(_button));
        }
        else if (_questionCount == 4)
        {
            _gameScreen.gameObject.SetActive(false);
            _waitScreen.gameObject.SetActive(true);
            _isWaiting = true;
        }
        _questionCount++;

    }
    IEnumerator GetNewQuestion(ButtonScript _button)
    {
        yield return new WaitForSeconds(0.5f);
        _apiManager.GetQuestion();
        _button.ChangeColor(Color.white);
        _timer.ResetTimer();
    }
    private void Count1(int count)
    {
        _count1 = count;
    }
    private void Count2(int count)
    {
        _count2 = count;
    }
    public string GetCorrectAnswer()
    {
        if (CurrentQuestion == null)
            throw new ArgumentNullException("CurrentQuestion is Null") ;
        switch (CurrentQuestion.correctAnswer)
        {
            case 1:
                return CurrentQuestion.answer_01;

            case 2:
                return CurrentQuestion.answer_02;

            case 3:
                return CurrentQuestion.answer_03;

            case 4:
                return CurrentQuestion.answer_04;

            default:
                throw new Exception("correct question value out of bound");
        }
    }
}
