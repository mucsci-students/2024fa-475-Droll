using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotWall : MonoBehaviour
{
    public SpriteRenderer mySprite;
    // Start is called before the first frame update
    void Start()
    {
        mySprite = GameObject.Find("Grid").GetComponent<SpriteRenderer>();
        transform.position = new Vector3(0f, -mySprite.bounds.extents.y + mySprite.bounds.extents.y / 6f , 0f);
    }
}
