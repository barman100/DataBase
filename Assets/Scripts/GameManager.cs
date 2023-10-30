using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static Question CurrentQuestion { get; set; } 

    public static string GetCorrectAnswer()
    {
        if (CurrentQuestion == null)
            throw new ArgumentNullException("CurrentQuestion is Null") ;
        switch (CurrentQuestion.correct)
        {
            case 1:
                return CurrentQuestion.ans1;

            case 2:
                return CurrentQuestion.ans2;

            case 3:
                return CurrentQuestion.ans3;

            case 4:
                return CurrentQuestion.ans4;

            default:
                throw new Exception("correct question value out of bound");
        }
    }
}
