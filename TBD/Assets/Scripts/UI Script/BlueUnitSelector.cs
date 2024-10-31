using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueUnitSelector : MonoBehaviour
{
    public struct myUnit{
        public GameObject myObject;
        public int cost;
    }

    public GameObject blueWalker;
    public GameObject blueRunner;
    public GameObject blueBarrior;
    public GameObject blueShoot;

    public myUnit[] Units;

    public myUnit blueWalkUnit;
    public myUnit blueRunUnit;
    public myUnit blueBarUnit;
    public myUnit blueShootUnit;

    public int currentUnit;

    // Start is called before the first frame update
    void Start()
    {
        //init units
        blueWalkUnit = new myUnit();
        blueWalkUnit.myObject = blueWalker;
        blueWalkUnit.cost = 60;
        blueRunUnit = new myUnit();
        blueRunUnit.myObject = blueRunner;
        blueRunUnit.cost = 50;
        blueBarUnit = new myUnit();
        blueBarUnit.myObject = blueBarrior;
        blueBarUnit.cost = 40;
        blueShootUnit = new myUnit();
        blueShootUnit.myObject = blueShoot;
        blueShootUnit.cost = 30;

        //init array
        Units = new myUnit[4];
        Units[3] = blueBarUnit;
        Units[2] = blueShootUnit;
        Units[1] = blueWalkUnit;
        Units[0] = blueRunUnit;

        currentUnit = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1)){
            if(currentUnit == 0){
                currentUnit = 3;
            }
            else{
                currentUnit -=1;
            }
        }
        if(Input.GetKeyDown(KeyCode.Keypad3)){
            if(currentUnit == 3){
                currentUnit = 0;
            }
            else{
                currentUnit +=1;
            }
        }
    }
}
