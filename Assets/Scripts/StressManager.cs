using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StressManager : MonoBehaviour
{
    public static float stressLvl;
    private bool isDead; 
    private bool stop;

    // Start is called before the first frame update
    void Start()
    {
        stop = false;
        isDead = false;
        stressLvl = 0;
    }
    public void stressBuild()
    {
        if (stressLvl >= 0 && stressLvl <= 100 && isDead == false)
        {
            stressLvl += 1f; //scalable stressLvl decrement
            Debug.Log(stressLvl);
        }
        else 
        {
            stop = true;
            isDead = true;
            Death();
        }

    }

    public void Death()
    {
        if (isDead == true)
        {
/*            Time.timeScale = 0; //freezes 
            SceneManager.LoadScene("MainMenuSample");
            Time.timeScale = 1; //unfreeze*/
            Debug.Log("Dead");

            gameObject.transform.position = PlayerFall.origin;

        }
    }

    IEnumerator stressDecreaseTime() //scales decrease time of stress level
    {
        stressBuild();
        yield return new WaitForSeconds(0.5f);
        Debug.Log(stressLvl);
    }

    public void LightningStrike()
    {
        if (!stop)
            StartCoroutine(stressDecreaseTime());
    }

    // Update is called once per frame
    void Update()
    {
    }
}