using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    [SerializeField] private GameObject player;
    private NavMeshAgent navMeshAgent;
    private float offsetX = 1.5f, offsetY = 1.9f, frequency = 0.1f;
    private float objectSize = 0.275535f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void spiritPos()
    {
        if(StressManager.stressLvl > 5 && StressManager.stressLvl < 10)
        {
            offsetX = Mathf.Clamp(offsetX-0.001f, 1.3f, 1.5f);
            offsetY = Mathf.Clamp(offsetY-0.001f, 1.4f, 1.9f);
        }
        else if (StressManager.stressLvl >= 10 && StressManager.stressLvl < 16)
        {
            offsetX = Mathf.Clamp(offsetX - 0.001f, 1.2f, 1.5f);
            offsetY = Mathf.Clamp(offsetY - 0.001f, 0.9f, 1.9f);
        }
    }

    private void Update()
    {
        spiritPos();

        float amplitudeX = 0.1f;
        float amplitudeY = 0.9f; //ori 1f
        float cosWave = Mathf.Cos(Time.time) * frequency * amplitudeX;
        float sinWave = Mathf.Sin(Time.time) * frequency * amplitudeY;

/*        float speed = 1f;
        float depth = 2f;*/

        int randNum = Random.Range(1, 6);

        if (randNum == 2)
        {
            for (float i = 0; i < 3; i++) { transform.localScale = new Vector3(Mathf.Clamp(objectSize * (Mathf.Sin(Time.time * -0.5f) + i), 0.275535f, 0.3050219f), Mathf.Clamp(objectSize * (Mathf.Sin(Time.time * -0.5f) + i), 0.2755535f, 0.3050219f)); }
        }

        /*            float scaleInOut = (Mathf.Sin(Time.time * speed);
                    transform.localScale = new Vector2(scaleInOut, scaleInOut) * depth;
                    Debug.Log(scaleInOut);*/ //scales spirit



        navMeshAgent.transform.position = new Vector3(cosWave * movePositionTransform.position.x + offsetX + player.transform.position.x , sinWave * movePositionTransform.position.y + offsetY + player.transform.position.y, 0);


        
        
    }
}
