using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    float fixedPosY = -7.06f;
    private bool isDead = false;
    Vector2 origin;


    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
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
    }
}
