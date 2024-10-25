using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWalkerScript : MonoBehaviour
{
    public int health;

    public float timePassed;
    public bool backup;
    public float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        health = 20;
        movespeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //On death
        if(health <= 0){
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
        transform.position += new Vector3(1f, 0f, 0f) * movespeed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D col){
        //hit by bullet
        if(col.gameObject.layer == 11){
            health -= 5;
        }
        //hit by walker
        else if (col.gameObject.layer == 13){
            health -= 20;
        }
        //hit by runner
        else if (col.gameObject.layer == 17){
            health -= 5;
        }
        //hits enemy barrior
        else if (col.gameObject.layer == 15){
            backup = true;
        }
        //hits enemy wall
        else if (col.gameObject.layer == 7){
            health -= 999;
        }
    }
}
