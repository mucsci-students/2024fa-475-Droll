using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSelect : MonoBehaviour
{
    public GameObject redGuy;
    public GameObject redShoot;
    public GameObject redBar;
    public GameObject redWalk;
    public GameObject redRunner;

    public RedMoveScript rgScript;

    public GameObject myGrid;
    public GridManager myGridScript;

    public int r;
    public int c;

    public LeftWall leftWallScript;
    public bool isDead;

    public RedUnitSelector rus;
    
    // Start is called before the first frame update
    void Start()
    {
        redGuy = GameObject.Find("RedGuy");
        rgScript = redGuy.GetComponent<RedMoveScript>();

        myGrid = GameObject.Find("Grid");
        myGridScript = myGrid.GetComponent<GridManager>();
        
        c = 1;
        r = 2;

        leftWallScript = GameObject.Find("left wall").GetComponent<LeftWall>();

        rus = GameObject.Find("RedUnitManager").GetComponent<RedUnitSelector>();
    }

    // Update is called once per frame
    void Update()
    {
        isDead = leftWallScript.redGameOver;
        if (!isDead){

            //adjust selector horizontaly based on keys
            if(Input.GetKeyDown(KeyCode.D)){
                c = Mathf.Min(c+1, 5);
            }
            if(Input.GetKeyDown(KeyCode.A)){
                c = Mathf.Max(c-1, 1);
            }

            r = rgScript.r;

            //preforms adjustment
            ref var curPoint = ref myGridScript.gridMap[r,c];
            transform.position = curPoint.pos;

            ref int rgMoney = ref rgScript.money;


            //place unit
            if(Input.GetKeyDown(KeyCode.Alpha2)){
                if(rus.Units[rus.currentUnit].cost <= rgMoney){
                    Instantiate(rus.Units[rus.currentUnit].myObject, curPoint.pos, Quaternion.identity);
                    rgMoney -= rus.Units[rus.currentUnit].cost;
                }
            }

            /*
            //Place Barrior on 1 key
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                if(!curPoint.isFull && rgMoney >= 40){
                    var newGuy =  Instantiate(redBar, transform.position, Quaternion.identity).GetComponent<RedBarScript>();
                    curPoint.isFull = true;
                    newGuy.r = r;
                    newGuy.c = c;

                    rgMoney -= 40;
                }
            }
            //Place Shooter on 2 key
            if(Input.GetKeyDown(KeyCode.Alpha2)){
                if(!curPoint.isFull && rgMoney >= 30){
                    var newGuy =  Instantiate(redShoot, transform.position, Quaternion.identity).GetComponent<RedShoot>();
                    curPoint.isFull = true;
                    newGuy.r = r;
                    newGuy.c = c;

                    rgMoney -= 30;
                }
            }
            //Place Walekr on 3 key
            if(Input.GetKeyDown(KeyCode.Alpha3)){
                if(rgMoney >= 60){
                    Instantiate(redWalk, transform.position, Quaternion.identity);

                    rgMoney -= 60;
                }
            }
            //place runner on 4
            if(Input.GetKeyDown(KeyCode.Alpha4)){
                if(rgMoney >= 50){
                    Instantiate(redRunner, transform.position, Quaternion.identity);

                    rgMoney -= 50;
                }
            }
            */
        }
    }
}
