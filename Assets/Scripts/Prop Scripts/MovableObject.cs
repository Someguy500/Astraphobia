using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : PlayerBehaviour
{
    [SerializeField] GameObject Player;
    public Rigidbody2D rb;
    private float objectScale = 0.25f;
    float offsetX = 1f;
    float offsetY = -0.11f;
    public static bool backCarry = false;

    private void Start()
    {
        rb.mass = 210;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(rb.velocity.x) < speed && CarryScript.isObject) //Movement
            rb.AddForce(new Vector2(xMove * speed, 0), ForceMode2D.Force);

        if (CarryScript.isObject)
        {
            rb.mass = 3;
            transform.position = Player.transform.position;
            if(Player.transform.localScale.x > 0)
            {
                transform.position = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, 0);
            }
            else if(Player.transform.localScale.x < 0 && transform.localScale.x > 0) 
            {
                backCarry = true;
                transform.position = new Vector3(transform.position.x - offsetX, transform.position.y + offsetY, 0);
            }
            
        }
        else
        {
            rb.mass = 210;
        }

        if(CarryScript.isObject)
        {

        }
    }
}
