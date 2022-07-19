using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundTrigger : MonoBehaviour
{
    public void OnButtonPress()
    {
        SoundManager.Instance.PlaySoundSolo("MenuSoundTest");
    }
}
