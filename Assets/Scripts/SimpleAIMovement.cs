using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAIMovement : MonoBehaviour
{
    [SerializeField] Transform entry;
    [SerializeField] Transform target;
    NavMeshAgent agent;
    
    
    void Awake()
    {
        Vector3 entryPosition = entry.transform.position;
        transform.position = entryPosition;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}
