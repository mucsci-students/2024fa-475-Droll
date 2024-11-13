using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

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

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume){
        //spawn
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

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
