using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    [SerializeField] private GameObject player;
    private NavMeshAgent navMeshAgent;
    private float offsetX = 1.5f, offsetY = 1f, frequency = 0.1f;
    private float objectSize = 0.275535f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
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
