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

    public BlueMoveScript bgScript;

    public GameObject myGrid;
    public GridManager myGridScript;
    public float topRow;
    public float botRow;
    public float top1Row;
    public float bot1Row;

    public int r;
    public int c;

    public RightWall rightWallScript;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        blueGuy = GameObject.Find("BlueGuy");
        bgScript = blueGuy.GetComponent<BlueMoveScript>();

        myGrid = GameObject.Find("Grid");
        myGridScript = myGrid.GetComponent<GridManager>();
        
        c = 11;

        rightWallScript = GameObject.Find("right wall").GetComponent<RightWall>();
    }

    // Update is called once per frame
    void Update()
    {
        isDead = rightWallScript.blueGameOver;
        if (!isDead){

            //only needed once but has to be after grid is set up
            topRow = myGridScript.topRowBorder;
            botRow = myGridScript.botRowBorder;
            top1Row = topRow - myGridScript.vSize;
            bot1Row = botRow + myGridScript.vSize;
            

            bgPos = blueGuy.transform.position.y;
            if(bgPos > topRow){
                r = 0;
            }
            else if(bgPos > top1Row){
                r = 1;
            }
            else if (bgPos < botRow){
                r = 4;
            }
            else if (bgPos < bot1Row){
                r = 3;
            }
            else{
                r = 2;
            }

            if(Input.GetKeyDown(KeyCode.RightArrow)){
                c = Mathf.Min(c+1, 11);
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                c = Mathf.Max(c-1, 7);
            }

            ref var curPoint = ref myGridScript.gridMap[r,c];
            transform.position = curPoint.pos;

            ref int bgMoney = ref bgScript.money;

            //Place Barrior on 1 key
            if(Input.GetKeyDown(KeyCode.Keypad1)){
                if(!curPoint.isFull && bgMoney >= 40){
                    var newGuy =  Instantiate(blueBar, transform.position, Quaternion.identity).GetComponent<BlueBarScript>();
                    curPoint.isFull = true;
                    newGuy.r = r;
                    newGuy.c = c;

                    bgMoney -= 40;
                }
            }
            //Place Shoot on 2 key
            if(Input.GetKeyDown(KeyCode.Keypad2)){
                if(!curPoint.isFull && bgMoney >= 30){
                    var newGuy = Instantiate(blueShoot, transform.position, Quaternion.identity).GetComponent<BlueShoot>();
                    curPoint.isFull = true;
                    newGuy.r = r;
                    newGuy.c = c;

                    bgMoney -= 30;
                }
            }
            //Place Walekr on 3 key
            if(Input.GetKeyDown(KeyCode.Keypad3)){
                if(bgMoney >= 60){
                    Instantiate(blueWalk, transform.position, Quaternion.identity);

                    bgMoney -= 60;
                }
            }
            //place runner on 4
            if(Input.GetKeyDown(KeyCode.Keypad4)){
                if(bgMoney >= 50){
                    Instantiate(blueRunner, transform.position, Quaternion.identity);

                    bgMoney -= 50;
                }
            }
        }
    }
}
