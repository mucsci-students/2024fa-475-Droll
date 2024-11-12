using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayWalkerLeftScript : MonoBehaviour
{
    public int health;

    public float timePassed;
    public bool backup;
    public float movespeed;

    public BlueMoveScript blueGuyScript;
    public RedMoveScript redGuyScript;
    public bool lastHitRed;

    // Start is called before the first frame update
    void Start()
    {
        health = 20;
        movespeed = 1f;

        blueGuyScript = GameObject.Find("BlueGuy").GetComponent<BlueMoveScript>();
        redGuyScript = GameObject.Find("RedGuy").GetComponent<RedMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //On death
        if(health <= 0){
            if(lastHitRed){
                redGuyScript.money += 30;
            }
            else{
                blueGuyScript.money += 30;
            }

            GameObject.Find("GrayManager").GetComponent<GraySpawning>().bossTimer -= 1;

            Destroy(gameObject);
        }

        //on backup movespeed is halved and inverted
        if(backup){
            timePassed += Time.deltaTime;
            if (timePassed < 2){
                movespeed = -.5f;
            }
            else{
                movespeed = 1f;
                backup = false;
                timePassed = 0;
            }
        }


        //Walk to other side (unless backup)
        transform.position += new Vector3(-1f, 0f, 0f) * movespeed * Time.deltaTime;
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
            health -= 7;
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
        //hits enemy barrior
        else if (col.gameObject.layer == 15 || col.gameObject.layer == 14){
            backup = true;
        }
        //hits enemy wall
        else if (col.gameObject.layer == 7 || col.gameObject.layer == 6){
            if(col.gameObject.layer == 6){
                lastHitRed = true;
            }
            else{
                lastHitRed = false;
            }
            health -= 999;
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
