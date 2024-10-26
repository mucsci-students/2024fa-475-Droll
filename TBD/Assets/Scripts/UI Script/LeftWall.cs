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
        
        health = 1000;
    }

    void Update(){
        if (health <= 0){
            redGameOver = true;
        }
    }
}
