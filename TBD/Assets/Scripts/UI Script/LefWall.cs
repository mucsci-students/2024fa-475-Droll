using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWall : MonoBehaviour
{
    public SpriteRenderer mySprite;
    // Start is called before the first frame update
    void Start()
    {
        mySprite = GameObject.Find("Grid").GetComponent<SpriteRenderer>();
        transform.position = new Vector3(-mySprite.bounds.extents.x + 3f * mySprite.bounds.extents.x / 14f , 0f, 0f);
    }
}
