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
    [SerializeField] private AudioClip[] SoundEffectAmbi;
    [SerializeField] private AudioSource SoundSourceAmbi;
    private GameObject[] singletonCheck;
    private float MasVol = 0.5f;
    private float SFXVol = 0.5f;
    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
            Destroy(this); 
        else 
            Instance = this; 
        
        DontDestroyOnLoad (this);
        
        SoundSourceCont.volume = SFXVol;
        SoundSourceSolo.volume = SFXVol;
    }

    public void PlaySoundSolo(string SoundName) //Single SFX, might need to make more than one
    {
        for(int i = 0; i < SoundEffectSolo.Length; i++)
        {
            if(SoundEffectSolo[i].name == SoundName)
            {
                SoundSourceSolo.clip = SoundEffectSolo[i];
                SoundSourceSolo.Play();
            }
        }
    }

    public void PlaySoundCont(string ContSoundName) //Footsteps
    {
        for(int i = 0; i < SoundEffectCont.Length; i++)
        {
            if(SoundEffectCont[i].name == ContSoundName)
            {
                SoundSourceCont.clip = SoundEffectCont[i];
                SoundSourceCont.Play();
            }
        }
    }

    public void PlaySoundAmbi(string AmbiSoundName) //Ambient
    {
        for (int i = 0; i < SoundEffectCont.Length; i++)
        {
            if (SoundEffectCont[i].name == AmbiSoundName)
            {
                SoundSourceAmbi.clip = SoundEffectAmbi[i];
                SoundSourceAmbi.Play();
            }
        }
    }

    public void StopCont()
    {
        SoundSourceCont.Stop();
    }

    public void ChangeMVol(float inM)
    {
        MasVol = inM;
        AudioListener.volume = MasVol;
    }
    
    public void ChangeSVol(float inS)
    {
        SFXVol = inS;
        SoundSourceCont.volume = SFXVol;
        SoundSourceSolo.volume = SFXVol;
    }

    public void ListenerUpdate()
    {
        AudioListener.volume = MasVol;
    }
}
