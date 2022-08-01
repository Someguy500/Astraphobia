using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pMenu.SetActive(true);
        }
        else
        {
            pMenu.SetActive(false);
        }
    }
}
