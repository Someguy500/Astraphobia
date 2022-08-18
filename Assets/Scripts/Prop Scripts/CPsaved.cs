using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPsaved : MonoBehaviour
{
    public static Vector3 savePoint;
    private bool savedCP = false;

    private void Start()
    {
        savePoint = this.gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && savedCP == false)
        {
            savedCP = true;
            PlayerFall.origin = savePoint;
        }
    }
}
