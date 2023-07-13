using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSoundScript : MonoBehaviour
{
    [SerializeField] AudioClip selectSound;
    [SerializeField] AudioClip acceptSound;
    [SerializeField] AudioClip cancelSound;
    private AudioSource uiSound;

    // Start is called before the first frame update
    void Start()
    {
        uiSound = this.GetComponent<AudioSource>();
    }
    public void PlayAcceptSound()
    {
        uiSound.clip = acceptSound;
        uiSound.Play();
    }

    public void PlaySelectSound()
    {
        uiSound.clip = selectSound;
        uiSound.Play();
    }

    public void PlayCancelSound()
    {
        uiSound.clip = cancelSound;
        uiSound.Play();
    }
}
