using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonAction : MonoBehaviour
{
    public string sceneName;
    public void buttonAction()
    {
        Debug.Log("Done!");
        SceneManager.LoadScene(sceneName);
    }
}
