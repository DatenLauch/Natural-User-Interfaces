using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Enable or disable camera tracking
    public bool isCameraFixed = true;

    // Fixed camera position
    public Vector3 fixedPosition;

    // Fixed camera rotation
    public Quaternion fixedRotation;

    void Update()
    {
        if (isCameraFixed)
        {
            // Set the camera position and rotation to the fixed values
            transform.position = fixedPosition;
            transform.rotation = fixedRotation;
        }
    }
}
