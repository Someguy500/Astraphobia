using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : PlayerBehaviour
{
    GameObject Player;
    private Rigidbody2D rb;
    private float objectScale = 0.25f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(rb.velocity.x) < speed && CarryScript.isObject) //Movement
            rb.AddForce(new Vector2(xMove * speed, 0), ForceMode2D.Force);

        //Change Orientation
        if (CarryScript.disableOri == false && CarryScript.isObject)
        {
            Vector3 characterScale = transform.localScale;
            if (Input.GetAxis("Horizontal") > 0)
                characterScale.x = objectScale;
            else if (Input.GetAxis("Horizontal") < 0)
                characterScale.x = -objectScale;
            transform.localScale = characterScale;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && CarryScript.isObject)
        {
            PlayerAnimationManager.Instance.ChangeAnim("Jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (CarryScript.isObject)
        {
            
        }
    }
}
