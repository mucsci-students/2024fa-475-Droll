using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBarScript : MonoBehaviour
{
    public int health;
    public int r;
    public int c;

    public BlueMoveScript blueGuyScript;

    // Start is called before the first frame update
    void Start()
    {
        health = 30;

        blueGuyScript = GameObject.Find("BlueGuy").GetComponent<BlueMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //on death
        if(health <= 0){
            blueGuyScript.money += 20;

            GameObject.Find("Grid").GetComponent<GridManager>().gridMap[r,c].isFull = false;
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D col){
        //hit by walker
        if (col.gameObject.layer == 13 || col.gameObject.layer == 18){
            health -= 10;
        }
        //hit by runner
        else if (col.gameObject.layer == 17){
            health -= 5;
        }
        
        //hit by healpowerup
        else if (col.gameObject.layer == 21){
            health += 30;
        }
        //hit by atkpowerup
        else if (col.gameObject.layer == 24){
            health -= 21;
        }

        //hit by bossball
        else if (col.gameObject.layer == 28){
            health -= 15;
        }
    }
}
