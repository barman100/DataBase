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
    [SerializeField] MainMenuManager mainMenuManager;
    [SerializeField] GameEndManager gameEndManager;
    private int questionCount = 1;
    public void ButtonClicked()
    {
        if (answerText.text == GameManager.GetCorrectAnswer())
        {
            button.image.color = Color.green;
            Debug.Log("answer is correct");
            if (timer.currentTime > 0)
            {
                score.score = 5;
                timer.finalTime = (int)(timer.initialTime - timer.currentTime);
                apiManager.UpdatePlayerScore(score.score, mainMenuManager.playerID);
                apiManager.UpdatePlayerTime(timer.finalTime, mainMenuManager.playerID);
            }

            if (timer.currentTime <= 0)
            {
                score.score = 2;
                apiManager.UpdatePlayerScore(score.score, mainMenuManager.playerID);
            }
        }

        else
        {
            button.image.color = Color.red;
            Debug.Log("answer is not correct");
        }

        if (questionCount <= 3)
        {
            StartCoroutine(GetNewQuestion());
        }
        else if (questionCount == 4)
            gameEndManager.EndGame();
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
