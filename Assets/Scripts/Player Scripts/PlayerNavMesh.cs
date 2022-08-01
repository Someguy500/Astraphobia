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

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float amplitudeX = 0.1f;
        float amplitudeY = 1f;
        float cosWave = Mathf.Sin(Time.time) * frequency * amplitudeX;
        float sinWave = Mathf.Cos(Time.time) * frequency * amplitudeY;


        navMeshAgent.transform.position = new Vector3(cosWave * movePositionTransform.position.x + offsetX + player.transform.position.x , sinWave * movePositionTransform.position.y + offsetY + player.transform.position.y, 0);


        
        
    }
}
