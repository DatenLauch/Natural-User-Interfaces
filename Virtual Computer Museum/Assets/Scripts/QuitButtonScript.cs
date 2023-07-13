using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI exitButtonText;
    [SerializeField] UiSoundScript uiSounds;

    public void HoverButton()
    {
        uiSounds.PlaySelectSound();
        exitButtonText.text = "> Quit <";
    }

    public void UnhoverButton()
    {
        exitButtonText.text = "Quit";
    }
    public void ClickQuit()
    {
        uiSounds.PlayAcceptSound();
        
        if (UnityEditor.EditorApplication.isPlaying)
            UnityEditor.EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }

}