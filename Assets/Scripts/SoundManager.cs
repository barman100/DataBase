using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Button _musicButton_01;
    [SerializeField] Button _musicButton_02;
    [SerializeField] Button _musicButton_03;
    
    [SerializeField] Button _soundButton_01;
    [SerializeField] Button _soundButton_02;
    [SerializeField] Button _soundButton_03;

    [SerializeField] Sprite _musicOn;
    [SerializeField] Sprite _musicOff;
    
    [SerializeField] Sprite _soundOn;
    [SerializeField] Sprite _soundOff;

    [SerializeField] AudioSource _clickSound;
    [SerializeField] AudioSource _music;

    private bool _isMusicPlaying = true;
    private bool _isSoundPlaying = true;

    public void StopMusic()
    {
        if (_isMusicPlaying)
        {
            _music.enabled = false;
            _isMusicPlaying = false;
            _musicButton_01.image.sprite = _musicOff;
            _musicButton_02.image.sprite = _musicOff;
            _musicButton_03.image.sprite = _musicOff;
        }
        else if (!_isMusicPlaying)
        {
            _music.enabled = true;
            _isMusicPlaying = true;
            _musicButton_01.image.sprite = _musicOn;
            _musicButton_02.image.sprite = _musicOn;
            _musicButton_03.image.sprite = _musicOn;
        }
    }
    public void StopSound()
    {
        if (_isSoundPlaying)
        {
            _clickSound.enabled = false;
            _isSoundPlaying = false;
            _soundButton_01.image.sprite = _soundOff;
            _soundButton_02.image.sprite = _soundOff;
            _soundButton_03.image.sprite = _soundOff;
        }
        else if (!_isSoundPlaying)
        {
            _clickSound.enabled = true;
            _isSoundPlaying = true;
            _soundButton_01.image.sprite = _soundOn;
            _soundButton_02.image.sprite = _soundOn;
            _soundButton_03.image.sprite = _soundOn;
        }
    }
    public void PlayButtonSound()
    {
        if (_isSoundPlaying)
        _clickSound.Play();
    }
}
