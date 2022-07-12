using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningInteractable : MonoBehaviour
{
    private static LightningInteractable _instance;
    public static LightningInteractable Instance { get { return _instance; } }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    public static void LightningStruck(GameObject gameObject)
    {
        Animator anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isStruck", true);
    }
}
