using System.Collections;
using UnityEngine;

public class ObjectGrabberVR : MonoBehaviour
{
    public Transform handTransform; // Die Transform-Komponente der VR-Hand (wo das Objekt platziert wird)
    public float grabDistance = 0.1f; // Die maximale Entfernung, in der das Objekt gegriffen werden kann
    public LayerMask grabMask; // Die Layer, die das gegriffene Objekt haben soll

    private GameObject grabbedObject;
    private bool isGrabbing;

    void Update()
    {
        if (Input.GetButtonDown("VR_Grab")) // Hier müssen Sie den Input für das Greifen über VR-Controller einfügen
        {
            if (!isGrabbing)
                TryGrabObject();
            else
                ReleaseObject();
        }

        if (isGrabbing && grabbedObject != null)
        {
            UpdateGrabbedObjectPosition();
        }
    }

    void TryGrabObject()
    {
        // Raycast basierend auf der Position und Blickrichtung der VR-Hand
        Ray ray = new Ray(handTransform.position, handTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, grabDistance, grabMask))
        {
            grabbedObject = hit.collider.gameObject;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true; // Deaktiviert die Physik des Objekts beim Greifen
            isGrabbing = true;

            // Hier können Sie die Animation abspielen und den Sound abspielen
            // z.B. grabbedObject.GetComponent<Animation>().Play("GrabAnimation");
            //      grabbedObject.GetComponent<AudioSource>().PlayOneShot(grabSound);
        }
    }

    void UpdateGrabbedObjectPosition()
    {
        grabbedObject.transform.position = handTransform.position;
        grabbedObject.transform.rotation = handTransform.rotation;
    }

    void ReleaseObject()
    {
        if (grabbedObject != null)
        {
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false; // Aktiviert die Physik des Objekts wieder
            grabbedObject = null;
            isGrabbing = false;
        }
    }
}
