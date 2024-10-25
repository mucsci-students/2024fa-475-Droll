using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //struct for each cell in grid
    public struct GridPoint{
        public bool isFull;
        public Vector3 pos;

        public GridPoint(Vector3 point){
            isFull = false;
            pos = point;
        }
    }
    public GameObject tempr;
    public GameObject tempb;

    public SpriteRenderer mySprite;
    
    public float upEdge;
    public float rigEdge;
    public float vSize;
    public float hSize;

    public float topBorder;
    public float botBorder;
    public float topRowBorder;
    public float botRowBorder;

    public Vector3 tempPos;

    public GridPoint[,] gridMap;

    // Start is called before the first frame update
    void Start()
    {
        gridMap = new GridPoint[3, 10];

        // get bounds of sprite
        mySprite = GetComponent<SpriteRenderer>();
        upEdge = mySprite.bounds.extents.y;
        rigEdge = mySprite.bounds.extents.x;
        vSize = upEdge / 2f;
        hSize = rigEdge / 6f;
        topBorder = upEdge - .5f * vSize;
        botBorder = -topBorder;
        topRowBorder = topBorder - vSize;
        botRowBorder = -topRowBorder;


        //set red's Grid
        tempPos = new Vector3( -rigEdge + hSize, upEdge - vSize, 0f);
        for (int j = 0; j < 3; j++){
            for (int i = 0; i < 5; i++){
                gridMap[j,i] = new GridPoint(tempPos);

                Instantiate(tempr, tempPos, Quaternion.identity);

                tempPos.x += hSize;
            }
            tempPos.x = -mySprite.bounds.extents.x + hSize;
            tempPos.y -= vSize;
        }

        //set blue's Grid
        tempPos = new Vector3( rigEdge - hSize, upEdge - vSize, 0f);
        for (int j = 0; j < 3; j++){
            for (int i = 10; i > 5; i--){
                gridMap[j,i-1] = new GridPoint(tempPos);

                Instantiate(tempb, tempPos, Quaternion.identity);

                tempPos.x -= hSize;
            }
            tempPos.x = mySprite.bounds.extents.x - hSize;
            tempPos.y -= vSize;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

