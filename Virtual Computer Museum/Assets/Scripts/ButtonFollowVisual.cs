using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollowVisual : MonoBehaviour
{
    public Transform visualTarget;
    public Vector3 localAxis;
    public float followAngleThreshold = 10f;
    public float resetSpeed = 5f;

    private Vector3 initialLocalPos;
    private Transform pokeAttachTransform;
    private XRBaseInteractable interactable;
    private bool isFollowing = false;
    private bool freeze = false;

    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.onSelectEntered.AddListener(Follow);
        interactable.onSelectExited.AddListener(Reset);
        interactable.onSelectEntered.AddListener(Freeze);
        initialLocalPos = visualTarget.localPosition;
    }

    private void Follow(XRBaseInteractor interactor)
    {
        if (interactor is XRPokeInteractor pokeInteractor)
        {
            pokeAttachTransform = pokeInteractor.attachTransform;
            Vector3 offset = visualTarget.position - pokeAttachTransform.position;
            float pokeAngle = Vector3.Angle(offset, visualTarget.TransformDirection(localAxis));

            if (pokeAngle < followAngleThreshold)
            {
                isFollowing = true;
                freeze = false;
            }
        }
    }

    private void Reset(XRBaseInteractor interactor)
    {
        if (interactor is XRPokeInteractor)
        {
            isFollowing = false;
            freeze = false;
        }
    }

    private void Freeze(XRBaseInteractor interactor)
    {
        if (interactor is XRPokeInteractor)
        {
            freeze = true;
        }
    }

    void Update()
    {
        if (!isFollowing && !freeze && pokeAttachTransform != null)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(pokeAttachTransform.position);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis);
            visualTarget.position = visualTarget.TransformPoint(constrainedLocalTargetPosition);
        }
        else
        {
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, initialLocalPos, Time.deltaTime * resetSpeed);
        }
    }
}
