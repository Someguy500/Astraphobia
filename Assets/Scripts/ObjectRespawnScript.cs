using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawnScript : MonoBehaviour
{
    float fixedPosY = -7.06f;
    private bool isOut = false;
    private Vector2 objOrigin;

    void Start()
    {
        objOrigin = transform.position;
    }

    public void OutofBounds()
    {
        Respawn();
        isOut = false;
    }


    public void Respawn()
    {
        gameObject.transform.position = objOrigin;
    }

    void Update()
    {
        if (gameObject.transform.position.y <= fixedPosY)
        {
            isOut = true;
            OutofBounds();
        }
    }
}
