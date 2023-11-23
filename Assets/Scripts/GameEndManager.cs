using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameEndManager : MonoBehaviour
{
    [SerializeField] APIManager _apiManager;
    [SerializeField] UIManager _uiManager;
    [SerializeField] Canvas _waitScreen;
    [SerializeField] Canvas _gameEnd;

    
    public void EndGame()
    {
        _apiManager.GetScore(1, score1 =>
        {
            _apiManager.GetScore(2, score2 =>
            {
                _apiManager.GetTime(1, time1 =>
                {
                    _apiManager.GetTime(2, time2 =>
                    {
                        if (score1 > score2)
                        {
                            _apiManager.GetPlayerName(1);
                            _waitScreen.gameObject.SetActive(false);
                            _gameEnd.gameObject.SetActive(true);
                        }
                        else if (score2 > score1)
                        {
                            _apiManager.GetPlayerName(2);
                            _waitScreen.gameObject.SetActive(false);
                            _gameEnd.gameObject.SetActive(true);
                        }
                        else
                        {
                            if (time1 < time2)
                            {
                                _apiManager.GetPlayerName(1);
                                _waitScreen.gameObject.SetActive(false);
                                _gameEnd.gameObject.SetActive(true);
                            }
                            else if (time2 < time1)
                            {
                                _apiManager.GetPlayerName(2);
                                _waitScreen.gameObject.SetActive(false);
                                _gameEnd.gameObject.SetActive(true);
                            }
                            else
                            {
                                _waitScreen.gameObject.SetActive(false);
                                _gameEnd.gameObject.SetActive(true);
                                _uiManager.ZeroPointsGame();
                            }
                        }
                    });
                });
            });
        });

        StartCoroutine(End());
    }
    IEnumerator End()
    {
        GameManager._isWaiting = false;
        yield return new WaitForSeconds(3.0f);
        _apiManager.DeletePlayer();
        Application.Quit();
    }
}
