using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadingTextScript : MonoBehaviour
{
    [System.Serializable]
    public class FloatingText
    {
        public BoxCollider2D trigger;
        public string text;
    }

    public List<FloatingText> floatingTexts;

    //[SerializeField] GameObject Player;
    [SerializeField] private CanvasGroup UIGrp;
    //[SerializeField] private string[] texts = new string[5];
    public TextMeshProUGUI txt;
    Mesh mesh;
    Vector3[] vertices;
    List<int> wordIndexes;
    List<int> wordLengths;
    float wobbleVal = 0.1f;
    private static bool fadeIn, fadeOut;
    
    public static FadingTextScript Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        fadeIn = false;
        fadeOut = false;
        UIGrp.alpha = 0;
    }
    
    public void Appear()
    {
        fadeIn = true;
        fadeOut = false;
    }

    public void Fade()
    {
        fadeIn = false;
        fadeOut = true;
    }

    Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time * wobbleVal), Mathf.Cos(time * wobbleVal));
    }
    
    void Update()
    {
        txt.ForceMeshUpdate();
        mesh = txt.mesh;
        vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++) //text wobble effect
        {
            Vector3 offset = Wobble(Time.time + i);
            vertices[i] = vertices[i] + offset;
        }

        mesh.vertices = vertices;
        txt.canvasRenderer.SetMesh(mesh);

        // if(Player.transform.position.x < -13)
        // {
        //     Fade();
        // }
        // else if (Player.transform.position.x >= -13 && Player.transform.position.x <= -7)
        // {
        //     txt.text = texts[0];
        //     Appear();
        //     if (Input.GetMouseButton(0) && txt.text == texts[0])
        //     {
        //         txt.text = texts[1];
        //     }
        // }
        // else if (Player.transform.position.x >= -7 && Player.transform.position.x <= -4)
        // {     
        //     Fade();
        // }
        // else if (Player.transform.position.x >= -4 && Player.transform.position.x <= 3)
        // {
        //     txt.text = texts[2];
        //     Appear();
        // }
        // else if(Player.transform.position.x > 3 && Player.transform.position.x < 18)
        // {
        //     Fade();
        // }
        // else if (Player.transform.position.x >= 18 && Player.transform.position.x <= 22)
        // {
        //     txt.text = texts[3];
        //     Appear();
        // }
        // else if (Player.transform.position.x > 22 && Player.transform.position.x < 27) //half done
        // {
        //     Fade();
        // }
        // else if (Player.transform.position.x >= 27 && Player.transform.position.x <= 32)
        // {
        //     txt.text = texts[4];
        //     Appear();
        // }
        // else if (Player.transform.position.x > 32) //half done
        // {
        //     Fade();
        // }
        // else if (Player.transform.position.x < -3.3)
        // {
        //     UIGrp.alpha = 0;
        // }
        // else
        // {
        //     Fade();
        // }

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
                if (UIGrp.alpha <= 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
}
