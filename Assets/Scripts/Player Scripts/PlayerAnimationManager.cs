using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public static PlayerAnimationManager Instance;
    private Animator anim;
    private enum AnimationState
    {
        Idle, Walk, Jump, Slide, Push, Pull
    }
    
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
        ResetAllParams(animName);
        anim.SetBool(animName, true);
    }

    public void ResetAllParams(string animName)
    {
        foreach (var parameter in anim.parameters)
            if (parameter.type == AnimatorControllerParameterType.Trigger && parameter.name != animName)
                anim.ResetTrigger(parameter.name);
    }
}
