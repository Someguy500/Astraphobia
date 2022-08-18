using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressRestoreScript : MonoBehaviour
{
    private bool restore = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && restore == false)
        {
            StressManager.stressLvl -= 8;
            StressManager.saveSanity = StressManager.stressLvl;
            restore = true;           
        }
    }
}
