using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public string sceneName;
    public GameObject objectWithButtonActionScript;

    public void buttonAction()
    {
        
        if (!(sceneName == "Museum"))
        {
            // Speichere die aktuelle Position und die Szene in der Datenklasse
            //PositionDataManager.SetPreviousPosition(objectWithButtonActionScript.transform.position);
            //Debug.Log("gespeichert! "+objectWithButtonActionScript.transform.position);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Done!");
            //objectWithButtonActionScript.transform.position = PositionDataManager.GetPreviousPosition();
            objectWithButtonActionScript.transform.position = new Vector3(-1.18f, 0f, 17.4f);
            SceneManager.LoadScene(sceneName);
           
        }
        
    }
}
