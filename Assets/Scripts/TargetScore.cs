using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TargetScore : MonoBehaviour
{

    private Text happyLevel;
    private int score = 0;
    private Text successText;

    void Awake() {
        happyLevel = GameObject.Find("HappyLevel1").GetComponent<Text>();

        successText = GameObject.Find("CompletedText").GetComponent<Text> ();
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
            score = int.Parse(happyLevel.text);
            score++;
            happyLevel.text = score.ToString();
            // target.gameObject.SetActive(false);
            Destroy(target.gameObject);

            if (score >= 20) {
                happyLevel.text = "20";
                successText.text = "Level Complete !";
            }
        }

    }

    IEnumerator RestartGame() {
        yield return new WaitForSecondsRealtime (2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
