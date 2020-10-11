using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAIMovement : MonoBehaviour
{
    // [SerializeField] Transform entry;
    // [SerializeField] Transform target;
    NavMeshAgent agent;
    
    List<Transform> entryLocations = new List<Transform>();
    List<Transform> targetLocations = new List<Transform>();

    private int entryIndex;
    private int targetIndex;
    
    Vector3 entryPosition;
    public Vector3 targetPosition;

    // private Text happyLevel;
    // private int score = 0;
    
    void Awake()
    {
        entryLocations.Add(GameObject.Find("Pos_Start1").transform);
        entryLocations.Add(GameObject.Find("Pos_Start2").transform);
        entryLocations.Add(GameObject.Find("Pos_Start3").transform);
        entryLocations.Add(GameObject.Find("Pos_Start4").transform);
        entryLocations.Add(GameObject.Find("Pos_Start5").transform);
        entryLocations.Add(GameObject.Find("Pos_Start6").transform);
        entryLocations.Add(GameObject.Find("Pos_Start7").transform);
        entryLocations.Add(GameObject.Find("Pos_Start8").transform);
        entryLocations.Add(GameObject.Find("Pos_Start9").transform);
        entryLocations.Add(GameObject.Find("Pos_Start10").transform);
        entryLocations.Add(GameObject.Find("Pos_Start11").transform);
        entryLocations.Add(GameObject.Find("Pos_Start12").transform);

        targetLocations.Add(GameObject.Find("Pos_Bank").transform);
        targetLocations.Add(GameObject.Find("Pos_Restaurant1").transform);
        targetLocations.Add(GameObject.Find("Pos_Restaurant2").transform);
        targetLocations.Add(GameObject.Find("Pos_MedicalCentre").transform);
        targetLocations.Add(GameObject.Find("Pos_Mart1").transform);
        targetLocations.Add(GameObject.Find("Pos_Mart2").transform);
        targetLocations.Add(GameObject.Find("Pos_Mall").transform);
        targetLocations.Add(GameObject.Find("Pos_Hospital").transform);
        targetLocations.Add(GameObject.Find("Pos_QuarantineCentre").transform);


        entryIndex = Random.Range(0, entryLocations.Count);
        targetIndex = Random.Range(0, targetLocations.Count);

        entryPosition = entryLocations[entryIndex].transform.position;
        transform.position = entryPosition;

        targetPosition = targetLocations[targetIndex].position;

        
        // happyLevel = GameObject.Find("HappyLevel").GetComponent<Text> ();
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

        // if (transform.position == targetPosition) {
        //     Debug.Log("dfdff");
        //     //dfdddd
        //     Destroy(this.gameObject);
        // }

        // if (Vector3.Distance(targetPosition, this.transform.position) < 0.5) {
        //     score = int.Parse(happyLevel.text);
        //     happyLevel.text = (score + 1).ToString();
        //     // gameObject.SetActive(false);
        // }
    }
}
