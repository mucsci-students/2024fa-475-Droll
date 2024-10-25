using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSelect : MonoBehaviour
{
    public GameObject redGuy;
    public GameObject redShoot;
    public GameObject redBar;
    public GameObject redWalk;
    public GameObject redSpike;
    public float rgPos;

    public GameObject myGrid;
    public GridManager myGridScript;
    public float topRow;
    public float botRow;

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
        

        //adjust selector verttically based on player pos
        rgPos = redGuy.transform.position.y;
        if(rgPos > topRow){
            r = 0;
        }
        else if (rgPos < botRow){
            r = 2;
        }
        else{
            r = 1;
        }

        //adjust selector horizontaly based on keys
        if(Input.GetKeyDown(KeyCode.D)){
            c = Mathf.Min(c+1, 4);
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
                Instantiate(redBar, transform.position, Quaternion.identity);
                curPoint.isFull = true;
            }
        }
        //Place Walekr on 3 key
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            Instantiate(redWalk, transform.position, Quaternion.identity);
        }
        //place spike on 4
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            if(!curPoint.isFull){
                var newGuy = Instantiate(redSpike, transform.position, Quaternion.identity);
                curPoint.isFull = true;
            }
        }
    }
}
