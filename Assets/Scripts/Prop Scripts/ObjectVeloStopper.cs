using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVeloStopper : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            collision.gameObject.GetComponent<MovableObject>().enabled = false;
            collision.gameObject.tag = "Unpushable";
        }
    }
}
