using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePropCollider : MonoBehaviour
{
    private PolygonCollider2D collider;
    void Awake()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        collider.TryUpdateShapeToAttachedSprite();
    }
}
