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
        isPrelude = true;
        SoundMusicManager.instance.PlaySoundMusicClip(prelude, transform, 1f);
    }

    void Update(){
        timePassed += Time.deltaTime;
        if(isPrelude){
            if(timePassed > 40f){
                isPrelude = false;
                timePassed = 0;
                SoundMusicManager.instance.PlaySoundMusicClip(battle, transform, 1f);
            }
        }
        else{
            if(timePassed > 96f){
                timePassed = 0;
                SoundMusicManager.instance.PlaySoundMusicClip(battle, transform, 1f);
            }
        }
    }
}
