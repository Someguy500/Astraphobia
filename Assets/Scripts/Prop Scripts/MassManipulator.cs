using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassManipulator : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public BoxCollider2D bCol;
    [SerializeField] public BoxCollider2D bCol2;

    void Start()
    {
/*        bCol.isTrigger = true;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;*/
        
    }

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.E) && (Input.GetKey(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.E) && (Input.GetKey(KeyCode.D))) || (Input.GetKeyDown(KeyCode.E) && (Input.GetKey(KeyCode.LeftArrow))) || (Input.GetKey(KeyCode.LeftArrow) && (Input.GetKey(KeyCode.A)))))
        {
/*            bCol.isTrigger = false;
            rb.constraints = RigidbodyConstraints2D.None;
            bCol = bCol2;*/
            rb.mass = 3;
        }
        else if(MovableScript.changeAnim == false)
        {
/*            bCol.isTrigger = true;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;*/
            rb.mass = 210;
        }
    }
}
