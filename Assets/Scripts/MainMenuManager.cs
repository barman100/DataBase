using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject Credits;
    [SerializeField] Canvas StartScreen;
    [SerializeField] Canvas NameScreen;
    [SerializeField] Canvas WaitScreen;
    [SerializeField] TMP_InputField NameInputField;
    [SerializeField] Button ReturnButton;
    [SerializeField] TMP_InputField playerName;
    [SerializeField] MainMenuAPIManager _MainMenuAPIManager;
    private int playerCount = 0;
    private bool CreditsShowing = false;
    public static int playerID = 0;

    private void Start()
    {
        StartScreen.gameObject.SetActive(true);
        NameScreen.gameObject.SetActive(false);
        WaitScreen.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (WaitScreen.isActiveAndEnabled == true)
        {
            playerCount = _MainMenuAPIManager.GetPlayerCount();
            if (playerCount == 1)
                playerID = 1;
            else if (playerCount == 2)
            {
                if (playerID == 0)
                    playerID = 2;
                StartGame();
            }
        }
    }
    public void StartButtonClicked()
    {
        StartScreen.gameObject.SetActive(false);
        NameScreen.gameObject.SetActive(true);
    }
    public void EnteredName()
    {
        if (NameInputField.text != "")
        {
            _MainMenuAPIManager.UpdatePlayerName(playerName.text);
            NameScreen.gameObject.SetActive(false);
            WaitScreen.gameObject.SetActive(true);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ShowCredits()
    {
        
        if (CreditsShowing) { Credits.SetActive(false); CreditsShowing = false; ReturnButton.gameObject.SetActive(false); }
        else if (!CreditsShowing) { Credits.SetActive(true); CreditsShowing = true; ReturnButton.gameObject.SetActive(true); }
    }
    public void ReturnButtonClicked()
    {
        if (NameScreen.isActiveAndEnabled == true)
        {
            StartScreen.gameObject.SetActive(true);
            NameScreen.gameObject.SetActive(false);
        }
        else if (CreditsShowing)
        { Credits.SetActive(false); CreditsShowing = false; ReturnButton.gameObject.SetActive(false); }
    }
   
}
