using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRunnerScript : MonoBehaviour
{
    public int health;

    public float timePassed;
    public bool backup;
    public float movespeed;

    public BlueMoveScript blueGuyScript;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        movespeed = 3f;

        blueGuyScript = GameObject.Find("BlueGuy").GetComponent<BlueMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //On death
        if(health <= 0){
            blueGuyScript.money += 25;

            Destroy(gameObject);
        }

        //on backup movespeed is halved and inverted
        if(backup){
            timePassed += Time.deltaTime;
            if (timePassed < 1){
                movespeed = -1.5f;
            }
            else{
                movespeed = 3f;
                backup = false;
                timePassed = 0;
            }
        }


        //Walk to other side (unless backup)
        transform.position += new Vector3(1f, 0f, 0f) * movespeed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D col){
        //hit by bullet
        if(col.gameObject.layer == 11 || col.gameObject.layer == 20){
            health -= 5;
        }
        //hit by walker
        else if (col.gameObject.layer == 13 || col.gameObject.layer == 18){
            health -= 10;
        }
        //hit by runner
        else if (col.gameObject.layer == 17){
            health -= 10;
        }

        //hits enemy barrior
        else if (col.gameObject.layer == 15){
            backup = true;
        }
        //hits enemy shooter
        else if (col.gameObject.layer == 9 || col.gameObject.layer == 19){
            backup = true;
        }
        //hits enemy wall
        else if (col.gameObject.layer == 7){
            health -= 999;
        }
    }
}
