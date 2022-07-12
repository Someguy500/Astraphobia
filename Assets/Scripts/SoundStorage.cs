using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class SoundStorage : MonoBehaviour
{
    private static SoundStorage _i;

    public static SoundStorage i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<SoundStorage>("Scripts/SoundStoreObject"));
            return _i;
        }
    }

    public AudioClip TestSound;
}
