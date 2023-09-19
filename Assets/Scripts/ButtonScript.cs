using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] TMP_Text answerText;
    [SerializeField] Button button;
    public void ButtonClicked()
    {
        if (answerText.text == GameManager.GetCorrectAnswer())
        {
            button.image.color = Color.green;
            Debug.Log("answer is correct");
        }

        else
        {
            button.image.color = Color.red;
            Debug.Log("answer is not correct");
        }
            
    }
}
