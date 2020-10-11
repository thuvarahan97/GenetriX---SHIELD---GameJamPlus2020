using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianNeed : MonoBehaviour {
    // Start is called before the first frame update
    public string type;
    public float spentTime;
    public string status; // CurfewWaiting, Waiting, Going, Process, end
    public float happyValue; //Also Negative allowed
    public float happyDecGradient;

    public float minHappyValue, maxHappyValue;
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
    
    public void setStatus(string v){
        status = v;
    }
    public CivilianNeed (int level) {
        levelValue = level;
        rValue = Random.Range (0, needMessages[level].Length);
        type = needTypes[level][rValue];
        mValue = Random.Range (0, needMessages[level][rValue].Length);
        popMessage = needMessages[level][rValue][mValue];
        status = "Waiting";
        happyDecGradient = -50;

        if (level == 0) {
            happyValue = Random.Range (60, 100);
            minHappyValue = -1* Random.Range (60, 100);
            spentTime = Random.Range (5, 10);
        }
        if (level == 1) {
            happyValue = Random.Range (40, 70);
            minHappyValue = -1*   Random.Range (40, 70);
            spentTime = Random.Range (10, 20);
        }
        if (level == 2) {
            happyValue = Random.Range (10, 40);
            minHappyValue = -1*  Random.Range (10, 40);
            spentTime = Random.Range (10, 25);
        }
        maxHappyValue = happyValue;
    }
    

    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        decreasesSpentTime ();
        decreasesHappiness ();
        if( status == "End" ) { Destroy(this); }
    }

    void decreasesHappiness () {
        if (status == "CurfewWaiting") {
            happyDecGradient +=  1.2f*Time.deltaTime;

            happyValue = (1f/(1f+Mathf.Exp(0.1f*happyDecGradient)) - 0.5f)*(maxHappyValue-minHappyValue)+(maxHappyValue+minHappyValue)/2f;
            // happyValue -= (rangeHappyValue/150) /(1+Mathf.Exp(-0.1f*happyDecGradient))*(1-(1 /(1+Mathf.Exp(-0.1f*happyDecGradient))));
        }
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