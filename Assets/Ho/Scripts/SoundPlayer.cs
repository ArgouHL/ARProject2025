using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource sfxPlayer;
    public AudioClip click;
    public AudioClip correct;

    public static SoundPlayer instance;
    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        DialogueSystem.OnClickNextDialog += PlayClick;
    }

    private void OnDisable()
    {
        DialogueSystem.OnClickNextDialog -= PlayClick;
    }

    public void PlayBGM()
    {
        bgm.Play();
    }

    public void PlayClick()
    {
        sfxPlayer.PlayOneShot(click);
    }

    public void PlayCorrect()
    {
        sfxPlayer.PlayOneShot(correct);
    }

}
