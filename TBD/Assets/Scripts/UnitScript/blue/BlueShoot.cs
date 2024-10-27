using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueShoot : MonoBehaviour
{
    public GameObject bullet;
    public int health;
    public float timePassed;
    public int r;
    public int c;

    public RedMoveScript redGuyScript;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 10;

        redGuyScript = GameObject.Find("RedGuy").GetComponent<RedMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //ON DEATH
        if(health <= 0){
            redGuyScript.money += 15;

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
        if(col.gameObject.layer == 10 || col.gameObject.layer == 20){
            health -= 3;
        }
        //hit by walker
        else if (col.gameObject.layer == 12 || col.gameObject.layer == 18){
            health -= 10;
        }
        //hit by runner
        else if (col.gameObject.layer == 16){
            health -= 5;
        }

        //hit by healpowerup
        else if (col.gameObject.layer == 22){
            health += 20;
        }
        //hit by atkpowerup
        else if (col.gameObject.layer == 23){
            health -= 14;
        }

        //hit by bossball
        else if (col.gameObject.layer == 28){
            health -= 10;
        }
    }
}
