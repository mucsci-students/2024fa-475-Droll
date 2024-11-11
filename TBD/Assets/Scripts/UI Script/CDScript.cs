/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDScript : MonoBehaviour
{

    public float maxTime;
    public float maxScale;

    public GameObject RHObject;
    public bool RHisOnCD;
    public float RHcurTime;
    public float RHcurScale
    // Start is called before the first frame update
    void Start()
    {
        maxScale = 10f;
        maxTime = 30f;
        RHisOnCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && !RHisOnCD){
            RHisOnCD = true;
            RHcurTime = 0f;
        }
        if(RHisOnCD){
            RHcurTime += Time.deltaTime;

            RHcurScale = ( mathf.Max(0, maxTime - curTime) / maxTime ) * maxScale; 

            RHObject.transform.localeScale = new Vector3(curScale, curScale, 0f);

            if(RHcurTime >= maxTime){
                RHisOnCD = true;
                curTime = 0;
            }
        }
    }
}
*/