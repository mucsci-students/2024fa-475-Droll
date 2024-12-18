using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedUnitSelector : MonoBehaviour
{
    public struct myUnit{
        public GameObject myObject;
        public int cost;
    }

    public GameObject redWalker;
    public GameObject redRunner;
    public GameObject redBarrior;
    public GameObject redShoot;

    public myUnit[] Units;

    public myUnit redWalkUnit;
    public myUnit redRunUnit;
    public myUnit redBarUnit;
    public myUnit redShootUnit;

    public int currentUnit;

    // Start is called before the first frame update
    void Start()
    {
        //init units
        redWalkUnit = new myUnit();
        redWalkUnit.myObject = redWalker;
        redWalkUnit.cost = 60;
        redRunUnit = new myUnit();
        redRunUnit.myObject = redRunner;
        redRunUnit.cost = 50;
        redBarUnit = new myUnit();
        redBarUnit.myObject = redBarrior;
        redBarUnit.cost = 40;
        redShootUnit = new myUnit();
        redShootUnit.myObject = redShoot;
        redShootUnit.cost = 30;

        //init array
        Units = new myUnit[4];
        Units[0] = redBarUnit;
        Units[1] = redShootUnit;
        Units[2] = redWalkUnit;
        Units[3] = redRunUnit;

        currentUnit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            if(currentUnit == 0){
                currentUnit = 3;
            }
            else{
                currentUnit -=1;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            if(currentUnit == 3){
                currentUnit = 0;
            }
            else{
                currentUnit +=1;
            }
        }
    }
}
