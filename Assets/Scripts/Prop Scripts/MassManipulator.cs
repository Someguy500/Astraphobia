using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassManipulator : MonoBehaviour
{
   [SerializeField] Rigidbody2D rb;

    void Start()
    {
        rb.mass = 210;
    }

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.E) && (Input.GetKey(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.E) && (Input.GetKey(KeyCode.D))) || (Input.GetKeyDown(KeyCode.E) && (Input.GetKey(KeyCode.LeftArrow))) || (Input.GetKey(KeyCode.LeftArrow) && (Input.GetKey(KeyCode.A)))))
        {
            rb.mass = 3;
        }
        else if(MovableScript.changeAnim == false)
        {
            rb.mass = 210;
        }

    }
}
