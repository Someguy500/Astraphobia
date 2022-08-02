using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientationScript : MonoBehaviour
{
    private float scale;

    private void Awake()
    {
        scale = transform.localScale.x;
    }

    void Update()
    {
        if (MovableScript.disableOri == false)
        {
            Vector3 characterScale = transform.localScale;
            if (Input.GetAxis("Horizontal") > 0)
            {
                characterScale.x = scale;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                characterScale.x = -scale;
            }
            transform.localScale = characterScale;
        }
    }

}
