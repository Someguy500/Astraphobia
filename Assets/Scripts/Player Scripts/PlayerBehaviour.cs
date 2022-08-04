using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool isGrounded = true;
    private bool isZooming;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private float extraJumpSpace = 0.02f;
    [SerializeField] private LayerMask platLayerMask;
    [SerializeField] private float sizeScale = 0.25f;
    float fricVal = 0f;

    private float playerScale;
    
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        anim.SetBool("Idle", true);
        playerScale = transform.localScale.x;
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
    }
    
    void Update()
    {
        GroundedCheck();

        float xMove = Input.GetAxisRaw("Horizontal");
        if (!isZooming)
        {
            //Movement
            if (Mathf.Abs(rb.velocity.x) < speed)
                rb.AddForce(new Vector2(xMove * speed, 0), ForceMode2D.Force);
            
            //Change Orientation
            if (CarryScript.disableOri == false)
            {
                Vector3 characterScale = transform.localScale;
                if (Input.GetAxis("Horizontal") > 0)
                    characterScale.x = playerScale;
                else if (Input.GetAxis("Horizontal") < 0)
                    characterScale.x = -playerScale;
                transform.localScale = characterScale;
            }
            
            if (xMove != 0 && CarryScript.changeAnim == false)
            {
                PlayerAnimationManager.Instance.ChangeAnim("Walk");
            }       
            else if(CarryScript.changeAnim == false)
            {
                PlayerAnimationManager.Instance.ChangeAnim("Idle");
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                PlayerAnimationManager.Instance.ChangeAnim("Jump");
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            // if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetMouseButton(0))
            //    isZooming = true;
        }
        // else if (Input.GetMouseButton(0) == false)
        //    isZooming = false;

    }
}
