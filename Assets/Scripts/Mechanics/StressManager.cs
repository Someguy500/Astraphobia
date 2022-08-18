using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StressManager : MonoBehaviour
{
    public static int stressLvl;
    public static int saveSanity = 0; // saves stressLvl
    public int lightningCost;
    private bool isDead; 
    private bool stop;

    void Start()
    {
        stop = false;
        isDead = false;
        stressLvl = saveSanity;
        
    }

    void Awake()//just to start off with heartbeat1
    {
        SoundManager.Instance.PlaySoundCont("heartbeat");
        Time.timeScale = 1;
    }
    public void stressBuild()
    {
        if (stressLvl >= 0 && stressLvl < 16 && isDead == false)
        {
            stressLvl += lightningCost; //scalable stressLvl decrement
            //Debug.Log(stressLvl);
            HeartbeatSpeedCheck();
        }
        else 
        {
            stop = true;
            isDead = true;
            Death();
            
        }
    }

    public static void ResetStress()
    {
        stressLvl = saveSanity;
        HeartbeatSpeedCheck();
    }
    
    public void Death()
    {
        if (isDead)
        {
            Time.timeScale = 0; //freezes 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            /*Time.timeScale = 1; //unfreeze*/

        }
    }

    IEnumerator stressDecreaseTime() //scales decrease time of stress level
    {
        stressBuild();
        yield return new WaitForSeconds(0.5f);
        //Debug.Log(stressLvl);
    }

    public void LightningStrike()
    {
        if (!stop)
            StartCoroutine(stressDecreaseTime());
    }

    // Update is called once per frame
    void Update()
    {
        if(stressLvl < 0)
        {
            stressLvl = 0;
        }

        Debug.Log(stressLvl);
    }

    static void HeartbeatSpeedCheck()
    {
        if (stressLvl > 5)
        {
            if (stressLvl > 10)
            {
                SoundManager.Instance.PlaySoundCont("heartbeat3");
            }
            else
            {
                SoundManager.Instance.PlaySoundCont("heartbeat2");
            }
        }
        else
        {
            SoundManager.Instance.PlaySoundCont("heartbeat");
        }
    }

}