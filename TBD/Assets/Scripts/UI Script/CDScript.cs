
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDScript : MonoBehaviour
{

    public float maxTime;
    public float maxScale;

    public GameObject CDObject;
    public bool isOnCD;
    public float curTime;
    public float curScale;
    public KeyCode KeyTest;
    // Start is called before the first frame update
    void Start()
    {
        maxScale = .5f;
        maxTime = 30f;
        isOnCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOnCD)
        {
            CDObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
        if(Input.GetKeyDown(KeyTest) && !isOnCD){
            isOnCD = true;
            CDObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
            curTime = 0f;
        }
        if(isOnCD){
            curTime += Time.deltaTime;

            curScale = ( Mathf.Max(0, maxTime - curTime) / maxTime ) * maxScale; 

            CDObject.transform.localScale = new Vector3(curScale, curScale, 0f);

            if(curTime >= maxTime){
                isOnCD = false;
                curTime = 0;
            }
        }
    }
}
