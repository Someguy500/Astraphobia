using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    float fixedPosY = -7.06f;
    private bool isDead = false;
    public static Vector2 origin;
    public Rigidbody2D rb;
    [SerializeField] private LayerMask CPLayerMask;

    void Start()
    {
        origin = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    public void fallDeath()
    {
        Respawn();
        isDead = false;
    }


    public void Respawn()
    {
        gameObject.transform.position = origin;
    }


    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= fixedPosY)
        {
            isDead = true;
            fallDeath();
        }
        
        RaycastHit2D CheckpointCheck = Physics2D.Raycast(new Vector2(rb.position.x, rb.position.y), Vector2.down, 1, CPLayerMask);

        if (CheckpointCheck.collider != null)
        {
            origin = transform.position;
        }
    }
}
