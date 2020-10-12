using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TargetScore : MonoBehaviour
{

    private Text happyLevel;
    private Text coronaLevel;
    private int score = 0;
    private int bad = 0;
    private Text successText;
    private Text gameOverText;

    private GameObject successTextObj;
    private GameObject gameOverTextObj;

    void Awake() {
        happyLevel = GameObject.Find("HappyLevel1").GetComponent<Text>();
        coronaLevel = GameObject.Find("CoronaLevel1").GetComponent<Text>();

        successTextObj = GameObject.Find("CompletedText");
        gameOverTextObj = GameObject.Find("GameOverText");
        successText = GameObject.Find("CompletedText").GetComponent<Text> ();
        gameOverText = GameObject.Find("GameOverText").GetComponent<Text> ();

    }
    // Start is called before the first frame update
    void Start()
    {
                successTextObj.SetActive(false);
                gameOverTextObj.SetActive(false);
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
            if (target.tag == "Good") {
                score = int.Parse(happyLevel.text);
                score++;
                happyLevel.text = score.ToString();
            }
            
            if (target.tag == "Corona") {
                bad = int.Parse(coronaLevel.text);
                bad++;
                coronaLevel.text = bad.ToString();
            }
            // target.gameObject.SetActive(false);
            Destroy(target.gameObject);

            if (score >= 10) {
                happyLevel.text = "10";
                successTextObj.SetActive(true);
                gameOverTextObj.SetActive(true);
                successText.text = "Level Complete !";

                StartCoroutine (RestartGame());
            }

            if (bad >= 10) {
                coronaLevel.text = "10";
                gameOverText.text = "Game Over !";
                StartCoroutine (RestartGame());
            }
        }

    }

    IEnumerator RestartGame() {
        yield return new WaitForSecondsRealtime (2f);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
