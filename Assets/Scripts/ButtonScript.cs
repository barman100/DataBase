using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] TMP_Text answerText;
    public void ButtonClicked()
    {
        if (answerText.text == GameManager.GetCorrectAnswer())
            Debug.Log("answer is correct");
        
        else
            Debug.Log("answer is not correct");
    }
}
