using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillSlideEvent : MonoBehaviour
{
    public float slideDuration = 5f;
    private bool allowJump = false;
    
    private GameObject player;
    private PlayerBehaviour pb;
    private Rigidbody2D prb;

    public Transform slidepoint;
    public Transform landpoint;

    private Coroutine co;
    
    private void Start()
    {
        player = GameObject.Find("Player");
        pb = player.GetComponent<PlayerBehaviour>();
        prb = player.GetComponent<Rigidbody2D>();
    }

    public void StartEvent()
    {
        pb.enabled = false;
        co = StartCoroutine(Lerp(player.transform.position, slidepoint.transform.position, slideDuration));
    }

    public void AllowJump()
    {
        allowJump = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (allowJump))
        {
            allowJump = false;
            StopAllCoroutines();
            prb.isKinematic = true;
            StartCoroutine(LerpJump(player.transform.position, landpoint.transform.position, 1));
            player.GetComponent<Animator>().SetBool("Jump", true);
            
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
            player.transform.position = new Vector3(Mathf.Lerp(start.x, end.x, time / t), end.y + pb.jumpForce / 2 * Mathf.Sin(time / t * Mathf.PI), player.transform.position.z);
            time += Time.deltaTime;
            yield return null;
        }
        pb.enabled = true;
        prb.isKinematic = false;
    }
}
