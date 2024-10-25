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

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //ON DEATH
        if(health <= 0){
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
        if(col.gameObject.layer == 10){
            health -= 3;
        }
        //hit by walker
        else if (col.gameObject.layer == 12){
            health -= 10;
        }
        //hit by runner
        else if (col.gameObject.layer == 16){
            health -= 5;
        }
    }
}
