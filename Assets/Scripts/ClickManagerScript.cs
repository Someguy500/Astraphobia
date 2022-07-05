using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManagerScript : MonoBehaviour
{
    private float mouseX, mouseY;

    void Update()
    {
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("X: " + mouseX + ", Y: " + mouseY);
        }
    }
}
