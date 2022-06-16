using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private bool isGrounded = true;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private float extraJumpSpace = 0.02f;
    [SerializeField] private LayerMask platLayerMask;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    void Jump()
    {
        
    }

    private void GroundedCheck()
    {
        RaycastHit2D groundRayL = Physics2D.Raycast(new Vector2(rb.position.x-(col.size.x/2), rb.position.y), Vector2.down,col.size.y+extraJumpSpace, platLayerMask);
        RaycastHit2D groundRayR = Physics2D.Raycast(new Vector2(rb.position.x+(col.size.x/2), rb.position.y), Vector2.down,col.size.y+extraJumpSpace, platLayerMask);
        RaycastHit2D groundRayB = Physics2D.Raycast(new Vector2(rb.position.x-(col.size.x/2), rb.position.y+extraJumpSpace), Vector2.right,col.size.x, platLayerMask);
        
        if (groundRayL.collider == null && groundRayR.collider == null && groundRayB.collider == null)
        {
            isGrounded = false;
            //Debug.Log("Not Grounded");
        }
        else
        {
            isGrounded = true;
            //Debug.Log("Grounded");
        }

        ;
    }
    
    void Update()
    {
        GroundedCheck();
        float xMove = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(xMove, 0, 0) * (speed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space)&& (isGrounded == true) )
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //(just in case you wanted to set jump speed instead of adding)
            //rigidbody.velocity.y = jumpForce;
        }
            
    }
}
