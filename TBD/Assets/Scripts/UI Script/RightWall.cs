using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWall : MonoBehaviour
{
    public SpriteRenderer gridSprite;

    public int health;
    public bool blueGameOver;

    // Start is called before the first frame update
    void Start()
    {
        gridSprite = GameObject.Find("Grid").GetComponent<SpriteRenderer>();
        transform.position = new Vector3(gridSprite.bounds.extents.x - 3f * gridSprite.bounds.extents.x / 14f , 0f, 0f);
        health = 300;
    }

    void Update(){
        if (health <= 0){
            blueGameOver = true;
        }
    }
    
    public void OnTriggerEnter2D(Collider2D col){
        //hit by bullet
        if(col.gameObject.layer == 10 || col.gameObject.layer == 20){
            health -= 2;
        }
        //hit by walker
        else if (col.gameObject.layer == 12 || col.gameObject.layer == 18){
            health -= 10;
        }
        //hit by runner
        else if (col.gameObject.layer == 16){
            health -= 5;
        }

        //hit by bossball
        else if (col.gameObject.layer == 28){
            health -= 10;
        }
    }


}
