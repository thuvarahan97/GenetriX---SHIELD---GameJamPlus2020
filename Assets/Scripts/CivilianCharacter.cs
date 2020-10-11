using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianCharacter : MonoBehaviour
{
    public int homeCoordinateX;
    public int homeCoordinateY;
    public int currentCoordinateX;
    public int currentCoordinateY;
	public float moveSpeed;
    public bool isIsolation;
    public bool isUnderTreatment;
    public float coronaEeffect;
    public float coronaEeffectedTime;

    public float treatmentSpeed;
    public float speradingSpeed = 0.5f;
    public float speradingParaK = -0.05f;
    public float speradingParaA = 30f; // 0.5 on this time

    public string state; // StaingHome, ReturingHome, Need

    public CivilianNeed currentNeed;
    
    public List<CivilianNeed> needsList = new List<CivilianNeed>();

    public List <GameObject> currentCollisionCivilian  = new List <GameObject> ();

    // Start is called before the first frame update
    void Start()
    {
        coronaEeffect = 0; // Random.value
        isUnderTreatment = false;
        isIsolation = false;
        state = "StaingHome";
        Invoke("generateNeedLvl0", Random.Range(15, 30));
        Invoke("generateNeedLvl12", Random.Range(10, 20));
        InvokeRepeating("coronaSocialSpreading", 2f, 2f);
    }

    // Update is called once per frame

    void Update()
    {
        if(isUnderTreatment){
            treatmentHealing();
        }else{
            coronaEffectSpreading();
        }

        foreach (var need in needsList)
        {
            //Debug.Log(need);
            Debug.Log(need.status + " 0 need.status ");
            currentNeed = need;
            currentNeed.setStatus("End");
            Debug.Log(need.status+ "  need.status");
            Debug.Log(currentNeed.status + "  currentNeed.status" );
        }
        setNeedstate();
    }

    void setNeedstate(){
        foreach (var need in needsList)
        {
            if (need.status == "End")
            {
                // Add overall Happy
                needsList.Remove (need);
            }
        }

        if(currentNeed == null || need.status == "CurfewWaiting" || need.status == "End"){
            if (needsList.Count>0)
            {
                currentNeed = (from n in needsList where n.status ==  "Waiting" select n).ToList().First();
            }
            else{
                currentNeed = null;
            }
        }

    }

    void treatmentHealing(){
        if (coronaEeffect > 0){
            coronaEeffect -= treatmentSpeed*Time.deltaTime;
        }
        else
        {
            coronaEeffect = 0;
            coronaEeffectedTime = 0;
            isUnderTreatment = false;0
            isIsolation = false;
        }
    }

    void generateNeedLvl0()
    {
      CivilianNeed need = new CivilianNeed(0);
      needsList.Add(need);
      Invoke("generateNeedLvl0", Random.Range(15, 30));
    }

    // void fulfillNeed(){
    //     if(currentNeed != null || currentNeed.state == "CurfewWaiting"){
    //         foreach (var need in needsList)
    //         {
    //             if(need != null || need.state == "CurfewWaiting"){
    //                 currentNeed = need;
    //             }
    //         }
    //     }
    // }

    void generateNeedLvl12()
    {
      CivilianNeed need = new CivilianNeed(Random.Range(1, 3));
      needsList.Add(need);
      Invoke("generateNeedLvl12", Random.Range(10, 20));
    }

    void EffectCorona(float eff){ // Called by Another CivilianCharacter
        if(coronaEeffect==0){
            coronaEeffect = eff;
            coronaEeffectedTime = (Mathf.Log((1/eff) -1,Mathf.Exp(1))/speradingParaK) + speradingParaA;
        }
    }
    void coronaEffectSpreading(){
        if (coronaEeffect > 0){
            coronaEeffectedTime += speradingSpeed*Time.deltaTime;
            coronaEeffect = 1/(1+Mathf.Exp(speradingParaK* ( coronaEeffectedTime-speradingParaA)));
        }
    }

    void coronaSocialSpreading(){
        if (coronaEeffect > 0 && !isIsolation)
        {
            float chance = coronaEeffect * 0.4f; //0.2
            foreach (GameObject civilianGObject in currentCollisionCivilian) {
                if (chance > Random.value )
                {
                    print (civilianGObject.name);
                    civilianGObject.GetComponent<CivilianCharacter>().EffectCorona(chance/10f);
                }
            }
        }
    }

    
     void OnTriggerEnter(Collider col) {
         Debug.Log ("civilianGObject");
         currentCollisionCivilian.Add (col.gameObject);
     }
 
     void OnCollisionExit (Collision col) {
          currentCollisionCivilian.Remove (col.gameObject);
     }


}
