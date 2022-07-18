using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = System.Object;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] SoundEffectSolo;
    [SerializeField] private AudioSource SoundSourceSolo;
    [SerializeField] private AudioClip[] SoundEffectCont;
    [SerializeField] private AudioSource SoundSourceCont;
    private GameObject[] singletonCheck;

    private void Awake()
    {
        singletonCheck = GameObject.FindGameObjectsWithTag("SoundManager");
        if (singletonCheck.Length > 1)
        {
            Destroy(this.GameObject());
        }
        else
        {
            DontDestroyOnLoad(this.GameObject());
        }
    }

    public void PlaySoundSolo(string SoundName)
    {
        for(int i = 0; i < SoundEffectSolo.Length; i++)
        {
            if(SoundEffectSolo[i].name == SoundName)
            {
                SoundSourceSolo.clip = SoundEffectSolo[i];
            }
        }
    }
}
