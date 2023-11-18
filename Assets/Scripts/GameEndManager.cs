using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndManager : MonoBehaviour
{
    [SerializeField] APIManager apiManager;
    [SerializeField] Canvas GamePlay;
    [SerializeField] Canvas GameEnd;

    
    public void EndGame()
    {
        apiManager.GetScore(1, score1 =>
        {
            apiManager.GetScore(2, score2 =>
            {
                apiManager.GetTime(1, time1 =>
                {
                    apiManager.GetTime(2, time2 =>
                    {
                        if (score1 > score2)
                        {
                            apiManager.GetPlayerName(1);
                            GamePlay.gameObject.SetActive(false);
                            GameEnd.gameObject.SetActive(true);
                        }
                        else if (score2 > score1)
                        {
                            apiManager.GetPlayerName(2);
                            GamePlay.gameObject.SetActive(false);
                            GameEnd.gameObject.SetActive(true);
                        }
                        else
                        {
                            if (time1 < time2)
                            {
                                apiManager.GetPlayerName(1);
                                GamePlay.gameObject.SetActive(false);
                                GameEnd.gameObject.SetActive(true);
                            }
                            else if (time2 < time1)
                            {
                                apiManager.GetPlayerName(2);
                                GamePlay.gameObject.SetActive(false);
                                GameEnd.gameObject.SetActive(true);
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
        yield return new WaitForSeconds(3.0f);
        apiManager.DeletePlayer();
        SceneManager.LoadScene(0);
    }
}
