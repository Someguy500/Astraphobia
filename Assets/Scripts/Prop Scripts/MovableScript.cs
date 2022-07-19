using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableScript : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;
    bool onMove = true;
    bool disconnect = false;
    public static bool changeAnim = false;
    public static bool disableOri = false;
    public Animator anim;
    private bool animMove = false;

    GameObject box;
    private void Start()
    {
        Debug.Log(box);
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false; 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (animMove)
        {
            if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
            {
                anim.SetInteger("anim", 1);
                anim.SetBool("Push", true);
                //anim.SetBool("Pull", false);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A)))
            {
                anim.SetInteger("anim", 2);
                anim.SetBool("Pull", true);
                //anim.SetBool("Push", false);
            }
        }


        if (onMove)
        {
            if (hit.collider != null && Input.GetKeyDown(KeyCode.V) && animMove == false)
            {
                animMove = true;
                disableOri = true;
                changeAnim = true;
              
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
                changeAnim = false;
                anim.SetBool("Idle", true);
                anim.SetBool("Push", false);
                anim.SetBool("Push", false);
                disconnect = false;
                box.GetComponent<FixedJoint2D>().enabled = false;
                disableOri = false;
                onMove = true;
                animMove = false;
            }
            else if (hit.collider != null && Input.GetKeyDown(KeyCode.V))
            {
                changeAnim = false;
                anim.SetBool("Idle", true);
                anim.SetBool("Pull", false);
                anim.SetBool("Push", false);
                box.GetComponent<FixedJoint2D>().enabled = false;
                Debug.Log(box);
                Debug.Log("detached^");
                disableOri = false;
                onMove = true;
                animMove = false;
            }

        }         

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }



}
