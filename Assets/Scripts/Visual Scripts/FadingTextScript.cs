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

    [SerializeField] private CanvasGroup UIGrp;
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
