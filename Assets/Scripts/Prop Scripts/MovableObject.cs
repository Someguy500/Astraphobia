using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : PlayerBehaviour
{
    [SerializeField] GameObject Player;
    public Rigidbody2D rb;
    private float objectScale = 0.25f;
    float offsetX = 1f;
    float offsetY = 0;

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

        if (CarryScript.isObject)
        {
            rb.mass = 3;
            transform.position = Player.transform.position;
            transform.position = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, 0);
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
