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

    public Collider2D startTrigger;
    public Collider2D jumpTrigger;
    
    private void Start()
    {
        player = GameObject.Find("Player");
        pb = player.GetComponent<PlayerBehaviour>();
    }

    public void StartEvent()
    {
        pb.enabled = false;
        StartCoroutine(Slide(player.transform.position, jumpTrigger.transform.position));
    }

    public void AllowJump()
    {
        allowJump = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (allowJump))
        {
            StopAllCoroutines();
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * player.GetComponent<PlayerBehaviour>().jumpForce, ForceMode2D.Impulse);
            player.GetComponent<Animator>().SetBool("Jump", true);
            allowJump = false;
            pb.enabled = true;
        }
    }

    IEnumerator Slide(Vector3 start, Vector3 end)
    {
        float time = 0;
        while (time < slideDuration)
        {
            player.transform.position = Vector3.Lerp(start, end, time / slideDuration);
            time += Time.deltaTime;
            yield return null;
        }
        player.transform.position = end;
    }
}
