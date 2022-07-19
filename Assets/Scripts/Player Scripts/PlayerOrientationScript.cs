using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientationScript : MonoBehaviour
{

    private void flip()
    {

    }

    void Update()
    {
        if (MovableScript.disableOri == false)
        {
            Vector3 characterScale = transform.localScale;
            if (Input.GetAxis("Horizontal") > 0)
            {
                characterScale.x = 0.25f;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                characterScale.x = -0.25f;
            }
            transform.localScale = characterScale;
        }
    }

}
