using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : PlayerBehaviour
{
    [SerializeField] GameObject Player;
    public Rigidbody2D rb;
    private BoxCollider2D col;
    float offsetX = 1f;
    float offsetY = -0.11f;
    public static bool backCarry = false;

    private void Start()
    {
        rb.mass = 210;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");

/*        if (Mathf.Abs(rb.velocity.x) < speed && CarryScript.isObject) //Movement
            rb.AddForce(new Vector2(xMove * speed, 0), ForceMode2D.Force);*/

        if (CarryScript.isObject && CarryScript.box == this.gameObject)
        {
            rb.mass = 3;
            
            transform.position = Player.transform.position;
            if(Player.transform.localScale.x > 0)
            {
                backCarry = false;
                transform.position = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, 0);
            }
            else if(Player.transform.localScale.x < 0) 
            {
                backCarry = true;
                transform.position = new Vector3(transform.position.x - offsetX, transform.position.y + offsetY, 0);
            }
            
        }
        else
        {
            rb.mass = 210;
        }

    }
}
