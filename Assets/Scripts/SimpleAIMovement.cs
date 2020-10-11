using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAIMovement : MonoBehaviour
{
    // [SerializeField] Transform entry;
    // [SerializeField] Transform target;
    NavMeshAgent agent;
    
    public List<Transform> entryLocations;
    public List<Transform> targetLocations;

    private int entryIndex;
    private int targetIndex;
    
    Vector3 entryPosition;
    Vector3 targetPosition;
    
    void Awake()
    {
        entryIndex = Random.Range(0, entryLocations.Count);
        targetIndex = Random.Range(0, targetLocations.Count);

        entryPosition = entryLocations[entryIndex].transform.position;
        transform.position = entryPosition;

        targetPosition = targetLocations[targetIndex].position;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.SetDestination(targetLocations[targetIndex].position);

        if (transform.position == targetPosition) {
            Debug.Log("dfdff");
            //dfdddd
            Destroy(this.gameObject);
        }
    }
}
