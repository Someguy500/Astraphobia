using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxScript : MonoBehaviour
{
private float length, startpos;

[SerializeField] private float scaleMult;

public GameObject cam;

public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y);

        if (cam.transform.position.x > startpos + 3*length)
        {
            startpos += 3*length;
            
        }
        else if (cam.transform.position.x < startpos - 3*length)
        {
            startpos -= 3*length;
        }
    }
}
