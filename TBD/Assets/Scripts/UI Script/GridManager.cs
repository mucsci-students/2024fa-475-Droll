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
    public GameObject tempg;

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
        gridMap = new GridPoint[5, 13];

        // get bounds of sprite
        mySprite = GetComponent<SpriteRenderer>();
        upEdge = mySprite.bounds.extents.y;
        rigEdge = mySprite.bounds.extents.x;
        vSize = upEdge / 3f;
        hSize = rigEdge / 7f;
        topBorder = upEdge - .5f * vSize;
        botBorder = -topBorder;
        topRowBorder = topBorder - vSize;
        botRowBorder = -topRowBorder;


        //set red's Grid
        tempPos = new Vector3( -rigEdge + hSize, upEdge - vSize, 0f);
        for (int j = 0; j < 5; j++){
            for (int i = 0; i < 6; i++){
                gridMap[j,i] = new GridPoint(tempPos);

                Instantiate(tempr, tempPos, Quaternion.identity);

                tempPos.x += hSize;
            }
            tempPos.x = -mySprite.bounds.extents.x + hSize;
            tempPos.y -= vSize;
        }

        //set blue's Grid
        tempPos = new Vector3( rigEdge - hSize, upEdge - vSize, 0f);
        for (int j = 0; j < 5; j++){
            for (int i = 13; i > 7; i--){
                gridMap[j,i-1] = new GridPoint(tempPos);

                Instantiate(tempb, tempPos, Quaternion.identity);

                tempPos.x -= hSize;
            }
            tempPos.x = mySprite.bounds.extents.x - hSize;
            tempPos.y -= vSize;
        }

        tempPos = new Vector3( 0f, upEdge - vSize, 0f);
        for (int j = 0; j < 5; j++){
            
            gridMap[j,6] = new GridPoint(tempPos);

            Instantiate(tempg, tempPos, Quaternion.identity);

            tempPos.y -= vSize;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

