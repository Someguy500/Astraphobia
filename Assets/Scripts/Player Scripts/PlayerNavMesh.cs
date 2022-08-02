using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    [SerializeField] private GameObject player;
    private NavMeshAgent navMeshAgent;
    private float offsetX = 1f, offsetY = 1f, frequency = 0.1f;
    private float objectSize = 0.2937263f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float amplitudeX = 0.1f;
        float amplitudeY = 1f;
        float cosWave = Mathf.Cos(Time.time) * frequency * amplitudeX;
        float sinWave = Mathf.Sin(Time.time) * frequency * amplitudeY;

        int randNum = Random.Range( 1, 5);

        if (randNum == 2)
        {
            for (int i = 0; i < 3; i++) { transform.localScale = new Vector3(Mathf.Clamp(objectSize * (Mathf.Sin(Time.time) + i), 0.2755535f, 0.3378734f), Mathf.Clamp(objectSize * (Mathf.Sin(Time.time) + i), 0.2755535f, 0.3378734f)); }
        }

        navMeshAgent.transform.position = new Vector3(cosWave * movePositionTransform.position.x + offsetX + player.transform.position.x , sinWave * movePositionTransform.position.y + offsetY + player.transform.position.y, 0);


        
        
    }
}
