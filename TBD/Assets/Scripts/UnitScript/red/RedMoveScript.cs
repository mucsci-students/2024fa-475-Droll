using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMoveScript : MonoBehaviour
{
    public Vector3 moveDir;
    public float moveSpeed;
    public int money;

    public SpriteRenderer gridSprite;

    public LeftWall leftWallScript;
    public bool isDead;

    public GridManager myGridScript;

    public float topRow;
    public float botRow;
    public float top1Row;
    public float bot1Row;

    public int r;

    public GameObject redHeal;
    public GameObject redAtk;
    public GameObject redSpdUp;

    public bool HealCD;
    public bool AtkCD;
    public bool SpdUpCD;

    public float HealTimer;
    public float AtkTimer;
    public float SpdUpTimer;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2;
        moveDir = Vector3.zero;
        money = 250;

        gridSprite = GameObject.Find("Grid").GetComponent<SpriteRenderer>();
        myGridScript = GameObject.Find("Grid").GetComponent<GridManager>();

        transform.position = new Vector3(-gridSprite.bounds.extents.x + gridSprite.bounds.extents.x / 7f , 0f, 0f);

        leftWallScript = GameObject.Find("left wall").GetComponent<LeftWall>();

        HealTimer = 30f;
        AtkTimer = 30f;
        SpdUpTimer = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        isDead = leftWallScript.redGameOver;
        if (!isDead){
            moveDir = new Vector3 (0f, Input.GetAxis("RedMove"), 0f);
            transform.position += Vector3.Normalize(moveDir) * moveSpeed * Time.deltaTime;

            //only needed once but has to be after grid is set up
            topRow = myGridScript.topRowBorder;
            botRow = myGridScript.botRowBorder;
            top1Row = topRow - myGridScript.vSize;
            bot1Row = botRow + myGridScript.vSize;

            //adjust selector verttically based on player pos
            float y = transform.position.y;
            if(y > topRow){
                r = 0;
            }
            else if(y > top1Row){
                r = 1;
            }
            else if (y < botRow){
                r = 4;
            }
            else if (y < bot1Row){
                r = 3;
            }
            else{
                r = 2;
            }

            //hero actions
            if(Input.GetKeyDown(KeyCode.Z) && !HealCD && Time.timeScale != 0){
                Instantiate(redHeal, myGridScript.gridMap[r,6].pos, Quaternion.identity);
                StartCoroutine(healCDcounter());
            }
            if(Input.GetKeyDown(KeyCode.X) && !AtkCD && Time.timeScale != 0){
                Instantiate(redAtk, myGridScript.gridMap[r,6].pos, Quaternion.identity);
                StartCoroutine(atkCDcounter());
            }
            if(Input.GetKeyDown(KeyCode.C) && !SpdUpCD && Time.timeScale != 0){
                Instantiate(redSpdUp, myGridScript.gridMap[r,6].pos, Quaternion.identity);
                StartCoroutine(spdupCDcounter());
            }
        }
    }

    IEnumerator healCDcounter()
    {
        HealCD = true;
        yield return new WaitForSeconds(HealTimer);
        HealCD = false;
    }
    IEnumerator atkCDcounter()
    {
        AtkCD = true;
        yield return new WaitForSeconds(AtkTimer);
        AtkCD = false;
    }
    IEnumerator spdupCDcounter()
    {
        SpdUpCD = true;
        yield return new WaitForSeconds(SpdUpTimer);
        SpdUpCD = false;
    }
    public int GetRedMoney(){
        return money;
    }
}
