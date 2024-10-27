using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayShootLeft : MonoBehaviour
{
    public GameObject bullet;
    public int health;
    public float timePassed;
    public int r;
    public int c;

    public BlueMoveScript blueGuyScript;
    public RedMoveScript redGuyScript;
    public bool lastHitRed;

    // Start is called before the first frame update
    void Start()
    {
        health = 20;

        blueGuyScript = GameObject.Find("BlueGuy").GetComponent<BlueMoveScript>();
        redGuyScript = GameObject.Find("RedGuy").GetComponent<RedMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //ON DEATH
        if(health <= 0){
            if(lastHitRed){
                redGuyScript.money += 15;
            }
            else{
                blueGuyScript.money += 15;
            }

            GameObject.Find("Grid").GetComponent<GridManager>().gridMap[r,c].isFull = false;
            GameObject.Find("GrayManager").GetComponent<GraySpawning>().bossTimer -= 1;

            Destroy(gameObject);
        }

        //Fire after 2 sec
        timePassed += Time.deltaTime;
        if (timePassed > 2f){
            Instantiate(bullet, transform.position, Quaternion.identity);
            timePassed = 0f;
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
            health -= 5;
        }

        //hit by atkpowerup
        else if (col.gameObject.layer == 23 || col.gameObject.layer == 24){
            if(col.gameObject.layer == 23){
                lastHitRed = true;
            }
            else{
                lastHitRed = false;
            }
            health -= 14;
        }
    }
    
}
