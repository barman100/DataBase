using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    [SerializeField] APIManager apiManager;
    
    public void EndGame()
    {
        if (apiManager.GetScore(1) > apiManager.GetScore(2))
            Debug.Log("Player 1 Win");
        else if (apiManager.GetScore(2) > apiManager.GetScore(1))
            Debug.Log("Player 2 Win");
        else
        {
            if (apiManager.GetTime(1) > apiManager.GetTime(2))
                Debug.Log("Player 1 Win");
            else if (apiManager.GetTime(2) > apiManager.GetTime(1))
                Debug.Log("Player 2 Win");
        }
    }
}
