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
    [SerializeField] private Timer timer;
    [SerializeField] private Score score;
    private int time;
    public void ButtonClicked()
    {
        if (answerText.text == GameManager.GetCorrectAnswer())
        {
            button.image.color = Color.green;
            Debug.Log("answer is correct");
            if (timer.currentTime > 0)
            {
                score.score += 5;
                apiManager.UpdatePlayerScore(score.score);
                apiManager.UpdatePlayerTime(time);
            }

            if (timer.currentTime <= 0)
            {
                score.score += 2;
                apiManager.UpdatePlayerScore(score.score);
            }
        }

        else
        {
            button.image.color = Color.red;
            Debug.Log("answer is not correct");
        }
            
    }
}
