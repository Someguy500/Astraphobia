using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingTextTrigger : MonoBehaviour
{
    private BoxCollider2D trigger;

    private void Awake()
    {
        trigger = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        foreach (var ft in FadingTextScript.Instance.floatingTexts)
        {
            if (trigger.name == ft.trigger.name)
                FadingTextScript.Instance.txt.text = ft.text;
        }
        FadingTextScript.Instance.Appear();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        FadingTextScript.Instance.Fade();
    }
}
