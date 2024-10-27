using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraySpawning : MonoBehaviour
{
    public GameObject walkLeft;
    public GameObject walkRight;
    public GameObject ShootLeft;
    public GameObject ShootRight;
    public GameObject boss;

    public GridManager gridScript;

    public float timePassed;
    public float timePassed1;

    public int r;
    public int c;

    public int shootDir;

    public int bossTimer;
    public bool bossAlive;

    // Start is called before the first frame update
    void Start()
    {
        gridScript = GameObject.Find("Grid").GetComponent<GridManager>();
        c = 6;
        bossTimer = 50;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        timePassed1 += Time.deltaTime;

        //spawns walkers
        if (timePassed > 5f){
            r = Random.Range(0, 5);
            Instantiate(walkLeft, gridScript.gridMap[r,c].pos, Quaternion.identity);
            r = Random.Range(0, 5);
            Instantiate(walkRight, gridScript.gridMap[r,c].pos, Quaternion.identity);

            timePassed = 0;
        }

        //spawns shooters
        if(timePassed1 > 20){
            shootDir = Random.Range(0,2);
            r = Random.Range(0, 5);
            if(shootDir == 1 && !gridScript.gridMap[r,c].isFull){
                var newGuy = Instantiate(ShootLeft, gridScript.gridMap[r,c].pos, Quaternion.identity).GetComponent<GrayShootLeft>();
                gridScript.gridMap[r,c].isFull = true;
                newGuy.r = r;
                newGuy.c = c;
            }
            else if (!gridScript.gridMap[r,c].isFull){
                var newGuy = Instantiate(ShootRight, gridScript.gridMap[r,c].pos, Quaternion.identity).GetComponent<GrayShootRight>();
                gridScript.gridMap[r,c].isFull = true;
                newGuy.r = r;
                newGuy.c = c;
            }

            shootDir = Random.Range(0,2);
            r = Random.Range(0, 5);
            if(shootDir == 1 && !gridScript.gridMap[r,c].isFull){
                var newGuy = Instantiate(ShootLeft, gridScript.gridMap[r,c].pos, Quaternion.identity).GetComponent<GrayShootLeft>();
                gridScript.gridMap[r,c].isFull = true;
                newGuy.r = r;
                newGuy.c = c;
            }
            else if (!gridScript.gridMap[r,c].isFull){
                var newGuy = Instantiate(ShootRight, gridScript.gridMap[r,c].pos, Quaternion.identity).GetComponent<GrayShootRight>();
                gridScript.gridMap[r,c].isFull = true;
                newGuy.r = r;
                newGuy.c = c;
            }

            timePassed1 = 0;
        }

        //spawns boss
        if(bossTimer <= 0 && !bossAlive){
            Instantiate(boss, gridScript.gridMap[2,c].pos, Quaternion.identity);
            bossAlive = true;
            bossTimer = 50;
        }
    }
}
