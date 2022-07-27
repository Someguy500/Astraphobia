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
        if (Player.transform.position.x >= 31f) //trigger range
        {
            rb.simulated = false;
            rb.simulated = true;
            rb.constraints = RigidbodyConstraints2D.None;
            if (roll == 0)
            {
                roll++;
                /*rb.AddForce(new Vector2(-0.1f, 0) * 2);*/
                StartCoroutine(bDelay());
            }
          
        }

        if (gameObject.transform.position.x <= -29f) 
        {
            roll = 1;
        }
    }

    IEnumerator bDelay()
    {       
        yield return new WaitForSeconds(3.1f);
        transform.localScale = new Vector3(0.1947076f, 0.1947076f, 0.1947076f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && Player.transform.position.x >= 30f)
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
