using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressRestoreScript : MonoBehaviour
{
    bool restore = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && restore == false)
        {
            restore = true;
            StressManager.stressLvl -= 8;
            StressManager.saveSanity = StressManager.stressLvl;
            SpiritStressLink.additiveStress = true;
            Debug.Log("Restore stress");
        }
    }
}
