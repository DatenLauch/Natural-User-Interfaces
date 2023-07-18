using UnityEngine;
using UnityEngine.UI;

public class Render2DGameOnCanvas : MonoBehaviour
{
    public GameObject gameObject;  // Reference to the 2D game GameObject
    private RawImage rawImage;     // Reference to the RawImage component

    private void Start()
    {
        // Get the RawImage component on the Canvas
        rawImage = GetComponent<RawImage>();

        // Create a new RenderTexture and assign it to the RawImage
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 0);
        renderTexture.filterMode = FilterMode.Point;  // Set filter mode to preserve pixel art

        // Set the active RenderTexture and render the game GameObject onto it
        RenderTexture.active = renderTexture;
        RenderTexture previousActiveTexture = RenderTexture.active;
        Camera gameCamera = CreateGameCamera(renderTexture);
        gameCamera.targetTexture = renderTexture;
        gameCamera.Render();

        // Assign the RenderTexture to the RawImage
        rawImage.texture = renderTexture;

        // Clean up
        gameCamera.targetTexture = null;
        RenderTexture.active = previousActiveTexture;
        Destroy(gameCamera.gameObject);
    }

    private Camera CreateGameCamera(RenderTexture targetTexture)
    {
        GameObject cameraObject = new GameObject("Game Camera");
        Camera gameCamera = cameraObject.AddComponent<Camera>();
        gameCamera.clearFlags = CameraClearFlags.Color;
        gameCamera.backgroundColor = Color.clear;
        gameCamera.orthographic = true;
        gameCamera.orthographicSize = Screen.height / 2f;
        gameCamera.cullingMask = LayerMask.GetMask("GameLayer");
        gameCamera.targetTexture = targetTexture;
        return gameCamera;
    }
}
