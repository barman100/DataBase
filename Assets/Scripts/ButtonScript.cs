using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] TMP_Text answerText;
    [SerializeField] Button button;
    [SerializeField] APIManager apiManager;
    [SerializeField] Timer timer;
    [SerializeField] Score score;
    [SerializeField] Canvas GameScreen;
    [SerializeField] Canvas WaitScreen;
    private static int questionCount = 1;

    private void Start()
    {
        GameScreen.gameObject.SetActive(true);
        WaitScreen.gameObject.SetActive(false);
    }
    public void ButtonClicked()
    {
        if (answerText.text == GameManager.GetCorrectAnswer())
        {
            button.image.color = Color.green;
            Debug.Log("answer is correct");
            if (timer.currentTime > 0)
            {
                score.score = 5;
                timer.finalTime = (timer.initialTime - timer.currentTime);
                apiManager.UpdatePlayerScore(score.score, MainMenuManager.playerID);
                apiManager.UpdatePlayerTime(timer.finalTime, MainMenuManager.playerID);
                apiManager.UpdatePlayerQuestionCount(questionCount, MainMenuManager.playerID);
            }
            if (timer.currentTime <= 0)
            {
                score.score = 0;
                apiManager.UpdatePlayerScore(score.score, MainMenuManager.playerID);
                apiManager.UpdatePlayerQuestionCount(questionCount, MainMenuManager.playerID);
            }
        }
        else
        {
            button.image.color = Color.red;
            apiManager.UpdatePlayerQuestionCount(questionCount, MainMenuManager.playerID);
            Debug.Log("answer is not correct");
        }

        if (questionCount <= 3)
        {
            StartCoroutine(GetNewQuestion());
        }
        else if (questionCount == 4)
        {
            GameScreen.gameObject.SetActive(false);
            WaitScreen.gameObject.SetActive(true);
            GameManager.isWaiting = true;
        }
        questionCount++;

    }
    
    IEnumerator GetNewQuestion()
    {
        yield return new WaitForSeconds(0.5f);
        apiManager.GetQuestion();
        button.image.color = Color.white;
        timer.ResetTimer();
    }
}
