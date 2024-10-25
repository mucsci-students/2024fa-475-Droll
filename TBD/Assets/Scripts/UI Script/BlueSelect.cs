using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSelect : MonoBehaviour
{
    public GameObject blueGuy;
    public GameObject blueShoot;
    public GameObject blueBar;
    public GameObject blueWalk;
    public GameObject blueRunner;
    public float bgPos;

    public GameObject myGrid;
    public GridManager myGridScript;
    public float topRow;
    public float botRow;

    public int r;
    public int c;
    // Start is called before the first frame update
    void Start()
    {
        blueGuy = GameObject.Find("BlueGuy");

        myGrid = GameObject.Find("Grid");
        myGridScript = myGrid.GetComponent<GridManager>();
        
        c = 8;
    }

    // Update is called once per frame
    void Update()
    {
        //only needed once but has to be after grid is set up
        topRow = myGridScript.topRowBorder;
        botRow = myGridScript.botRowBorder;
        

        bgPos = blueGuy.transform.position.y;
        if(bgPos > topRow){
            r = 0;
        }
        else if (bgPos < botRow){
            r = 2;
        }
        else{
            r = 1;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            c = Mathf.Min(c+1, 8);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            c = Mathf.Max(c-1, 5);
        }

        ref var curPoint = ref myGridScript.gridMap[r,c];
        transform.position = curPoint.pos;

        //Place Barrior on 1 key
        if(Input.GetKeyDown(KeyCode.Keypad1)){
            if(!curPoint.isFull){
                var newGuy =  Instantiate(blueBar, transform.position, Quaternion.identity).GetComponent<BlueBarScript>();
                curPoint.isFull = true;
                newGuy.r = r;
                newGuy.c = c;
            }
        }
        //Place Shoot on 2 key
        if(Input.GetKeyDown(KeyCode.Keypad2)){
            if(!curPoint.isFull){
                var newGuy = Instantiate(blueShoot, transform.position, Quaternion.identity).GetComponent<BlueShoot>();
                curPoint.isFull = true;
                newGuy.r = r;
                newGuy.c = c;
            }
        }
        //Place Walekr on 3 key
        if(Input.GetKeyDown(KeyCode.Keypad3)){
            Instantiate(blueWalk, transform.position, Quaternion.identity);
        }
        //place runner on 4
        if(Input.GetKeyDown(KeyCode.Keypad4)){
            Instantiate(blueRunner, transform.position, Quaternion.identity);
        }
    }
}
