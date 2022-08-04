using UnityEngine;

public class MovableScript : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;
    bool onMove = true;
    bool disconnect = false;
    public static bool changeAnim = false;
    public static bool disableOri = false; //disables playerOrientation for that period of time
    public Animator anim;
    private bool animMove = false;

    GameObject box;
    private void Start()
    {
        Debug.Log(box);
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false; //Set the raycasts or linecasts that start inside Colliders to not detect Colliders.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask); 
        //sets the raycast from the player to only hit and detect the box Mask ^

        if (animMove) //animation switching from push and pull
        {
            if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
            {
                PlayerAnimationManager.Instance.ChangeAnim("Push");
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A)))
            {
                PlayerAnimationManager.Instance.ChangeAnim("Pull");
            }
        }


        if (onMove) //the if onMove was initially made to stop players from spamming (subject to change)
        {
            if (hit.collider != null && Input.GetKeyDown(KeyCode.E) && animMove == false) //carrying the box (Only triggers when moving and pressing e)
            {
                
                animMove = true;
                disableOri = true;
                changeAnim = true;
              
                box = hit.collider.gameObject; //assigns the box to return back if the collider hits an object 
                box.GetComponent<FixedJoint2D>().enabled = true; //enables the FixedJoint2D component 
                box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>(); 
                //anchors the preset position of the player and the box in a position where it looks like its picking up
                onMove = false;
                disconnect = true;

            }
        }
        else
        {
            if (disconnect && transform.position.y <= -1.7) 
                // ^disconects the box automatically when (player falls off a cliff but carries a box or gets stuck while carrying the box on the edge of a cliff)
            {
                changeAnim = false;
                PlayerAnimationManager.Instance.ChangeAnim("Idle");
                disconnect = false;
                box.GetComponent<FixedJoint2D>().enabled = false; //disables the FixedJoint2D component 
                disableOri = false; 
                onMove = true;
                animMove = false;
            }
            else if (hit.collider != null && Input.GetKeyDown(KeyCode.E)) 
                //^ disconnects the box when raycast hits nothing and input is pressed)
            {
                changeAnim = false;
                PlayerAnimationManager.Instance.ChangeAnim("Idle");
                box.GetComponent<FixedJoint2D>().enabled = false;
                disableOri = false;
                onMove = true;
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
