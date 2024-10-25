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
    public float rgPos;

    public GameObject myGrid;
    public GridManager myGridScript;
    public float topRow;
    public float botRow;
    public float top1Row;
    public float bot1Row;


    public int r;
    public int c;
    // Start is called before the first frame update
    void Start()
    {
        redGuy = GameObject.Find("RedGuy");

        myGrid = GameObject.Find("Grid");
        myGridScript = myGrid.GetComponent<GridManager>();
        
        c = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //only needed once but has to be after grid is set up
        topRow = myGridScript.topRowBorder;
        botRow = myGridScript.botRowBorder;
        top1Row = topRow - myGridScript.vSize;
        bot1Row = botRow + myGridScript.vSize;

        //adjust selector verttically based on player pos
        rgPos = redGuy.transform.position.y;
        if(rgPos > topRow){
            r = 0;
        }
        else if(rgPos > top1Row){
            r = 1;
        }
        else if (rgPos < botRow){
            r = 4;
        }
        else if (rgPos < bot1Row){
            r = 3;
        }
        else{
            r = 2;
        }

        //adjust selector horizontaly based on keys
        if(Input.GetKeyDown(KeyCode.D)){
            c = Mathf.Min(c+1, 5);
        }
        if(Input.GetKeyDown(KeyCode.A)){
            c = Mathf.Max(c-1, 1);
        }

        //preforms adjustment
        ref var curPoint = ref myGridScript.gridMap[r,c];
        transform.position = curPoint.pos;

        //Place Shooter on 2 key
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            if(!curPoint.isFull){
                var newGuy =  Instantiate(redShoot, transform.position, Quaternion.identity).GetComponent<RedShoot>();
                curPoint.isFull = true;
                newGuy.r = r;
                newGuy.c = c;
            }
        }
        //Place Barrior on 1 key
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            if(!curPoint.isFull){
                var newGuy =  Instantiate(redBar, transform.position, Quaternion.identity).GetComponent<RedBarScript>();
                curPoint.isFull = true;
                newGuy.r = r;
                newGuy.c = c;
            }
        }
        //Place Walekr on 3 key
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            Instantiate(redWalk, transform.position, Quaternion.identity);
        }
        //place runner on 4
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            Instantiate(redRunner, transform.position, Quaternion.identity);
        }
    }
}
