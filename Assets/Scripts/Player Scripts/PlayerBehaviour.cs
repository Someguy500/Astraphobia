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
    private bool isZooming = false;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private float extraJumpSpace = 0.02f;
    [SerializeField] private LayerMask platLayerMask;
    [SerializeField] private float sizeScale = 0.25f;
    float fricVal = 0f;

    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        anim.SetBool("Idle", true);

    }

    void Jump()
    {
        
    }

    private void GroundedCheck()
    {
        RaycastHit2D groundRayL = Physics2D.Raycast(new Vector2(rb.position.x-((col.size.x/2)*sizeScale), rb.position.y), Vector2.down,(col.size.y+extraJumpSpace)*sizeScale, platLayerMask);
        RaycastHit2D groundRayR = Physics2D.Raycast(new Vector2(rb.position.x+((col.size.x/2)*sizeScale), rb.position.y), Vector2.down,(col.size.y+extraJumpSpace)*sizeScale, platLayerMask);
        RaycastHit2D groundRayB = Physics2D.Raycast(new Vector2(rb.position.x-((col.size.x/2)*sizeScale), (rb.position.y+extraJumpSpace+col.size.y)*sizeScale), Vector2.right,col.size.x*sizeScale, platLayerMask);
        
        if (groundRayL.collider == null && groundRayR.collider == null && groundRayB.collider == null)
            isGrounded = false;
        else
            isGrounded = true;

        ;
    }
    
    void Update()
    {
        GroundedCheck();

        float xMove = Input.GetAxisRaw("Horizontal");
        if (isZooming == false)
        {
            //transform.Translate(new Vector3(xMove, 0, 0) * (speed * Time.deltaTime));
            //rb.velocity = new Vector2(xMove * speed, rb.velocity.y);
            if (Mathf.Abs(rb.velocity.x) < speed)
                rb.AddForce(new Vector2(xMove * speed, 0), ForceMode2D.Force);

            if (xMove != 0 && MovableScript.changeAnim == false)
            {
                anim.SetInteger("anim", 0);
                PlayerAnimationManager.Instance.ChangeAnim("Walk");
            }       
            else
            {
                if(MovableScript.changeAnim == false)
                {
                    anim.SetInteger("anim", 0);
                    PlayerAnimationManager.Instance.ChangeAnim("Idle");
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && (isGrounded == true))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                PlayerAnimationManager.Instance.ChangeAnim("Jump");
            }

            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetMouseButton(0) == true)
                isZooming = true;
        }
        else if (Input.GetMouseButton(0) == false)
            isZooming = false;

    }
}
