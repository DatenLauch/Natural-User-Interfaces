using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioGuideScript : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] Button button;
    [SerializeField] Sprite playIcon;
    [SerializeField] Sprite stopIcon;
    Boolean play = false;

    void playAudioGuide()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        changeToStopIcon();
        play = true;
    }

    void stopAudioGuide()
    {
        audioSource.Stop();
        changeToPlayIcon();
        play = false;

    }

    public void PlayPause()
    {
        if (play)
            stopAudioGuide();

        else
            playAudioGuide();
    }

    void changeToPlayIcon()
    {
        button.GetComponent<Image>().sprite = playIcon;
    }

    void changeToStopIcon()
    {
        button.GetComponent<Image>().sprite = stopIcon;
    }
}
