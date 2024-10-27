using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GraySpawning gManager;

    public int health;

    public float timePassed;

    public BlueMoveScript blueGuyScript;
    public RedMoveScript redGuyScript;
    public bool lastHitRed;

    public GridManager myGridScript;

    public GameObject ballRight;
    public GameObject ballLeft;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;

        gManager = GameObject.Find("GrayManager").GetComponent<GraySpawning>();

        blueGuyScript = GameObject.Find("BlueGuy").GetComponent<BlueMoveScript>();
        redGuyScript = GameObject.Find("RedGuy").GetComponent<RedMoveScript>();

        myGridScript = GameObject.Find("Grid").GetComponent<GridManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            if(lastHitRed){
                redGuyScript.money += 100;
            }
            else{
                blueGuyScript.money += 100;
            }

            gManager.bossAlive = false;

            Destroy(gameObject);
        }

        timePassed += Time.deltaTime;
        if(timePassed > 10f){
            for(int i = 0; i < 5; i++){
                Instantiate(ballRight, myGridScript.gridMap[i,6].pos, Quaternion.identity);
                Instantiate(ballLeft, myGridScript.gridMap[i,6].pos, Quaternion.identity);
            }
            timePassed = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D col){
        //hit by bullet
        if(col.gameObject.layer == 11 || col.gameObject.layer == 10){
            if(col.gameObject.layer == 10){
                lastHitRed = true;
            }
            else{
                lastHitRed = false;
            }
            health -= 4;
        }
        //hit by walker
        else if (col.gameObject.layer == 13 || col.gameObject.layer == 12){
            if(col.gameObject.layer == 12){
                lastHitRed = true;
            }
            else{
                lastHitRed = false;
            }
            health -= 20;
        }
        //hit by runner
        else if (col.gameObject.layer == 17 || col.gameObject.layer == 16){
            if(col.gameObject.layer == 16){
                lastHitRed = true;
            }
            else{
                lastHitRed = false;
            }
            health -= 10;
        }
    }
}
