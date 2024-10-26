using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBarScript : MonoBehaviour
{
    public int health;
    public int r;
    public int c;

    public RedMoveScript redGuyScript;

    // Start is called before the first frame update
    void Start()
    {
        health = 30;

        redGuyScript = GameObject.Find("RedGuy").GetComponent<RedMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //on death
        if(health <= 0){
            redGuyScript.money += 20;

            GameObject.Find("Grid").GetComponent<GridManager>().gridMap[r,c].isFull = false;
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D col){
        //hit by walker
        if (col.gameObject.layer == 12 || col.gameObject.layer == 18){
            health -= 10;
        }
        //hit by runner
        else if (col.gameObject.layer == 16){
            health -= 5;
        }
    }
}
