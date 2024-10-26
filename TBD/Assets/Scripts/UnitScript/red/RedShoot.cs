using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShoot : MonoBehaviour
{
    public GameObject bullet;
    public int health;
    public float timePassed;
    public int r;
    public int c;

    public BlueMoveScript blueGuyScript;

    // Start is called before the first frame update
    void Start()
    {
        health = 20;

        blueGuyScript = GameObject.Find("BlueGuy").GetComponent<BlueMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //ON DEATH
        if(health <= 0){
            blueGuyScript.money += 15;

            GameObject.Find("Grid").GetComponent<GridManager>().gridMap[r,c].isFull = false;
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
        if(col.gameObject.layer == 11 || col.gameObject.layer == 20){
            health -= 4;
        }
        //hit by walker
        else if (col.gameObject.layer == 13 || col.gameObject.layer == 18){
            health -= 20;
        }
        //hit by runner
        else if (col.gameObject.layer == 17){
            health -= 5;
        }
    }
    
}
