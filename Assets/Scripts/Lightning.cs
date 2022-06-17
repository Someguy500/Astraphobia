using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//How to Generate Shockingly Good 2D Lightning Effects in Unity (C#) by Aaron Davis
//URL : https://gamedevelopment.tutsplus.com/tutorials/how-to-generate-shockingly-good-2d-lightning-effects-in-unity-c--cms-21275

public class Lightning : MonoBehaviour
{
    public Vector2 start;
    public Vector2 end;
    public float thickness;

    public GameObject startCap, endCap, lineSegment;

    public void SetLine(Vector2 start, Vector2 end, float thickness)
    {
        this.start = start;
        this.end = end;
        this.thickness = thickness;
    }

    public void SetColor(Color c)
    {
        
    }

    public void Draw()
    {
        //Calculating Vector values
        Vector2 distance = end - start;
        float deltaRad = Mathf.Atan2(distance.y, distance.x);
        float deltaDeg = deltaRad * Mathf.Rad2Deg;

        //Scale line to reflect length and thickness
        lineSegment.transform.localScale = new Vector3(100 * (distance.magnitude / lineSegment.GetComponent<SpriteRenderer>().sprite.rect.width), thickness, lineSegment.transform.localScale.z);
        startCap.transform.localScale = new Vector3(startCap.transform.localScale.x, thickness, startCap.transform.localScale.z);
        endCap.transform.localScale = new Vector3(endCap.transform.localScale.x, thickness, endCap.transform.localScale.z);
        
        //Rotate line to face right direction
        lineSegment.transform.rotation = Quaternion.Euler(new Vector3(0, 0, deltaDeg));
        startCap.transform.rotation = Quaternion.Euler(new Vector3(0,0, deltaDeg));
        endCap.transform.rotation = Quaternion.Euler(new Vector3(0,0,deltaDeg + 180));
        
        //Center line at start point
        lineSegment.transform.position = new Vector3(start.x, start.y, lineSegment.transform.position.z);
        startCap.transform.position = new Vector3(start.x, start.y, startCap.transform.position.z);
        endCap.transform.position = new Vector3(start.x, start.y, endCap.transform.position.z);
        
        //Adjusting positions
        float lineLength = lineSegment.transform.localScale.x * lineSegment.GetComponent<SpriteRenderer>().sprite.rect.width / 2f;
        float startLength = startCap.transform.localScale.x * startCap.GetComponent<SpriteRenderer>().sprite.rect.width / 2f;
        float endLength = endCap.transform.localScale.x * endCap.GetComponent<SpriteRenderer>().sprite.rect.width / 2f;

        lineSegment.transform.position += new Vector3(.01f * Mathf.Cos(deltaRad) * lineLength, .01f * Mathf.Sin(deltaRad) * lineLength, 0);
        startCap.transform.position -= new Vector3(.01f * Mathf.Cos(deltaRad) * startLength, .01f * Mathf.Sin(deltaRad) * startLength, 0);
        endCap.transform.position += new Vector3(.01f * Mathf.Cos(deltaRad) * lineLength * 2, .01f * Mathf.Sin(deltaRad) * lineLength * 2, 0); 
        endCap.transform.position += new Vector3(.01f * Mathf.Cos(deltaRad) * endLength, .01f * Mathf.Sin(deltaRad) * endLength, 0);
    }
}
