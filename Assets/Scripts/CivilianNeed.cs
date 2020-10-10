using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianNeed : MonoBehaviour {
    // Start is called before the first frame update
    public string type;
    public float spentTime;
    public string status; // CurfewWaiting, Waiting, Going, Process, end
    public float happyValue; //Also Negative allowed

    public float minHappyValue;
    public string popMessage;

    public static string[][] needTypes = new string[][] { new string[] { "Food", "Med" }, new string[] { "Event", "Study" }, new string[] { "Cinima", "Sports", "Visting" } };
    public int levelValue, rValue, mValue;
    public static string[][][] needMessages = new string[][][] {
        new string[][] { new string[] { "I need to Buy Groceries" }, new string[] { "I need to Buy Meds" }
        },
        new string[][] {  new string[] { "I want to attend a Wedding", "I want to attend a Feunral" },
        new string[] { "I want Study with my friend", "I am going Tution" }
        },
        new string[][] { new string[] { "I whna watch Cinima" },
        new string[] { "I am Going to Play Foodball", "I am Going to Play Foodball" },
        new string[] { "I want Vist Maria" }
        }
    };
    
    public CivilianNeed (int level) {
        levelValue = level;
        rValue = Random.Range (0, needMessages[level].Length);
        type = needTypes[level][rValue];
        mValue = Random.Range (0, needMessages[level][rValue].Length);
        popMessage = needMessages[level][rValue][mValue];
        status = "Waiting";

        if (level == 0) {
            happyValue = Random.Range (60, 100);
            minHappyValue = -1 * Random.Range (60, 100);
            spentTime = Random.Range (5, 10);
        }
        if (level == 1) {
            happyValue = Random.Range (40, 70);
            minHappyValue = -1 * Random.Range (40, 70);
            spentTime = Random.Range (10, 20);
        }
        if (level == 2) {
            happyValue = Random.Range (10, 40);
            minHappyValue = -1 * Random.Range (10, 40);
            spentTime = Random.Range (10, 25);
        }
    }

    void Start () {

    }

    // Update is called once per frame
    void Update () {
        decreasesSpentTime ();
    }

    void decreasesHappiness () {
        
    }

    void decreasesSpentTime () {
        if (status == "Process") {
            if (spentTime > 0) {
                spentTime -= Time.deltaTime;
            }
            else {
                spentTime = 0;
                status = "End";
            }
        }
    }

}