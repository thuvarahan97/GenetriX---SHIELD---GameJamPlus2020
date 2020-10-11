using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RectangleShape : MonoBehaviour
{
    public GameObject NavMesh;

    // Start is called before the first frame update
    void Start()
    {
        NavMesh = GameObject.Find("NavMesh");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(1)) {
            Destroy(this.gameObject.GetComponent<NavMeshModifier>());
            NavMesh.GetComponent<NavMeshSurface2d>().BuildNavMesh();
            Destroy(this.gameObject);
            
        }
    }
}
