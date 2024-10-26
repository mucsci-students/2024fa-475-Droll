using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMoveScript : MonoBehaviour
{

    public Vector3 moveDir;
    public float moveSpeed;
    public int money;

    public SpriteRenderer gridSprite;

    public RightWall rightWallScript;
    public bool isDead;

    public GridManager myGridScript;

    public float topRow;
    public float botRow;
    public float top1Row;
    public float bot1Row;

    public int r;

    public GameObject blueHeal;
    public GameObject blueAtk;
    public GameObject blueSpdUp;

    public bool HealCD;
    public bool AtkCD;
    public bool SpdUpCD;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2;
        moveDir = Vector3.zero;
        money = 250;

        gridSprite = GameObject.Find("Grid").GetComponent<SpriteRenderer>();
        myGridScript = GameObject.Find("Grid").GetComponent<GridManager>();

        transform.position = new Vector3(gridSprite.bounds.extents.x - gridSprite.bounds.extents.x / 7f , 0f, 0f);

        rightWallScript = GameObject.Find("right wall").GetComponent<RightWall>();
    }

    // Update is called once per frame
    void Update()
    {
        isDead = rightWallScript.blueGameOver;
        if (!isDead){
            moveDir = new Vector3 (0f, Input.GetAxis("BlueMove"), 0f);
            transform.position += Vector3.Normalize(moveDir) * moveSpeed * Time.deltaTime;

            //only needed once but has to be after grid is set up
            topRow = myGridScript.topRowBorder;
            botRow = myGridScript.botRowBorder;
            top1Row = topRow - myGridScript.vSize;
            bot1Row = botRow + myGridScript.vSize;
            
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
            if(Input.GetKeyDown(KeyCode.Keypad7) && !HealCD){
                Instantiate(blueHeal, myGridScript.gridMap[r,6].pos, Quaternion.identity);
                StartCoroutine(healCDcounter());
            }
            if(Input.GetKeyDown(KeyCode.Keypad8) && !AtkCD){
                Instantiate(blueAtk, myGridScript.gridMap[r,6].pos, Quaternion.identity);
                StartCoroutine(atkCDcounter());
            }
            if(Input.GetKeyDown(KeyCode.Keypad9) && !SpdUpCD){
                Instantiate(blueSpdUp, myGridScript.gridMap[r,6].pos, Quaternion.identity);
                StartCoroutine(spdupCDcounter());
            }
        }
    }

    IEnumerator healCDcounter()
    {
        HealCD = true;
        yield return new WaitForSeconds(3f);
        HealCD = false;
    }
    IEnumerator atkCDcounter()
    {
        AtkCD = true;
        yield return new WaitForSeconds(3f);
        AtkCD = false;
    }
    IEnumerator spdupCDcounter()
    {
        SpdUpCD = true;
        yield return new WaitForSeconds(3f);
        SpdUpCD = false;
    }
}

