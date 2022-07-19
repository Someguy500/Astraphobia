using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMove : MonoBehaviour
{
	public Rigidbody2D rb;
	public int roll;
    public GameObject Player;
    public Vector3 oriPos;
    public static bool resetPos;
    public bool isLock = false;

	void Start()
	{
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        oriPos = gameObject.transform.position;
        resetPos = false;

        roll = 0;
	}

    public void unlocked()
    {
        if (Player.transform.position.x >= 30f)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            if (roll == 0)
            {
                roll++;
                rb.AddForce(new Vector2(-1, 0) * 2);
            }
            
        }

        if (gameObject.transform.position.x <= -29f)
        {
            roll = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !(gameObject.transform.position.x >= -29f))
        {
            resetPos = true;
            gameObject.transform.position = oriPos;
            roll = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void Update()
    {
        unlocked();
    }
}
