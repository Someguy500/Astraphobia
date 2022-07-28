using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadingTextScript : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] private CanvasGroup UIGrp;
    [SerializeField] public static bool fadeIn = false;
    [SerializeField] public static bool fadeOut = false;
    [SerializeField] private string[] texts = new string[5];
    [SerializeField] private TextMeshProUGUI txt;

    void Start()
    {
        fadeIn = false;
        fadeOut = false;
        UIGrp.alpha = 0;
    }


    public static void Appear()
    {
        fadeIn = true;
    }

    public static void Fade()
    {
        fadeOut = true;
    }

    void Update()
    {

        if (Player.transform.position.x >= -13 && Player.transform.position.x <= -7)
        {
            Appear();
            txt.text = texts[0];
        }
        else if (Player.transform.position.x < -13)
        {
            Fade();
        }
        else
        {
            Fade();
        }


        if (fadeIn)
        {
            if(UIGrp.alpha < 1)
            {
                UIGrp.alpha += Time.deltaTime;
                if(UIGrp.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (UIGrp.alpha >= 0)
            {
                UIGrp.alpha -= Time.deltaTime;
                if (UIGrp.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
}
