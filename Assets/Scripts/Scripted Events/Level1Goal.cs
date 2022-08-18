using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Goal : MonoBehaviour
{
    public static bool sceneNew = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sceneNew = true;
            SoundManager.Instance.StopCont();
        }
    }

}
