using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public static PlayerAnimationManager Instance;
    private Animator anim;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        anim = gameObject.GetComponent<Animator>();
    }

    public void ChangeAnim(string animName)
    {
        ResetAllParams();
        anim.SetBool(animName, true);
    }

    public void ResetAllParams()
    {
        foreach (var parameter in anim.parameters)
            anim.SetBool(parameter.name, false);
    }
}
