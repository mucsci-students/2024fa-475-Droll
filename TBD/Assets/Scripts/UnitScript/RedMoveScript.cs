using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMoveScript : MonoBehaviour
{
    public Vector3 moveDir;
    public float moveSpeed;
    public int money;

    public SpriteRenderer gridSprite;

    public LeftWall leftWallScript;
    public bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2;
        moveDir = Vector3.zero;
        money = 250;

        gridSprite = GameObject.Find("Grid").GetComponent<SpriteRenderer>();
        transform.position = new Vector3(-gridSprite.bounds.extents.x + gridSprite.bounds.extents.x / 7f , 0f, 0f);

        leftWallScript = GameObject.Find("left wall").GetComponent<LeftWall>();
    }

    // Update is called once per frame
    void Update()
    {
        isDead = leftWallScript.redGameOver;
        if (!isDead){
            moveDir = new Vector3 (0f, Input.GetAxis("RedMove"), 0f);
            transform.position += Vector3.Normalize(moveDir) * moveSpeed * Time.deltaTime;
        }
    }
}
