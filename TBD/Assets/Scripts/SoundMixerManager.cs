using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    
    private void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetMasterVolume(float level){
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(level)*20);
    }

    public void SetSoundFXVolume(float level){
        audioMixer.SetFloat("SoundFXVolume", Mathf.Log10(level)*20);
    }

    public void SetMusicVolume(float level){
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(level)*20);
    }
}
