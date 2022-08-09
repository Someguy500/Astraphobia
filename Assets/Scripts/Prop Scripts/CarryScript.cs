using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryScript : MonoBehaviour
{
    public static GameObject box;
    public float distance = 1f;
    public LayerMask boxMask;
    bool disconnect = false;
    public static bool changeAnim = false;
    public static bool disableOri = false; 
    public Animator anim;
    private bool animMove = false;
    public static bool isObject = false;
    private Rigidbody2D playerRb;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (animMove) //animation switching from push and pull
        {

            if (playerRb.velocity.x < 0 && MovableObject.backCarry)
            {
                anim.speed = 20;
                PlayerAnimationManager.Instance.ChangeAnim("Push");
            }
            else if (playerRb.velocity.x > 0 && MovableObject.backCarry)
            {
                anim.speed = 20;
                PlayerAnimationManager.Instance.ChangeAnim("Pull");
            }
            else if (playerRb.velocity.x > 0)
            {
                anim.speed = 20;
                PlayerAnimationManager.Instance.ChangeAnim("Push");
            }
            else if (playerRb.velocity.x < 0)
            {
                anim.speed = 20;
                PlayerAnimationManager.Instance.ChangeAnim("Pull");
            }
            else
            {
                anim.speed = 0;
            }

        }

        if (hit.collider != null && Input.GetKeyDown(KeyCode.E) && animMove == false) 
        {       
            isObject = true;
            animMove = true;
            disableOri = true;
            changeAnim = true;
            box = hit.collider.gameObject; 
            disconnect = true;

        }
        else
        {
            if (disconnect && transform.position.y <= -1.7)
            {
                anim.speed = 1;
                isObject = false;
                changeAnim = false;
                PlayerAnimationManager.Instance.ChangeAnim("Idle");
                disconnect = false;            
                disableOri = false;
                animMove = false;
            }
            else if (hit.collider != null && Input.GetKeyDown(KeyCode.E))
            //^ disconnects the box when raycast hits nothing and input is pressed)
            {
                anim.speed = 1;
                isObject = false;
                changeAnim = false;
                PlayerAnimationManager.Instance.ChangeAnim("Idle");
                disableOri = false;
                animMove = false;
            }

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta; //using gizmo to draw a line to display range
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }


}
