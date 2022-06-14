using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Jump()
    {
        
    }
    
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(xMove, 0, 0) * (speed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
