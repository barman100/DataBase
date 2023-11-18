using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Button MusicButton1;
    [SerializeField] Button SoundButton1;
    [SerializeField] Button MusicButton2;
    [SerializeField] Button SoundButton2;
    [SerializeField] Button MusicButton3;
    [SerializeField] Button SoundButton3;

    [SerializeField] Sprite MusicOn;
    [SerializeField] Sprite MusicOff;
    [SerializeField] Sprite SoundOn;
    [SerializeField] Sprite SoundOff;

    [SerializeField] AudioSource ClickSound;
    [SerializeField] AudioSource Music;

    private bool isMusicPlaying = true;
    private bool isSoundPlaying = true;

    public void StopMusic()
    { 
        if (isMusicPlaying) { Music.enabled = false; isMusicPlaying = false; MusicButton1.image.sprite = MusicOff; MusicButton2.image.sprite = MusicOff; MusicButton3.image.sprite = MusicOff; }
        else if (!isMusicPlaying) { Music.enabled = true; isMusicPlaying = true; MusicButton1.image.sprite = MusicOn; MusicButton2.image.sprite = MusicOn; MusicButton3.image.sprite = MusicOn; }
    }
    public void StopSound()
    {
        if (isSoundPlaying) { ClickSound.enabled = false; isSoundPlaying = false; SoundButton1.image.sprite = SoundOff; SoundButton2.image.sprite = SoundOff; SoundButton3.image.sprite = SoundOff; }
        else if (!isSoundPlaying) { ClickSound.enabled = true; isSoundPlaying = true; SoundButton1.image.sprite = SoundOn; SoundButton2.image.sprite = SoundOn; SoundButton3.image.sprite = SoundOn; }
    }
    public void PlayButtonSound()
    {
        if (isSoundPlaying)
        ClickSound.Play();
    }
}
