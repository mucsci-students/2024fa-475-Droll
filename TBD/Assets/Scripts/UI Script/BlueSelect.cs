using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSelect : MonoBehaviour
{
    public GameObject blueGuy;

    public BlueMoveScript bgScript;

    public GameObject myGrid;
    public GridManager myGridScript;
    
    public int r;
    public int c;

    public RightWall rightWallScript;
    public bool isDead;

    public BlueUnitSelector bus;

    [SerializeField] private AudioClip spawnSound;

    // Start is called before the first frame update
    void Start()
    {
        blueGuy = GameObject.Find("BlueGuy");
        bgScript = blueGuy.GetComponent<BlueMoveScript>();

        myGrid = GameObject.Find("Grid");
        myGridScript = myGrid.GetComponent<GridManager>();
        
        c = 11;
        r = 2;

        rightWallScript = GameObject.Find("right wall").GetComponent<RightWall>();

        bus = GameObject.Find("BlueUnitManager").GetComponent<BlueUnitSelector>();
    }

    // Update is called once per frame
    void Update()
    {
        isDead = rightWallScript.blueGameOver;
        if (!isDead){

            if(Input.GetKeyDown(KeyCode.RightArrow) && Time.timeScale != 0){
                c = Mathf.Min(c+1, 11);
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow) && Time.timeScale != 0){
                c = Mathf.Max(c-1, 7);
            }

            r = bgScript.r;

            ref var curPoint = ref myGridScript.gridMap[r,c];
            transform.position = curPoint.pos;

            ref int bgMoney = ref bgScript.money;

            ref int curUnit = ref bus.currentUnit;

            //place unit
            if(Input.GetKeyDown(KeyCode.Keypad2) && Time.timeScale != 0){
                if(bus.Units[curUnit].cost <= bgMoney){
                    if(curUnit == 0 || curUnit == 1){
                        if(!curPoint.isFull){
                            SoundFXManager.instance.PlaySoundFXClip(spawnSound, transform, 1f);
                            var newguy = Instantiate(bus.Units[bus.currentUnit].myObject, curPoint.pos, Quaternion.identity);
                            bgMoney -= bus.Units[bus.currentUnit].cost;
                            curPoint.isFull = true;
                            if(curUnit == 1){
                                var ngs = newguy.GetComponent<BlueShoot>();
                                ngs.r = r;
                                ngs.c = c;
                            }
                            else{
                                var ngs = newguy.GetComponent<BlueBarScript>();
                                ngs.r = r;
                                ngs.c = c;
                            }
                        }
                    }
                    else{
                        SoundFXManager.instance.PlaySoundFXClip(spawnSound, transform, 1f);
                        Instantiate(bus.Units[bus.currentUnit].myObject, curPoint.pos, Quaternion.identity);
                        bgMoney -= bus.Units[bus.currentUnit].cost;
                    }
                }
            }
        }
    }
}
