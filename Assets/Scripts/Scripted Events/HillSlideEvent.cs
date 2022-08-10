using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillSlideEvent : MonoBehaviour
{
    public float slideDuration = 3f;
    private bool allowJump = false;
    
    private GameObject player;
    private PlayerBehaviour playerPB;
    private Rigidbody2D playerRB;
    private CapsuleCollider2D playerCol;
    private Animator playerAnim;

    private Vector2 playerColSize;
    public Transform slidepoint;
    public Transform landpoint;

    private bool sliding;
   
    private void Start()
    {
        player = GameObject.Find("Player");
        playerPB = player.GetComponent<PlayerBehaviour>();
        playerRB = player.GetComponent<Rigidbody2D>();
        playerCol = player.GetComponent<CapsuleCollider2D>();
        playerAnim = player.GetComponent<Animator>();

        playerColSize = playerCol.size;
    }

    public void StartEvent()
    {
        playerPB.enabled = false;
        playerCol.size = new Vector2(playerCol.size.x, 1);
        sliding = true;
        PlayerAnimationManager.Instance.ChangeAnim("Slide");
        //StartCoroutine(Lerp(player.transform.position, slidepoint.transform.position, slideDuration));
    }

    public void EnterJumpTrigger()
    {
        allowJump = true;
    }

    public void ExitJumpTrigger()
    {
        allowJump = false;
        sliding = false;
        playerPB.enabled = true;
        playerCol.size = playerColSize;
    }

    private void Update()
    {
        if (sliding)
            playerRB.AddForce(Vector2.right * 5, ForceMode2D.Force);
        
        if (Input.GetKeyDown(KeyCode.Space) && (allowJump))
        {
            allowJump = false;
            StopAllCoroutines();
            playerRB.isKinematic = true;
            StartCoroutine(LerpJump(player.transform.position, landpoint.transform.position, 1));
            PlayerAnimationManager.Instance.ChangeAnim("Jump");
            playerPB.enabled = true;
        }
    }

    IEnumerator Lerp(Vector3 start, Vector3 end, float t)
    {
        float time = 0;
        while (time < t)
        {
            player.transform.position = Vector3.Lerp(start, end, time / t);
            time += Time.deltaTime;
            yield return null;
        }
    }
    
    IEnumerator LerpJump(Vector3 start, Vector3 end, float t)
    {
        float time = 0;
        while (time < t)
        {
            player.transform.position = new Vector3(Mathf.Lerp(start.x, end.x, time / t), end.y + playerPB.jumpForce / 2 * Mathf.Sin(time / t * Mathf.PI), player.transform.position.z);
            time += Time.deltaTime;
            yield return null;
        }
        playerRB.isKinematic = false;
    }
}
