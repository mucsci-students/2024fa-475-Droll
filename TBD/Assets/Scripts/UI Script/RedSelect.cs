using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSelect : MonoBehaviour
{
    public GameObject redGuy;

    public RedMoveScript rgScript;

    public GameObject myGrid;
    public GridManager myGridScript;

    public int r;
    public int c;

    public LeftWall leftWallScript;
    public bool isDead;

    public RedUnitSelector rus;

    [SerializeField] private AudioClip spawnSound;
    
    // Start is called before the first frame update
    void Start()
    {
        redGuy = GameObject.Find("RedGuy");
        rgScript = redGuy.GetComponent<RedMoveScript>();

        myGrid = GameObject.Find("Grid");
        myGridScript = myGrid.GetComponent<GridManager>();
        
        c = 1;
        r = 2;

        leftWallScript = GameObject.Find("left wall").GetComponent<LeftWall>();

        rus = GameObject.Find("RedUnitManager").GetComponent<RedUnitSelector>();
    }

    // Update is called once per frame
    void Update()
    {
        isDead = leftWallScript.redGameOver;
        if (!isDead){

            //adjust selector horizontaly based on keys
            if(Input.GetKeyDown(KeyCode.D)){
                c = Mathf.Min(c+1, 5);
            }
            if(Input.GetKeyDown(KeyCode.A)){
                c = Mathf.Max(c-1, 1);
            }

            r = rgScript.r;

            //preforms adjustment
            ref var curPoint = ref myGridScript.gridMap[r,c];
            transform.position = curPoint.pos;

            ref int rgMoney = ref rgScript.money;

            ref int curUnit = ref rus.currentUnit;

            //place unit
            if(Input.GetKeyDown(KeyCode.Alpha2)){
                if(rus.Units[curUnit].cost <= rgMoney){
                    if(curUnit == 1 || curUnit == 0){
                        if(!curPoint.isFull){
                            SoundFXManager.instance.PlaySoundFXClip(spawnSound, transform, 1f);
                            var newguy = Instantiate(rus.Units[rus.currentUnit].myObject, curPoint.pos, Quaternion.identity);
                            rgMoney -= rus.Units[rus.currentUnit].cost;
                            curPoint.isFull = true;
                            if(curUnit == 1){
                                var ngs = newguy.GetComponent<RedShoot>();
                                ngs.r = r;
                                ngs.c = c;
                            }
                            else{
                                var ngs = newguy.GetComponent<RedBarScript>();
                                ngs.r = r;
                                ngs.c = c;
                            }
                        }
                    }
                    else{
                        SoundFXManager.instance.PlaySoundFXClip(spawnSound, transform, 1f);
                        Instantiate(rus.Units[rus.currentUnit].myObject, curPoint.pos, Quaternion.identity);
                        rgMoney -= rus.Units[rus.currentUnit].cost;
                    }
                }
            }
        }
    }
}
