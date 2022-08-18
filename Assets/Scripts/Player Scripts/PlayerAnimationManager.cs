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

    public void ChangeAnimTrigger(string animName)
    {
        ResetAllParams(animName);
        anim.SetTrigger(animName);
    }

    public void ChangeAnimBool(string animName)
    {
        anim.SetBool(animName, true);
        StartCoroutine(DisableBool(animName));
    }

    IEnumerator DisableBool(string animName)
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool(animName,false);  
    }
    

    public void ResetAllParams(string animName)
    {
        foreach (var parameter in anim.parameters)
            if (parameter.type == AnimatorControllerParameterType.Trigger && parameter.name != animName)
                anim.ResetTrigger(parameter.name);
    }
}
