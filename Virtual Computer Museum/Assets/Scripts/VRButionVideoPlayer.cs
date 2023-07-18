using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class VRButtonVideoPlayer : MonoBehaviour
{
    public GameObject videoObject; // Das Video-Objekt, das aktiviert wird
    public VideoPlayer videoPlayer; //Der VideoPlayer, der das Video abspielt

    private XRBaseInteractable interactable;
    private bool isVideoPlaying = false;

    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.onSelectEntered.AddListener(OnButtonPressed);
    }

    private void OnButtonPressed(XRBaseInteractor interactor)
    {
        // Überprüfen, ob der Interaktor eine VR-Hand ist
        if (interactor is XRDirectInteractor)
        {
            // Aktivieren des Video-Objekts
            videoObject.SetActive(true);

            // Starten des Videos, wenn es nicht bereits läuft
            if (!isVideoPlaying)
            {
                videoPlayer.Play();
                isVideoPlaying = true;
            }
        }
    }
}
