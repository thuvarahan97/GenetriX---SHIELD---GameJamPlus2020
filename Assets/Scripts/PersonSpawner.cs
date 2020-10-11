using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] person;

    void Awake() {
    }

    void Start() {
        StartCoroutine (SpawnPerson(0.5f));
    }

    IEnumerator SpawnPerson(float time) {
        yield return new WaitForSecondsRealtime (time);

        Vector3 temp = transform.position;
        temp.x = -17.5f;
        temp.y = 9.51f;
        temp.z = 0;

        Instantiate (person[Random.Range(0, person.Length)], temp, Quaternion.identity);
        
        StartCoroutine (SpawnPerson(Random.Range(1.0f, 5.0f)));
    }
}
