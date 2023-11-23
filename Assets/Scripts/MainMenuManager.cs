using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject _credits;
    [SerializeField] Canvas _startScreen;
    [SerializeField] Canvas _nameScreen;
    [SerializeField] Canvas _waitScreen;
    [SerializeField] TMP_InputField _nameInputField;
    [SerializeField] Button _returnButton;
    [SerializeField] TMP_InputField _playerName;
    [SerializeField] MainMenuAPIManager _mainMenuAPIManager;
    private int _playerCount = 0;
    private bool _creditsShowing = false;

    public static int PlayerID = 0;
    private void Start()
    {
        _startScreen.gameObject.SetActive(true);
        _nameScreen.gameObject.SetActive(false);
        _waitScreen.gameObject.SetActive(false);
    }
    private void Update()
    {
        CheckForPlayers();
    }

    private void CheckForPlayers()
    {
        if (_waitScreen.isActiveAndEnabled == true)
        {
            _playerCount = _mainMenuAPIManager.GetPlayerCount();

            if (_playerCount == 1)
                PlayerID = 1;

            else if (_playerCount == 2)
            {
                if (PlayerID == 0)
                    PlayerID = 2;

                StartGame();
            }
        }
    }

    public void StartButtonClicked()
    {
        _startScreen.gameObject.SetActive(false);
        _nameScreen.gameObject.SetActive(true);
    }
    public void EnteredName()
    {
        if (_nameInputField.text != "")
        {
            _mainMenuAPIManager.UpdatePlayerName(_playerName.text);
            _nameScreen.gameObject.SetActive(false);
            _waitScreen.gameObject.SetActive(true);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ShowCredits()
    {

        if (_creditsShowing)
        {
            _credits.SetActive(false);
            _creditsShowing = false;
            _returnButton.gameObject.SetActive(false);
        }
        else if (!_creditsShowing)
        {
            _credits.SetActive(true);
            _creditsShowing = true;
            _returnButton.gameObject.SetActive(true);
        }
    }
    public void ReturnButtonClicked()
    {
        if (_nameScreen.isActiveAndEnabled == true)
        {
            _startScreen.gameObject.SetActive(true);
            _nameScreen.gameObject.SetActive(false);
        }
        else if (_creditsShowing)
        {
            _credits.SetActive(false);
            _creditsShowing = false;
            _returnButton.gameObject.SetActive(false);
        }
    }

}
