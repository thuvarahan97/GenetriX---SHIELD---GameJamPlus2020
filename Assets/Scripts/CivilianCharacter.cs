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
    
    public List<CivilianNeed> Needs = new List<CivilianNeed>();

    // Start is called before the first frame update
    void Start()
    {
        coronaEeffect = 0; // Random.value
        isUnderTreatment = false;
        isIsolation = false;

        Invoke("generateNeed", Random.Range(10, 20));
    }

    // Update is called once per frame

    void Update()
    {
        if(isUnderTreatment){
            treatmentHealing();
        }else{
            coronaEffectSpreading();
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
            isUnderTreatment = false;
            isIsolation = false;
        }
    }

    void generateNeed()
    {
      float randomTime = Random.Range(10, 20);
      CivilianNeed need = new CivilianNeed();
      
      Invoke("generateNeed", randTime);
    }



    void EffectCorona(float eff){ // Called by Another CivilianCharacter
        coronaEeffect = eff;
        coronaEeffectedTime = (Mathf.Log((1/eff) -1,Mathf.Exp(1))/speradingParaK) + speradingParaA;
    }
    void coronaEffectSpreading(){
        if (coronaEeffect > 0){
            coronaEeffectedTime += speradingSpeed*Time.deltaTime;
            coronaEeffect = 1/(1+Mathf.Exp(speradingParaK* ( coronaEeffectedTime-speradingParaA)));
        }
    }

    void coronaSocialSpreading(){
        // Who Meet, Spreading (0.01*coronaEeffect) Corana Chance 0.5
    }


}
