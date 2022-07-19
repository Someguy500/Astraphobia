using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVolRemind : MonoBehaviour
{
    void Awake()
    {
        SoundManager.Instance.ListenerUpdate();
        Destroy(gameObject);
    }
}
