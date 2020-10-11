using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] person;
    
    private BoxCollider2D col;

    float x1, x2;

    void Awake() {
        // col = GetComponent<BoxCollider2D> ();

        // x1 = transform.position.x - col.bounds.size.x / 2f;
        // x2 = transform.position.x + col.bounds.size.x / 2f;
    }

    void Start() {
        StartCoroutine (SpawnPerson(0.5f));
    }

    IEnumerator SpawnPerson(float time) {
        yield return new WaitForSecondsRealtime (time);

        Vector3 temp = transform.position;
        temp.x = -17.5f;
        temp.y = 9.51f;
        temp.y = 0;

        Instantiate (person[Random.Range(0, person.Length)], temp, Quaternion.identity);
        
        StartCoroutine (SpawnPerson(Random.Range(0.00001f, 1.5f)));
    }
}
