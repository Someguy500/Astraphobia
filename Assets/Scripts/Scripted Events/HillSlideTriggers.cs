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
        if (other.CompareTag("Player") && gameObject.name == "Start Trigger")
            hse.StartEvent();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObject.name == "Jump Trigger")
            hse.AllowJump();
    }
}
