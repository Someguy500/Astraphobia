using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillSlideTriggers : MonoBehaviour
{
    private HillSlideEvent hse;

    private void Start()
    {
        hse = GetComponentInParent<HillSlideEvent>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObject.GetComponent<Collider2D>() == hse.startTrigger)
            hse.StartEvent();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.GetComponent<Collider2D>() == hse.jumpTrigger)
            hse.AllowJump();
    }
}
