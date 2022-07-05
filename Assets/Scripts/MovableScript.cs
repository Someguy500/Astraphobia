using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableScript : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;
    bool onMove = true;
    bool disconnect = false;

    GameObject box;
    private void Start()
    {
        Debug.Log(box);
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);



        if (onMove)
        {

            if (hit.collider != null && Input.GetKeyDown(KeyCode.V))
            {
                box = hit.collider.gameObject;
                box.GetComponent<FixedJoint2D>().enabled = true;
                box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
                Debug.Log(box);
                Debug.Log("attached^");
                onMove = false;
                disconnect = true;
            }
        }
        else
        {
            if (disconnect && transform.position.y <= -1.7)
            {
                disconnect = false;
                box.GetComponent<FixedJoint2D>().enabled = false;
                onMove = true;
            }
            else if (hit.collider == null && Input.GetKeyDown(KeyCode.V))
            {
                box.GetComponent<FixedJoint2D>().enabled = false;
                Debug.Log(box);
                Debug.Log("detached^");
                onMove = true;
            }

        }
        



        

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }

}
