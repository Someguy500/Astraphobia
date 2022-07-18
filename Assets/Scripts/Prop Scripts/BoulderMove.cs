using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMove : MonoBehaviour
{
	public Rigidbody2D rb;
	public int roll;
    public GameObject Player;

	void Start()
	{
		rb.constraints = RigidbodyConstraints2D.FreezeAll;
        roll = 0;
	}

    private void Update()
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
    }
}
