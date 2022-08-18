using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchScript : MonoBehaviour
{
    private void Update()
    {

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            Level1Goal.sceneNew = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }


    }
}
