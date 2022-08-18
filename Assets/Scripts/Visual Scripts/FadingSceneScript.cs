using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadingSceneScript : MonoBehaviour
{
    public Animator animator;
    private int sceneToLoad;

    void Update()
    {  
/*        if (Input.GetMouseButtonDown(1)) // if player reaches the end
        {
            FadeToScene(2);
        }*/

    }

    public void FadeToScene(int sceneIndex)
    {
        sceneToLoad = sceneIndex; 
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
