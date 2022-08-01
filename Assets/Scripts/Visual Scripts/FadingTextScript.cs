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
    Mesh mesh;
    Vector3[] vertices;
    List<int> wordIndexes;
    List<int> wordLengths;

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

    Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time * 0.2f), Mathf.Cos(time * 0.2f));
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


        if (Player.transform.position.x >= -13 && Player.transform.position.x <= -7)
        {
            txt.text = texts[0];
            Appear();
            if (Input.GetMouseButton(0) && txt.text == texts[0])
            {
                txt.text = texts[1];
            }
        }
        else if (Player.transform.position.x < -13 && Player.transform.position.x > 7)
        {
            Fade();
        }
        else if (Player.transform.position.x >= -4 && Player.transform.position.x <= 3)
        {
            txt.text = texts[2];
            Appear();
        }
        else if (Player.transform.position.x < -4)
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
