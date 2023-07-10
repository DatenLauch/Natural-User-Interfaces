using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI startButtonText;
    [SerializeField] UiSoundScript uiSounds;
    [SerializeField] GameObject entranceDoor;
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;

    public void HoverButton()
    {
        uiSounds.PlaySelectSound();
        startButtonText.text = "> Start <";
    }

    public void UnhoverButton()
    {
        startButtonText.text = "Start";
    }

    public void ClickStart()
    {
        quitButton.enabled = false;
        quitButton.GetComponent<EventTrigger>().enabled = false;
        startButton.enabled = false;
        startButton.GetComponent<EventTrigger>().enabled = false;
        uiSounds.PlayAcceptSound();
        StartCoroutine(MoveObjectCoroutine());
    }

    private IEnumerator MoveObjectCoroutine()
    {
        float elapsedTime = 0f;
        int duration = 2;
        Vector3 currentPosition = entranceDoor.transform.position;
        Vector3 targetPosition = new Vector3(5.0f, -4f, -20.25f);

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            entranceDoor.transform.position = Vector3.Lerp(currentPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        entranceDoor.transform.position = targetPosition;
        Destroy(entranceDoor);
    }
}
