using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueRunnerScript : MonoBehaviour
{
    public int health;

    public float timePassed;
    public bool backup;
    public float movespeed;

    public RedMoveScript redGuyScript;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        movespeed = 3f;

        redGuyScript = GameObject.Find("RedGuy").GetComponent<RedMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //On death
        if(health <= 0){
            redGuyScript.money += 25;

            Destroy(gameObject);
        }

        //on backup movespeed is halved and inverted
        if(backup){
            timePassed += Time.deltaTime;
            if (timePassed < .75){
                movespeed = -1.5f;
            }
            else{
                movespeed = 3f;
                backup = false;
                timePassed = 0;
            }
        }


        //Walk to other side (unless backup)
        transform.position += new Vector3(-1f, 0f, 0f) * movespeed * Time.deltaTime;
    }

    //DAMAGE TAKEN
    public void OnTriggerEnter2D(Collider2D col){
        //hit by bullet
        if(col.gameObject.layer == 10 || col.gameObject.layer == 20){
            health -= 5;
        }
        //hit by walker
        else if (col.gameObject.layer == 12 || col.gameObject.layer == 18){
            health -= 999;
        }
        //hit by runner
        else if (col.gameObject.layer == 16){
            health -= 999;
        }

        //hits enemy barrior
        else if (col.gameObject.layer == 14){
            backup = true;
        }
        //hits enemy shooter
        else if (col.gameObject.layer == 8 || col.gameObject.layer == 19){
            backup = true;
        }
        //hits enemy wall
        else if (col.gameObject.layer == 6){
            health -= 999;
        }
        
        //hit by healpowerup
        else if (col.gameObject.layer == 22){
            health += 10;
        }
        //hit by atkpowerup
        else if (col.gameObject.layer == 23){
            health -= 7;
        }
        //hit by spdUPpowerup
        else if (col.gameObject.layer == 26){
            movespeed = 6;
        }

        //hit by bossball
        else if (col.gameObject.layer == 28){
            health -= 5;
        }
    }
}
