using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TargetScore : MonoBehaviour
{

    private Text happyLevel;
    private int score = 0;

    void Awake() {
        
        happyLevel = GameObject.Find("HappyLevel").GetComponent<Text> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D target) {
        SimpleAIMovement playerScript = target.gameObject.GetComponent<SimpleAIMovement>();
        Vector3 targetPosition = playerScript.targetPosition;
        Vector3 thisPosition = transform.position;
        if (targetPosition == thisPosition) {
            score++;
            Debug.Log(score.ToString());
            // happyLevel.text = (score + 1).ToString();
            // target.gameObject.SetActive(false);
            Destroy(target.gameObject);
        }
    }
}
