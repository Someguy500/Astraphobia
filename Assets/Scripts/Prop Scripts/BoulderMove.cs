using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMove : MonoBehaviour
{
	public Rigidbody2D rb;

	void Start()
	{
		rb.constraints = RigidbodyConstraints2D.FreezeAll;
	}
}
