using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMusicManager : MonoBehaviour
{
    public static SoundMusicManager instance;

    [SerializeField] private AudioSource soundMusicObject;

    public void Start(){
        if (GameObject.FindGameObjectsWithTag("fxManager").Length > 1){
            Destroy(gameObject);
        }
    }

    private void Awake(){
        if (instance == null){
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySoundMusicClip(AudioClip audioClip, Transform spawnTransform, float volume){
        //spawn
        AudioSource audioSource = Instantiate(soundMusicObject, spawnTransform.position, Quaternion.identity);

        //assign
        audioSource.clip = audioClip;

        //volume
        audioSource.volume = volume;

        //sound
        audioSource.Play();

        //length
        float clipLength = audioSource.clip.length;

        //destroy
        Destroy(audioSource.gameObject, clipLength);
    }
}
