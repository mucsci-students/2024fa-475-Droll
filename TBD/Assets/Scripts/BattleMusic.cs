using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMusic : MonoBehaviour
{

    [SerializeField] private AudioClip prelude;
    [SerializeField] private AudioClip battle;

    public bool isPrelude;

    public float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        SoundMusicManager.instance.PlaySoundMusicClip(prelude, transform, 1f);
        isPrelude = true;
    }

    void Update(){
        timePassed += Time.deltaTime;
        if(isPrelude){
            if(timePassed >= 40f){
                timePassed = 0;
                isPrelude = false;
                SoundMusicManager.instance.PlaySoundMusicClip(battle, transform, 1f);
            }
        }
        else{
            if(timePassed >= 96){
                timePassed = 0;
                SoundMusicManager.instance.PlaySoundMusicClip(battle, transform, 1f);
            } 
        }
    }
}
