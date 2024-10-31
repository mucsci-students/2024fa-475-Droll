using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWall : MonoBehaviour
{
    public SpriteRenderer gridSprite;

    public int health;
    public bool redGameOver;
    // Start is called before the first frame update
    void Start()
    {
        gridSprite = GameObject.Find("Grid").GetComponent<SpriteRenderer>();
        transform.position = new Vector3(-gridSprite.bounds.extents.x + 3f * gridSprite.bounds.extents.x / 14f , 0f, 0f);
        
        health = 300;
    }

    void Update(){
        if (health <= 0){
            redGameOver = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D col){
        //hit by bullet
        if(col.gameObject.layer == 11 || col.gameObject.layer == 20){
            health -= 2;
        }
        //hit by walker
        else if (col.gameObject.layer == 13 || col.gameObject.layer == 18){
            health -= 10;
        }
        //hit by runner
        else if (col.gameObject.layer == 17){
            health -= 5;
        }

        //hit by bossball
        else if (col.gameObject.layer == 28){
            health -= 10;
        }
    }
    public int GetRedHealth()
    {
        return health;
    }

}
